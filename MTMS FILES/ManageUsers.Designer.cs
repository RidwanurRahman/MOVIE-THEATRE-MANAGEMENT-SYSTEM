namespace Movie_Theater_Management_System
{
    partial class ManageUsers
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
            lblManageUsersDashboard = new Label();
            dgvManageUsers = new DataGridView();
            txtUserName = new MaskedTextBox();
            lblRole = new Label();
            txtPassword = new MaskedTextBox();
            lblPassword = new Label();
            lblUserName = new Label();
            lblManageUsers = new Label();
            btnClear = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnApprove = new Button();
            txtSearch = new MaskedTextBox();
            lblSearch = new Label();
            btnX = new Button();
            cmbRole = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvManageUsers).BeginInit();
            SuspendLayout();
            // 
            // lblManageUsersDashboard
            // 
            lblManageUsersDashboard.AutoSize = true;
            lblManageUsersDashboard.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblManageUsersDashboard.Location = new Point(250, 338);
            lblManageUsersDashboard.Name = "lblManageUsersDashboard";
            lblManageUsersDashboard.Size = new Size(243, 23);
            lblManageUsersDashboard.TabIndex = 86;
            lblManageUsersDashboard.Text = "Manage Users Dashboard";
            // 
            // dgvManageUsers
            // 
            dgvManageUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvManageUsers.Location = new Point(26, 372);
            dgvManageUsers.Name = "dgvManageUsers";
            dgvManageUsers.RowHeadersWidth = 51;
            dgvManageUsers.Size = new Size(697, 144);
            dgvManageUsers.TabIndex = 84;
            dgvManageUsers.CellDoubleClick += dgvManageUsers_CellDoubleClick;
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(181, 108);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(213, 27);
            txtUserName.TabIndex = 82;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRole.Location = new Point(35, 223);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(51, 23);
            lblRole.TabIndex = 77;
            lblRole.Text = "Role";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(181, 160);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(213, 27);
            txtPassword.TabIndex = 76;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPassword.Location = new Point(35, 164);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(99, 23);
            lblPassword.TabIndex = 75;
            lblPassword.Text = "Password";
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserName.Location = new Point(35, 112);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(107, 23);
            lblUserName.TabIndex = 74;
            lblUserName.Text = "UserName";
            // 
            // lblManageUsers
            // 
            lblManageUsers.AutoSize = true;
            lblManageUsers.Font = new Font("Britannic Bold", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblManageUsers.Location = new Point(295, 23);
            lblManageUsers.Name = "lblManageUsers";
            lblManageUsers.Size = new Size(227, 37);
            lblManageUsers.TabIndex = 73;
            lblManageUsers.Text = "Manage Users";
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.Location = new Point(630, 155);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 42);
            btnClear.TabIndex = 90;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.Location = new Point(498, 155);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 42);
            btnUpdate.TabIndex = 89;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click_1;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(630, 98);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 42);
            btnDelete.TabIndex = 88;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnApprove
            // 
            btnApprove.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnApprove.Location = new Point(490, 98);
            btnApprove.Name = "btnApprove";
            btnApprove.Size = new Size(120, 42);
            btnApprove.TabIndex = 87;
            btnApprove.Text = "Approve";
            btnApprove.UseVisualStyleBackColor = true;
            btnApprove.Click += btnApprove_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(540, 316);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(184, 27);
            txtSearch.TabIndex = 93;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSearch.Location = new Point(540, 285);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(72, 23);
            lblSearch.TabIndex = 92;
            lblSearch.Text = "Search";
            // 
            // btnX
            // 
            btnX.BackColor = Color.Red;
            btnX.Font = new Font("Arial Rounded MT Bold", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnX.ForeColor = Color.Transparent;
            btnX.Location = new Point(685, -2);
            btnX.Name = "btnX";
            btnX.Size = new Size(84, 44);
            btnX.TabIndex = 95;
            btnX.Text = "X";
            btnX.UseVisualStyleBackColor = false;
            btnX.Click += btnX_Click_1;
            // 
            // cmbRole
            // 
            cmbRole.FormattingEnabled = true;
            cmbRole.Items.AddRange(new object[] { "Audience", "Admin", "SuperAdmin" });
            cmbRole.Location = new Point(181, 217);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(213, 28);
            cmbRole.TabIndex = 96;
            // 
            // ManageUsers
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 128, 128);
            ClientSize = new Size(770, 521);
            Controls.Add(cmbRole);
            Controls.Add(btnX);
            Controls.Add(txtSearch);
            Controls.Add(lblSearch);
            Controls.Add(btnClear);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(btnApprove);
            Controls.Add(lblManageUsersDashboard);
            Controls.Add(dgvManageUsers);
            Controls.Add(txtUserName);
            Controls.Add(lblRole);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(lblUserName);
            Controls.Add(lblManageUsers);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ManageUsers";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ManageUsers";
            ((System.ComponentModel.ISupportInitialize)dgvManageUsers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblManageUsersDashboard;
        private DataGridView dgvManageUsers;
        private MaskedTextBox txtUserName;
        private Label lblRole;
        private MaskedTextBox txtPassword;
        private Label lblPassword;
        private Label lblUserName;
        private Label lblManageUsers;
        private Button btnClear;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnApprove;
        private MaskedTextBox txtSearch;
        private Label lblSearch;
        private Button btnX;
        private ComboBox cmbRole;
    }
}