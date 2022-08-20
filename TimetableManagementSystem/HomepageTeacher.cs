using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimetableManagementSystem
{
    public partial class HomepageTeacher : Form
    {
        public HomepageTeacher()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void btnMngAcc_Click(object sender, EventArgs e)
        {
            TeacherAccount obj = new TeacherAccount();
            obj.Show();
            this.Hide(); 
        }

        private void btnMngTtb_Click(object sender, EventArgs e)
        {
            TeacherTimetable obj = new TeacherTimetable();
            obj.Show();
            this.Close();
        }
    }
}
