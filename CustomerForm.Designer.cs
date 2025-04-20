namespace QuanLyGuiTietKiem
{
    partial class CustomerForm
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
            System.Windows.Forms.Button btnTransaction;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerForm));
            System.Windows.Forms.Button btnPersonalInfomation;
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSavingAccount = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.pnDisplay = new System.Windows.Forms.Panel();
            btnTransaction = new System.Windows.Forms.Button();
            btnPersonalInfomation = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTransaction
            // 
            btnTransaction.FlatAppearance.BorderSize = 0;
            btnTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnTransaction.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnTransaction.Image = ((System.Drawing.Image)(resources.GetObject("btnTransaction.Image")));
            btnTransaction.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnTransaction.Location = new System.Drawing.Point(0, 333);
            btnTransaction.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            btnTransaction.Name = "btnTransaction";
            btnTransaction.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            btnTransaction.Size = new System.Drawing.Size(200, 80);
            btnTransaction.TabIndex = 2;
            btnTransaction.Text = "GIAO DỊCH";
            btnTransaction.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            btnTransaction.UseVisualStyleBackColor = true;
            btnTransaction.Click += new System.EventHandler(this.btnTransaction_Click);
            // 
            // btnPersonalInfomation
            // 
            btnPersonalInfomation.FlatAppearance.BorderSize = 0;
            btnPersonalInfomation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnPersonalInfomation.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnPersonalInfomation.Image = ((System.Drawing.Image)(resources.GetObject("btnPersonalInfomation.Image")));
            btnPersonalInfomation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnPersonalInfomation.Location = new System.Drawing.Point(0, 181);
            btnPersonalInfomation.Name = "btnPersonalInfomation";
            btnPersonalInfomation.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            btnPersonalInfomation.Size = new System.Drawing.Size(200, 80);
            btnPersonalInfomation.TabIndex = 0;
            btnPersonalInfomation.Text = "CÁ NHÂN";
            btnPersonalInfomation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnPersonalInfomation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            btnPersonalInfomation.UseVisualStyleBackColor = true;
            btnPersonalInfomation.Click += new System.EventHandler(this.btnPersonalInfomation_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(btnTransaction);
            this.panel1.Controls.Add(this.btnSavingAccount);
            this.panel1.Controls.Add(btnPersonalInfomation);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 720);
            this.panel1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(174, 125);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // btnSavingAccount
            // 
            this.btnSavingAccount.FlatAppearance.BorderSize = 0;
            this.btnSavingAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSavingAccount.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSavingAccount.Image = ((System.Drawing.Image)(resources.GetObject("btnSavingAccount.Image")));
            this.btnSavingAccount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSavingAccount.Location = new System.Drawing.Point(0, 257);
            this.btnSavingAccount.Name = "btnSavingAccount";
            this.btnSavingAccount.Size = new System.Drawing.Size(200, 80);
            this.btnSavingAccount.TabIndex = 1;
            this.btnSavingAccount.Text = "TÀI KHOẢN";
            this.btnSavingAccount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSavingAccount.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSavingAccount.UseVisualStyleBackColor = true;
            this.btnSavingAccount.Click += new System.EventHandler(this.btnSavingAccount_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(48)))), ((int)(((byte)(64)))));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnExit.Location = new System.Drawing.Point(1047, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(30, 30);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(48)))), ((int)(((byte)(64)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button3.Location = new System.Drawing.Point(1017, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(30, 30);
            this.button3.TabIndex = 11;
            this.button3.Text = "O";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(48)))), ((int)(((byte)(64)))));
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnMinimize.Location = new System.Drawing.Point(987, 2);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(30, 30);
            this.btnMinimize.TabIndex = 11;
            this.btnMinimize.Text = "-";
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(48)))), ((int)(((byte)(64)))));
            this.panelHeader.Controls.Add(this.btnExit);
            this.panelHeader.Controls.Add(this.btnMinimize);
            this.panelHeader.Controls.Add(this.button3);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(200, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1080, 34);
            this.panelHeader.TabIndex = 1;
            this.panelHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelHeader_MouseDown);
            // 
            // pnDisplay
            // 
            this.pnDisplay.Location = new System.Drawing.Point(206, 40);
            this.pnDisplay.Name = "pnDisplay";
            this.pnDisplay.Size = new System.Drawing.Size(1071, 668);
            this.pnDisplay.TabIndex = 3;
            this.pnDisplay.Paint += new System.Windows.Forms.PaintEventHandler(this.pnDisplay_Paint);
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.pnDisplay);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CustomerForm";
            this.Text = "CustomerForm";
            this.Load += new System.EventHandler(this.CustomerForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Button btnSavingAccount;
        private System.Windows.Forms.Panel pnDisplay;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}