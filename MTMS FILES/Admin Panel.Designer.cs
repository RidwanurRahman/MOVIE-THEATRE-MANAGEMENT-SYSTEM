namespace Movie_Theater_Management_System
{
    partial class Admin_Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin_Dashboard));
            panel1 = new Panel();
            label1 = new Label();
            lblX = new Label();
            panel2 = new Panel();
            btnManageSeat = new Button();
            btnManageShows = new Button();
            btnManageMovies = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.BurlyWood;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lblX);
            panel1.Location = new Point(0, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(891, 85);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cambria", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(304, 23);
            label1.Name = "label1";
            label1.Size = new Size(299, 40);
            label1.TabIndex = 2;
            label1.Text = "Admin Dashboard";
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
            // panel2
            // 
            panel2.BackColor = Color.PeachPuff;
            panel2.Controls.Add(btnManageSeat);
            panel2.Controls.Add(btnManageShows);
            panel2.Controls.Add(btnManageMovies);
            panel2.Location = new Point(638, 83);
            panel2.Name = "panel2";
            panel2.Size = new Size(250, 446);
            panel2.TabIndex = 1;
            // 
            // btnManageSeat
            // 
            btnManageSeat.BackColor = Color.Maroon;
            btnManageSeat.Font = new Font("Cambria", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnManageSeat.ForeColor = SystemColors.Control;
            btnManageSeat.Location = new Point(34, 237);
            btnManageSeat.Name = "btnManageSeat";
            btnManageSeat.Size = new Size(180, 61);
            btnManageSeat.TabIndex = 2;
            btnManageSeat.Text = "Manage Seat";
            btnManageSeat.UseVisualStyleBackColor = false;
            btnManageSeat.Click += btnManageSeat_Click;
            // 
            // btnManageShows
            // 
            btnManageShows.BackColor = Color.Maroon;
            btnManageShows.Font = new Font("Cambria", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnManageShows.ForeColor = SystemColors.Control;
            btnManageShows.Location = new Point(34, 145);
            btnManageShows.Name = "btnManageShows";
            btnManageShows.Size = new Size(180, 61);
            btnManageShows.TabIndex = 1;
            btnManageShows.Text = "Manage Shows";
            btnManageShows.UseVisualStyleBackColor = false;
            btnManageShows.Click += btnManageShows_Click;
            // 
            // btnManageMovies
            // 
            btnManageMovies.BackColor = Color.Maroon;
            btnManageMovies.Font = new Font("Cambria", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnManageMovies.ForeColor = SystemColors.Control;
            btnManageMovies.Location = new Point(34, 61);
            btnManageMovies.Name = "btnManageMovies";
            btnManageMovies.Size = new Size(180, 61);
            btnManageMovies.TabIndex = 0;
            btnManageMovies.Text = "Manage Movies";
            btnManageMovies.UseVisualStyleBackColor = false;
            btnManageMovies.Click += btnManageMovies_Click;
            // 
            // Admin_Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(889, 524);
            Controls.Add(panel2);
            Controls.Add(panel1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Admin_Dashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin_Dashboard";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblX;
        private Label label1;
        private Panel panel2;
        private Button btnManageSeat;
        private Button btnManageShows;
        private Button btnManageMovies;
    }
}