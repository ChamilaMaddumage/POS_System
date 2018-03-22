using Services.GridForms;
using Services.Payments;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Services
{
    public partial class SalesReturn:Form
    {
        string Documentid = Guid.NewGuid().ToString();
        private GetItemCodes GetItemCode;
        private GRNCheque ChequeForm;
        private Mobile MobileForm;
        private Card CardForm;
        private GetCustomerCode CustomerDetailsForm;
        public static string InvoiceDocumentID;
        public string duration = "";

        public SalesReturn()
        {
            InitializeComponent();
            GetItemCode = new GetItemCodes();
            GetItemCode.FormClosed += new FormClosedEventHandler(GetItemCode_FormClosed);
            ChequeForm = new GRNCheque();
            ChequeForm.FormClosed += new FormClosedEventHandler(Cheque_FromClosed);
            MobileForm = new Mobile();
            MobileForm.FormClosed += new FormClosedEventHandler(Mobile_FromClosed);
            CustomerDetailsForm = new GetCustomerCode();
            CustomerDetailsForm.FormClosed += new FormClosedEventHandler(GetCustomerCode_FormClosed);

        }

        private void GetCustomerCode_FormClosed(object sender,FormClosedEventArgs e)
        {
            textBoxCSName.Text = CustomerDetailsForm.CSName;
            textBoxCSID.Text = CustomerDetailsForm.CSCode;
        }

        private void Mobile_FromClosed(object sender,FormClosedEventArgs e)
        {
            //Mobile closed event
        }

        private void Cheque_FromClosed(object sender,FormClosedEventArgs e)
        {
            //Mobile closed event
        }

        private void GetItemCode_FormClosed(object sender,FormClosedEventArgs e)
        {
            textBoxItemCode.Text = GetItemCode.ItemCode;
            textBoxItemName.Text = GetItemCode.ItemName;
            textBoxCost.Text = GetItemCode.ItemCost;
            textBoxQuentity.Focus();
        }

        private void pictureBox2_Click(object sender,EventArgs e)
        {
            CustomerDetailsForm.ShowDialog();

        }

        private void textBoxItemCode_KeyUp(object sender,KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                LoadItemDetailsBarcode();
                textBoxQuentity.Focus();
                e.Handled = true;
            }
        }

        private void SalesReturn_Load(object sender,EventArgs e)
        {
            labelInvoiceDocNo.Hide();
            labelDiscountedAmount.Hide();
            Globlevariable.PrintDocNo = "";
            labelDocID.Text = Documentid;
            labelDocID.Visible = false;
        }

        private void buttonAdd_Click(object sender,EventArgs e)
        {
            Addtogrid();
        }

        private void dataGridView1_CellDoubleClick(object sender,DataGridViewCellEventArgs e)
        {
            try
            {
                if(this.dataGridView1.SelectedRows.Count > 0)
                {
                    dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
                }
                decimal Total = 0;

                for(int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    Total += Convert.ToDecimal(dataGridView1.Rows[i].Cells["Amount"].Value);
                }

                textBoxItemAmount.Text = Total.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Invalid Selection " + ex);
            }
        }

        private void textBoxQuentity_KeyUp(object sender,KeyEventArgs e)
        {
            CalculationFN01();
            if(e.KeyCode == Keys.Enter)
            {
                Addtogrid();
                labelDiscountedAmount.Text = "";
                textBoxItemName.Clear();
                textBoxItemCode.Clear();
                textBoxQuentity.Clear();
                textBoxAmount.Clear();
                textBoxCost.Clear();
                textBoxItemCode.Focus();
                e.Handled = true;
            }
        }

        private void pictureBox1_Click(object sender,EventArgs e)
        {
            GetItemCode.ShowDialog();

        }





        //------------------------Other FN Start-------------------//
        public void CalculationFN01()
        {
            try
            {
                decimal Cost = 0;
                decimal Quentity = 0;
                decimal Amount = 0;
                decimal discount = 0;
                if(textBoxCost.Text == "")
                {
                    Cost = 0;
                }
                else
                {
                    Cost = Convert.ToDecimal(textBoxCost.Text);
                }
                if(textBoxQuentity.Text == "")
                {
                    Quentity = 0;
                }
                else
                {
                    Quentity = Convert.ToDecimal(textBoxQuentity.Text);
                }
                if(textBoxAmount.Text == "")
                {
                    Amount = 0;
                }
                Amount = Quentity * Cost;
                labelDiscountedAmount.Text = discount.ToString("N");
                textBoxAmount.Text = Amount.ToString("N");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void LoadItemDetailsBarcode()
        {
            try
            {
                ProjectConnection Newconnection = new ProjectConnection();
                Newconnection.Connection_Today();
                SqlCommand comm = new SqlCommand();
                comm.Connection = ProjectConnection.conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "Stock.Search_Items";
                comm.Parameters.AddWithValue("@Search_Condition",textBoxItemCode.Text);
                SqlDataReader dr;
                dr = comm.ExecuteReader();
                if(dr.HasRows == true)
                {
                    dr.Read();
                    textBoxItemCode.Text = dr["Item Code"].ToString();
                    textBoxItemName.Text = dr["Item Name"].ToString();
                    textBoxCost.Text = dr["Selling_Price"].ToString();
                    dr.Close();
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error Loading Customer Details");
            }
        }
        public void LoadPrintInvoiceCode()
        {
            ProjectConnection Newconnection = new ProjectConnection();
            Newconnection.Connection_Today();
            SqlCommand comm = new SqlCommand();
            comm.Connection = ProjectConnection.conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = " SELECT TOP 1 [Doc_No] FROM [Sales].[Invoice_Header] WHERE Status = 0 ORDER BY [System_Date_Time] DESC ";
            SqlDataReader dr;
            dr = comm.ExecuteReader();
            if(dr.HasRows == true)
            {
                dr.Read();
                labelInvoiceDocNo.Text = dr["Doc_No"].ToString();
                dr.Close();
            }
            Globlevariable.PrintDocNo = labelInvoiceDocNo.Text;
            PrintForm PF = new PrintForm();
            PF.Show();
        }
        public void Addtogrid()
        {
            try
            {
                if(textBoxCSID.Text != "")
                {
                    pictureBox2.Enabled = false;
                }
                if(textBoxCost.Text == "")
                {
                    MessageBox.Show("Please Fill Cost");
                }
                else if(textBoxQuentity.Text == "")
                {
                    MessageBox.Show("Please Fill Quentity");
                }
                else if(textBoxAmount.Text == "")
                {
                    MessageBox.Show("Please Fill Amount");
                }
                else if(textBoxItemCode.Text == "")
                {
                    MessageBox.Show("Please Fill Item Code");
                }
                else if(textBoxCSID.Text == "")
                {
                    MessageBox.Show("Customer Not Selected");
                }

                else
                {
                    if(labelDiscountedAmount.Text == "")
                    {
                        labelDiscountedAmount.Text = "0.00";
                    }
                    //int row = 0;
                    //dataGridView1.Rows.Add();
                    //row = dataGridView1.Rows.Count - 2;
                    //for(int i = 0; i <= dataGridView1.Rows.Count - 2; i++)
                    //{
                    //    dataGridView1["ItemName",row].Value = textBoxItemName.Text;
                    //    dataGridView1["ItemCost",row].Value = textBoxCost.Text;
                    //    dataGridView1["ItemQuentity",row].Value = textBoxQuentity.Text;
                    //    dataGridView1["Amount",row].Value = textBoxAmount.Text;
                    //    dataGridView1["ItemCode",row].Value = textBoxItemCode.Text;
                    //    dataGridView1["Discount",row].Value = labelDiscountedAmount.Text;
                    //}
                    //   textBoxItemAmount.Text = total.ToString();

                    decimal Total = 0;

                    for(int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        Total += Convert.ToDecimal(dataGridView1.Rows[i].Cells["Amount"].Value);
                    }

                    textBoxItemAmount.Text = Total.ToString();
                    labelDiscountedAmount.Text = "";
                    textBoxAmount.Clear();
                    textBoxCost.Clear();
                    textBoxItemCode.Clear();
                    textBoxQuentity.Clear();
                    textBoxItemName.Clear();
                }
            }
            catch(Exception EX)
            {
                Documentid = Guid.NewGuid().ToString();
                labelDocID.Text = Documentid;
                MessageBox.Show(EX.Message);
            }
        }

        public void LoadInvoice()
        {
            try
            {
                ProjectConnection Newconnection = new ProjectConnection();
                Newconnection.Connection_Today();
                SqlCommand comm = new SqlCommand();
                comm.Connection = ProjectConnection.conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "dbo.SRN_Load_Invoice_Details";
                comm.Parameters.AddWithValue("@Invoice",textBoxInvoice.Text);
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                DataGridViewColumn column = dataGridView1.Columns[0];
                column.Width = 310;
            }
            catch(Exception ex)
            {
                Documentid = Guid.NewGuid().ToString();
                labelDocID.Text = Documentid;
                MessageBox.Show(ex.Message);
            }
        }
        public void OtherGeneralDetails()
        {
            try {
            ProjectConnection Newconnection = new ProjectConnection();
            Newconnection.Connection_Today();
            SqlCommand comm = new SqlCommand();
            comm.Connection = ProjectConnection.conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "dbo.SRN_Load_Invoice_Header";
            comm.Parameters.AddWithValue("@Invoice",textBoxInvoice.Text);
            SqlDataReader dr;
            dr = comm.ExecuteReader();
            if(dr.HasRows == true)
            {
                dr.Read();
                textBoxCSID.Text = dr["Customer_Code"].ToString();
                textBoxCSName.Text = dr["Name"].ToString();
                textBoxItemAmount.Text = dr["Total_Amount"].ToString();
                textBoxSelectedInv.Text = dr["Doc_No"].ToString();
                dr.Close();
            }
           }
           catch(Exception)
            {
                MessageBox.Show("Faild Loading Details");
            } 
        }
        public void Clear()
        {
            textBoxItemAmount.Clear();
            textBoxSelectedInv.Clear();
            textBoxCSName.Clear();
            textBoxCSID.Clear();
            textBoxItemName.Clear();
            textBoxItemCode.Clear();
            textBoxQuentity.Clear();
            textBoxAmount.Clear();
            textBoxCost.Clear();
            textBoxItemCode.Focus();
        }

        private void textBoxInvoice_KeyUp(object sender,KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Clear();
                OtherGeneralDetails();
                LoadInvoice();
                e.Handled = true;
            }
        }

 

        private void dataGridView1_CellClick(object sender,DataGridViewCellEventArgs e)
        {
            try {
            if(this.dataGridView1.SelectedRows.Count > 0)
            {
                if(e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                    textBoxItemName.Text = row.Cells[0].Value.ToString();
                    textBoxItemCode.Text = row.Cells[1].Value.ToString();
                    textBoxCost.Text = row.Cells[2].Value.ToString();
                    textBoxQuentity.Text = row.Cells[3].Value.ToString();
                    textBoxAmount.Text = row.Cells[4].Value.ToString();
                }

                dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
            }
            }
            catch(Exception)
            {
                MessageBox.Show("Faild Data Passing to Inputs");
            }
        }

        private void buttonSave_Click(object sender,EventArgs e)
        {
            string Documentid = Guid.NewGuid().ToString();

            SaveInvoiceDetails();

        }
        //------------------------Other FN END-------------------//


        public void SaveInvoiceDetails()
        {
            try
            {
                int rows = dataGridView1.Rows.Count;
                for(int i = 0; rows - 1 > i; i++)

                {
                    ProjectConnection Newconnection = new ProjectConnection();
                    Newconnection.Connection_Today();
                    SqlCommand comm = new SqlCommand();
                    comm.Connection = ProjectConnection.conn;
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.CommandText = "dbo.SRN_Save_Srn_Details";
                    comm.Parameters.AddWithValue("@ID",Documentid.ToString());
                    comm.Parameters.AddWithValue("@Item_Code",(dataGridView1.Rows[i].Cells["ItemCode"].Value).ToString());
                    comm.Parameters.AddWithValue("@Selling_Price",Convert.ToDecimal((dataGridView1.Rows[i].Cells["ItemCost"].Value).ToString()));
                    comm.Parameters.AddWithValue("@Quentity",Convert.ToDecimal((dataGridView1.Rows[i].Cells["ItemQuentity"].Value).ToString()));
                    comm.Parameters.AddWithValue("@Amount",Convert.ToDecimal((dataGridView1.Rows[i].Cells["Amount"].Value).ToString()));
                    comm.ExecuteNonQuery();

                }
                SaveInvoice();
            }
            catch(Exception ex)
            {
                MessageBox.Show("SRN DETAILS ERROR \nTry Again with Correct Inputs \n" + ex.Message);
            }
        }
        public void SaveInvoice()
        {
            try
            {

                ProjectConnection Newconnection = new ProjectConnection();
                Newconnection.Connection_Today();
                SqlCommand comm = new SqlCommand();
                comm.Connection = ProjectConnection.conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "dbo.SRN_Save_Srn_header";
                comm.Parameters.AddWithValue("@ID",Documentid.ToString());
                comm.Parameters.AddWithValue("@Invoice",textBoxInvoice.Text);
                comm.Parameters.AddWithValue("@Total_Amount",Convert.ToDecimal(textBoxItemAmount.Text));
                comm.Parameters.AddWithValue("@Remark ",textBoxRemark.Text);
                comm.Parameters.AddWithValue("@Customer_Code",textBoxCSID.Text);
                comm.Parameters.AddWithValue("@Date",Convert.ToDateTime(dateTimePickerTranDate.Text));

                comm.ExecuteNonQuery();
                MessageBox.Show("Sales Return Saved");
            }
            catch(Exception ex)
            {
                MessageBox.Show("SRN HEADER ERROR \nTry Again with Correct Inputs \n" + ex.Message);
            }
        }

        private void buttonClear_Click(object sender,EventArgs e)
        {
            dataclear();
        }
        public void dataclear()
        {

            dataGridView1.DataSource = "";
            labelDiscountedAmount.Text = "";
            textBoxAmount.Clear();
            textBoxCost.Clear();
            textBoxCSID.Clear();
            textBoxCSName.Clear();
            textBoxQuentity.Clear();
            textBoxItemAmount.Clear();
            textBoxItemName.Clear();
            textBoxRemark.Clear();
            InvoiceDocumentID = Guid.NewGuid().ToString();
        }

        private void buttonViewSRN_Click(object sender,EventArgs e)
        {
            ViewSRN SRN = new ViewSRN();
            SRN.Show();
        }

        private void pictureBox3_Click(object sender,EventArgs e)
        {
            string Documentid = Guid.NewGuid().ToString();
            SaveInvoiceDetails();
        }

        private void pictureBox4_Click(object sender,EventArgs e)
        {
            dataclear();
        }
    }
}
