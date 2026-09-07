namespace Movie_Theater_Management_System
{
    partial class Register
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
            cmbRole = new ComboBox();
            txtUserName = new MaskedTextBox();
            lblRole = new Label();
            txtPassword = new MaskedTextBox();
            lblPassword = new Label();
            lblUserName = new Label();
            lblRegister = new Label();
            btnX = new Button();
            btnRegister = new Button();
            SuspendLayout();
            // 
            // cmbRole
            // 
            cmbRole.FormattingEnabled = true;
            cmbRole.Items.AddRange(new object[] { "Audience", "Admin", "SuperAdmin" });
            cmbRole.Location = new Point(239, 281);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(213, 28);
            cmbRole.TabIndex = 103;
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(239, 172);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(213, 27);
            txtUserName.TabIndex = 102;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRole.Location = new Point(93, 287);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(51, 23);
            lblRole.TabIndex = 101;
            lblRole.Text = "Role";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(239, 224);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(213, 27);
            txtPassword.TabIndex = 100;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPassword.Location = new Point(93, 228);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(99, 23);
            lblPassword.TabIndex = 99;
            lblPassword.Text = "Password";
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserName.Location = new Point(93, 176);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(107, 23);
            lblUserName.TabIndex = 98;
            lblUserName.Text = "UserName";
            // 
            // lblRegister
            // 
            lblRegister.AutoSize = true;
            lblRegister.Font = new Font("Britannic Bold", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRegister.Location = new Point(215, 58);
            lblRegister.Name = "lblRegister";
            lblRegister.Size = new Size(218, 37);
            lblRegister.TabIndex = 97;
            lblRegister.Text = "Registeration";
            // 
            // btnX
            // 
            btnX.BackColor = Color.Red;
            btnX.Font = new Font("Arial Rounded MT Bold", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnX.ForeColor = Color.Transparent;
            btnX.Location = new Point(528, -2);
            btnX.Name = "btnX";
            btnX.Size = new Size(84, 44);
            btnX.TabIndex = 104;
            btnX.Text = "X";
            btnX.UseVisualStyleBackColor = false;
            btnX.Click += btnX_Click;
            // 
            // btnRegister
            // 
            btnRegister.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegister.Location = new Point(254, 405);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(120, 42);
            btnRegister.TabIndex = 105;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 128, 128);
            ClientSize = new Size(612, 528);
            Controls.Add(btnRegister);
            Controls.Add(btnX);
            Controls.Add(cmbRole);
            Controls.Add(txtUserName);
            Controls.Add(lblRole);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(lblUserName);
            Controls.Add(lblRegister);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Register";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Register";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbRole;
        private MaskedTextBox txtUserName;
        private Label lblRole;
        private MaskedTextBox txtPassword;
        private Label lblPassword;
        private Label lblUserName;
        private Label lblRegister;
        private Button btnX;
        private Button btnRegister;
    }
}