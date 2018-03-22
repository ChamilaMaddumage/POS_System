using CrystalDecisions.CrystalReports.Engine;
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
    public partial class PrintForm : Form
    {
        ReportDocument cry = new ReportDocument();
        public PrintForm()
        {
            InitializeComponent();
        }

        private void PrintForm_Load(object sender, EventArgs e)
        {
            try
            {
            cry.Load(@"C:\Reports\CRYPT.rpt");
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=POS;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("[Sales].[Invoice_Print_Details]", con);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.Add("@Doc_No", System.Data.SqlDbType.VarChar, 50).Value = Globlevariable.PrintDocNo;
            DataSet st = new DataSet();
            sda.Fill(st, "DATA");
            cry.SetDataSource(st);
            //crystalReportViewer1.ReportSource = cry;
                cry.PrintToPrinter(1,false,0,0);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
