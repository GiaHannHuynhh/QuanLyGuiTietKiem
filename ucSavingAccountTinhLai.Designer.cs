namespace QuanLyGuiTietKiem
{
    partial class ucSavingAccountTinhLai
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
            this.txtNgayMoSo = new System.Windows.Forms.TextBox();
            this.dateTimePickerDenNgay = new System.Windows.Forms.DateTimePicker();
            this.txtSoDuHienTai = new System.Windows.Forms.TextBox();
            this.btnTinhLai = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMaSoTK = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLaiDuKien = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNgayMoSo
            // 
            this.txtNgayMoSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.8F);
            this.txtNgayMoSo.Location = new System.Drawing.Point(19, 101);
            this.txtNgayMoSo.Name = "txtNgayMoSo";
            this.txtNgayMoSo.ReadOnly = true;
            this.txtNgayMoSo.Size = new System.Drawing.Size(233, 26);
            this.txtNgayMoSo.TabIndex = 0;
            // 
            // dateTimePickerDenNgay
            // 
            this.dateTimePickerDenNgay.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerDenNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerDenNgay.Location = new System.Drawing.Point(356, 141);
            this.dateTimePickerDenNgay.Name = "dateTimePickerDenNgay";
            this.dateTimePickerDenNgay.Size = new System.Drawing.Size(233, 27);
            this.dateTimePickerDenNgay.TabIndex = 1;
            // 
            // txtSoDuHienTai
            // 
            this.txtSoDuHienTai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.8F);
            this.txtSoDuHienTai.Location = new System.Drawing.Point(19, 47);
            this.txtSoDuHienTai.Name = "txtSoDuHienTai";
            this.txtSoDuHienTai.ReadOnly = true;
            this.txtSoDuHienTai.Size = new System.Drawing.Size(233, 26);
            this.txtSoDuHienTai.TabIndex = 2;
            // 
            // btnTinhLai
            // 
            this.btnTinhLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.8F);
            this.btnTinhLai.ForeColor = System.Drawing.Color.Black;
            this.btnTinhLai.Location = new System.Drawing.Point(249, 232);
            this.btnTinhLai.Name = "btnTinhLai";
            this.btnTinhLai.Size = new System.Drawing.Size(143, 44);
            this.btnTinhLai.TabIndex = 3;
            this.btnTinhLai.Text = "Tính Lãi Dự Kiến";
            this.btnTinhLai.UseVisualStyleBackColor = true;
            this.btnTinhLai.Click += new System.EventHandler(this.btnTinhLai_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(47, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ngày mở sổ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(19, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Số dư hiện tại: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(325, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ngày tính lãi dự kiến:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtMaSoTK);
            this.groupBox1.Controls.Add(this.txtNgayMoSo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtSoDuHienTai);
            this.groupBox1.Location = new System.Drawing.Point(28, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(578, 160);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // txtMaSoTK
            // 
            this.txtMaSoTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.8F);
            this.txtMaSoTK.Location = new System.Drawing.Point(328, 47);
            this.txtMaSoTK.Name = "txtMaSoTK";
            this.txtMaSoTK.ReadOnly = true;
            this.txtMaSoTK.Size = new System.Drawing.Size(233, 26);
            this.txtMaSoTK.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(325, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Mã số tài khoản:";
            // 
            // txtLaiDuKien
            // 
            this.txtLaiDuKien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.8F);
            this.txtLaiDuKien.Location = new System.Drawing.Point(197, 345);
            this.txtLaiDuKien.Name = "txtLaiDuKien";
            this.txtLaiDuKien.ReadOnly = true;
            this.txtLaiDuKien.Size = new System.Drawing.Size(233, 26);
            this.txtLaiDuKien.TabIndex = 8;
            // 
            // ucSavingAccountTinhLai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.Controls.Add(this.txtLaiDuKien);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTinhLai);
            this.Controls.Add(this.dateTimePickerDenNgay);
            this.Controls.Add(this.groupBox1);
            this.Name = "ucSavingAccountTinhLai";
            this.Size = new System.Drawing.Size(640, 490);
            this.Load += new System.EventHandler(this.ucSavingAccountTinhLai_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNgayMoSo;
        private System.Windows.Forms.DateTimePicker dateTimePickerDenNgay;
        private System.Windows.Forms.TextBox txtSoDuHienTai;
        private System.Windows.Forms.Button btnTinhLai;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMaSoTK;
        private System.Windows.Forms.TextBox txtLaiDuKien;
    }
}
