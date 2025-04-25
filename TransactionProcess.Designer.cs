namespace QuanLyGuiTietKiem
{
    partial class TransactionProcess
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
            this.btnCreateTransaction = new System.Windows.Forms.Button();
            this.dgvTransactions = new System.Windows.Forms.DataGridView();
            this.lblAccountID = new System.Windows.Forms.Label();
            this.lblTransactionType = new System.Windows.Forms.Label();
            this.txtAccountID = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.cmbTransactionType = new System.Windows.Forms.ComboBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreateTransaction
            // 
            this.btnCreateTransaction.BackColor = System.Drawing.Color.White;
            this.btnCreateTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateTransaction.Location = new System.Drawing.Point(437, 55);
            this.btnCreateTransaction.Name = "btnCreateTransaction";
            this.btnCreateTransaction.Size = new System.Drawing.Size(151, 44);
            this.btnCreateTransaction.TabIndex = 0;
            this.btnCreateTransaction.Text = "Tạo giao dịch";
            this.btnCreateTransaction.UseVisualStyleBackColor = false;
            this.btnCreateTransaction.Click += new System.EventHandler(this.btnCreateTransaction_Click);
            // 
            // dgvTransactions
            // 
            this.dgvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransactions.Location = new System.Drawing.Point(27, 285);
            this.dgvTransactions.Name = "dgvTransactions";
            this.dgvTransactions.RowHeadersWidth = 51;
            this.dgvTransactions.RowTemplate.Height = 24;
            this.dgvTransactions.Size = new System.Drawing.Size(656, 239);
            this.dgvTransactions.TabIndex = 2;
            // 
            // lblAccountID
            // 
            this.lblAccountID.AutoSize = true;
            this.lblAccountID.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblAccountID.Location = new System.Drawing.Point(24, 62);
            this.lblAccountID.Name = "lblAccountID";
            this.lblAccountID.Size = new System.Drawing.Size(105, 16);
            this.lblAccountID.TabIndex = 4;
            this.lblAccountID.Text = "Mã Sổ Tiết Kiệm";
            // 
            // lblTransactionType
            // 
            this.lblTransactionType.AutoSize = true;
            this.lblTransactionType.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblTransactionType.Location = new System.Drawing.Point(24, 152);
            this.lblTransactionType.Name = "lblTransactionType";
            this.lblTransactionType.Size = new System.Drawing.Size(95, 16);
            this.lblTransactionType.TabIndex = 5;
            this.lblTransactionType.Text = "Loại Giao Dịch";
            // 
            // txtAccountID
            // 
            this.txtAccountID.Location = new System.Drawing.Point(210, 59);
            this.txtAccountID.Name = "txtAccountID";
            this.txtAccountID.Size = new System.Drawing.Size(163, 22);
            this.txtAccountID.TabIndex = 6;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(210, 99);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(163, 22);
            this.txtAmount.TabIndex = 7;
            // 
            // cmbTransactionType
            // 
            this.cmbTransactionType.FormattingEnabled = true;
            this.cmbTransactionType.Items.AddRange(new object[] {
            "Gửi tiền",
            "Rút gốc",
            "Rút lãi",
            "Tất toán"});
            this.cmbTransactionType.Location = new System.Drawing.Point(210, 144);
            this.cmbTransactionType.Name = "cmbTransactionType";
            this.cmbTransactionType.Size = new System.Drawing.Size(163, 24);
            this.cmbTransactionType.TabIndex = 8;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblAmount.Location = new System.Drawing.Point(24, 102);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(116, 16);
            this.lblAmount.TabIndex = 9;
            this.lblAmount.Text = "Số Tiền Giao Dịch";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblMessage.Location = new System.Drawing.Point(27, 210);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(73, 16);
            this.lblMessage.TabIndex = 10;
            this.lblMessage.Text = "Thông báo";
            // 
            // TransactionProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(1065, 584);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.cmbTransactionType);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.txtAccountID);
            this.Controls.Add(this.lblTransactionType);
            this.Controls.Add(this.lblAccountID);
            this.Controls.Add(this.dgvTransactions);
            this.Controls.Add(this.btnCreateTransaction);
            this.Name = "TransactionProcess";
            this.Text = "TransactionProcess";
            this.Load += new System.EventHandler(this.TransactionProcess_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateTransaction;
        private System.Windows.Forms.DataGridView dgvTransactions;
        private System.Windows.Forms.Label lblAccountID;
        private System.Windows.Forms.Label lblTransactionType;
        private System.Windows.Forms.TextBox txtAccountID;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.ComboBox cmbTransactionType;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblMessage;
    }
}