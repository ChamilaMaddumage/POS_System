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
    public partial class Cash : Form
    {
        int SaveType = 0;

        public Cash()
        {
            InitializeComponent();
        }

        private void radioButtonCashIn_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonCashIn.Checked == true)
            {
                labelFromTo.Text = "From :";
            }
        }

        private void radioButtonCashOut_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonCashOut.Checked == true)
            {
                labelFromTo.Text = "To :";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveType = 1;
            SaveDelete();
            LoadBalance();
        }

        private void Cash_Load(object sender, EventArgs e)

        {
            radioButtonCashOut.Checked = true;
            gridCash();
            LoadCashTranDocNo();
            LoadBalance();
        }
        public void LoadBalance()
        {
            ProjectConnection Newconnection = new ProjectConnection();
            Newconnection.Connection_Today();
            SqlCommand comm = new SqlCommand();
            comm.Connection = ProjectConnection.conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "Finance.Load_Cash_Balance";
            SqlDataReader dr;
            dr = comm.ExecuteReader();
            if (dr.HasRows == true)
            {
                dr.Read();
                labelBalance.Text = dr["Amount"].ToString();
                dr.Close();
            }
        }
        public void LoadCashTranDocNo()
        {
            ProjectConnection Newconnection = new ProjectConnection();
            Newconnection.Connection_Today();
            SqlCommand comm = new SqlCommand();
            comm.Connection = ProjectConnection.conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "finance.Cash_Transaction_Doc_No";
            SqlDataReader dr;
            dr = comm.ExecuteReader();
            if (dr.HasRows == true)
            {
                dr.Read();
                labelDoc_No.Text = dr["Doc_No"].ToString();
                dr.Close();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            LoadCashTranDocNo();
        }
        public void SaveDelete()
        {
            try
            {
                if (radioButtonCashOut.Checked == true || radioButtonCashIn.Checked == true)
                {
                    ProjectConnection Newconnection = new ProjectConnection();
                    Newconnection.Connection_Today();
                    SqlCommand comm = new SqlCommand();
                    comm.Connection = ProjectConnection.conn;
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.CommandText = "finance.Save_Cash_transaction";
                    comm.Parameters.AddWithValue("@Save_Type", SaveType);
                    comm.Parameters.AddWithValue("@Doc_No", labelDoc_No.Text);
                    if (textBoxAmount.Text == "")
                    {
                        comm.Parameters.AddWithValue("@Amount", 0);
                    }
                    else
                    {
                        comm.Parameters.AddWithValue("@Amount", Convert.ToDecimal(textBoxAmount.Text));
                    }

                    if (radioButtonCashIn.Checked == true)
                    {
                        comm.Parameters.AddWithValue("@Type", "Debit");
                    }
                    else if (radioButtonCashOut.Checked == true)
                    {
                        comm.Parameters.AddWithValue("@Type", "Credit");
                    }
                    if (checkBoxBankTransfer.Checked == true)
                    {
                        comm.Parameters.AddWithValue("@Account_Name", "Bank Trasnfer");
                    }
                    else
                    {
                        comm.Parameters.AddWithValue("@Account_Name", textBoxDirection.Text);
                    }
                    comm.Parameters.AddWithValue("@Note", textBoxNote.Text);

                    comm.Parameters.AddWithValue("@Transaction_Date",Convert.ToDateTime(dateTimePickerTransactionDate.Text));
                    comm.Parameters.AddWithValue("@Transaction_Doc_No","");

                    comm.ExecuteNonQuery();
                    gridCash();
                    if (SaveType == 1)
                    {
                        MessageBox.Show("Saved Successfully");
                    }
                    else if (SaveType == 2)
                    {
                        MessageBox.Show("Deleted Successfully");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void gridCash()
        {
            try
            {
                ProjectConnection Newconnection = new ProjectConnection();
                Newconnection.Connection_Today();
                SqlCommand comm = new SqlCommand();
                comm.Connection = ProjectConnection.conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "finance.Load_Cash_Transactions";
                comm.Parameters.AddWithValue("@Search_Condition", textBoxSearch.Text);
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewBanking.DataSource = dt;
                GridRowColour();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            gridCash();
        }

        private void dataGridViewBanking_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridViewBanking.Rows[e.RowIndex];
                labelDoc_No.Text = row.Cells[0].Value.ToString();
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Clear();
            LoadBalance();
        }
        public void Clear()
        {
            textBoxAmount.Clear();
            textBoxDirection.Clear();
            textBoxNote.Clear();
            textBoxSearch.Clear();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            SaveType = 2;
            SaveDelete();
        }
        private void GridRowColour()
        {
     
                //try
                //{
                //    foreach(DataGridViewRow Myrow in dataGridViewBanking.Rows)
                //    {           
                //        if(Myrow.Cells[5].ToString() == "Credit")
                //        {
                //            Myrow.DefaultCellStyle.ForeColor = Color.Red;
                //        }
                //        else
                //        {
                //            Myrow.DefaultCellStyle.ForeColor = Color.Green;
                //        }
                //    }
                //}
                //catch(System.Exception ex)
                //{

                //}
        }
    }
}
