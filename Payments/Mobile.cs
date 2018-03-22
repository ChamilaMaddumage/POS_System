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

namespace Services.Payments
{
    public partial class Mobile : Form
    {
        public string MobileTotal
        {
            get { return textBoxTotalAmount.Text; }
            set { textBoxTotalAmount.Text = value; }
        }
        public Mobile()
        {
            InitializeComponent();
        }

        private void Mobile_Load(object sender, EventArgs e)
        {
            labelDocID.Text = Invoice.InvoiceDocumentID;
            textBoxMobileNo.Clear();
            textBoxMobileAmount.Clear();
            richTextBoxNote.Clear();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            int row = 0;
            dataGridView1.Rows.Add();
            row = dataGridView1.Rows.Count - 2;
            decimal Total = 0;
            for (int i = 0; i <= dataGridView1.Rows.Count - 2; i++)
            {
                dataGridView1["MobileNo", row].Value = textBoxMobileNo.Text;
                dataGridView1["Amount", row].Value = textBoxMobileAmount.Text;
                dataGridView1["Bank", row].Value = comboBoxServiceName.Text;
                dataGridView1["Note", row].Value = richTextBoxNote.Text;
                Total += Convert.ToDecimal(dataGridView1["Amount", row].Value);
                textBoxTotalAmount.Text = Total.ToString();
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            ProjectConnection Newconnection = new ProjectConnection();
            Newconnection.Connection_Today();
            for (int i = 0; i <= dataGridView1.Rows.Count - 2; i++)
            {

                SqlCommand comm = new SqlCommand();
                comm.Connection = ProjectConnection.conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = (@"[Sales].[Tempory_Save_Mobile_Data]");
                comm.Parameters.AddWithValue("@ID", labelDocID.Text);
                comm.Parameters.AddWithValue("@Mobile_No", Convert.ToString(dataGridView1.Rows[i].Cells[0].Value));
                comm.Parameters.AddWithValue("@Amount", Convert.ToDecimal(dataGridView1.Rows[i].Cells[1].Value));
                comm.Parameters.AddWithValue("@Bank", Convert.ToString(dataGridView1.Rows[i].Cells[2].Value));
                comm.Parameters.AddWithValue("@Note", Convert.ToString(dataGridView1.Rows[i].Cells[3].Value));
                comm.ExecuteNonQuery();
            }
        }
        public void SaveMobile()
        {
            ProjectConnection Newconnection = new ProjectConnection();
            Newconnection.Connection_Today();
            for (int i = 0; i <= dataGridView1.Rows.Count - 2; i++)
            {

                SqlCommand comm = new SqlCommand();
                comm.Connection = ProjectConnection.conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = (@"[Sales].[Tempory_Save_Mobile_Data]");
                comm.Parameters.AddWithValue("@ID", labelDocID.Text);
                comm.Parameters.AddWithValue("@Mobile_No", Convert.ToString(dataGridView1.Rows[i].Cells[0].Value));
                comm.Parameters.AddWithValue("@Amount", Convert.ToDecimal(dataGridView1.Rows[i].Cells[1].Value));
                comm.Parameters.AddWithValue("@Bank", Convert.ToString(dataGridView1.Rows[i].Cells[2].Value));
                comm.Parameters.AddWithValue("@Note", Convert.ToString(dataGridView1.Rows[i].Cells[3].Value));
                comm.ExecuteNonQuery();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
