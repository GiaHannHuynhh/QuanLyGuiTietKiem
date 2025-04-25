namespace QuanLyGuiTietKiem
{
    partial class InterestRateManagementForm
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
            this.txtNewRate = new System.Windows.Forms.TextBox();
            this.btnUpdateRate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvInterestRates = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMaLoaiTK = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInterestRates)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNewRate
            // 
            this.txtNewRate.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtNewRate.Location = new System.Drawing.Point(188, 76);
            this.txtNewRate.Name = "txtNewRate";
            this.txtNewRate.Size = new System.Drawing.Size(197, 20);
            this.txtNewRate.TabIndex = 0;
            // 
            // btnUpdateRate
            // 
            this.btnUpdateRate.BackColor = System.Drawing.Color.Red;
            this.btnUpdateRate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateRate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdateRate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnUpdateRate.Location = new System.Drawing.Point(469, 31);
            this.btnUpdateRate.Name = "btnUpdateRate";
            this.btnUpdateRate.Size = new System.Drawing.Size(86, 22);
            this.btnUpdateRate.TabIndex = 1;
            this.btnUpdateRate.Text = "Cập nhật";
            this.btnUpdateRate.UseVisualStyleBackColor = false;
            this.btnUpdateRate.Click += new System.EventHandler(this.btnUpdateRate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(92, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Lãi suất mới";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnClear
            // 
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.Location = new System.Drawing.Point(608, 30);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(39, 23);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label4.Location = new System.Drawing.Point(270, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(217, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "DANH SÁCH LOẠI TIẾT KIỆM";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // dgvInterestRates
            // 
            this.dgvInterestRates.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.dgvInterestRates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInterestRates.GridColor = System.Drawing.Color.Black;
            this.dgvInterestRates.Location = new System.Drawing.Point(88, 212);
            this.dgvInterestRates.Name = "dgvInterestRates";
            this.dgvInterestRates.Size = new System.Drawing.Size(572, 195);
            this.dgvInterestRates.TabIndex = 14;
            this.dgvInterestRates.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInterestRates_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(175, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(92, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Mã loại tiết kiệm";
            // 
            // txtMaLoaiTK
            // 
            this.txtMaLoaiTK.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtMaLoaiTK.Location = new System.Drawing.Point(188, 33);
            this.txtMaLoaiTK.Name = "txtMaLoaiTK";
            this.txtMaLoaiTK.Size = new System.Drawing.Size(197, 20);
            this.txtMaLoaiTK.TabIndex = 19;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(190, 110);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 13);
            this.lblMessage.TabIndex = 21;
            // 
            // InterestRateManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(729, 450);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMaLoaiTK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvInterestRates);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUpdateRate);
            this.Controls.Add(this.txtNewRate);
            this.Name = "InterestRateManagementForm";
            this.Text = "Interest Rate Management";
            this.Load += new System.EventHandler(this.InterestRateManagementForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInterestRates)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNewRate;
        private System.Windows.Forms.Button btnUpdateRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvInterestRates;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMaLoaiTK;
        private System.Windows.Forms.Label lblMessage;
    }
}