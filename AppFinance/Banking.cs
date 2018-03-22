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
    public partial class Banking : Form
    {
        int SaveType = 0;
        public Banking()
        {
            InitializeComponent();
        }

        private void Banking_Load(object sender, EventArgs e)
        {
            radioButtonBankIn.Checked = true;
            gridCheque();
            LoadBankTranDocNo();
            BankAccountGrid();
            gridBanking();
            LoadBalance();
        }
        public void LoadBalance()
        {
            ProjectConnection Newconnection = new ProjectConnection();
            Newconnection.Connection_Today();
            SqlCommand comm = new SqlCommand();
            comm.Connection = ProjectConnection.conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "Finance.Load_Bank_Balance";
            SqlDataReader dr;
            dr = comm.ExecuteReader();
            if (dr.HasRows == true)
            {
                dr.Read();
                labelBalance.Text = dr["Amount"].ToString();
                dr.Close();
            }
        }

        private void radioButtonBankIn_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonBankIn.Checked == true)
            {
                labelBankingFromTo.Text = "From :";
            }
        }

        private void radioButtonBankOut_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonBankOut.Checked == true)
            {
                labelBankingFromTo.Text = "To :";
            }
        }

        private void buttonNewBankAccount_Click(object sender, EventArgs e)
        {
            BankAccount BACT = new BankAccount();
            BACT.ShowDialog();
        }

        public void BankAccountGrid()
        {
            try
            {
                ProjectConnection Newconnection = new ProjectConnection();
                Newconnection.Connection_Today();
                SqlCommand comm = new SqlCommand();
                comm.Connection = ProjectConnection.conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "Finance.Load_bank_acount_details";
                comm.Parameters.AddWithValue("@Search_Condition", textBoxSearch.Text);
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewBankAccount.DataSource = dt;
                dataGridViewBankAccount.Columns[0].Visible = false;
                dataGridViewBankAccount.Columns[2].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            DataGridViewColumn column = dataGridViewBankAccount.Columns[1];
            column.Width = 150;
        }

        private void dataGridViewBankAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridViewBankAccount.Rows[e.RowIndex];
                textBoxAccount.Text = row.Cells[1].Value.ToString();
                textBoxAccountNo.Text = row.Cells[2].Value.ToString();
                textBoxAccountDoc_No.Text = row.Cells[0].Value.ToString();
            }
        }

        private void buttonBankSave_Click(object sender, EventArgs e)
        {
            SaveType = 1;
            SaveDelete();
            LoadBalance();

        }
        public void SaveDelete()
        {
            if (radioButtonBankOut.Checked == true || radioButtonBankIn.Checked == true)
            {
                ProjectConnection Newconnection = new ProjectConnection();
                Newconnection.Connection_Today();
                SqlCommand comm = new SqlCommand();
                comm.Connection = ProjectConnection.conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "Finance.Save_Delete_Bank_Transaction";
                comm.Parameters.AddWithValue("@Save_Type", SaveType);
                comm.Parameters.AddWithValue("@Doc_No", labelDoc_No.Text);
                comm.Parameters.AddWithValue("@Account_Doc_No", textBoxAccountDoc_No.Text);
                comm.Parameters.AddWithValue("@Account", textBoxDirection.Text);
                if (textBoxAmount.Text == "")
                {
                    comm.Parameters.AddWithValue("@Amount",0);
                }
                else
                {
                    comm.Parameters.AddWithValue("@Amount", Convert.ToDecimal(textBoxAmount.Text));
                }

                comm.Parameters.AddWithValue("@Date", Convert.ToDateTime(dateTimePickerTranBanking.Text));

                if (radioButtonBankIn.Checked == true)
                {
                    comm.Parameters.AddWithValue("@Type", "Debit");
                }
                else if (radioButtonBankOut.Checked == true)
                {
                    comm.Parameters.AddWithValue("@Type", "Credit");
                }
                comm.Parameters.AddWithValue("@Note", textBoxNote.Text);

                comm.ExecuteNonQuery();
                LoadBankTranDocNo();
                gridBanking();
                clear();
            }
        }
        public void LoadBankTranDocNo()
        {
            ProjectConnection Newconnection = new ProjectConnection();
            Newconnection.Connection_Today();
            SqlCommand comm = new SqlCommand();
            comm.Connection = ProjectConnection.conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "Finance.Load_Bank_Transaction_Doc_No ";
            SqlDataReader dr;
            dr = comm.ExecuteReader();
            if (dr.HasRows == true)
            {
                dr.Read();
                labelDoc_No.Text = dr["Doc_No"].ToString();
                dr.Close();
            }
        }
        public void gridBanking()
        {
            try
            {
                ProjectConnection Newconnection = new ProjectConnection();
                Newconnection.Connection_Today();
                SqlCommand comm = new SqlCommand();
                comm.Connection = ProjectConnection.conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "Finance.Load_Banking_Transactions_To_Grid_View";
                comm.Parameters.AddWithValue("@Search_Condition", textBoxSearch.Text);
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewBanking.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            DataGridViewColumn column1 = dataGridViewBanking.Columns[1];
            column1.Width = 250;
            DataGridViewColumn column2 = dataGridViewBanking.Columns[2];
            column2.Width = 150;
            DataGridViewColumn column6 = dataGridViewBanking.Columns[6];
            column6.Width = 170;
        }

        private void dataGridViewBanking_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridViewBanking.Rows[e.RowIndex];
                labelDoc_No.Text = row.Cells[0].Value.ToString();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            SaveType = 2;
            SaveDelete();
            LoadBalance();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LoadBankTranDocNo();
        }
        public void gridCheque()
        {
            try
            {
                ProjectConnection Newconnection = new ProjectConnection();
                Newconnection.Connection_Today();
                SqlCommand comm = new SqlCommand();
                comm.Connection = ProjectConnection.conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "Finance.Load_Cheques_To_banking";
                comm.Parameters.AddWithValue("@Search_Condition", textBox1.Text);
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewCheques.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //DataGridViewColumn column1 = dataGridViewBanking.Columns[1];
            //column1.Width = 250;
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            gridCheque();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonBankClear_Click(object sender, EventArgs e)
        {
            LoadBalance();
            clear();
        }
        public void clear()
        {
            textBox1.Clear();
            textBoxAccount.Clear();
            textBoxAccountDoc_No.Clear();
            textBoxAccountNo.Clear();
            textBoxSearch.Clear();
            textBoxDirection.Clear();
            textBoxNote.Clear();
        }

        private void textBoxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            BankAccountGrid();
            gridBanking();
        }

        private void labelDoc_No_Click(object sender,EventArgs e)
        {

        }
    }
}

