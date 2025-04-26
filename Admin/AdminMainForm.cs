using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyGuiTietKiem
{
    public partial class AdminMainForm: Form
    {
        public AdminMainForm()
        {
            InitializeComponent();
        }

        private void approveDeleteUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AccountApprovalForm().ShowDialog();
        }

        private void manageStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new  ManageStaffForm().ShowDialog();
        }
    }
}
