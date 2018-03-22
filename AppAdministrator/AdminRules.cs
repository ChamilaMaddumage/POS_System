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
    public partial class AdminRules:Form
    {
        public int SaveType = 0;

        public AdminRules()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender,EventArgs e)
        {
            ProjectConnection Newconnection = new ProjectConnection();
            Newconnection.Connection_Today();
            SqlCommand comm = new SqlCommand();
            comm.Connection = ProjectConnection.conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "dbo.Update_Permission  ";
            comm.Parameters.AddWithValue("@Setting_Name",labelSettingName.Text);
            if(checkBoxSetting.Checked == true)
            {
                comm.Parameters.AddWithValue("@Value","ACTIVE");
            }
            else
            {
                comm.Parameters.AddWithValue("@Value","DEACTIVE");
            }

            comm.ExecuteNonQuery();
            Form1.LoadPermission();
            LoadSettings();
            MessageBox.Show("Successfully");
        }

        private void AdminRules_Load(object sender,EventArgs e)
        {
            LoadSettings();
            Clear();
        }

        private void dataGridView1_CellClick(object sender,DataGridViewCellEventArgs e)
        {
            try
            {
                if(e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                    labelSettingName.Text = row.Cells[0].Value.ToString();
                    if(row.Cells[1].Value.ToString() == "ACTIVE")
                    {
                        checkBoxSetting.Checked = true;
                    }
                    else
                    {
                        checkBoxSetting.Checked = false;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void LoadSettings()
        {
            ProjectConnection Newconnection = new ProjectConnection();
            Newconnection.Connection_Today();
            SqlCommand comm = new SqlCommand();
            comm.Connection = ProjectConnection.conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "dbo.Load_Permission";
            comm.Parameters.AddWithValue("@Search_Condition",textBoxSearch.Text);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        public void Clear()
        {
            checkBoxSetting.Checked = false;
            labelSettingName.Text = "Sellect Setting";
        }

        private void textBoxSearch_KeyUp(object sender,KeyEventArgs e)
        {
            LoadSettings();
        }

        private void buttonCreate_Click(object sender,EventArgs e)
        {
            SaveType = 1;
            SaveDelete();
        }
        public void SaveDelete()
        {
            try
            {

                ProjectConnection Newconnection = new ProjectConnection();
                Newconnection.Connection_Today();
                SqlCommand comm = new SqlCommand();
                comm.Connection = ProjectConnection.conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "dbo.Create_User";
                comm.Parameters.AddWithValue("@Save_type",SaveType);
                comm.Parameters.AddWithValue("@Name",textBoxUserFullName.Text);
                comm.Parameters.AddWithValue("@Nic",textBoxNic.Text);
                comm.Parameters.AddWithValue("@User_name",textBoxUserName.Text);
                comm.Parameters.AddWithValue("@Password",textBoxConformPassword.Text);
                comm.Parameters.AddWithValue("@Type",comboBox1.Text);

                comm.ExecuteNonQuery();
                if(SaveType == 1)
                {
                    MessageBox.Show("User Created");
                }
                else if(SaveType == 2)
                {
                    MessageBox.Show("User Deleted");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonDelete_Click(object sender,EventArgs e)
        {
            SaveType = 2;
            SaveDelete();
        }

        private void buttonBackup_Click(object sender,EventArgs e)
        {
            ProjectConnection Newconnection = new ProjectConnection();
            Newconnection.Connection_Today();
            SqlCommand comm = new SqlCommand();
            comm.Connection = ProjectConnection.conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "dbo.Backup_Database";
            comm.ExecuteNonQuery();
            MessageBox.Show("Back up Done successfully","SQLDB Backup",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
