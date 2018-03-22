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
    public partial class GetItemCodes:Form
    {
        public string ItemCode
        {
            get
            {
                return textBoxItemCode02.Text;
            }
            set
            {
                textBoxItemCode02.Text = value;
            }
        }
        public string ItemName
        {
            get
            {
                return textBoxItemName02.Text;
            }
            set
            {
                textBoxItemName02.Text = value;
            }
        }
        public string ItemCost
        {
            get
            {
                return textBoxItemCost02.Text;
            }
            set
            {
                textBoxItemCost02.Text = value;
            }
        }
        public string CostForGRN
        {
            get
            {
                return textCost.Text;
            }
            set
            {
                textCost.Text = value;
            }
        }

        public GetItemCodes()
        {
            InitializeComponent();
        }

        private void GetItemCodes_Load(object sender,EventArgs e)
        {
            SearchItemCodes();
            textBoxSearchCondition.Focus();

        }

        private void buttonSearch_Click(object sender,EventArgs e)
        {
            SearchItemCodes();
        }

        private void textBoxSearchCondition_KeyDown(object sender,KeyEventArgs e)
        {
            SearchItemCodes();
        }

        private void pictureBox1_Click(object sender,EventArgs e)
        {
            this.Close();
        }
        public void SearchItemCodes()
        {
            try
            {
                ProjectConnection Newconnection = new ProjectConnection();
                Newconnection.Connection_Today();
                SqlCommand comm = new SqlCommand();
                comm.Connection = ProjectConnection.conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "Stock.Search_Items";
                comm.Parameters.AddWithValue("@Search_Condition",textBoxSearchCondition.Text);
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender,DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBoxItemCode02.Text = row.Cells[0].Value.ToString();
                textBoxItemName02.Text = row.Cells[1].Value.ToString();
                textBoxItemCost02.Text = row.Cells[4].Value.ToString();
                textCost.Text = row.Cells[2].Value.ToString();
                //textBoxDiscount03.Text = row.Cells[3].Value.ToString();
            }
        }

        private void dataGridView1_CellEnter(object sender,DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBoxItemCode02.Text = row.Cells[0].Value.ToString();
                textBoxItemName02.Text = row.Cells[1].Value.ToString();
                textBoxItemCost02.Text = row.Cells[4].Value.ToString();
                textCost.Text = row.Cells[2].Value.ToString();
                //textBoxDiscount03.Text = row.Cells[3].Value.ToString();
            }
        }


    }
}
