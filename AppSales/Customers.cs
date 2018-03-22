using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Services
{
    public partial class Customers : Form
    {
        //Save type 1 Update 2 Delete
        int SaveType = 0;
        public Customers()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxName.Text == "")
                {
                    MessageBox.Show("Required Name Field");
                }
                else
                {
                    ProjectConnection Newconnection = new ProjectConnection();
                    Newconnection.Connection_Today();
                    SqlCommand comm = new SqlCommand();
                    comm.Connection = ProjectConnection.conn;
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.CommandText = "Customer.Save_Customer_Details";
                    comm.Parameters.AddWithValue("@Name", textBoxName.Text);
                    comm.Parameters.AddWithValue("@Address", textBoxAddress.Text);
                    comm.Parameters.AddWithValue("@Nic", textBoxNic.Text);
                    comm.Parameters.AddWithValue("@Mobile_2", textBoxMobile02.Text);
                    comm.Parameters.AddWithValue("@Mobile_1", textBoxMobile01.Text);
                    comm.Parameters.AddWithValue("@Email", textBoxEmail.Text);
                    comm.Parameters.AddWithValue("@Website", textBoxWebsite.Text);
                    comm.Parameters.AddWithValue("@Other_Contact_Details", textBoxOtherContact.Text);
                    comm.Parameters.AddWithValue("@Customer_Since", Convert.ToDateTime(dateTimePickerSince.Text));
                    comm.Parameters.AddWithValue("@Note", textBoxNote.Text);
                    comm.Parameters.AddWithValue("@User_Code", "");
                    comm.ExecuteNonQuery();
                    grid();
                    LoadCustomerCode();
                    Clear();
                    MessageBox.Show("Saved");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString() + "Do not enter duplicate value");
            }
        }
        public void LoadCustomerCode()
        {
            ProjectConnection Newconnection = new ProjectConnection();
            Newconnection.Connection_Today();
            SqlCommand comm = new SqlCommand();
            comm.Connection = ProjectConnection.conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "customer.Customer_Code";
            SqlDataReader dr;
            dr = comm.ExecuteReader();
            if (dr.HasRows == true)
            {
                dr.Read();
                textBoxCSCode.Text = dr["Doc_No"].ToString();
                dr.Close();
            }
        }

        private void Customers_Load(object sender, EventArgs e)
        {
            if(Permission.CustomerSave == "DEACTIVE")
            {
                btnSave.Enabled = false;
            }
            if(Permission.CustomerUpdate == "DEACTIVE")
            {
                btnUpdate.Enabled = false;
            }
            if(Permission.CustomerDelete == "DEACTIVE")
            {
                btnDelete.Enabled = false;
            }
            textBoxName.Focus();
            LoadCustomerCode();
            grid();
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
                comm.CommandText = "Customer.Load_Customers_Grid";
                comm.Parameters.AddWithValue("@Search_Condition", textBoxSearch.Text);
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SaveType = 1;
            UpdateDelete();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LoadCustomerCode();
        }
        private void textBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            grid();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try { 
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                textBoxCSCode.Text = row.Cells[0].Value.ToString();
                textBoxName.Text = row.Cells[1].Value.ToString();
                textBoxAddress.Text = row.Cells[3].Value.ToString();
                textBoxNic.Text = row.Cells[4].Value.ToString();
                textBoxMobile02.Text = row.Cells[5].Value.ToString();
                textBoxMobile01.Text = row.Cells[6].Value.ToString();
                textBoxEmail.Text = row.Cells[7].Value.ToString();
                textBoxWebsite.Text = row.Cells[8].Value.ToString();
                textBoxOtherContact.Text = row.Cells[9].Value.ToString();
                dateTimePickerSince.Text = row.Cells[10].Value.ToString();
                textBoxNote.Text = row.Cells[11].Value.ToString();
                //,Oil_Brain, Oil_Filter, Desel_Filter, Air_Filter, Carbon_Filter, Transmition, Brak_Fuel, Coolent, 
                //Delegal_Oil, Power_Oil, Other_Detail01, Other_Detail02, Other_Detail03, Other_Detail04

            }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void UpdateDelete()
        {
            try
            {
                ProjectConnection Newconnection = new ProjectConnection();
                Newconnection.Connection_Today();
                SqlCommand comm = new SqlCommand();
                comm.Connection = ProjectConnection.conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "Customer.Update_Customer";
                comm.Parameters.AddWithValue("@Save_Type", SaveType);
                comm.Parameters.AddWithValue("@Doc_No", textBoxCSCode.Text);
                comm.Parameters.AddWithValue("@Name", textBoxName.Text);
                comm.Parameters.AddWithValue("@Address", textBoxAddress.Text);
                comm.Parameters.AddWithValue("@Nic", textBoxNic.Text);
                comm.Parameters.AddWithValue("@Mobile_2", textBoxMobile02.Text);
                comm.Parameters.AddWithValue("@Mobile_1", textBoxMobile01.Text);
                comm.Parameters.AddWithValue("@Email", textBoxEmail.Text);
                comm.Parameters.AddWithValue("@Website", textBoxWebsite.Text);
                comm.Parameters.AddWithValue("@Other_Contact_Details", textBoxOtherContact.Text);
                comm.Parameters.AddWithValue("@Customer_Since", Convert.ToDateTime(dateTimePickerSince.Text));
                comm.Parameters.AddWithValue("@Note", textBoxNote.Text);
                comm.ExecuteNonQuery();
                grid();
                LoadCustomerCode();
                if (SaveType == 1)
                {
                    Clear();
                    MessageBox.Show("Updated");
                }
                else if (SaveType == 2)
                {
                    Clear();
                    MessageBox.Show("Deleted");
                }
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SaveType = 2;
            UpdateDelete();
            Clear();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            //,Oil_Brain, Oil_Filter, Desel_Filter, Air_Filter, Carbon_Filter, Transmition, Brak_Fuel, Coolent, 
            //Delegal_Oil, Power_Oil, Other_Detail01, Other_Detail02, Other_Detail03, Other_Detail04
            textBoxEmail.Clear();
            textBoxAddress.Clear();
            textBoxCSCode.Clear();
            textBoxMobile01.Clear();
            textBoxMobile02.Clear();
            textBoxNic.Clear();
            textBoxNote.Clear();
            textBoxWebsite.Clear();
            textBoxOtherContact.Clear();
            textBoxName.Clear();
            grid();
            LoadCustomerCode();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

  
    }
}
