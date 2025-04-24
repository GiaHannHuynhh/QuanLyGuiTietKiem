namespace QuanLyGuiTietKiem
{
    partial class ucSavingAccountCloseRequest
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
            this.txtSoDuHienTai = new System.Windows.Forms.TextBox();
            this.btnSubmitCloseRequest = new System.Windows.Forms.Button();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // txtSoDuHienTai
            // 
            this.txtSoDuHienTai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.8F);
            this.txtSoDuHienTai.Location = new System.Drawing.Point(353, 119);
            this.txtSoDuHienTai.Name = "txtSoDuHienTai";
            this.txtSoDuHienTai.ReadOnly = true;
            this.txtSoDuHienTai.Size = new System.Drawing.Size(235, 26);
            this.txtSoDuHienTai.TabIndex = 1;
            // 
            // btnSubmitCloseRequest
            // 
            this.btnSubmitCloseRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.8F);
            this.btnSubmitCloseRequest.ForeColor = System.Drawing.Color.Black;
            this.btnSubmitCloseRequest.Location = new System.Drawing.Point(226, 237);
            this.btnSubmitCloseRequest.Name = "btnSubmitCloseRequest";
            this.btnSubmitCloseRequest.Size = new System.Drawing.Size(188, 46);
            this.btnSubmitCloseRequest.TabIndex = 2;
            this.btnSubmitCloseRequest.Text = "YÊU CẦU TẤT TOÁN";
            this.btnSubmitCloseRequest.UseVisualStyleBackColor = true;
            this.btnSubmitCloseRequest.Click += new System.EventHandler(this.btnSubmitCloseRequest_Click);
            // 
            // txtAccount
            // 
            this.txtAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.8F);
            this.txtAccount.Location = new System.Drawing.Point(48, 119);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.ReadOnly = true;
            this.txtAccount.Size = new System.Drawing.Size(235, 26);
            this.txtAccount.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.8F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(44, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mã số tài khoản:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.8F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(349, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Số dư hiện tại:";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(33, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(578, 101);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // ucSavingAccountCloseRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAccount);
            this.Controls.Add(this.btnSubmitCloseRequest);
            this.Controls.Add(this.txtSoDuHienTai);
            this.Controls.Add(this.groupBox1);
            this.Name = "ucSavingAccountCloseRequest";
            this.Size = new System.Drawing.Size(640, 490);
            this.Load += new System.EventHandler(this.ucSavingAccountCloseRequest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtSoDuHienTai;
        private System.Windows.Forms.Button btnSubmitCloseRequest;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
