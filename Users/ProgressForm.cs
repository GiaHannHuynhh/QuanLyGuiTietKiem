using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace QuanLyGuiTietKiem
{
    public partial class ProgressForm: Form
    {
        public ProgressForm()
        {
            InitializeComponent();
            progressBarLoading.Style = ProgressBarStyle.Marquee;
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public static void ShowProgress(Form parent, Action action)
        {
            using (var progress = new ProgressForm())
            {
                progress.Show(parent);
                Application.DoEvents(); // Đảm bảo form hiển thị ngay lập tức
                action.Invoke();
                progress.Close();
            }
        }
    }
}
