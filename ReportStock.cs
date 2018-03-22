using System;
using System.Data;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;

namespace Services
{
    public partial class ReportStock:Form
    {
        ReportDocument cry = new ReportDocument();

        public ReportStock()
        {
            InitializeComponent();
        }

        private void ReportStock_Load(object sender,EventArgs e)
        {
            try
            {
                cry.Load(@"C:\Reports\ReportStockDetails.rpt");
                SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=POS;Integrated Security=True");
                SqlDataAdapter sda = new SqlDataAdapter("dbo.Reports_Stock_Details",con);
                // comm.Parameters.AddWithValue("@SearchCondition", textBoxSearchCondition.Text);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                //sda.SelectCommand.Parameters.Add("@Doc_No",System.Data.SqlDbType.VarChar,50).Value = "INV-1";
                DataSet st = new DataSet();
                sda.Fill(st,"StockDetails");
                cry.SetDataSource(st);
                crystalReportViewer1.ReportSource = cry;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
