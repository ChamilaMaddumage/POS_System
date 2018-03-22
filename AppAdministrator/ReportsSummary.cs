using System;
using System.Data;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;


namespace Services
{
    public partial class ReportsSummary:Form
    {
        ReportDocument cry = new ReportDocument();

        public ReportsSummary()
        {
            InitializeComponent();
        }

        private void ReportsSummary_Load(object sender,EventArgs e)
        {
            try
            {
                cry.Load(@"C:\Reports\ReportSummary.rpt");
                SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=POS;Integrated Security=True");
                SqlDataAdapter sda = new SqlDataAdapter("dbo.Reports_Daily_Summary",con);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.Add("@From_Date",System.Data.SqlDbType.VarChar,50).Value = Globlevariable.FromDate;
                sda.SelectCommand.Parameters.Add("@To_Date",System.Data.SqlDbType.VarChar,50).Value = Globlevariable.Todate;
                DataSet st = new DataSet();
                sda.Fill(st,"DailySummary");
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
