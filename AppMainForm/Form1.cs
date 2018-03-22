using Services.Stock;
using Services.GridForms;
using Services.Payments;
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
    public partial class Form1:Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnMenuGroup2_Click(object sender,EventArgs e)
        {
            if(pnlMenuGroup2.Height == 44 || pnlMenuGroup2.Height == 35)
            {
                pnlMenuGroup2.Height = (44 * 5) + 2;
                btnMenuGroup2.Image = Properties.Resources.UpBtnE;

            }
            else
            {
                pnlMenuGroup2.Height = 35;
                btnMenuGroup2.Image = Properties.Resources.DownBtnE;

            }
        }

        private void btnMenuGroup1_Click(object sender,EventArgs e)
        {
            if(pnlMenuGroup1.Height == 44 || pnlMenuGroup1.Height == 35)
            {
                pnlMenuGroup1.Height = (44 * 4) + 2;
                btnMenuGroup1.Image = Properties.Resources.UpBtnE;
            }
            else
            {
                pnlMenuGroup1.Height = 35;
                btnMenuGroup1.Image = Properties.Resources.DownBtnE;

            }
        }

        private void btnMenuGroup3_Click(object sender,EventArgs e)
        {
            if(pnlMenuGroup3.Height == 40 || pnlMenuGroup3.Height == 35)
            {
                pnlMenuGroup3.Height = (35 * 3) + 2;
                btnMenuGroup3.Image = Properties.Resources.UpBtnE;

            }
            else
            {
                pnlMenuGroup3.Height = 35;
                btnMenuGroup3.Image = Properties.Resources.DownBtnE;

            }
        }

        private void buttonGroup4_Click(object sender,EventArgs e)
        {
            if(pnlMenuGroup4.Height == 40 || pnlMenuGroup4.Height == 35)
            {
                pnlMenuGroup4.Height = (40 * 4) + 2;
                buttonGroup4.Image = Properties.Resources.UpBtnE;
            }
            else
            {
                pnlMenuGroup4.Height = 35;
                buttonGroup4.Image = Properties.Resources.DownBtnE;

            }
        }

        private void Form1_Load(object sender,EventArgs e)
        {
            if(Globlevariable.UserType == "Standard User")
            {
                LoadPermission();
            }
            LoadPermission();

            labelUserName.Text = "Hello :" + Globlevariable.UserName;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            Left = Top = 1;
            pnlMenuGroup1.Height = (44 * 4) + 2;
            pnlMenuGroup2.Height = (44 * 5) + 2;
            //pnlMenuGroup2.Height = 35;
            pnlMenuGroup3.Height = 35;
            pnlMenuGroup4.Height = 35;
            btnMenuGroup1.Image = Properties.Resources.UpBtnE;
            btnMenuGroup2.Image = Properties.Resources.DownBtnE;
            btnMenuGroup3.Image = Properties.Resources.DownBtnE;
            buttonGroup4.Image = Properties.Resources.DownBtnE;


            Invoice Template = new Invoice();
            Template.MdiParent = this;
            Template.AutoScroll = false;
            Template.Show();
            Template.AutoScroll = false;

        }

        private void button2_Click(object sender,EventArgs e)
        {
            SalesReturn Template = new SalesReturn();
            Template.MdiParent = this;
            Template.AutoScroll = false;
            Template.Show();
            Template.AutoScroll = false;
            //Form
        }

        private void button3_Click(object sender,EventArgs e)
        {
           //Form
        }

        private void btnAbout_Click(object sender,EventArgs e)
        {
            Invoice Template = new Invoice();
            Template.MdiParent = this;
            Template.AutoScroll = false;
            Template.Show();
            Template.AutoScroll = false;
        }

        private void button5_Click(object sender,EventArgs e)
        {
            Items itm = new Items();
            itm.MdiParent = this;
            itm.AutoScroll = false;
            itm.Show();
            itm.AutoScroll = false;
        }

        private void button4_Click(object sender,EventArgs e)
        {
            Customers cs = new Customers();
            cs.MdiParent = this;
            cs.AutoScroll = false;
            cs.Show();
            cs.AutoScroll = false;
        }

        private void button14_Click(object sender,EventArgs e)
        {
            Suppliers SUP = new Suppliers();
            SUP.MdiParent = this;
            SUP.AutoScroll = false;
            SUP.Show();
            SUP.AutoScroll = false;

        }

        private void button10_Click(object sender,EventArgs e)
        {
            Banking BNK = new Banking();
            BNK.MdiParent = this;
            BNK.AutoScroll = false;
            BNK.Show();
            BNK.AutoScroll = false;
        }

        private void button9_Click(object sender,EventArgs e)
        {
            Cash CSH = new Cash();
            CSH.MdiParent = this;
            CSH.AutoScroll = false;
            CSH.Show();
            CSH.AutoScroll = false;
        }

        private void button6_Click(object sender,EventArgs e)
        {

            //This is used to clear the static general list collection of GRNChequeDataGridView
            //START
            ChequeGRN.GRNChequeDataGridView.Clear();
            //END

            GRN GRN = new GRN();
            GRN.MdiParent = this;
            GRN.AutoScroll = false;
            GRN.Show();
            GRN.AutoScroll = false;
        }

        private void button13_Click(object sender,EventArgs e)
        {
            InvoiceRep INR = new InvoiceRep();
            INR.MdiParent = this;
            INR.AutoScroll = false;
            INR.Show();
            INR.AutoScroll = false;
        }

        //private void button11_Click(object sender, EventArgs e)
        //{
        //    Users USR = new Users();
        //    USR.MdiParent = this;
        //    USR.AutoScroll = false;
        //    USR.Show();
        //    USR.AutoScroll = false;
        //}

        private void button7_Click(object sender,EventArgs e)
        {
            //AdminRules USR = new AdminRules();
            //USR.MdiParent = this;
            //USR.AutoScroll = false;
            //USR.Show();
            //USR.AutoScroll = false;
            if(Globlevariable.UserType == "Administrator")
            {
                AdminRules USR = new AdminRules();
                USR.MdiParent = this;
                USR.AutoScroll = false;
                USR.Show();
                USR.AutoScroll = false;
            }

            else
            {
                MessageBox.Show("You Don't have permissions.Contact Administrator");
            }
        }

        private void button11_Click_1(object sender,EventArgs e)
        {
            //Users USR = new Users();
            //USR.MdiParent = this;
            //USR.AutoScroll = false;
            //USR.Show();
            //USR.AutoScroll = false;

            if(Globlevariable.UserType == "Administrator")
            {
                Users USR = new Users();
                USR.MdiParent = this;
                USR.AutoScroll = false;
                USR.Show();
                USR.AutoScroll = false;
            }

            else
            {
                MessageBox.Show("You Don't have permissions.Contact Administrator");
            }
        }

        private void buttonStock_Click(object sender,EventArgs e)
        {
            StockDetails SD = new StockDetails();
            SD.MdiParent = this;
            SD.AutoScroll = false;
            SD.Show();
            SD.AutoScroll = false;
        }


       public static void LoadPermission()
        {
            try
            {
                ProjectConnection Newconnection = new ProjectConnection();
                Newconnection.Connection_Today();
                SqlCommand comm = new SqlCommand();
                comm.Connection = ProjectConnection.conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "dbo.Load_Permission_For_User";
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                //MessageBox.Show(dt.Rows[0][1].ToString());
                //MessageBox.Show(dt.Rows[1][1].ToString());
                Permission.InvoiceSave                  = dt.Rows[0][1].ToString();
                Permission.InvoiceDisount               = dt.Rows[1][1].ToString();
                Permission.InvoiceCustomerSelect        = dt.Rows[2][1].ToString();
                Permission.InvoiceDateSelect            = dt.Rows[3][1].ToString();
                Permission.InvoiceSellingPriceChange    = dt.Rows[4][1].ToString();
                Permission.GRNCostChange                = dt.Rows[5][1].ToString();
                Permission.GRNDiscountChange            = dt.Rows[6][1].ToString();
                Permission.GRNOldView                   = dt.Rows[7][1].ToString();
                Permission.GRNSave                      = dt.Rows[8][1].ToString();
                Permission.ItemSave                     = dt.Rows[9][1].ToString();
                Permission.ItemUpdate                   = dt.Rows[10][1].ToString();
                Permission.ItemDelete                   = dt.Rows[11][1].ToString();
                Permission.CustomerSave                 = dt.Rows[12][1].ToString();
                Permission.CustomerUpdate               = dt.Rows[13][1].ToString();
                Permission.CustomerDelete               = dt.Rows[14][1].ToString();
                Permission.SupplierSave                 = dt.Rows[15][1].ToString();
                Permission.SupplierUpadate              = dt.Rows[16][1].ToString();
                Permission.SupplierDelete               = dt.Rows[17][1].ToString();
                Permission.StockView                    = dt.Rows[18][1].ToString();
                Permission.BarcodePrintAccess           = dt.Rows[19][1].ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button8_Click(object sender,EventArgs e)
        {
            PurchaseReturn PRN = new PurchaseReturn();
            PRN.MdiParent = this;
            PRN.AutoScroll = false;
            PRN.Show();
            PRN.AutoScroll = false;
        }

        private void button4_Click_1(object sender,EventArgs e)
        {
            Customers CS = new Customers();
            CS.MdiParent = this;
            CS.AutoScroll = false;
            CS.Show();
            CS.AutoScroll = false;
        }

        private void pictureBox2_Click(object sender,EventArgs e)
        {
            Login Log = new Login();
            Log.Show();
            this.Close();
        }

        private void buttonGRNHystory_Click(object sender,EventArgs e)
        {
            GRNHistory GH = new GRNHistory();
            GH.MdiParent = this;
            GH.AutoScroll = false;
            GH.Show();
            GH.AutoScroll = false;
        }
    }
}
