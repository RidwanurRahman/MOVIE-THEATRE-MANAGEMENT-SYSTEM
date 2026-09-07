namespace Movie_Theater_Management_System
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            panel1 = new Panel();
            llblRegister = new LinkLabel();
            lblDonthaveanaccount = new Label();
            chkShowPassword = new CheckBox();
            btnX = new Button();
            lblLogin = new Label();
            btnLogin = new Button();
            txtPassword = new TextBox();
            txtUserName = new TextBox();
            lblPassword = new Label();
            lblUserName = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightSalmon;
            panel1.Controls.Add(llblRegister);
            panel1.Controls.Add(lblDonthaveanaccount);
            panel1.Controls.Add(chkShowPassword);
            panel1.Controls.Add(btnX);
            panel1.Controls.Add(lblLogin);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(txtUserName);
            panel1.Controls.Add(lblPassword);
            panel1.Controls.Add(lblUserName);
            panel1.Location = new Point(698, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(429, 526);
            panel1.TabIndex = 11;
            // 
            // llblRegister
            // 
            llblRegister.AutoSize = true;
            llblRegister.Location = new Point(284, 478);
            llblRegister.Name = "llblRegister";
            llblRegister.Size = new Size(63, 20);
            llblRegister.TabIndex = 22;
            llblRegister.TabStop = true;
            llblRegister.Text = "Register";
            llblRegister.LinkClicked += llblRegister_LinkClicked;
            // 
            // lblDonthaveanaccount
            // 
            lblDonthaveanaccount.AutoSize = true;
            lblDonthaveanaccount.Font = new Font("Calibri", 10.2F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblDonthaveanaccount.Location = new Point(110, 478);
            lblDonthaveanaccount.Name = "lblDonthaveanaccount";
            lblDonthaveanaccount.Size = new Size(180, 21);
            lblDonthaveanaccount.TabIndex = 21;
            lblDonthaveanaccount.Text = "Don't have an account? ";
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            chkShowPassword.Location = new Point(153, 331);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(146, 21);
            chkShowPassword.TabIndex = 20;
            chkShowPassword.Text = "Show Password";
            chkShowPassword.UseVisualStyleBackColor = true;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
            // 
            // btnX
            // 
            btnX.BackColor = Color.Red;
            btnX.Font = new Font("Arial Rounded MT Bold", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnX.ForeColor = Color.Transparent;
            btnX.Location = new Point(345, -2);
            btnX.Name = "btnX";
            btnX.Size = new Size(84, 44);
            btnX.TabIndex = 19;
            btnX.Text = "X";
            btnX.UseVisualStyleBackColor = false;
            btnX.Click += btnX_Click;
            // 
            // lblLogin
            // 
            lblLogin.Font = new Font("Arial Rounded MT Bold", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLogin.Location = new Point(153, 99);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(93, 40);
            lblLogin.TabIndex = 18;
            lblLogin.Text = "Login";
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Arial Rounded MT Bold", 13.8F);
            btnLogin.Location = new Point(295, 382);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(94, 43);
            btnLogin.TabIndex = 15;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(153, 279);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(236, 27);
            txtPassword.TabIndex = 14;
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(153, 208);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(236, 27);
            txtUserName.TabIndex = 13;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Arial Rounded MT Bold", 10.8F);
            lblPassword.Location = new Point(17, 286);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(98, 21);
            lblPassword.TabIndex = 12;
            lblPassword.Text = "Password";
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Arial Rounded MT Bold", 10.8F);
            lblUserName.Location = new Point(17, 208);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(110, 21);
            lblUserName.TabIndex = 11;
            lblUserName.Text = "User Name";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1125, 524);
            Controls.Add(panel1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Label lblLogin;
        private Button btnLogin;
        private TextBox txtPassword;
        private TextBox txtUserName;
        private Label lblPassword;
        private Label lblUserName;
        private Button btnX;
        private CheckBox chkShowPassword;
        private LinkLabel llblRegister;
        private Label lblDonthaveanaccount;
    }
}
