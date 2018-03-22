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
    public partial class ViewSRN:Form
    {
        public ViewSRN()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender,EventArgs e)
        {
            this.Close();
        }

        private void ViewSRN_Load(object sender,EventArgs e)
        {
            grid();
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
                comm.CommandText = "dbo.SRN_Load_SRN_Header ";
                comm.Parameters.AddWithValue("@Search_Condition",textBoxSearch.Text);
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewHeader.DataSource = dt;
                DataGridViewColumn column = dataGridViewHeader.Columns[2];
                column.Width = 255;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void gridDetails()
        {
            try
            {
                ProjectConnection Newconnection = new ProjectConnection();
                Newconnection.Connection_Today();
                SqlCommand comm = new SqlCommand();
                comm.Connection = ProjectConnection.conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "dbo.[SRN_Load_SRN_DETAILS] ";
                comm.Parameters.AddWithValue("@Search_Condition",textBoxSearch.Text);
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                //dataGridViewDetails.DataSource = dt;
                //DataGridViewColumn column = dataGridViewDetails.Columns[2];
                //column.Width = 255;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonDelete_Click(object sender,EventArgs e)
        {
            try
            {
                ProjectConnection Newconnection = new ProjectConnection();
                Newconnection.Connection_Today();
                SqlCommand comm = new SqlCommand();
                comm.Connection = ProjectConnection.conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "dbo.SRN_Delete_SRN";
                comm.Parameters.AddWithValue("@Doc_No",textBoxSearch.Text);
                comm.ExecuteNonQuery();
                grid();
            }
            catch(Exception)
            {
                MessageBox.Show("Fail Delete");
            }
        }

        private void dataGridViewHeader_CellClick(object sender,DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridViewHeader.Rows[e.RowIndex];
                textBoxSearch.Text = row.Cells[0].Value.ToString();
            }
        }

        private void textBoxSearch_KeyUp(object sender,KeyEventArgs e)
        {
            grid();
        }

        private void buttonLoad_Click(object sender,EventArgs e)
        {
            grid();
        }
    }
}
