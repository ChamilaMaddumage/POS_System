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

namespace Services.Payments
{
    public partial class GRNCheque : Form
    {
        public string totalCheque
        {
            get { return textBoxTotalAmount.Text; }
            set { textBoxTotalAmount.Text = value; }
        }
        public GRNCheque()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxBank.Text == "")
            {
                MessageBox.Show("Please Select Bank Account,\nIF Bank Account not available \nGo to Finance and add bank account\nThanks");
            }
            else
            {
                int row = 0;
                //decimal Total = 0;
                dataGridView1.Rows.Add();
                row = dataGridView1.Rows.Count - 2;
                for (int i = 0; i <= dataGridView1.Rows.Count - 2; i++)
                {
                    dataGridView1["ChequeNo", row].Value = textBoxCheqNo.Text;
                    dataGridView1["ChequeAmount", row].Value = textBoxChqAmount.Text;
                    dataGridView1["Bank", row].Value = textBoxBank.Text;
                    dataGridView1["Note", row].Value = richTextBoxNote.Text;
                    //Total += Convert.ToDecimal(dataGridView1["ChequeAmount", row].Value);
                    //textBoxTotalAmount.Text = Total.ToString();
                }
                decimal Total = 0;

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    Total += Convert.ToDecimal(dataGridView1.Rows[i].Cells["ChequeAmount"].Value);
                }

                textBoxTotalAmount.Text = Total.ToString();
            }
        }

        private void Cheque_Load(object sender, EventArgs e)
        {
            labelDocID.Hide();
            textBoxCheqNo.Clear();
            textBoxChqAmount.Clear();
            richTextBoxNote.Clear();
            BankAccountGrid();
            labelDocID.Text = Invoice.InvoiceDocumentID;
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
                comm.Parameters.AddWithValue("@Search_Condition", "");
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewBankAccount.DataSource = dt;
                dataGridViewBankAccount.Columns[0].Visible = false;
                dataGridViewBankAccount.Columns[2].Visible = false;
                DataGridViewColumn column = dataGridViewBankAccount.Columns[1];
                column.Width = 150;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        public void SaveCheque()
        {
            try
            {
                ProjectConnection Newconnection = new ProjectConnection();
                Newconnection.Connection_Today();
                for (int i = 0; i <= dataGridView1.Rows.Count - 2; i++)
                {

                    SqlCommand comm = new SqlCommand();
                    comm.Connection = ProjectConnection.conn;
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.CommandText = (@"Sales.Tempory_Save_Cheque_Data");
                    comm.Parameters.AddWithValue("@ID", labelDocID.Text);
                    comm.Parameters.AddWithValue("@Cheque_No", Convert.ToString(dataGridView1.Rows[i].Cells[0].Value));
                    comm.Parameters.AddWithValue("@Amount", Convert.ToDecimal(dataGridView1.Rows[i].Cells[1].Value));
                    comm.Parameters.AddWithValue("@Bank", Convert.ToString(dataGridView1.Rows[i].Cells[2].Value));
                    comm.Parameters.AddWithValue("@Note", Convert.ToString(dataGridView1.Rows[i].Cells[3].Value));
                    comm.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SaveCheque();
            this.Close();
        }

        private void dataGridViewBankAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridViewBankAccount.Rows[e.RowIndex];
                
                textBoxBank.Text = row.Cells[0].Value.ToString();
            }
        }
    }
}
