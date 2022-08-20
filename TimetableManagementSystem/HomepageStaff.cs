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
    public partial class HomepageStaff : Form
    {
        public HomepageStaff()
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
            StaffAccount obj = new StaffAccount();
            obj.Show();
            this.Close();
        }

        private void btnMngTtb_Click(object sender, EventArgs e)
        {
            StaffTimetable obj = new StaffTimetable();
            obj.Show();
            this.Close();
        }

        
    }
}
