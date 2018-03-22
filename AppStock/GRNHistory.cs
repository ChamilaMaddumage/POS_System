using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Services
{
    public partial class GRNHistory : Form
    {
        public GRNHistory()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GRNHistory_Load(object sender, EventArgs e)
        {
            grid();
            gridDetails();
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
                comm.CommandText = "GRN.Load_Grn_Header";
                comm.Parameters.AddWithValue("@Search_Condition", textBoxSearch.Text);
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewHeader.DataSource = dt;
                DataGridViewColumn column = dataGridViewHeader.Columns[2];
                column.Width = 255;
            }
            catch (Exception ex)
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
                comm.CommandText = "GRN.Load_Grn_Details";
                comm.Parameters.AddWithValue("@Search_Condition", textBoxSearch.Text);
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewDetails.DataSource = dt;
                DataGridViewColumn column = dataGridViewDetails.Columns[2];
                column.Width = 255;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            grid();
            gridDetails();
        }

        private void textBoxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            grid();
            gridDetails();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ProjectConnection Newconnection = new ProjectConnection();
                Newconnection.Connection_Today();
                SqlCommand comm = new SqlCommand();
                comm.Connection = ProjectConnection.conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "grn.Delete_Grn";
                comm.Parameters.AddWithValue("@Doc_No", textBoxSearch.Text);
                comm.ExecuteNonQuery();
                grid();
                gridDetails();
            }
            catch (Exception)
            {
                MessageBox.Show("Fail Delete");
            }
        }

        private void dataGridViewHeader_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridViewHeader.Rows[e.RowIndex];
                textBoxSearch.Text = row.Cells[0].Value.ToString();
            }
            grid();
            gridDetails();
        }
    }
}
