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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void buttonlogin_Click(object sender, EventArgs e)
        {

            Loginfrm();
        }
        public void Loginfrm()
        {
            if(comboBoxUserType.Text == "Standard User")
            {
                ProjectConnection Newconnection = new ProjectConnection();
                Newconnection.Connection_Today();
                SqlCommand comm = new SqlCommand("Select * from [dbo].[User_Details] where User_name=@username and Password=@password and Status=0 and User_Type = 'Standard User' ",ProjectConnection.conn);
                comm.Connection = ProjectConnection.conn;
                comm.CommandType = CommandType.Text;
                comm.Parameters.AddWithValue("@username",textBox1.Text);
                comm.Parameters.AddWithValue("@password",textBox2.Text);
                UserName();
                SqlDataAdapter adapt = new SqlDataAdapter(comm);
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                ProjectConnection.conn.Close();
                int count = ds.Tables[0].Rows.Count;
                if(count == 1)
                {
                    Form1 frm1 = new Form1();
                    frm1.Show();
                    this.Hide();
                }
                else
                {
                    label3.Text = "Login Failed!";
                    pictureBox1.Visible = true;
                    textBox1.Clear();
                    textBox2.Clear();
                }
            }
            else if(comboBoxUserType.Text == "Administrator")
            {
                ProjectConnection Newconnection = new ProjectConnection();
                Newconnection.Connection_Today();
                SqlCommand comm = new SqlCommand("Select * from [dbo].[User_Details] where User_name=@username and Password=@password and Status=0 and User_Type = 'Administrator' ",ProjectConnection.conn);
                comm.Connection = ProjectConnection.conn;
                comm.CommandType = CommandType.Text;
                comm.Parameters.AddWithValue("@username",textBox1.Text);
                comm.Parameters.AddWithValue("@password",textBox2.Text);
                UserName();
                SqlDataAdapter adapt = new SqlDataAdapter(comm);
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                ProjectConnection.conn.Close();
                int count = ds.Tables[0].Rows.Count;
                
                if(count == 1)
                {
                    Form1 frm1 = new Form1();
                    frm1.Show();
                    this.Hide();
                }
                else
                {
                    label3.Text = "Login Failed!";
                    pictureBox1.Visible = true;
                    textBox1.Clear();
                    textBox2.Clear();
                }
            }
            
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void UserName()
        {
            ProjectConnection Newconnection = new ProjectConnection();
            Newconnection.Connection_Today();
            SqlCommand comm = new SqlCommand();
            comm.Connection = ProjectConnection.conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "Select User_Name,User_Type from [dbo].[User_Details] where User_name=@username and Password=@password and Status=0";
            comm.Parameters.AddWithValue("@username", textBox1.Text);
            comm.Parameters.AddWithValue("@password", textBox2.Text);
            SqlDataReader dr;
            dr = comm.ExecuteReader();
            if (dr.HasRows == true)
            {
                dr.Read();
                Globlevariable.UserName = dr["User_Name"].ToString();
                Globlevariable.UserType = dr["User_Type"].ToString();
                dr.Close();
            }
            pictureBox1.Visible = false;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            //label3.Text = "Please enter user name and password";
            pictureBox1.Visible = false;
        }

        private void buttonlogin_KeyUp(object sender,KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Loginfrm();
                e.Handled = true;
            }
        }

        private void textBox1_KeyUp(object sender,KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Loginfrm();
                e.Handled = true;
            }
        }

        private void textBox2_KeyUp(object sender,KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Loginfrm();
                e.Handled = true;
            }
        }
    }
}
