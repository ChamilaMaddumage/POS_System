using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Services.Stock
{
    public partial class Items:Form
    {
        public Items()
        {
            InitializeComponent();

            //Save Update btn Enable Disable
            //START
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            //END
        }

        private void btnSave_Click(object sender,EventArgs e)
        {
            try
            {
                if(textBoxItemName.Text == "")
                {
                    MessageBox.Show("Please Enter Name");
                }
                else
                {
                    if(textBoxItemSerial.Text == "")
                    {
                        textBoxItemSerial.Text = "N/A";
                    }

                    if(textBoxCost.Text == "")
                    {
                        textBoxCost.Text = (0.00).ToString();
                    }
                    if(textBoxSellingPrice.Text == "")
                    {
                        textBoxSellingPrice.Text = (0.00).ToString();
                    }
                    if(textBoxNote.Text == "")
                    {
                        textBoxNote.Text = "N/A";
                    }

                    ProjectConnection Newconnection = new ProjectConnection();
                    Newconnection.Connection_Today();
                    SqlCommand comm = new SqlCommand();
                    comm.Connection = ProjectConnection.conn;
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.CommandText = "[stock].[Add_Item]";
                    comm.Parameters.AddWithValue("@ItemName",textBoxItemName.Text);
                    comm.Parameters.AddWithValue("@Serial",textBoxItemSerial.Text);
                    comm.Parameters.AddWithValue("@Cost",decimal.Parse(textBoxCost.Text));
                    comm.Parameters.AddWithValue("@Selling_Price",decimal.Parse(textBoxSellingPrice.Text));
                    comm.Parameters.AddWithValue("@Note",textBoxNote.Text);
                    comm.Parameters.AddWithValue("@Date",Convert.ToDateTime(dateTimePicker1.Text));
                    comm.Parameters.AddWithValue("@ReOrderLevel",int.Parse(textBoxReOrderLevel.Text));
                    comm.ExecuteNonQuery();
                    LoadItemCode();
                    grid();
                    TotalStockCost();
                    Clear();
                }


            }
            catch(Exception ex)
            {
                LoadItemCode();
                MessageBox.Show(ex.Message);
            }
        }
        public void LoadItemCode()
        {
            ProjectConnection Newconnection = new ProjectConnection();
            Newconnection.Connection_Today();
            SqlCommand comm = new SqlCommand();
            comm.Connection = ProjectConnection.conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "[Stock].[Load_Item_Code]";
            SqlDataReader dr;
            dr = comm.ExecuteReader();
            if(dr.HasRows == true)
            {
                dr.Read();
                textBoxItemCode.Text = dr["Doc_No"].ToString();
                dr.Close();
            }
        }

        private void Items_Load(object sender,EventArgs e)
        {
            textBoxItemName.Focus();
            if(Permission.BarcodePrintAccess == "DEACTIVE")
            {
                groupBoxBarcode.Enabled = false;
            }
            if(Permission.ItemSave == "DEACTIVE")
            {
                btnSave.Enabled = false;
            }
            if(Permission.ItemUpdate == "DEACTIVE")
            {
                btnUpdate.Enabled = false;
            }
            if(Permission.ItemDelete == "DEACTIVE")
            {
                btnDelete.Enabled = false;
            }
            LoadItemCode();
            grid();
            TotalStockCost();
        }
        public void ItemBalances()
        {
            //ProjectConnection Newconnection = new ProjectConnection();
            //Newconnection.Connection_Today();
            //SqlCommand comm = new SqlCommand();
            //comm.Connection = ProjectConnection.conn;
            //comm.CommandType = CommandType.StoredProcedure;
            //comm.CommandText = "grn.Item_Stock_Balance";
            //comm.Parameters.AddWithValue("@Item_Code", textBoxItemCode.Text);
            //SqlDataReader dr;
            //dr = comm.ExecuteReader();
            //if (dr.HasRows == true)
            //{
            //    dr.Read();
            //    textBoxAvailableStock.Text = dr["Balance"].ToString();
            //    dr.Close();
            //}
        }
        public void TotalStockCost()
        {
            //ProjectConnection Newconnection = new ProjectConnection();
            //Newconnection.Connection_Today();
            //SqlCommand comm = new SqlCommand();
            //comm.Connection = ProjectConnection.conn;
            //comm.CommandType = CommandType.StoredProcedure;
            //comm.CommandText = "GRN.Total_Stock";
            //SqlDataReader dr;
            //dr = comm.ExecuteReader();
            //if (dr.HasRows == true)
            //{
            //    dr.Read();
            //    labelTotalStockCost.Text ="Total Stock Cost : Rs."+ dr["Amount"].ToString();
            //    dr.Close();
            //}
        }

        private void pictureBox1_Click(object sender,EventArgs e)
        {
            LoadItemCode();
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
                comm.CommandText = "Stock.Search_Items";
                comm.Parameters.AddWithValue("@Search_Condition",textBoxSearch.Text);
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[7].DefaultCellStyle.BackColor = Color.Gold;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            DataGridViewColumn column1 = dataGridView1.Columns[1];
            column1.Width = 260;
            DataGridViewColumn column5 = dataGridView1.Columns[5];
            column5.Width = 130;
            DataGridViewColumn column8 = dataGridView1.Columns[8];
            column8.Width = 100;

        }

        private void textBoxSearch_KeyPress(object sender,KeyPressEventArgs e)
        {
            dataGridView1.Columns[7].DefaultCellStyle.BackColor = Color.Gold;
            grid();
        }

        private void dataGridView1_CellClick(object sender,DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBoxItemCode.Text = row.Cells[0].Value.ToString();
                //Barcode Input Fill Values Goes Here
                textBoxItemCodeBarcode.Text = row.Cells[0].Value.ToString();
                textBoxItemName.Text = row.Cells[1].Value.ToString();
                textBoxCost.Text = row.Cells[2].Value.ToString();
                textBoxItemSerial.Text = row.Cells[3].Value.ToString();
                textBoxSellingPrice.Text = row.Cells[4].Value.ToString();
                textBoxSellingPriceBarcode.Text = row.Cells[4].Value.ToString();
                textBoxNote.Text = row.Cells[5].Value.ToString();
                dateTimePicker1.Text = row.Cells[6].Value.ToString();
                textBoxAvailableStock.Text = row.Cells[7].Value.ToString();
                textBoxReOrderLevel.Text = row.Cells[8].Value.ToString();
                //textBoxCurrentStock.Text = row.Cells[8].Value.ToString();

                //Save Update btn Enable Disable
                //START
                btnSave.Enabled = false;
                btnUpdate.Enabled = true;
                //END
            }
            ItemBalances();
        }

        private void btnUpdate_Click(object sender,EventArgs e)
        {
            try
            {
                if(textBoxItemName.Text == "")
                {
                    MessageBox.Show("Please Enter Name");
                }
                else
                {
                    if(textBoxItemSerial.Text == "")
                    {
                        textBoxItemSerial.Text = "N/A";
                    }

                    if(textBoxCost.Text == "")
                    {
                        textBoxCost.Text = (0.00).ToString();
                    }
                    if(textBoxSellingPrice.Text == "")
                    {
                        textBoxSellingPrice.Text = (0.00).ToString();
                    }
                    if(textBoxNote.Text == "")
                    {
                        textBoxNote.Text = "N/A";
                    }

                    ProjectConnection Newconnection = new ProjectConnection();
                    Newconnection.Connection_Today();
                    SqlCommand comm = new SqlCommand();
                    comm.Connection = ProjectConnection.conn;
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.CommandText = "Stock.Update_Items";
                    comm.Parameters.AddWithValue("@Doc_No",textBoxItemCode.Text);
                    comm.Parameters.AddWithValue("@ItemName",textBoxItemName.Text);
                    comm.Parameters.AddWithValue("@Serial",textBoxItemSerial.Text);
                    comm.Parameters.AddWithValue("@Cost",decimal.Parse(textBoxCost.Text));
                    comm.Parameters.AddWithValue("@Selling_Price",decimal.Parse(textBoxSellingPrice.Text));
                    comm.Parameters.AddWithValue("@Note",textBoxNote.Text);
                    comm.Parameters.AddWithValue("@Date",Convert.ToDateTime(dateTimePicker1.Text));
                    comm.Parameters.AddWithValue("@ReOrderLevel",int.Parse(textBoxReOrderLevel.Text));
                    comm.ExecuteNonQuery();
                    LoadItemCode();
                    grid();
                    TotalStockCost();
                    Clear();
                }


            }
            catch(Exception ex)
            {
                LoadItemCode();
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender,EventArgs e)
        {
            try
            {
                ProjectConnection Newconnection = new ProjectConnection();
                Newconnection.Connection_Today();
                SqlCommand comm = new SqlCommand();
                comm.Connection = ProjectConnection.conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "Stock.Delete_Items";
                comm.Parameters.AddWithValue("@Doc_No",textBoxItemCode.Text);
                comm.ExecuteNonQuery();
                LoadItemCode();
                grid();
                TotalStockCost();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease Enter Valid Item Code");
            }
        }

        private void pictureBox2_Click(object sender,EventArgs e)
        {
            this.Close();
        }

        private void panel4_Paint(object sender,PaintEventArgs e)
        {

        }

        private void buttonClear_Click(object sender,EventArgs e)
        {
            Clear();
            TotalStockCost();
        }
        public void Clear()
        {
            textBoxSearch.Clear();
            textBoxAvailableStock.Clear();
            textBoxCost.Clear();
            //textBoxItemName.Clear();
            textBoxItemSerial.Clear();
            textBoxCost.Clear();
            textBoxSellingPrice.Clear();
            textBoxNote.Clear();
            textBoxSellingPriceBarcode.Clear();
            textBoxItemCodeBarcode.Clear();
            textBoxQuentityBarcode.Clear();
            textBoxReOrderLevel.Clear();
            textBoxItemName.Clear();
            textBoxSearch.Clear();
            LoadItemCode();
            grid();

            //Save Update btn Enable Disable
            //START
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            //END
        }

        private void buttonPrintBarCode_Click(object sender,EventArgs e)
        {
            if(textBoxItemCodeBarcode.Text == "" || textBoxSellingPriceBarcode.Text == "" || textBoxQuentityBarcode.Text == "")
            {
                MessageBox.Show("Please Fill Empty Fileds");
            }
            else
            {
                Globlevariable.ItemDocNo = textBoxItemCodeBarcode.Text;
                Globlevariable.ItemPrice = textBoxSellingPriceBarcode.Text;
                Globlevariable.ItemPrintQty = Convert.ToInt32(textBoxQuentityBarcode.Text);
                Barcode bar = new Barcode();
                bar.Show();
            }
        }

        private void label13_Click(object sender,EventArgs e)
        {

        }
    }
}
