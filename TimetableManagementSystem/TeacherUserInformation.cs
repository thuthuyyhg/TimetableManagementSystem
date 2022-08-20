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
    public partial class TeacherUserInformation : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        
        public TeacherUserInformation()
        {
            InitializeComponent();
            con = new SqlConnection("server=DESKTOP-RUN1CAB\\SQLEXPRESS01;Initial Catalog=ASM2_TimetableMng;Integrated Security=SSPI;MultipleActiveResultSets=true"); 
        }
        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            TeacherAccount obj = new TeacherAccount();
            obj.Show();
            this.Close();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            try
            {
               
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM LoginCredentials where username='" + txtUsr.Text + "' AND password='" + txtPwd.Text + "'";
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    // create sql command to execute
                    SqlCommand cmd2 = con.CreateCommand();
                    // create insert command
                    cmd2.CommandText = "UpdateInfoTeacher";
                    cmd2.CommandType = CommandType.StoredProcedure;
                    // add parameters to insert command
                    cmd2.Parameters.Add("@username", SqlDbType.VarChar, 50).Value = txtUsr.Text;
                    cmd2.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = txtFirstName.Text;
                    cmd2.Parameters.Add("@LastName", SqlDbType.NVarChar, 50).Value = txtLastName.Text;
                    cmd2.Parameters.Add("@Dob", SqlDbType.Date).Value = DTPBirthday.Value;
                    cmd2.Parameters.Add("@Phone", SqlDbType.Int).Value = Int32.Parse(txtPhone.Text);
                    cmd2.Parameters.Add("@Address", SqlDbType.NVarChar, 100).Value = txtAddress.Text;
                    cmd2.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = txtEmail.Text;
                    // execute the query
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Update successfully!", "Success");
                }
                else
                {
                    MessageBox.Show("Please check username and password");
                }
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Insert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            txtUsr.Text = String.Empty;
            txtFirstName.Text = String.Empty;
            txtLastName.Text = String.Empty;
            txtPhone.Text = String.Empty;
            txtAddress.Text = String.Empty;
            txtEmail.Text = String.Empty;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsr.Text = String.Empty;
            txtFirstName.Text = String.Empty;
            txtLastName.Text = String.Empty;
            txtPhone.Text = String.Empty;
            txtAddress.Text = String.Empty;
            txtEmail.Text = String.Empty;
        }
    }
}
