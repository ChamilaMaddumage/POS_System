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
    public partial class StockDetails : Form
    {
        public StockDetails()
        {
            InitializeComponent();
        }

        private void StockDetails_Load(object sender, EventArgs e)
        {
            grid();
            textBoxSearch.Focus();
        }
        public void grid()
        {
            try
            {
                ProjectConnection Newconnection = new ProjectConnection();
                Newconnection.Connection_Today();
                SqlCommand comm = new SqlCommand();
                comm.Connection = ProjectConnection.conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "stock.Get_List_of_Stock_details";
                comm.Parameters.AddWithValue("@Search_Condition", textBoxSearch.Text);
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                DataGridViewColumn column = dataGridView1.Columns[0];
                DataGridViewColumn column2 = dataGridView1.Columns[4];
                column.Width = 255;
                column2.Width = 150;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void textBoxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            grid();
        }
    }
}
