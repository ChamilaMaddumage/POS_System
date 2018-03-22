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
    public partial class Users : Form
    {
        public int SaveType = 0;
        public Users()
        {
            InitializeComponent();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
 
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonViewStock_Click(object sender,EventArgs e)
        {
            ReportStock rs = new ReportStock();
            rs.Show();
        }

        private void buttonViewDailySummary_Click(object sender,EventArgs e)
        {
            try {
            Globlevariable.FromDate = Convert.ToDateTime(dateTimePickerFromDate.Text);
            Globlevariable.Todate = Convert.ToDateTime(dateTimePickerToDate.Text);

            ReportsSummary RS = new ReportsSummary();
            RS.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
