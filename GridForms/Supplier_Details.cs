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
    public partial class Supplier_Details : Form
    {
        public string SUpCode
        {
            get { return textBoxSUPCode.Text; }
            set { textBoxSUPCode.Text = value; }
        }
        public string SupName
        {
            get { return textBoxItemSUPName.Text; }
            set { textBoxItemSUPName.Text = value; }
        }
        public Supplier_Details()
        {
            InitializeComponent();
        }

        private void Supplier_Details_Load(object sender, EventArgs e)
        {
            LoadSupplier();
        }
        public void LoadSupplier()
        {
            try
            {
                ProjectConnection Newconnection = new ProjectConnection();
                Newconnection.Connection_Today();
                SqlCommand comm = new SqlCommand();
                comm.Connection = ProjectConnection.conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "Suppliers.Load_Suppliers_For_GRN";
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
            LoadSupplier();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                textBoxSUPCode.Text = row.Cells[0].Value.ToString();
                textBoxItemSUPName.Text = row.Cells[1].Value.ToString();

            }
        }
    }
}
