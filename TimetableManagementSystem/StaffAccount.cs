﻿using System;
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
    public partial class StaffAccount : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public StaffAccount()
        {
            InitializeComponent();
            con = new SqlConnection("server=DESKTOP-RUN1CAB\\SQLEXPRESS01;Initial Catalog=ASM2_TimetableMng;Integrated Security=SSPI;MultipleActiveResultSets=true"); 
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            HomepageStaff obj = new HomepageStaff();
            obj.Show();
            this.Close();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (txtNPwd.Text == txtRNPwd.Text)
            {
                try
                {
                    string user = txtUsr.Text;
                    string pass = txtOPwd.Text;
                    cmd = new SqlCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM LoginCredentials where username='" + txtUsr.Text + "' AND password='" + txtOPwd.Text + "'";
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {                      
                        try
                        {                            
                            // create sql command to execute query
                            SqlCommand cmd2 = con.CreateCommand();
                            // setting the name for the stored procedure command
                            cmd2.CommandText = "Pass_Change";
                            cmd2.CommandType = CommandType.StoredProcedure;
                            // add parameter to the command
                            cmd2.Parameters.Add("@User", SqlDbType.NVarChar).Value = txtUsr.Text;
                            cmd2.Parameters.Add("@OldPass", SqlDbType.NVarChar).Value = txtOPwd.Text;
                            cmd2.Parameters.Add("@NewPass", SqlDbType.NVarChar).Value = txtNPwd.Text;
                            // execute the query
                            cmd2.ExecuteNonQuery();
                            MessageBox.Show("Password changed!", "Success");                            
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(ex.Message, "Insert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        txtUsr.Text = String.Empty;
                        txtOPwd.Text = String.Empty;
                        txtNPwd.Text = String.Empty;
                        txtRNPwd.Text = String.Empty;
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or current password!","Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);// dislay error
                }
            } 
            else
            {
                MessageBox.Show("Please re-enter the same password!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsr.Text = String.Empty;
            txtOPwd.Text = String.Empty;
            txtNPwd.Text = String.Empty;
            txtRNPwd.Text = String.Empty;
        }
    }
}
