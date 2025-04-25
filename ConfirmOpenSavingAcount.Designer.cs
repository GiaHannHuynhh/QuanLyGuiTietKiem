namespace QuanLyGuiTietKiem
{
    partial class ConfirmOpenSavingAcount
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
            this.dgvOpenRequests = new System.Windows.Forms.DataGridView();
            this.dgvSavingsAccounts = new System.Windows.Forms.DataGridView();
            this.cmbBranch = new System.Windows.Forms.ComboBox();
            this.btnConfirmOpen = new System.Windows.Forms.Button();
            this.btnRejectOpen = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOpenRequests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSavingsAccounts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOpenRequests
            // 
            this.dgvOpenRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOpenRequests.Location = new System.Drawing.Point(439, 90);
            this.dgvOpenRequests.Name = "dgvOpenRequests";
            this.dgvOpenRequests.RowHeadersWidth = 51;
            this.dgvOpenRequests.RowTemplate.Height = 24;
            this.dgvOpenRequests.Size = new System.Drawing.Size(613, 224);
            this.dgvOpenRequests.TabIndex = 0;
            // 
            // dgvSavingsAccounts
            // 
            this.dgvSavingsAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSavingsAccounts.Location = new System.Drawing.Point(439, 414);
            this.dgvSavingsAccounts.Name = "dgvSavingsAccounts";
            this.dgvSavingsAccounts.RowHeadersWidth = 51;
            this.dgvSavingsAccounts.RowTemplate.Height = 24;
            this.dgvSavingsAccounts.Size = new System.Drawing.Size(613, 250);
            this.dgvSavingsAccounts.TabIndex = 1;
            this.dgvSavingsAccounts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // cmbBranch
            // 
            this.cmbBranch.FormattingEnabled = true;
            this.cmbBranch.Location = new System.Drawing.Point(179, 94);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.Size = new System.Drawing.Size(145, 24);
            this.cmbBranch.TabIndex = 2;
            // 
            // btnConfirmOpen
            // 
            this.btnConfirmOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmOpen.Location = new System.Drawing.Point(15, 198);
            this.btnConfirmOpen.Name = "btnConfirmOpen";
            this.btnConfirmOpen.Size = new System.Drawing.Size(145, 47);
            this.btnConfirmOpen.TabIndex = 3;
            this.btnConfirmOpen.Text = "Xác nhận mở sổ";
            this.btnConfirmOpen.UseVisualStyleBackColor = true;
            this.btnConfirmOpen.Click += new System.EventHandler(this.btnConfirmOpen_Click);
            // 
            // btnRejectOpen
            // 
            this.btnRejectOpen.Location = new System.Drawing.Point(179, 198);
            this.btnRejectOpen.Name = "btnRejectOpen";
            this.btnRejectOpen.Size = new System.Drawing.Size(145, 47);
            this.btnRejectOpen.TabIndex = 4;
            this.btnRejectOpen.Text = "Từ Chối Yêu Cầu";
            this.btnRejectOpen.UseVisualStyleBackColor = true;
            this.btnRejectOpen.Click += new System.EventHandler(this.btnRejectOpen_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblMessage.Location = new System.Drawing.Point(21, 141);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(76, 16);
            this.lblMessage.TabIndex = 5;
            this.lblMessage.Text = "Thông báo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(24, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Chọn Chi Nhánh:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Rockstone", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(595, 368);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(327, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "DANH SÁCH KHÁCH HÀNG ĐÃ MỞ SỔ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Rockstone", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(595, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(336, 24);
            this.label4.TabIndex = 8;
            this.label4.Text = "DANH SÁCH KHÁCH HÀNG CHỜ DUYỆT";
            // 
            // ConfirmOpenSavingAcount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(1064, 697);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnRejectOpen);
            this.Controls.Add(this.btnConfirmOpen);
            this.Controls.Add(this.cmbBranch);
            this.Controls.Add(this.dgvSavingsAccounts);
            this.Controls.Add(this.dgvOpenRequests);
            this.Name = "ConfirmOpenSavingAcount";
            this.Text = "ConfirmOpenSavingAcount";
            this.Load += new System.EventHandler(this.ConfirmOpenSavingAcount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOpenRequests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSavingsAccounts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOpenRequests;
        private System.Windows.Forms.DataGridView dgvSavingsAccounts;
        private System.Windows.Forms.ComboBox cmbBranch;
        private System.Windows.Forms.Button btnConfirmOpen;
        private System.Windows.Forms.Button btnRejectOpen;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}