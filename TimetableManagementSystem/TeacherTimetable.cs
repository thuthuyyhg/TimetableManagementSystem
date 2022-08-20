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
    public partial class TeacherTimetable : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;
        DataTable dt;

        public TeacherTimetable()
        {
            InitializeComponent();
            con = new SqlConnection("server=DESKTOP-RUN1CAB\\SQLEXPRESS01;Initial Catalog=ASM2_TimetableMng;Integrated Security=SSPI;MultipleActiveResultSets=true");

        }
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            HomepageTeacher obj = new HomepageTeacher();
            obj.Show();
            this.Close();
        }

        private void TeacherTimetable_Load(object sender, EventArgs e)
        {

        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                string teacherID = txtTeacherID.Text;
                cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM TimetableTeacher where TeacherID='" + txtTeacherID.Text + "'";
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    SqlCommand cmd = new SqlCommand("Select CourseID from TimetableTeacher where TeacherID='" + txtTeacherID.Text + "'", con);
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
                    MessageBox.Show("Incorrect TeacherID", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            Connectsql();
        }

        private void btnCourse_Click(object sender, EventArgs e)
        {
            TeacherCourse obj = new TeacherCourse();
            obj.Show();
            this.Hide();
        }
    }
}
