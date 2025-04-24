namespace QuanLyGuiTietKiem
{
    partial class ucSavingAccount
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblMessage = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnRequestClose = new System.Windows.Forms.Button();
            this.btnRequestOpen = new System.Windows.Forms.Button();
            this.btnCalculateInterest = new System.Windows.Forms.Button();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbAccounts = new System.Windows.Forms.ComboBox();
            this.pnDisplay = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            this.pnDisplay.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblMessage.Location = new System.Drawing.Point(99, 215);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(400, 20);
            this.lblMessage.TabIndex = 15;
            this.lblMessage.Text = "Vui lòng chọn chức năng!";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(678, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Nhập mã sổ tiết kiệm:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(48)))), ((int)(((byte)(64)))));
            this.panel3.Controls.Add(this.btnRequestClose);
            this.panel3.Controls.Add(this.btnRequestOpen);
            this.panel3.Controls.Add(this.btnCalculateInterest);
            this.panel3.Controls.Add(this.btnViewDetails);
            this.panel3.Location = new System.Drawing.Point(681, 226);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(364, 248);
            this.panel3.TabIndex = 11;
            // 
            // btnRequestClose
            // 
            this.btnRequestClose.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRequestClose.FlatAppearance.BorderSize = 0;
            this.btnRequestClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRequestClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRequestClose.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnRequestClose.Location = new System.Drawing.Point(0, 183);
            this.btnRequestClose.Name = "btnRequestClose";
            this.btnRequestClose.Size = new System.Drawing.Size(364, 61);
            this.btnRequestClose.TabIndex = 3;
            this.btnRequestClose.Text = "Tất toán";
            this.btnRequestClose.UseVisualStyleBackColor = true;
            this.btnRequestClose.Click += new System.EventHandler(this.btnRequestClose_Click);
            // 
            // btnRequestOpen
            // 
            this.btnRequestOpen.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRequestOpen.FlatAppearance.BorderSize = 0;
            this.btnRequestOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRequestOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRequestOpen.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnRequestOpen.Location = new System.Drawing.Point(0, 122);
            this.btnRequestOpen.Name = "btnRequestOpen";
            this.btnRequestOpen.Size = new System.Drawing.Size(364, 61);
            this.btnRequestOpen.TabIndex = 2;
            this.btnRequestOpen.Text = "Mở sổ";
            this.btnRequestOpen.UseVisualStyleBackColor = true;
            this.btnRequestOpen.Click += new System.EventHandler(this.btnRequestOpen_Click);
            // 
            // btnCalculateInterest
            // 
            this.btnCalculateInterest.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCalculateInterest.FlatAppearance.BorderSize = 0;
            this.btnCalculateInterest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalculateInterest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalculateInterest.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnCalculateInterest.Location = new System.Drawing.Point(0, 61);
            this.btnCalculateInterest.Name = "btnCalculateInterest";
            this.btnCalculateInterest.Size = new System.Drawing.Size(364, 61);
            this.btnCalculateInterest.TabIndex = 1;
            this.btnCalculateInterest.Text = "Tính lãi";
            this.btnCalculateInterest.UseVisualStyleBackColor = true;
            this.btnCalculateInterest.Click += new System.EventHandler(this.btnCalculateInterest_Click);
            // 
            // btnViewDetails
            // 
            this.btnViewDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnViewDetails.FlatAppearance.BorderSize = 0;
            this.btnViewDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewDetails.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnViewDetails.Location = new System.Drawing.Point(0, 0);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(364, 61);
            this.btnViewDetails.TabIndex = 0;
            this.btnViewDetails.Text = "Chi tiết";
            this.btnViewDetails.UseVisualStyleBackColor = true;
            this.btnViewDetails.Click += new System.EventHandler(this.btnViewDetails_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(334, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(407, 34);
            this.label1.TabIndex = 9;
            this.label1.Text = " TÀI KHOẢN GỬI TIẾT KIỆM";
            // 
            // groupBox1
            // 
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Location = new System.Drawing.Point(675, 204);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(380, 279);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chức năng";
            // 
            // cmbAccounts
            // 
            this.cmbAccounts.FormattingEnabled = true;
            this.cmbAccounts.Location = new System.Drawing.Point(682, 149);
            this.cmbAccounts.Name = "cmbAccounts";
            this.cmbAccounts.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbAccounts.Size = new System.Drawing.Size(364, 24);
            this.cmbAccounts.TabIndex = 17;
            this.cmbAccounts.SelectedIndexChanged += new System.EventHandler(this.cmbAccounts_SelectedIndexChanged);
            // 
            // pnDisplay
            // 
            this.pnDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(48)))), ((int)(((byte)(64)))));
            this.pnDisplay.Controls.Add(this.lblMessage);
            this.pnDisplay.Location = new System.Drawing.Point(18, 113);
            this.pnDisplay.Name = "pnDisplay";
            this.pnDisplay.Size = new System.Drawing.Size(640, 490);
            this.pnDisplay.TabIndex = 10;
            // 
            // ucSavingAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.Controls.Add(this.cmbAccounts);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pnDisplay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "ucSavingAccount";
            this.Size = new System.Drawing.Size(1080, 640);
            this.Load += new System.EventHandler(this.ucSavingAccount_Load);
            this.panel3.ResumeLayout(false);
            this.pnDisplay.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnRequestClose;
        private System.Windows.Forms.Button btnRequestOpen;
        private System.Windows.Forms.Button btnCalculateInterest;
        private System.Windows.Forms.Button btnViewDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbAccounts;
        private System.Windows.Forms.Panel pnDisplay;
    }
}
