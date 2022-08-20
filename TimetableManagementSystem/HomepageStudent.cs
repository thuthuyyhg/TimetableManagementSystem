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
    public partial class HomepageStudent : Form
    {
        public HomepageStudent()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Close();
        }

        private void btnMngAcc_Click(object sender, EventArgs e)
        {
            StudentAccount obj = new StudentAccount();
            obj.Show();
            this.Close();
        }

        private void btnMngTtb_Click(object sender, EventArgs e)
        {
            StudentTimetable obj = new StudentTimetable();
            obj.Show();
            this.Close();
        }
    }
}
