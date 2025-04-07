namespace QuanLyGuiTietKiem
{
    partial class AccountApprovalForm
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
            this.dgvPendingAccounts = new System.Windows.Forms.DataGridView();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendingAccounts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPendingAccounts
            // 
            this.dgvPendingAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPendingAccounts.Location = new System.Drawing.Point(199, 206);
            this.dgvPendingAccounts.Name = "dgvPendingAccounts";
            this.dgvPendingAccounts.RowHeadersWidth = 51;
            this.dgvPendingAccounts.RowTemplate.Height = 24;
            this.dgvPendingAccounts.Size = new System.Drawing.Size(501, 190);
            this.dgvPendingAccounts.TabIndex = 0;
            // 
            // btnApprove
            // 
            this.btnApprove.Location = new System.Drawing.Point(199, 95);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(142, 33);
            this.btnApprove.TabIndex = 1;
            this.btnApprove.Text = "Phê duyệt tài khoản";
            this.btnApprove.UseVisualStyleBackColor = true;
            // 
            // btnReject
            // 
            this.btnReject.Location = new System.Drawing.Point(365, 95);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(137, 33);
            this.btnReject.TabIndex = 2;
            this.btnReject.Text = "Từ chối tài khoản";
            this.btnReject.UseVisualStyleBackColor = true;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(196, 152);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(46, 16);
            this.lblMessage.TabIndex = 3;
            this.lblMessage.Text = "Chi tiết";
            // 
            // AccountApprovalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.dgvPendingAccounts);
            this.Name = "AccountApprovalForm";
            this.Text = "AccountApprovalForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendingAccounts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPendingAccounts;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Label lblMessage;
    }
}