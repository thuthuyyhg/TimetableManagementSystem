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
    public partial class StudentTimetable : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;
        DataTable dt;

        private void Connectsql()
        {

            string sql = "select * from course where CourseID='" + cbbCourse.Text + "'";
            SqlCommand com = new SqlCommand(sql, con);
            com.CommandType = CommandType.Text;
            /*Display DGW Timetable*/
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DGWStaff.DataSource = dt;
        }

        public StudentTimetable()
        {
            InitializeComponent();
            con = new SqlConnection("server=DESKTOP-RUN1CAB\\SQLEXPRESS01;Initial Catalog=ASM2_TimetableMng;Integrated Security=SSPI;MultipleActiveResultSets=true");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            HomepageStudent obj = new HomepageStudent();
            obj.Show();
            this.Close();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                string studentID = txtStudentID.Text;
                cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM TimetableStudent where StudentID='" + txtStudentID.Text + "'";
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    SqlCommand cmd = new SqlCommand("Select CourseID from TimetableStudent where StudentID='" + txtStudentID.Text + 
                        "'", con);
                    SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da2.Fill(ds);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    cbbCourse.DataSource = ds.Tables[0];
                    cbbCourse.DisplayMember = "CourseID";
                    cbbCourse.ValueMember = "CourseID";

                }
                else 
                {
                    MessageBox.Show("Incorrect StudentID", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            StudentCourse obj = new StudentCourse();
            obj.Show();
            this.Hide();
        }

        private void cbbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
           Connectsql();
        }
    }
}
