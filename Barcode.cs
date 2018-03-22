using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Services
{
    public partial class Barcode:Form
    {
        public Barcode()
        {
            InitializeComponent();
            Load += new EventHandler(Barcode_Load);

        }

        private void Barcode_Load(object sender,EventArgs e)
        {
            try {
            DataSet2 barcodeDetails = new DataSet2();
            DataTable dataTable = barcodeDetails.Barcodes;

            BarcodeReport Report = new BarcodeReport();
            int blank_labels = 0;
            int numberofLabel = Globlevariable.ItemPrintQty;
            for(int i = 0; i < numberofLabel; i++)
            {
                DataRow drow = dataTable.NewRow();
                string P_name = "DETAIL" + i.ToString();
                if(blank_labels <= i)
                {
                    drow["Doc_No"] =Globlevariable.ItemDocNo;

                    drow["Selling_Price"] = Globlevariable.ItemPrice;
                }
                dataTable.Rows.Add(drow);
            }

            Report.Database.Tables["Barcodes"].SetDataSource((DataTable)dataTable);


            crystalReportViewer1.ReportSource = Report;
            crystalReportViewer1.Refresh();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }
    }
}
