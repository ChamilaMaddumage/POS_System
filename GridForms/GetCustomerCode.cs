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

namespace Services.GridForms
{
    public partial class GetCustomerCode : Form
    {
        public string CSCode
        {
            get { return textBoxCSCode.Text; }
            set { textBoxCSCode.Text = value; }
        }
        public string CSName
        {
            get { return textBoxItemCSName.Text; }
            set { textBoxItemCSName.Text = value; }
        }
        public GetCustomerCode()
        {
            InitializeComponent();
        }

        private void GetCustomerCode_Load(object sender, EventArgs e)
        {
            try
            {
                ProjectConnection Newconnection = new ProjectConnection();
                Newconnection.Connection_Today();
                SqlCommand comm = new SqlCommand();
                comm.Connection = ProjectConnection.conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "Sales.Customer_Details_Load_Into_Data_Grid_View";
                comm.Parameters.AddWithValue("@SearchCondition", textBoxSearchCondition.Text);
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxSearchCondition_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                ProjectConnection Newconnection = new ProjectConnection();
                Newconnection.Connection_Today();
                SqlCommand comm = new SqlCommand();
                comm.Connection = ProjectConnection.conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "Sales.Customer_Details_Load_Into_Data_Grid_View";
                comm.Parameters.AddWithValue("@SearchCondition", textBoxSearchCondition.Text);
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                textBoxCSCode.Text = row.Cells[0].Value.ToString();
                textBoxItemCSName.Text = row.Cells[1].Value.ToString();

            }
        }
    }
}
