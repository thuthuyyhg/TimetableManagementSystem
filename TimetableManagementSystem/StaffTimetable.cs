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
    public partial class StaffTimetable : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;
        DataTable dt;
        

        public StaffTimetable()
        {
            InitializeComponent();
            con = new SqlConnection("server=DESKTOP-RUN1CAB\\SQLEXPRESS01;Initial Catalog=ASM2_TimetableMng;Integrated Security=SSPI;MultipleActiveResultSets=true"); 
            con.Open();
        }

        private void connectsql()
        {
            
            string sql = "select * from course";
            SqlCommand com = new SqlCommand(sql, con);
            com.CommandType = CommandType.Text;
            /*Display DGW Timetable*/
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            dt.Clear();
            da.Fill(dt);                    
            DGWStaff.DataSource = dt;

            /*Display ComboBox TeacherID*/
            SqlCommand cmd = new SqlCommand ("Select * from Teacher", con);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da2.Fill(ds);
            cmd.ExecuteNonQuery();
            con.Close();
            cbbTeacher.DataSource = ds.Tables[0];
            cbbTeacher.DisplayMember = "username";
            cbbTeacher.ValueMember = "username";
                        
        }

        private void StaffTimetable_Load(object sender, EventArgs e)
        {
            connectsql();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            HomepageStaff obj = new HomepageStaff();
            obj.Show();
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "insert into Course values(@CourseID,@CourseName,@TeacherID,@Subject,@Slot,@Day,@Room)";
                cmd.Parameters.Add("@CourseID", SqlDbType.VarChar, 10).Value = txtCourseID.Text;
                cmd.Parameters.Add("@CourseName", SqlDbType.NVarChar, 50).Value = txtCourseName.Text;
                cmd.Parameters.Add("@TeacherID", SqlDbType.VarChar, 50).Value = cbbTeacher.Text;
                cmd.Parameters.Add("@Subject", SqlDbType.NVarChar, 50).Value = txtSubject.Text;
                cmd.Parameters.Add("@Slot", SqlDbType.Int).Value = cbbSlot.SelectedItem;
                cmd.Parameters.Add("@Day", SqlDbType.VarChar, 10).Value = cbbDay.SelectedItem;
                cmd.Parameters.Add("@Room", SqlDbType.VarChar, 10).Value = cbbRoom.Text;
                cmd.ExecuteNonQuery();
                if(cbbTeacher.Text != "adminbtecst")
                {
                    SqlCommand cmd2 = con.CreateCommand();
                    cmd2.CommandText = "insert into TimetableTeacher values (@CourseID,@TeacherID,@attend)";
                    cmd2.Parameters.Add("@CourseID", SqlDbType.VarChar, 10).Value = txtCourseID.Text;
                    cmd2.Parameters.Add("@TeacherID", SqlDbType.VarChar, 50).Value = cbbTeacher.Text;
                    cmd2.Parameters.Add("@attend", SqlDbType.Bit).Value = 1;
                    cmd2.ExecuteNonQuery();
                }                
                MessageBox.Show("Add new course successful!", "Notification");
                connectsql();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Insert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }
        
        private void btnEdit_Click(object sender, EventArgs e)
        {
            con.Open();            
            try
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UpdateCourseInfo";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CourseID", SqlDbType.VarChar, 50).Value = txtCourseID.Text;
                cmd.Parameters.Add("@CourseName", SqlDbType.NVarChar, 50).Value = txtCourseName.Text;
                cmd.Parameters.Add("@TeacherID", SqlDbType.VarChar, 50).Value = cbbTeacher.Text;
                cmd.Parameters.Add("@Subject", SqlDbType.NVarChar, 50).Value = txtSubject.Text;
                cmd.Parameters.Add("@Slot", SqlDbType.Int).Value = cbbSlot.SelectedItem;
                cmd.Parameters.Add("@Day", SqlDbType.VarChar, 10).Value = cbbDay.SelectedItem;
                cmd.Parameters.Add("@Room", SqlDbType.VarChar, 10).Value = cbbRoom.Text;
                cmd.ExecuteNonQuery();
                if (cbbTeacher.Text != "adminbtecst")
                {
                    SqlCommand cmd2 = con.CreateCommand();
                    cmd2.CommandText = "EditCourseTTC";
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.Add("@CourseID", SqlDbType.VarChar, 10).Value = txtCourseID.Text;
                    cmd2.Parameters.Add("@TeacherID", SqlDbType.VarChar, 50).Value = cbbTeacher.Text;                    
                    cmd2.ExecuteNonQuery();
                }
                else
                {
                    SqlCommand cmd3 = con.CreateCommand();
                    cmd3.CommandText = "delete from TimetableTeacher where CourseID = @CourseID and TeacherID = @TeacherID";
                    cmd3.Parameters.Add("@CourseID", SqlDbType.VarChar, 10).Value = txtCourseID.Text;
                    cmd3.Parameters.Add("@TeacherID", SqlDbType.VarChar, 50).Value = cbbTeacher.Text;
                    cmd3.ExecuteNonQuery();
                }
                MessageBox.Show("Course Updated!", "Success");
                connectsql();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Insert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
            txtCourseID.Text = String.Empty;
            txtCourseName.Text = String.Empty;
            cbbTeacher.ResetText();
            txtSubject.Text = String.Empty;
            cbbSlot.ResetText();
            cbbDay.ResetText();
            cbbRoom.Text = String.Empty;

        }

        private void DGWStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGWStaff.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                DGWStaff.CurrentRow.Selected = true;
                txtCourseID.Text = DGWStaff.Rows[e.RowIndex].Cells["CourseID"].FormattedValue.ToString();
                txtCourseName.Text = DGWStaff.Rows[e.RowIndex].Cells["CourseName"].FormattedValue.ToString();
                cbbTeacher.Text = DGWStaff.Rows[e.RowIndex].Cells["TeacherID"].FormattedValue.ToString();
                txtSubject.Text = DGWStaff.Rows[e.RowIndex].Cells["Subject"].FormattedValue.ToString();
                cbbSlot.Text = DGWStaff.Rows[e.RowIndex].Cells["Slot"].FormattedValue.ToString();
                cbbDay.Text = DGWStaff.Rows[e.RowIndex].Cells["Day"].FormattedValue.ToString();
                cbbRoom.Text = DGWStaff.Rows[e.RowIndex].Cells["Room"].FormattedValue.ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you wanna delete this course?", "Delete Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) 
                == DialogResult.Yes)
            {
                con.Open();
                //create command
                SqlCommand cmd = con.CreateCommand();
                //create command query
                cmd.CommandText = "delete from Course where CourseID=@CourseID";                
                cmd.Parameters.Add("@CourseID", SqlDbType.VarChar, 5).Value = txtCourseID.Text;
                //Check if delete successfully
                if (cmd.ExecuteNonQuery() != 1)
                    MessageBox.Show("There is no course with the given ID", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Successfully Delete", "Delete", MessageBoxButtons.OK);
                    connectsql();
                }
                
            }
            else
            {
                //clear form
                txtCourseID.Text = "";
                txtCourseName.Text = "";
                cbbTeacher.ResetText();
                txtSubject.Text = "";
                cbbSlot.ResetText();
                cbbDay.ResetText();
                cbbRoom.Text = "";
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
    }
}
