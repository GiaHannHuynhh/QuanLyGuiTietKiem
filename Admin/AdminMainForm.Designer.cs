namespace QuanLyGuiTietKiem
{
    partial class AdminMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.uSERSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.approveDeleteUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageStaffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uSERSToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1364, 42);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // uSERSToolStripMenuItem
            // 
            this.uSERSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.approveDeleteUsersToolStripMenuItem,
            this.manageStaffToolStripMenuItem});
            this.uSERSToolStripMenuItem.Name = "uSERSToolStripMenuItem";
            this.uSERSToolStripMenuItem.Size = new System.Drawing.Size(102, 38);
            this.uSERSToolStripMenuItem.Text = "USERS";
            // 
            // approveDeleteUsersToolStripMenuItem
            // 
            this.approveDeleteUsersToolStripMenuItem.BackColor = System.Drawing.SystemColors.Info;
            this.approveDeleteUsersToolStripMenuItem.Name = "approveDeleteUsersToolStripMenuItem";
            this.approveDeleteUsersToolStripMenuItem.Size = new System.Drawing.Size(380, 44);
            this.approveDeleteUsersToolStripMenuItem.Text = "Approve/Delete Users";
            this.approveDeleteUsersToolStripMenuItem.Click += new System.EventHandler(this.approveDeleteUsersToolStripMenuItem_Click);
            // 
            // manageStaffToolStripMenuItem
            // 
            this.manageStaffToolStripMenuItem.Name = "manageStaffToolStripMenuItem";
            this.manageStaffToolStripMenuItem.Size = new System.Drawing.Size(380, 44);
            this.manageStaffToolStripMenuItem.Text = "Manage Staff";
            this.manageStaffToolStripMenuItem.Click += new System.EventHandler(this.manageStaffToolStripMenuItem_Click);
            // 
            // AdminMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1364, 671);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AdminMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminMainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem uSERSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem approveDeleteUsersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageStaffToolStripMenuItem;
    }
}