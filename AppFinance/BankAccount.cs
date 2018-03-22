using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Services
{
    public partial class BankAccount : Form
    {
        int SaveType = 0;
        public BankAccount()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (textBoxBankAccount.Text == "")
            {
                MessageBox.Show("Accont Name Required");
            }
            else if (textBoxAccountNo.Text == "")
            {
                MessageBox.Show("Accont No Required");
            }
            else
            {
                SaveType = 1;
                SaveDeleteUpdate();
                MessageBox.Show("Saved");
            }

        }
        public void SaveDeleteUpdate()
        {
            ProjectConnection Newconnection = new ProjectConnection();
            Newconnection.Connection_Today();
            SqlCommand comm = new SqlCommand();
            comm.Connection = ProjectConnection.conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "Finance.Save_Update_Delete_Bank_Account_Details";
            comm.Parameters.AddWithValue("@Save_Type", SaveType);
            comm.Parameters.AddWithValue("@Doc_No", textBoxDoc_No.Text);
            comm.Parameters.AddWithValue("@Bank_Or_Act", textBoxBankAccount.Text);
            comm.Parameters.AddWithValue("@Account_No", textBoxAccountNo.Text);
            comm.Parameters.AddWithValue("@Account_Type", comboBoxAccountType.Text);
            comm.ExecuteNonQuery();
            LoadBnkCode();
            grid();
        }
        public void LoadBnkCode()
        {
            ProjectConnection Newconnection = new ProjectConnection();
            Newconnection.Connection_Today();
            SqlCommand comm = new SqlCommand();
            comm.Connection = ProjectConnection.conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "Finance.Bank_Account_Doc_No";
            SqlDataReader dr;
            dr = comm.ExecuteReader();
            if (dr.HasRows == true)
            {
                dr.Read();
                textBoxDoc_No.Text = dr["Doc_No"].ToString();
                dr.Close();
            }
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
                comm.CommandText = "Finance.Select_Bank_Account_Grid";
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
        private void BankAccount_Load(object sender, EventArgs e)
        {
            LoadBnkCode();
            grid();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            LoadBnkCode();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            SaveType = 2;
            SaveDeleteUpdate();
            MessageBox.Show("Deleted");
        }
    }
}
