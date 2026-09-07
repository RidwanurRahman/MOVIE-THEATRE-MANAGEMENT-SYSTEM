namespace Movie_Theater_Management_System
{
    partial class SuperAdminDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SuperAdminDashboard));
            panel2 = new Panel();
            btnSalesReport = new Button();
            btnManageUsers = new Button();
            panel1 = new Panel();
            lblSuperAdminDashboard = new Label();
            lblX = new Label();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.PeachPuff;
            panel2.Controls.Add(btnSalesReport);
            panel2.Controls.Add(btnManageUsers);
            panel2.Location = new Point(641, 86);
            panel2.Name = "panel2";
            panel2.Size = new Size(250, 446);
            panel2.TabIndex = 3;
            // 
            // btnSalesReport
            // 
            btnSalesReport.BackColor = Color.Maroon;
            btnSalesReport.Font = new Font("Cambria", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalesReport.ForeColor = SystemColors.Control;
            btnSalesReport.Location = new Point(34, 193);
            btnSalesReport.Name = "btnSalesReport";
            btnSalesReport.Size = new Size(180, 61);
            btnSalesReport.TabIndex = 1;
            btnSalesReport.Text = "Sales Report";
            btnSalesReport.UseVisualStyleBackColor = false;
            btnSalesReport.Click += btnSalesReport_Click_1;
            // 
            // btnManageUsers
            // 
            btnManageUsers.BackColor = Color.Maroon;
            btnManageUsers.Font = new Font("Cambria", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnManageUsers.ForeColor = SystemColors.Control;
            btnManageUsers.Location = new Point(34, 76);
            btnManageUsers.Name = "btnManageUsers";
            btnManageUsers.Size = new Size(180, 61);
            btnManageUsers.TabIndex = 0;
            btnManageUsers.Text = "Manage Users";
            btnManageUsers.UseVisualStyleBackColor = false;
            btnManageUsers.Click += btnManageUsers_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.BurlyWood;
            panel1.Controls.Add(lblSuperAdminDashboard);
            panel1.Controls.Add(lblX);
            panel1.Location = new Point(1, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(891, 85);
            panel1.TabIndex = 2;
            // 
            // lblSuperAdminDashboard
            // 
            lblSuperAdminDashboard.AutoSize = true;
            lblSuperAdminDashboard.Font = new Font("Cambria", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSuperAdminDashboard.Location = new Point(280, 23);
            lblSuperAdminDashboard.Name = "lblSuperAdminDashboard";
            lblSuperAdminDashboard.Size = new Size(390, 40);
            lblSuperAdminDashboard.TabIndex = 2;
            lblSuperAdminDashboard.Text = "SuperAdmin Dashboard";
            // 
            // lblX
            // 
            lblX.AutoSize = true;
            lblX.BackColor = Color.DimGray;
            lblX.Font = new Font("Arial Rounded MT Bold", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblX.ForeColor = SystemColors.Control;
            lblX.Location = new Point(843, 0);
            lblX.Name = "lblX";
            lblX.Size = new Size(45, 32);
            lblX.TabIndex = 1;
            lblX.Text = " X ";
            lblX.Click += lblX_Click;
            // 
            // SuperAdminDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(892, 534);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SuperAdminDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SuperAdminDashboard";
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Button btnSalesReport;
        private Button btnManageUsers;
        private Panel panel1;
        private Label lblSuperAdminDashboard;
        private Label lblX;
    }
}