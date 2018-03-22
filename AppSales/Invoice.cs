using CrystalDecisions.CrystalReports.Engine;
using Services.GridForms;
using Services.Payments;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Services
{
    public partial class Invoice : Form
    {
        string Documentid = Guid.NewGuid().ToString();
        private GetItemCodes GetItemCode;
        private GRNCheque ChequeForm;
        private Mobile MobileForm;
        private Card CardForm;
        private GetCustomerCode CustomerDetailsForm;
        public static string InvoiceDocumentID;
        public string duration = "";
        public Invoice()
        {
            InitializeComponent();
            textBoxItemCode.Focus();
            GetItemCode = new GetItemCodes();
            GetItemCode.FormClosed += new FormClosedEventHandler(GetItemCode_FormClosed);
            ChequeForm = new GRNCheque();
            ChequeForm.FormClosed += new FormClosedEventHandler(Cheque_FromClosed);
            MobileForm = new Mobile();
            MobileForm.FormClosed += new FormClosedEventHandler(Mobile_FromClosed);
            CustomerDetailsForm = new GetCustomerCode();
            CustomerDetailsForm.FormClosed += new FormClosedEventHandler(GetCustomerCode_FormClosed);
            textBoxItemCode.Select(0,0);//not working

        }

        private void GetCustomerCode_FormClosed(object sender, FormClosedEventArgs e)
        {
            textBoxCSName.Text = CustomerDetailsForm.CSName;
            textBoxCSID.Text = CustomerDetailsForm.CSCode;
        }

        private void GetItemCode_FormClosed(object sender, FormClosedEventArgs e)
        {
            textBoxItemCode.Text = GetItemCode.ItemCode;
            textBoxItemName.Text = GetItemCode.ItemName;
            textBoxCost.Text = GetItemCode.ItemCost;
            textBoxQuentity.Focus();
        }

        private void Mobile_FromClosed(object sender, FormClosedEventArgs e)
        {
            // textBoxMobileAmount.Text = MobileForm.MobileTotal;
            Calculation();
        }

        private void Cheque_FromClosed(object sender, FormClosedEventArgs e)
        {
            textBoxChequeAmount.Text = ChequeForm.totalCheque;
            Calculation();

        }

        private void buttonAdd_Click(object sender, EventArgs e)//validations of textBox
        {

            if(textBoxCSID.Text != "")
            {
                pictureBox2.Enabled = false;
            }
            if(textBoxCost.Text == "")
            {
                MessageBox.Show("Please Fill Cost");
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
                Addtogrid();
            }
        }

        public void Addtogrid()//add items to grid
        {
            try
            {
                if(textBoxQuentity.Text == ""){ 
                textBoxQuentity.Text = "1";
                textBoxAmount = textBoxCost;
            }
                if(labelDiscountedAmount.Text=="")
                    {
                        labelDiscountedAmount.Text ="0.00";
                    }
                    int row = 0;
                    dataGridView1.Rows.Add();
                    row = dataGridView1.Rows.Count - 2;
                    for(int i = 0; i <= dataGridView1.Rows.Count - 2; i++)
                    {
                        dataGridView1["ItemName",row].Value = textBoxItemName.Text;
                        dataGridView1["ItemCost",row].Value = textBoxCost.Text;
                        dataGridView1["ItemQuentity",row].Value = textBoxQuentity.Text;
                        dataGridView1["Amount",row].Value = textBoxAmount.Text;
                        dataGridView1["ItemCode",row].Value = textBoxItemCode.Text;
                        dataGridView1["Discount",row].Value = labelDiscountedAmount.Text;

                        // total += Convert.ToDecimal(dataGridView1["Amount", row].Value);
                    }
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
                    textBoxItemCode.Select();
            }
            catch(Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }
        private void Invoice_Load(object sender, EventArgs e)//load invoice after login or click invoice
        {
            labelDiscountedAmount.Hide();
            labelInvoiceDocNo.Hide();
            if(Permission.InvoiceDisount =="DEACTIVE")
            {
                textBoxDiscount.Enabled = false;
            }
            if(Permission.InvoiceSave == "DEACTIVE")
            {
                buttonSave.Enabled = false;
            }
            if(Permission.InvoiceCustomerSelect == "DEACTIVE")
            {
                textBoxCSID.Text = "CUS-1";
                textBoxCSName.Text = "Default Customer";
                pictureBox2.Enabled = false;
            }
            if(Permission.InvoiceDateSelect == "DEACTIVE")
            {
                dateTimePickerTranDate.Enabled = false;
            }

            // MessageBox.Show(Permission.InvoiceDisount);
            labelDocID.Text = Documentid;
            textBoxCSID.Enabled = false;
            //textBoxItemCode.Enabled = false;
            textBoxItemName.Enabled = false;
            labelDocID.Visible = false;
            textBoxItemCode.Select();


        }

        private void buttonSave_Click(object sender, EventArgs e)//Click on save button
        {
            SaveInvoiceDetails();
            string Documentid = Guid.NewGuid().ToString();
        }
        public void SaveInvoiceDetails()//save to temp table
        {
            try
            {
                int rows = dataGridView1.Rows.Count;
                for (int i = 0; rows - 1 > i; i++)

                {
                    ProjectConnection Newconnection = new ProjectConnection();
                    Newconnection.Connection_Today();
                    SqlCommand comm = new SqlCommand();
                    comm.Connection = ProjectConnection.conn;
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.CommandText = "Sales.Save_Invoice_Details_Temp";
                    comm.Parameters.AddWithValue("@ID", Documentid.ToString());
                    comm.Parameters.AddWithValue("@Item_Code", (dataGridView1.Rows[i].Cells["ItemCode"].Value).ToString());
                    comm.Parameters.AddWithValue("@Selling_Price", Convert.ToDecimal((dataGridView1.Rows[i].Cells["ItemCost"].Value).ToString()));
                    comm.Parameters.AddWithValue("@Quantity", Convert.ToDecimal((dataGridView1.Rows[i].Cells["ItemQuentity"].Value).ToString()));
                    comm.Parameters.AddWithValue("@Amount",Convert.ToDecimal((dataGridView1.Rows[i].Cells["Amount"].Value).ToString()));
                    comm.Parameters.AddWithValue("@Discount",Convert.ToDecimal((dataGridView1.Rows[i].Cells["Discount"].Value).ToString()));
                    comm.ExecuteNonQuery();

                }
                SaveInvoice();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code INVD-01 \nTry Again with Correct Inputs \n" + ex.Message);
            }
        }
        public void SaveInvoice()//save to permenent table
        {
            try
            {

                ProjectConnection Newconnection = new ProjectConnection();
                Newconnection.Connection_Today();
                SqlCommand comm = new SqlCommand();
                comm.Connection = ProjectConnection.conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "Sales.Save_Invoice_Details";
                comm.Parameters.AddWithValue("@ID", Documentid.ToString());
                comm.Parameters.AddWithValue("@CS_Code", textBoxCSID.Text);
                comm.Parameters.AddWithValue("@Doc_Date", Convert.ToDateTime(dateTimePickerTranDate.Text));
                comm.Parameters.AddWithValue("@Total_Amount ", Convert.ToDecimal(textBoxItemAmount.Text));
                if (textBoxCSPaidCash.Text == "")
                {
                    comm.Parameters.AddWithValue("@Cash_Payment", 0);
                }
                else
                {
                    comm.Parameters.AddWithValue("@Cash_Payment", Convert.ToDecimal(textBoxCSPaidCash.Text));
                }
                if (textBoxChequeAmount.Text == "")
                {
                    comm.Parameters.AddWithValue("@Cheque_Payment", 0);
                }
                else
                {
                    comm.Parameters.AddWithValue("@Cheque_Payment", Convert.ToDecimal(textBoxChequeAmount.Text));
                }

                comm.Parameters.AddWithValue("@Remark", textBoxRemark.Text);

                comm.ExecuteNonQuery();
                LoadPrintInvoiceCode();//for print
                ClearInvoice();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code INVH-01 \nTry Again with Correct Inputs \n" + ex.Message);
            }
        }
        public void Calculation()
        {
            try
            {
                decimal total = 0;
                decimal CashPayment = 0;
                decimal ChequePayment = 0;
                decimal BalanceToCS = 0;

                if (textBoxItemAmount.Text == "")
                {
                    total = 0;
                }
                else
                {
                    total = Convert.ToDecimal(textBoxItemAmount.Text);
                }

                if (textBoxCSPaidCash.Text == "")
                {
                    CashPayment = 0;
                }
                else
                {
                    CashPayment = Convert.ToDecimal(textBoxCSPaidCash.Text);

                }

                if (textBoxChequeAmount.Text == "")
                {
                    ChequePayment = 0;
                }
                else
                {
                    ChequePayment = Convert.ToDecimal(textBoxChequeAmount.Text);

                }

                BalanceToCS = (CashPayment + ChequePayment) - total;
                labelBalance.Text = BalanceToCS.ToString();
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }

        private void textBoxCSPaidCash_KeyUp(object sender, KeyEventArgs e)
        {
            Calculation();
        }


        private void textBoxChequeAmount_KeyUp(object sender, KeyEventArgs e)
        {
            Calculation();
        }
        private void textBoxChequeAmount_Click(object sender, EventArgs e)
        {
            InvoiceDocumentID = labelDocID.Text;
            ChequeForm.ShowDialog();
        }

        private void textBoxMobileAmount_Click(object sender, EventArgs e)
        {
            InvoiceDocumentID = labelDocID.Text;
            MobileForm.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            GetItemCode.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            CustomerDetailsForm.ShowDialog();
        }
        public void CalculationFN01()
        {
            try
            {
                decimal Cost = 0;
                decimal Quentity = 0;
                decimal Amount = 0;
                decimal discount = 0;
                if (textBoxCost.Text == "")
                {
                    Cost = 0;
                }
                else
                {
                    Cost = Convert.ToDecimal(textBoxCost.Text);
                }
                if (textBoxQuentity.Text == "")
                {
                    Quentity = 0;
                }
                else
                {
                    Quentity = Convert.ToDecimal(textBoxQuentity.Text);
                }
                if (textBoxAmount.Text == "")
                {
                    Amount = 0;
                }
                if(textBoxDiscount.Text =="" )
                {
                    discount = 0;
                    Amount = Quentity * Cost;
                }
                else
                {
                    Amount = Quentity * Cost;
                    discount = Amount * (Convert.ToDecimal(textBoxDiscount.Text) / 100);
                    Amount = Amount - discount;

                }
                labelDiscountedAmount.Text = discount.ToString("N");
                textBoxAmount.Text = Amount.ToString("N");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxQuentity_KeyUp(object sender, KeyEventArgs e)
        {
            CalculationFN01();
            if(e.KeyCode == Keys.Enter)
            {
                Addtogrid();
                labelDiscountedAmount.Text = "";
                textBoxItemName.Clear();
                textBoxItemCode.Clear();
                textBoxQuentity.Clear();
                textBoxDiscount.Clear();
                textBoxAmount.Clear();
                textBoxCost.Clear();
                textBoxItemCode.Focus();
                e.Handled = true;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)//double click grid raw for delete an item
        {
            try {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
            }
            decimal Total = 0;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                Total += Convert.ToDecimal(dataGridView1.Rows[i].Cells["Amount"].Value);
            }

            textBoxItemAmount.Text = Total.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Invalid Selection "+ ex);
            }
        }
        public void ClearInvoice()//clear textBox
        {
            labelDiscountedAmount.Text = "";
            textBoxAmount.Clear();
            textBoxChequeAmount.Clear();
            textBoxCost.Clear();
            textBoxCSName.Clear();
            textBoxQuentity.Clear();
            textBoxItemAmount.Clear();
            textBoxItemName.Clear();
            textBoxCSPaidCash.Clear();
            textBoxRemark.Clear();
            labelBalance.Text = "Balance";
            pictureBox2.Enabled = true;
            this.dataGridView1.Rows.Clear();
            if(Permission.InvoiceCustomerSelect == "DEACTIVE")
            {
                textBoxCSID.Text = "CUS-1";
                textBoxCSName.Text = "Default Customer";
                pictureBox2.Enabled = false;
                textBoxCSName.Enabled = false;
            }
            else
            {
                textBoxCSID.Clear();

            }
        }

        private void buttonClear_Click(object sender, EventArgs e)//clear button
        {
            ClearInvoice();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxVechicleNo_KeyUp(object sender, KeyEventArgs e)
        {
            LoadCustomer();
        }
        public void LoadCustomer()
        {
            try
            {
                ProjectConnection Newconnection = new ProjectConnection();
                Newconnection.Connection_Today();
                SqlCommand comm = new SqlCommand();
                comm.Connection = ProjectConnection.conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "Customer.Load_Customer_Code_And_Name_Using_Vehicle_No";
                comm.Parameters.AddWithValue("@Vehicle_No", "");
                SqlDataReader dr;
                dr = comm.ExecuteReader();
                if (dr.HasRows == true)
                {
                    dr.Read();
                    textBoxCSID.Text = dr["Doc_No"].ToString();
                    textBoxCSName.Text = dr["Name"].ToString();
                    dr.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error Loading Customer Details");
            }
        }

        private void dailyInvoiceSummaryToolStripMenuItem_Click(object sender,EventArgs e)//nothing
        {

        }

        private void textBoxDiscount_KeyUp(object sender,KeyEventArgs e)
        {
            CalculationFN01();
            if(e.KeyCode == Keys.Enter)
            {
                Addtogrid();
                labelDiscountedAmount.Text = "";
                textBoxItemName.Clear();
                textBoxItemCode.Clear();
                textBoxQuentity.Clear();
                textBoxDiscount.Clear();
                textBoxAmount.Clear();
                textBoxCost.Clear();
                textBoxItemCode.Focus();
                e.Handled = true;
            }
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
                MessageBox.Show("Error Loading Item Details");
            }
        }
        public void LoadPrintInvoiceCode()//For print
        {
            try { 
            ReportDocument cry = new ReportDocument();
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
           // PrintForm PF = new PrintForm();
           // PF.Show();
            cry.Load(@"C:\Reports\CRYPT.rpt");
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=POS;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("[Sales].[Invoice_Print_Details]",con);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.Add("@Doc_No",System.Data.SqlDbType.VarChar,50).Value = Globlevariable.PrintDocNo;
            DataSet st = new DataSet();
            sda.Fill(st,"DATA");
            cry.SetDataSource(st);
            //crystalReportViewer1.ReportSource = cry;
            cry.PrintToPrinter(1,false,0,0);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void groupBox5_Enter(object sender,EventArgs e)
        {

        }

        private void pictureBox3_Click_1(object sender,EventArgs e)//save picture
        {
            SaveInvoiceDetails();
            string Documentid = Guid.NewGuid().ToString();
        }

        private void pictureBox4_Click(object sender,EventArgs e)//clear picture
        {
            ClearInvoice();
        }
    }
}
