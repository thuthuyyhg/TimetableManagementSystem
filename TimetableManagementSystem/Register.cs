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
    public partial class Register : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public Register()
        {
            InitializeComponent();
            con = new SqlConnection("server=DESKTOP-RUN1CAB\\SQLEXPRESS01;Initial Catalog=ASM2_TimetableMng;Integrated Security=SSPI;MultipleActiveResultSets=true");
            con.Open();
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            string stdconstraint = "bh";
            string tcconstraint = "tc";
            string staffconstraint = "btecst";
            if(cbbRole.SelectedItem!=null)
            {
                if (cbbRole.SelectedItem == "Student")
                {
                    if (txtPwd.Text == txtRpwd.Text)
                    {
                        if (txtUser.Text.Contains(stdconstraint))
                        {
                            try
                            {
                                SqlCommand cmd = con.CreateCommand();
                                cmd.CommandText = "insert into Student values(@username,@FirstName,@LastName,@DoB,@Address,@Email,@Phone)";
                                cmd.Parameters.Add("@username", SqlDbType.VarChar, 50).Value = txtUser.Text;
                                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = txtFirstName.Text;
                                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 50).Value = txtLastName.Text;
                                cmd.Parameters.Add("@Dob", SqlDbType.Date).Value = dtpDoB.Value;
                                cmd.Parameters.Add("@Phone", SqlDbType.Int).Value = Int32.Parse(txtPhone.Text);
                                cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 100).Value = txtAddress.Text;
                                cmd.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = txtEmail.Text;
                                SqlCommand cmd2 = con.CreateCommand();
                                cmd2.CommandText = "insert into LoginCredentials values(@username,@password,@role)";
                                cmd2.Parameters.Add("@username", SqlDbType.VarChar, 50).Value = txtUser.Text;
                                cmd2.Parameters.Add("@password", SqlDbType.VarChar, 50).Value = txtPwd.Text;
                                cmd2.Parameters.Add("@role", SqlDbType.VarChar, 10).Value = cbbRole.SelectedItem;
                                cmd.ExecuteNonQuery();
                                cmd2.ExecuteNonQuery();
                                MessageBox.Show("Successful Register!", "Notification");
                            }
                            catch (SqlException ex)
                            {
                                MessageBox.Show(ex.Message, "Insert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            txtUser.Text = String.Empty;
                            txtPwd.Text = String.Empty;
                            txtRpwd.Text = String.Empty;
                            txtFirstName.Text = String.Empty;
                            txtLastName.Text = String.Empty;
                            txtPhone.Text = String.Empty;
                            txtAddress.Text = String.Empty;
                            txtEmail.Text = String.Empty;                            
                            cbbRole.ResetText();
                        }
                        else
                        {
                            MessageBox.Show("Please insert your username with code you have been provided", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    else
                    {
                        MessageBox.Show("Password and Re-enter Password are not the same", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                if (cbbRole.SelectedItem == "Teacher")
                {
                    if (txtPwd.Text == txtRpwd.Text)
                    {
                        if (txtUser.Text.Contains(tcconstraint))
                        {
                            try
                            {
                                SqlCommand cmd = con.CreateCommand();
                                cmd.CommandText = "insert into Teacher values(@username,@FirstName,@LastName,@DoB,@Address,@Email,@Phone)";
                                cmd.Parameters.Add("@username", SqlDbType.VarChar, 50).Value = txtUser.Text;
                                cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = txtFirstName.Text;
                                cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = txtLastName.Text;
                                cmd.Parameters.Add("@Dob", SqlDbType.DateTime).Value = dtpDoB.Value;
                                cmd.Parameters.Add("@Phone", SqlDbType.Int).Value = Int32.Parse(txtPhone.Text);
                                cmd.Parameters.Add("@Address", SqlDbType.VarChar, 100).Value = txtAddress.Text;
                                cmd.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = txtEmail.Text;
                                SqlCommand cmd2 = con.CreateCommand();
                                cmd2.CommandText = "insert into LoginCredentials values(@username,@password,@role)";
                                cmd2.Parameters.Add("@username", SqlDbType.VarChar, 50).Value = txtUser.Text;
                                cmd2.Parameters.Add("@password", SqlDbType.VarChar, 50).Value = txtPwd.Text;
                                cmd2.Parameters.Add("@role", SqlDbType.VarChar, 10).Value = cbbRole.SelectedItem;
                                cmd.ExecuteNonQuery();
                                cmd2.ExecuteNonQuery();
                                MessageBox.Show("Successful Register!", "Notification");
                            }
                            catch (SqlException ex)
                            {
                                MessageBox.Show(ex.Message, "Insert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            txtUser.Text = String.Empty;
                            txtPwd.Text = String.Empty;
                            txtRpwd.Text = String.Empty;
                            txtFirstName.Text = String.Empty;
                            txtLastName.Text = String.Empty;
                            txtPhone.Text = String.Empty;
                            txtAddress.Text = String.Empty;
                            txtEmail.Text = String.Empty;
                            cbbRole.ResetText();
                        }
                        else
                        {
                            MessageBox.Show("Please insert your username with code you have been provided", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    else
                    {
                        MessageBox.Show("Password and Re-enter Password are not the same", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                if (cbbRole.SelectedItem == "Staff")
                {
                    if (txtPwd.Text == txtRpwd.Text)
                    {
                        if (txtUser.Text.Contains(staffconstraint))
                        {
                            try
                            {
                                SqlCommand cmd = con.CreateCommand();
                                cmd.CommandText = "insert into Staff values(@username,@FirstName,@LastName,@DoB,@Address,@Email,@Phone)";
                                cmd.Parameters.Add("@username", SqlDbType.VarChar, 50).Value = txtUser.Text;
                                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = txtFirstName.Text;
                                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 50).Value = txtLastName.Text;
                                cmd.Parameters.Add("@Dob", SqlDbType.Date).Value = dtpDoB.Value;
                                cmd.Parameters.Add("@Phone", SqlDbType.Int).Value = Int32.Parse(txtPhone.Text);
                                cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 100).Value = txtAddress.Text;
                                cmd.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = txtEmail.Text;
                                SqlCommand cmd2 = con.CreateCommand();
                                cmd2.CommandText = "insert into LoginCredentials values(@username,@password,@role)";
                                cmd2.Parameters.Add("@username", SqlDbType.VarChar, 50).Value = txtUser.Text;
                                cmd2.Parameters.Add("@password", SqlDbType.VarChar, 50).Value = txtPwd.Text;
                                cmd2.Parameters.Add("@role", SqlDbType.VarChar, 10).Value = cbbRole.SelectedItem;
                                cmd.ExecuteNonQuery();
                                cmd2.ExecuteNonQuery();
                                MessageBox.Show("Successful Register!", "Notification");
                            }
                            catch (SqlException ex)
                            {
                                MessageBox.Show(ex.Message, "Insert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            txtUser.Text = String.Empty;
                            txtPwd.Text = String.Empty;
                            txtRpwd.Text = String.Empty;
                            txtFirstName.Text = String.Empty;
                            txtLastName.Text = String.Empty;
                            txtPhone.Text = String.Empty;
                            txtAddress.Text = String.Empty;
                            txtEmail.Text = String.Empty;
                            cbbRole.ResetText();
                        }
                        else
                        {
                            MessageBox.Show("Please insert your username with code you have been provided", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    else
                    {
                        MessageBox.Show("Password and Re-enter Password do not match!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
                 
            else 
            {
                MessageBox.Show("Please choose a role!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }           

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUser.Text = String.Empty;
            txtPwd.Text = String.Empty;
            txtRpwd.Text = String.Empty;
            txtFirstName.Text = String.Empty;
            txtLastName.Text = String.Empty;
            txtPhone.Text = String.Empty;
            txtAddress.Text = String.Empty;
            txtEmail.Text = String.Empty;
            cbbRole.ResetText();
        }
    }
}
