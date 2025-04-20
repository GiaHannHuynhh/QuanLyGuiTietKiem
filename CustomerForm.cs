using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyGuiTietKiem
{
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng form hiện tại
        }

        // Khai báo để di chuyển form
        // Import các hàm từ user32.dll
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        // Các hằng số dùng để kéo form
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            panelHeader.MouseDown += panelHeader_MouseDown;
            
        }

        private void panelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0xA1, 0x2, 0);
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        ucPersonalInformation ucPi = new ucPersonalInformation();
        ucSavingAccount ucSa = new ucSavingAccount();
        ucTransaction ucTransaction = new ucTransaction();
        private void AddUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            pnDisplay.Controls.Clear();
            pnDisplay.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void pnDisplay_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPersonalInfomation_Click(object sender, EventArgs e)
        {
            AddUserControl(ucPi);
        }

        private void btnSavingAccount_Click(object sender, EventArgs e)
        {
            AddUserControl(ucSa);
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            AddUserControl(ucTransaction);
        }
    }
    
}
