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
    public partial class TeacherCourse : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;
        DataTable dt;

        public TeacherCourse()
        {
            InitializeComponent();
            con = new SqlConnection("server=DESKTOP-RUN1CAB\\SQLEXPRESS01;Initial Catalog=ASM2_TimetableMng;Integrated Security=SSPI;MultipleActiveResultSets=true");
        }

        private void connectsql()
        {
            string sql = "select CourseID, CourseName, TeacherID, Subject, Slot, Day, Room from Course";
            SqlCommand com = new SqlCommand(sql, con);
            com.CommandType = CommandType.Text;
            /*Display DGW Timetable*/
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DGWStaff.DataSource = dt;
        }

        private void TeacherCourse_Load(object sender, EventArgs e)
        {
            connectsql();
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "insert into TimetableTeacher values(@CourseID,@TeacherID, @attend)";
                cmd.Parameters.Add("@CourseID", SqlDbType.VarChar, 10).Value = txtCourseID.Text;
                cmd.Parameters.Add("@TeacherID", SqlDbType.NVarChar, 50).Value = txtTeacherID.Text;
                cmd.Parameters.Add("@attend", SqlDbType.Bit).Value = chkAttend.Checked;
                cmd.ExecuteNonQuery();
                SqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandText = "UpdateTimeTeacher_W";
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.Add("@CourseID", SqlDbType.VarChar, 10).Value = txtCourseID.Text;
                cmd2.Parameters.Add("@TeacherID", SqlDbType.NVarChar, 50).Value = txtTeacherID.Text;
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Join course successful!", "Notification");
                connectsql(); ;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Insert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Do you wanna withdraw from this course?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                con.Open();
                //create command
                SqlCommand cmd = con.CreateCommand();
                SqlCommand cmd2 = con.CreateCommand();
                //create command query
                //Delete record in Timetable Teacher
                cmd.CommandText = "delete from TimetableTeacher where CourseID='" + txtCourseID.Text + "' AND TeacherID='" + 
                    txtTeacherID.Text + "'";
                //Change TeacherID in Course to adminbtecst
                cmd2.CommandText = "UpdateTimeTeacher";
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.Add("@TeacherID", SqlDbType.VarChar, 50).Value = "adminbtecst";
                cmd2.Parameters.Add("@CourseID", SqlDbType.VarChar, 10).Value = txtCourseID.Text;
                
                //Check if delete successfully

                if (cmd.ExecuteNonQuery() != 1)
                    MessageBox.Show("You have not registered for this course!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Successfully Withdraw", "Notification", MessageBoxButtons.OK);
                    connectsql();
                }
                con.Close();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            da = new SqlDataAdapter("select * from Course where CourseName like'" + txtSearch.Text + "%'", con);
            dt = new DataTable();
            da.Fill(dt);
            DGWStaff.DataSource = dt;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TeacherTimetable obj = new TeacherTimetable();
            obj.Show();
            this.Close();
        }
    }
}
