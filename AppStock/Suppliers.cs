using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Services
{
    public partial class Suppliers : Form
    {
        int SaveType = 0;
        public Suppliers()
        {
            InitializeComponent();

            //Save Update Delete btn Enable Disable
            //START
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            //END
        }

        private void Suppliers_Load(object sender, EventArgs e)
        {
            if(Permission.SupplierSave == "DEACTIVE")
            {
                btnSave.Enabled = false;
            }
            if(Permission.SupplierUpadate == "DEACTIVE")
            {
                btnUpdate.Enabled = false;
            }
            if(Permission.SupplierDelete == "DEACTIVE")
            {
                btnDelete.Enabled = false;
            }

            LoadSupplierCode();
            grid();
            Clear();
        }
        public void SaveUpdateDelete()
        {
            try
            {
                ProjectConnection Newconnection = new ProjectConnection();
                Newconnection.Connection_Today();
                SqlCommand comm = new SqlCommand();
                comm.Connection = ProjectConnection.conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "Suppliers.Save_Update_Delete_Supplier_Details";
                comm.Parameters.AddWithValue("@Save_Type", SaveType);
                comm.Parameters.AddWithValue("@Doc_No", textBoxSupCode.Text);
                comm.Parameters.AddWithValue("@Name", textBoxName.Text);
                comm.Parameters.AddWithValue("@Company_Name", textBoxCompanyName.Text);
                comm.Parameters.AddWithValue("@Address", textBoxAddress.Text);
                comm.Parameters.AddWithValue("@Nic", textBoxNic.Text);
                comm.Parameters.AddWithValue("@Mobile_2", textBoxMobile02.Text);
                comm.Parameters.AddWithValue("@Mobile_1", textBoxMobile01.Text);
                comm.Parameters.AddWithValue("@Email", textBoxEmail.Text);
                comm.Parameters.AddWithValue("@Website", textBoxWebsite.Text);
                comm.Parameters.AddWithValue("@Other_Contact_Details", textBoxOtherContact.Text);
                comm.Parameters.AddWithValue("@Supplier_Since", Convert.ToDateTime(dateTimePickerSince.Text));
                comm.Parameters.AddWithValue("@Note", textBoxNote.Text);
                comm.ExecuteNonQuery();
                if (SaveType == 1)
                {
                    LoadSupplierCode();
                    Clear();
                    grid();
                    MessageBox.Show("Updated");
                }
                else if (SaveType == 2)
                {
                    LoadSupplierCode();
                    Clear();
                    grid();
                    MessageBox.Show("Deleted");
                }
                else if (SaveType == 3)
                {
                    LoadSupplierCode();
                    Clear();
                    grid();
                    MessageBox.Show("Saved");
                }
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }
        public void Clear()
        {
            textBoxEmail.Clear();
            textBoxAddress.Clear();
            textBoxCompanyName.Clear();
            textBoxSupCode.Clear();
            textBoxMobile01.Clear();
            textBoxMobile02.Clear();
            textBoxNic.Clear();
            textBoxNote.Clear();
            textBoxWebsite.Clear();
            textBoxOtherContact.Clear();
            textBoxName.Clear();
            textBoxSearch.Clear();
            LoadSupplierCode();
            grid();

            //Save Update Delete btn Enable Disable
            //START
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            //END

        }
        public void grid()
        {
            try
            {
                ProjectConnection Newconnection = new ProjectConnection();
                Newconnection.Connection_Today();
                SqlCommand comm = new SqlCommand();
                comm.Connection = ProjectConnection.conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "Suppliers.SearchSupplierDetails";
                comm.Parameters.AddWithValue("@SearchCondition",textBoxSearch.Text);
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            DataGridViewColumn column = dataGridView1.Columns[1];
            column.Width = 255;
        }
        private void textBoxSearch_KeyPress(object sender,KeyPressEventArgs e)
        {
            grid();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveType = 3;
            SaveUpdateDelete();
            Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SaveType = 2;
            SaveUpdateDelete();
            Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SaveType = 1;
            SaveUpdateDelete();
            Clear();
        }
        public void LoadSupplierCode()
        {
            ProjectConnection Newconnection = new ProjectConnection();
            Newconnection.Connection_Today();
            SqlCommand comm = new SqlCommand();
            comm.Connection = ProjectConnection.conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "Suppliers.Load_Supplier_Codes";
            SqlDataReader dr;
            dr = comm.ExecuteReader();
            if (dr.HasRows == true)
            {
                dr.Read();
                textBoxSupCode.Text = dr["Doc_No"].ToString();
                dr.Close();
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                textBoxSupCode.Text = row.Cells[0].Value.ToString();
                textBoxName.Text = row.Cells[1].Value.ToString();
                textBoxCompanyName.Text = row.Cells[2].Value.ToString();
                textBoxAddress.Text = row.Cells[3].Value.ToString();
                textBoxNic.Text = row.Cells[4].Value.ToString();
                textBoxMobile02.Text = row.Cells[5].Value.ToString();
                textBoxMobile01.Text = row.Cells[6].Value.ToString();
                textBoxEmail.Text = row.Cells[7].Value.ToString();
                textBoxWebsite.Text = row.Cells[8].Value.ToString();
                textBoxOtherContact.Text = row.Cells[9].Value.ToString();
                dateTimePickerSince.Text = row.Cells[10].Value.ToString();
                textBoxNote.Text = row.Cells[11].Value.ToString();

                //Save Update Delete btn Enable Disable
                //START
                btnSave.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                //END
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LoadSupplierCode();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
