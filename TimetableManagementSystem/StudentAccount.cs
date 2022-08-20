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
    public partial class StudentAccount : Form
    {
        public StudentAccount()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            HomepageStudent obj = new HomepageStudent();
            obj.Show();
            this.Close();
        }

        private void btnAcc_Click(object sender, EventArgs e)
        {
            StudentLoginAccount obj = new StudentLoginAccount();
            obj.Show();
            this.Close();
        }

        private void btnUsrInf_Click(object sender, EventArgs e)
        {
            StudentUserInformation obj = new StudentUserInformation();
            obj.Show();
            this.Close();
        }
    }
}
