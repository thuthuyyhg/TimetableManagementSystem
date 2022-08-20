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

    public partial class StudentCourse : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;
        DataTable dt;

        public StudentCourse()
        {
            InitializeComponent();
            con = new SqlConnection("server=DESKTOP-RUN1CAB\\SQLEXPRESS01;Initial Catalog=ASM2_TimetableMng;Integrated Security=SSPI;MultipleActiveResultSets=true");

        }

        private void connectsql()
        {

            string sql = "select * from Course";
            SqlCommand com = new SqlCommand(sql, con);
            com.CommandType = CommandType.Text;
            /*Display DGW Timetable*/
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DGWStaff.DataSource = dt;
        }

        private void StudentCourse_Load(object sender, EventArgs e)
        {
            connectsql();
        }

        
        private void btnJoin_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "insert into TimetableStudent values(@CourseID,@StudentID, @attend)";
                cmd.Parameters.Add("@CourseID", SqlDbType.VarChar, 10).Value = txtCourseID.Text;
                cmd.Parameters.Add("@StudentID", SqlDbType.NVarChar, 50).Value = txtStudentID.Text;
                cmd.Parameters.Add("@attend", SqlDbType.Bit).Value = chkAttend.Checked;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Join course successful!", "Notification");
                DGWStaff.Refresh();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Insert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you wanna withdraw from this course?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                con.Open();
                //create command
                SqlCommand cmd = con.CreateCommand();
                //create command query
                cmd.CommandText = "delete from TimetableStudent where CourseID='" + txtCourseID.Text + "' AND StudentID='" + txtStudentID.Text + "'";
                //cmd.Parameters.Add("@CourseID", SqlDbType.VarChar, 5).Value = txtCourseID.Text;
                //cmd.Parameters.Add("@StudentID", SqlDbType.VarChar, 5).Value = txtStudentID.Text;
                //Check if delete successfully
                if (cmd.ExecuteNonQuery() != 1)
                    MessageBox.Show("You have not registered for this course!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Successfully Withdraw", "Notification", MessageBoxButtons.OK);
                    DGWStaff.Refresh();
                }
                con.Close();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            da = new SqlDataAdapter("select * from Course where CourseName like %'" + txtSearch.Text + "%'", con);
            dt = new DataTable();
            da.Fill(dt);
            DGWStaff.DataSource = dt;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StudentTimetable obj = new StudentTimetable();
            obj.Show();
            this.Close();
        }

       
    }
}
