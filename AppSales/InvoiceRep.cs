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
    public partial class InvoiceRep : Form
    {
        public InvoiceRep()
        {
            InitializeComponent();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            gridInhHeader();
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
                comm.CommandText = "Sales.Load_Invoice";
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
        public void gridInhHeader()
        {
            try
            {
                ProjectConnection Newconnection = new ProjectConnection();
                Newconnection.Connection_Today();
                SqlCommand comm = new SqlCommand();
                comm.Connection = ProjectConnection.conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "Sales.Load_Invoice_Header";
                comm.Parameters.AddWithValue("@Search_Condition", textBoxSearch.Text);
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewHeader.DataSource = dt;
                DataGridViewColumn column = dataGridViewHeader.Columns[2];
                column.Width = 150;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InvoiceRep_Load(object sender, EventArgs e)
        {
            gridInhHeader();
            grid();
        }

        private void textBoxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            gridInhHeader();
            grid();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            Globlevariable.PrintDocNo = textBoxSearch.Text;

            if (textBoxSearch.Text == "")
            {
                MessageBox.Show("Please Enter Invoice Number for Print");
            }
            else
            {
                PrintForm PF = new PrintForm();
                PF.Show();
            }

        }

        private void dataGridViewHeader_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridViewHeader.Rows[e.RowIndex];
                    textBoxSearch.Text = row.Cells[0].Value.ToString();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            gridInhHeader();
            grid();
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
                comm.CommandText = "sales.Delete_Invoice";
                comm.Parameters.AddWithValue("@Doc_No", textBoxSearch.Text);
                comm.ExecuteNonQuery();
                gridInhHeader();
                grid();
                MessageBox.Show("Deleted Successfully");
            }
            catch(Exception)
            {
                MessageBox.Show("Fail Delete");
            }
            }
    }
}
