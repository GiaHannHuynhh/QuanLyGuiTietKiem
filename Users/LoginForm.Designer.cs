namespace QuanLyGuiTietKiem
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.linkLabel_forgetPassword = new System.Windows.Forms.LinkLabel();
            this.pictureBox_Logo = new System.Windows.Forms.PictureBox();
            this.linkLabel_newUser = new System.Windows.Forms.LinkLabel();
            this.btn_Login = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // linkLabel_forgetPassword
            // 
            this.linkLabel_forgetPassword.ActiveLinkColor = System.Drawing.Color.DarkViolet;
            this.linkLabel_forgetPassword.AutoSize = true;
            this.linkLabel_forgetPassword.Font = new System.Drawing.Font("Berlin Sans FB", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel_forgetPassword.LinkColor = System.Drawing.Color.Lime;
            this.linkLabel_forgetPassword.Location = new System.Drawing.Point(678, 683);
            this.linkLabel_forgetPassword.Name = "linkLabel_forgetPassword";
            this.linkLabel_forgetPassword.Size = new System.Drawing.Size(188, 26);
            this.linkLabel_forgetPassword.TabIndex = 23;
            this.linkLabel_forgetPassword.TabStop = true;
            this.linkLabel_forgetPassword.Text = "Forget Password?";
            this.linkLabel_forgetPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_forgetPassword_LinkClicked);
            // 
            // pictureBox_Logo
            // 
            this.pictureBox_Logo.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Logo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Logo.Image")));
            this.pictureBox_Logo.Location = new System.Drawing.Point(325, 111);
            this.pictureBox_Logo.Name = "pictureBox_Logo";
            this.pictureBox_Logo.Size = new System.Drawing.Size(122, 141);
            this.pictureBox_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Logo.TabIndex = 22;
            this.pictureBox_Logo.TabStop = false;
            // 
            // linkLabel_newUser
            // 
            this.linkLabel_newUser.ActiveLinkColor = System.Drawing.Color.DarkViolet;
            this.linkLabel_newUser.AutoSize = true;
            this.linkLabel_newUser.Font = new System.Drawing.Font("Berlin Sans FB", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel_newUser.LinkColor = System.Drawing.Color.Lime;
            this.linkLabel_newUser.Location = new System.Drawing.Point(440, 683);
            this.linkLabel_newUser.Name = "linkLabel_newUser";
            this.linkLabel_newUser.Size = new System.Drawing.Size(119, 26);
            this.linkLabel_newUser.TabIndex = 21;
            this.linkLabel_newUser.TabStop = true;
            this.linkLabel_newUser.Text = "New User?";
            this.linkLabel_newUser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_newUser_LinkClicked);
            // 
            // btn_Login
            // 
            this.btn_Login.BackColor = System.Drawing.Color.Green;
            this.btn_Login.Font = new System.Drawing.Font("Berlin Sans FB", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Login.ForeColor = System.Drawing.Color.White;
            this.btn_Login.Location = new System.Drawing.Point(723, 535);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(191, 70);
            this.btn_Login.TabIndex = 20;
            this.btn_Login.Text = "Login";
            this.btn_Login.UseVisualStyleBackColor = false;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.Firebrick;
            this.btn_Cancel.Font = new System.Drawing.Font("Berlin Sans FB", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel.ForeColor = System.Drawing.Color.White;
            this.btn_Cancel.Location = new System.Drawing.Point(353, 535);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(191, 70);
            this.btn_Cancel.TabIndex = 17;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(504, 399);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(430, 31);
            this.txtPassword.TabIndex = 16;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(504, 305);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(430, 31);
            this.txtUsername.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Berlin Sans FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(319, 393);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 35);
            this.label3.TabIndex = 14;
            this.label3.Text = "Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Berlin Sans FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(319, 305);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 35);
            this.label2.TabIndex = 13;
            this.label2.Text = "Username:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Berlin Sans FB Demi", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(564, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(327, 55);
            this.label1.TabIndex = 12;
            this.label1.Text = "Account Login";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1271, 802);
            this.Controls.Add(this.linkLabel_forgetPassword);
            this.Controls.Add(this.pictureBox_Logo);
            this.Controls.Add(this.linkLabel_newUser);
            this.Controls.Add(this.btn_Login);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel_forgetPassword;
        private System.Windows.Forms.PictureBox pictureBox_Logo;
        private System.Windows.Forms.LinkLabel linkLabel_newUser;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}