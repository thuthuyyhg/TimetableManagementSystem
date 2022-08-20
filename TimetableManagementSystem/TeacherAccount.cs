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
    public partial class TeacherAccount : Form
    {
        public TeacherAccount()
        {
            InitializeComponent();
        }

        private void TeacherAccount_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            HomepageTeacher obj = new HomepageTeacher();
            obj.Show();
            this.Close();
        }

        private void btnAcc_Click(object sender, EventArgs e)
        {
            TeacherLoginAccount obj = new TeacherLoginAccount();
            obj.Show();
            this.Close();
        }

        private void btnUsrInf_Click(object sender, EventArgs e)
        {
            TeacherUserInformation obj = new TeacherUserInformation();
            obj.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Close();
        }
    }
}
