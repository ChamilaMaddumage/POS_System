
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using Services.AppStock;

namespace Services.Payments
{
    public partial class ChequeGRN : Form
    {
        //This is used to pass the cheque detail data to the main form
        //START
        public static List<string[]> GRNChequeDataGridView = new List<string[]>();
        //END

        //This is from getters and setters add the cheque details
        //START
        public ChequeData AddedChequeData{
            get; set;
        }
        //END

        public string totalCheque
        {
            get { return textBoxTotalAmount.Text; }
            set { textBoxTotalAmount.Text = value; }
        }
        public void FillGridViewByChequeDetails()
        {
            for(int i = 0; i < GRNChequeDataGridView.Count; i++)
            {
                string[] StringArrayData = new string[4];
                //StringArrayData = ChequeGRN.GRNChequeDataGridView[i].OfType<string>.ToArray();
                StringArrayData = ((IEnumerable)GRNChequeDataGridView[i]).Cast<object>().Select(X => X == null ? null : X.ToString()).ToArray();
                //StringArrayData = (string[])ChequeGRN.GRNChequeDataGridView[i].ToArray(typeof(string));

                int row = 0;
                //decimal Total = 0;
                dataGridView1.Rows.Add();
                row = dataGridView1.Rows.Count - 2;
                for(int j = 0; j <= dataGridView1.Rows.Count - 2; j++)
                {
                    dataGridView1["ChequeNo",row].Value = (StringArrayData[0]).ToString();
                    dataGridView1["ChequeAmount",row].Value = (StringArrayData[1]).ToString();
                    dataGridView1["Bank",row].Value = (StringArrayData[2]).ToString();
                    dataGridView1["Note",row].Value = (StringArrayData[3]).ToString();
                    //Total += Convert.ToDecimal(dataGridView1["ChequeAmount", row].Value);
                    //textBoxTotalAmount.Text = Total.ToString();
                }
            }
        }

        public ChequeGRN()
        {
            InitializeComponent();
        }
       
        private void ChequeGRN_Load(object sender, EventArgs e)
        {
            labelDocID.Visible = false;
            BankAccountGrid();
            labelDocID.Text = GRN.GRNDocumentID;

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

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try {
                decimal decimalValue = 0;
                if(textBoxBank.Text == "")
                {
                    MessageBox.Show("Please select bank account.\nIf bank account haven't in the list please create bank account.\nThanks");
                }
                else if(textBoxCheqNo.Text == "")
                {
                    MessageBox.Show("Please Enter Cheque Number");
                }
                else if(textBoxChqAmount.Text == "")
                {
                    MessageBox.Show("Amount");
                }
                else if(!Decimal.TryParse(textBoxChqAmount.Text,out decimalValue))
                {
                    MessageBox.Show("Wrong type of cheque Amount");
                }
                else
                {
                    //We add the cheque data in to static generic collection of string[]
                    //START
                    string[] DataSet = new string[4];
                    DataSet[0] = textBoxCheqNo.Text;
                    DataSet[1] = textBoxChqAmount.Text;
                    DataSet[2] = textBoxBank.Text;
                    DataSet[3] = richTextBoxNote.Text;

                    GRNChequeDataGridView.Add(DataSet);
                    //END

                    ////Here we add values usinf getters and setters
                    ////START
                    //AddedChequeData.ChequeNo= textBoxCheqNo.Text;
                    //AddedChequeData.ChequeAmount = textBoxChqAmount.Text;
                    //AddedChequeData.Bank = textBoxBank.Text;
                    //AddedChequeData.Note = richTextBoxNote.Text;
                    ////END

                    int row = 0;
                    //decimal Total = 0;
                    dataGridView1.Rows.Add();
                    row = dataGridView1.Rows.Count - 2;
                    for(int i = 0; i <= dataGridView1.Rows.Count - 2; i++)
                            {
                                dataGridView1["ChequeNo",row].Value = textBoxCheqNo.Text;
                                dataGridView1["ChequeAmount",row].Value = textBoxChqAmount.Text;
                                dataGridView1["Bank",row].Value = textBoxBank.Text;
                                dataGridView1["Note",row].Value = richTextBoxNote.Text;
                                //Total += Convert.ToDecimal(dataGridView1["ChequeAmount", row].Value);
                                //textBoxTotalAmount.Text = Total.ToString();
                            }

                    textBoxCheqNo.Clear();
                    textBoxChqAmount.Clear();
                    textBoxBank.Clear();
                    richTextBoxNote.Clear();

                    decimal Total = 0;

                    for(int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        Total += Convert.ToDecimal(dataGridView1.Rows[i].Cells["ChequeAmount"].Value);
                    }

                    textBoxTotalAmount.Text = Total.ToString();
                }
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
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
