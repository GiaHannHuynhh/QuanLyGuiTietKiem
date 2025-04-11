namespace QuanLyGuiTietKiem
{
    partial class SavingsAccountForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtAccountID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.dgvSavingsAccounts = new System.Windows.Forms.DataGridView();
            this.btnCalculateInterest = new System.Windows.Forms.Button();
            this.btnRequestOpen = new System.Windows.Forms.Button();
            this.btnRequestClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSavingsAccounts)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(145)))), ((int)(((byte)(136)))));
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(960, 34);
            this.panel1.TabIndex = 1;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(145)))), ((int)(((byte)(136)))));
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button4.Location = new System.Drawing.Point(867, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(30, 30);
            this.button4.TabIndex = 11;
            this.button4.Text = "-";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(145)))), ((int)(((byte)(136)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button3.Location = new System.Drawing.Point(897, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(30, 30);
            this.button3.TabIndex = 11;
            this.button3.Text = "O";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(145)))), ((int)(((byte)(136)))));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnExit.Location = new System.Drawing.Point(927, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(30, 30);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(145)))), ((int)(((byte)(136)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "BACK";
            this.button1.UseCompatibleTextRendering = true;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(272, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(407, 34);
            this.label1.TabIndex = 2;
            this.label1.Text = " TÀI KHOẢN GỬI TIẾT KIỆM";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(48)))), ((int)(((byte)(64)))));
            this.panel2.Controls.Add(this.dgvSavingsAccounts);
            this.panel2.Location = new System.Drawing.Point(29, 129);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(499, 477);
            this.panel2.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(48)))), ((int)(((byte)(64)))));
            this.panel3.Controls.Add(this.btnRequestClose);
            this.panel3.Controls.Add(this.btnRequestOpen);
            this.panel3.Controls.Add(this.btnCalculateInterest);
            this.panel3.Controls.Add(this.btnViewDetails);
            this.panel3.Location = new System.Drawing.Point(563, 242);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(364, 248);
            this.panel3.TabIndex = 4;
            // 
            // txtAccountID
            // 
            this.txtAccountID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountID.Location = new System.Drawing.Point(563, 159);
            this.txtAccountID.Name = "txtAccountID";
            this.txtAccountID.Size = new System.Drawing.Size(364, 27);
            this.txtAccountID.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(560, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nhập mã sổ tiết kiệm:";
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
            // 
            // dgvSavingsAccounts
            // 
            this.dgvSavingsAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSavingsAccounts.Location = new System.Drawing.Point(3, 3);
            this.dgvSavingsAccounts.Name = "dgvSavingsAccounts";
            this.dgvSavingsAccounts.RowHeadersWidth = 51;
            this.dgvSavingsAccounts.RowTemplate.Height = 24;
            this.dgvSavingsAccounts.Size = new System.Drawing.Size(493, 471);
            this.dgvSavingsAccounts.TabIndex = 0;
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
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(559, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Chức năng:";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblMessage.Location = new System.Drawing.Point(643, 547);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(197, 20);
            this.lblMessage.TabIndex = 8;
            this.lblMessage.Text = "Vui lòng chọn chức năng!";
            // 
            // SavingsAccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(960, 720);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAccountID);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SavingsAccountForm";
            this.Text = "SavingsAccountForm";
            this.Load += new System.EventHandler(this.SavingsAccountForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSavingsAccounts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvSavingsAccounts;
        private System.Windows.Forms.Button btnViewDetails;
        private System.Windows.Forms.TextBox txtAccountID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRequestClose;
        private System.Windows.Forms.Button btnRequestOpen;
        private System.Windows.Forms.Button btnCalculateInterest;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblMessage;
    }
}