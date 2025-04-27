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
            this.label5 = new System.Windows.Forms.Label();
            this.txtMaLoaiTK = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnXoaLTK = new System.Windows.Forms.Button();
            this.btnThemLTK = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvInterestRates = new System.Windows.Forms.DataGridView();
            this.txtTenLoaiTK = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtKyHan = new System.Windows.Forms.TextBox();
            this.btnSearches = new System.Windows.Forms.Button();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInterestRates)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNewRate
            // 
            this.txtNewRate.BackColor = System.Drawing.Color.White;
            this.txtNewRate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewRate.Location = new System.Drawing.Point(121, 148);
            this.txtNewRate.Name = "txtNewRate";
            this.txtNewRate.Size = new System.Drawing.Size(88, 22);
            this.txtNewRate.TabIndex = 25;
            // 
            // btnUpdateRate
            // 
            this.btnUpdateRate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(98)))));
            this.btnUpdateRate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateRate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnUpdateRate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateRate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateRate.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnUpdateRate.Location = new System.Drawing.Point(0, 340);
            this.btnUpdateRate.Name = "btnUpdateRate";
            this.btnUpdateRate.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.btnUpdateRate.Size = new System.Drawing.Size(220, 55);
            this.btnUpdateRate.TabIndex = 1;
            this.btnUpdateRate.Text = "Cập nhật lãi suất";
            this.btnUpdateRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateRate.UseVisualStyleBackColor = false;
            this.btnUpdateRate.Click += new System.EventHandler(this.btnUpdateRate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(118, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Lãi suất";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Red;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(171, 180);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(38, 23);
            this.btnClear.TabIndex = 0;
            this.btnClear.Text = "Xóa";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(9, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 16);
            this.label5.TabIndex = 20;
            this.label5.Text = "Mã loại tiết kiệm";
            // 
            // txtMaLoaiTK
            // 
            this.txtMaLoaiTK.BackColor = System.Drawing.Color.White;
            this.txtMaLoaiTK.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaLoaiTK.Location = new System.Drawing.Point(12, 57);
            this.txtMaLoaiTK.Name = "txtMaLoaiTK";
            this.txtMaLoaiTK.Size = new System.Drawing.Size(197, 22);
            this.txtMaLoaiTK.TabIndex = 24;
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMessage.AutoSize = true;
            this.lblMessage.BackColor = System.Drawing.Color.White;
            this.lblMessage.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.White;
            this.lblMessage.Location = new System.Drawing.Point(344, 185);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(87, 18);
            this.lblMessage.TabIndex = 21;
            this.lblMessage.Text = "fdbdfbdfdfb";
            this.lblMessage.Click += new System.EventHandler(this.lblMessage_Click);
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.panelMenu.Controls.Add(this.btnSearches);
            this.panelMenu.Controls.Add(this.txtKyHan);
            this.panelMenu.Controls.Add(this.label4);
            this.panelMenu.Controls.Add(this.txtTenLoaiTK);
            this.panelMenu.Controls.Add(this.label2);
            this.panelMenu.Controls.Add(this.btnXoaLTK);
            this.panelMenu.Controls.Add(this.btnThemLTK);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Controls.Add(this.txtNewRate);
            this.panelMenu.Controls.Add(this.label5);
            this.panelMenu.Controls.Add(this.label1);
            this.panelMenu.Controls.Add(this.btnUpdateRate);
            this.panelMenu.Controls.Add(this.btnClear);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.ForeColor = System.Drawing.Color.Gainsboro;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 403);
            this.panelMenu.TabIndex = 22;
            // 
            // btnXoaLTK
            // 
            this.btnXoaLTK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(98)))));
            this.btnXoaLTK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaLTK.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnXoaLTK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaLTK.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaLTK.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnXoaLTK.Location = new System.Drawing.Point(0, 280);
            this.btnXoaLTK.Name = "btnXoaLTK";
            this.btnXoaLTK.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.btnXoaLTK.Size = new System.Drawing.Size(220, 55);
            this.btnXoaLTK.TabIndex = 23;
            this.btnXoaLTK.Text = "Xóa loại tiết kiệm";
            this.btnXoaLTK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaLTK.UseVisualStyleBackColor = false;
            this.btnXoaLTK.Click += new System.EventHandler(this.btnXoaLTK_Click);
            // 
            // btnThemLTK
            // 
            this.btnThemLTK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(98)))));
            this.btnThemLTK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemLTK.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnThemLTK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemLTK.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemLTK.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnThemLTK.Location = new System.Drawing.Point(0, 220);
            this.btnThemLTK.Name = "btnThemLTK";
            this.btnThemLTK.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.btnThemLTK.Size = new System.Drawing.Size(220, 55);
            this.btnThemLTK.TabIndex = 22;
            this.btnThemLTK.Text = "Thêm loại tiết kiệm";
            this.btnThemLTK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemLTK.UseVisualStyleBackColor = false;
            this.btnThemLTK.Click += new System.EventHandler(this.btnThemLTK_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.panelLogo.Controls.Add(this.label3);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.ForeColor = System.Drawing.Color.Gainsboro;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(220, 32);
            this.panelLogo.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(40, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "QUẢN LÝ LOẠI TIẾT KIỆM";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // panelTitle
            // 
            this.panelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.panelTitle.Controls.Add(this.label6);
            this.panelTitle.Location = new System.Drawing.Point(218, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(511, 70);
            this.panelTitle.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.label6.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(143, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(274, 22);
            this.label6.TabIndex = 12;
            this.label6.Text = "DANH SÁCH LOẠI TIẾT KIỆM";
            // 
            // dgvInterestRates
            // 
            this.dgvInterestRates.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInterestRates.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInterestRates.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvInterestRates.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.dgvInterestRates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInterestRates.GridColor = System.Drawing.Color.Black;
            this.dgvInterestRates.Location = new System.Drawing.Point(226, 76);
            this.dgvInterestRates.Name = "dgvInterestRates";
            this.dgvInterestRates.Size = new System.Drawing.Size(491, 319);
            this.dgvInterestRates.TabIndex = 14;
            this.dgvInterestRates.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInterestRates_CellContentClick);
            // 
            // txtTenLoaiTK
            // 
            this.txtTenLoaiTK.BackColor = System.Drawing.Color.White;
            this.txtTenLoaiTK.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenLoaiTK.Location = new System.Drawing.Point(12, 103);
            this.txtTenLoaiTK.Name = "txtTenLoaiTK";
            this.txtTenLoaiTK.Size = new System.Drawing.Size(197, 22);
            this.txtTenLoaiTK.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(9, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 16);
            this.label2.TabIndex = 26;
            this.label2.Text = "Tên loại tiết kiệm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(9, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 28;
            this.label4.Text = "Kỳ hạn";
            // 
            // txtKyHan
            // 
            this.txtKyHan.BackColor = System.Drawing.Color.White;
            this.txtKyHan.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKyHan.Location = new System.Drawing.Point(12, 148);
            this.txtKyHan.Name = "txtKyHan";
            this.txtKyHan.Size = new System.Drawing.Size(88, 22);
            this.txtKyHan.TabIndex = 29;
            // 
            // btnSearches
            // 
            this.btnSearches.BackColor = System.Drawing.Color.Green;
            this.btnSearches.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearches.FlatAppearance.BorderSize = 0;
            this.btnSearches.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearches.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearches.ForeColor = System.Drawing.Color.White;
            this.btnSearches.Location = new System.Drawing.Point(121, 180);
            this.btnSearches.Name = "btnSearches";
            this.btnSearches.Size = new System.Drawing.Size(38, 23);
            this.btnSearches.TabIndex = 25;
            this.btnSearches.Text = "Lọc";
            this.btnSearches.UseVisualStyleBackColor = false;
            this.btnSearches.Click += new System.EventHandler(this.btnSearches_Click);
            // 
            // InterestRateManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(729, 403);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.panelTitle);
            this.Controls.Add(this.txtMaLoaiTK);
            this.Controls.Add(this.dgvInterestRates);
            this.Controls.Add(this.panelMenu);
            this.Name = "InterestRateManagementForm";
            this.Text = "Interest Rate Management";
            this.Load += new System.EventHandler(this.InterestRateManagementForm_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInterestRates)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNewRate;
        private System.Windows.Forms.Button btnUpdateRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMaLoaiTK;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvInterestRates;
        private System.Windows.Forms.Button btnThemLTK;
        private System.Windows.Forms.Button btnXoaLTK;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTenLoaiTK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKyHan;
        private System.Windows.Forms.Button btnSearches;
    }
}