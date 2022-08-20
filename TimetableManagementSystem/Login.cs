using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TimetableManagementSystem
{
    public partial class Login : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public Login()
        {
            InitializeComponent();
            con = new SqlConnection("server=DESKTOP-RUN1CAB\\SQLEXPRESS01;Initial Catalog=ASM2_TimetableMng;Integrated Security=SSPI;MultipleActiveResultSets=true");
            
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            Register obj = new Register();
            obj.Show();
            this.Hide();                
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string user = txtUsr.Text;
                string pass = txtPwd.Text;
                cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM LoginCredentials where username='" + txtUsr.Text + "' AND password='" + txtPwd.Text + "'";
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (cbbRole.Text == "Staff")
                    {
                        SqlCommand cmdStu = con.CreateCommand();
                        cmdStu.CommandText = "SELECT * FROM Staff where username='" + txtUsr.Text + "'";
                        SqlDataReader drStu = cmdStu.ExecuteReader();
                        if (drStu.Read())
                        {
                            MessageBox.Show("Login sucess Welcome ");
                            HomepageStaff obj = new HomepageStaff();
                            obj.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Please choose your correct role", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    else if (cbbRole.Text == "Teacher")
                    {
                        SqlCommand cmdStu = con.CreateCommand();
                        cmdStu.CommandText = "SELECT * FROM Teacher where username='" + txtUsr.Text + "'";
                        SqlDataReader drStu = cmdStu.ExecuteReader();
                        if (drStu.Read())
                        {
                            MessageBox.Show("Login success Welcome ");
                            HomepageTeacher obj = new HomepageTeacher();
                            obj.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Please choose your correct role", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    else if (cbbRole.Text == "Student")
                    {
                        SqlCommand cmdStu = con.CreateCommand();
                        cmdStu.CommandText = "SELECT * FROM Student where username='" + txtUsr.Text +"'";
                        SqlDataReader drStu = cmdStu.ExecuteReader();
                        if (drStu.Read())
                        {
                            MessageBox.Show("Login success Welcome ");
                            HomepageStudent obj = new HomepageStudent();
                            obj.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Please choose your correct role", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        
                    }

                    else
                    {
                        MessageBox.Show("Please choose your role!");
                    }

                }
                else
                {
                    MessageBox.Show("Invalid Login please check username and password");
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);// hien thi thong bao loi neu co
            }

            
        }
    }
}
