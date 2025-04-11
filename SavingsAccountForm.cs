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
    public partial class SavingsAccountForm : Form
    {
        public SavingsAccountForm()
        {
            InitializeComponent();
        }

        private void SavingsAccountForm_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng form hiện tại
        }

       
    }
}
