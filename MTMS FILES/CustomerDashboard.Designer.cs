namespace Movie_Theater_Management_System
{
    partial class CustomerDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerDashboard));
            panel2 = new Panel();
            btnFeedback = new Button();
            btnBookingTicket = new Button();
            panel1 = new Panel();
            btnX = new Button();
            lblAudienceDashboard = new Label();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.PeachPuff;
            panel2.Controls.Add(btnFeedback);
            panel2.Controls.Add(btnBookingTicket);
            panel2.Location = new Point(643, 85);
            panel2.Name = "panel2";
            panel2.Size = new Size(250, 446);
            panel2.TabIndex = 3;
            panel2.Paint += panel2_Paint;
            // 
            // btnFeedback
            // 
            btnFeedback.BackColor = Color.Maroon;
            btnFeedback.Font = new Font("Cambria", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFeedback.ForeColor = SystemColors.Control;
            btnFeedback.Location = new Point(36, 199);
            btnFeedback.Name = "btnFeedback";
            btnFeedback.Size = new Size(180, 61);
            btnFeedback.TabIndex = 1;
            btnFeedback.Text = "Feedback";
            btnFeedback.UseVisualStyleBackColor = false;
            btnFeedback.Click += btnFeedback_Click;
            // 
            // btnBookingTicket
            // 
            btnBookingTicket.BackColor = Color.Maroon;
            btnBookingTicket.Font = new Font("Cambria", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBookingTicket.ForeColor = SystemColors.Control;
            btnBookingTicket.Location = new Point(36, 115);
            btnBookingTicket.Name = "btnBookingTicket";
            btnBookingTicket.Size = new Size(180, 61);
            btnBookingTicket.TabIndex = 0;
            btnBookingTicket.Text = "Booking Ticket";
            btnBookingTicket.UseVisualStyleBackColor = false;
            btnBookingTicket.Click += btnBookingTicket_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.BurlyWood;
            panel1.Controls.Add(btnX);
            panel1.Controls.Add(lblAudienceDashboard);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(891, 85);
            panel1.TabIndex = 2;
            // 
            // btnX
            // 
            btnX.BackColor = Color.Red;
            btnX.Font = new Font("Arial Rounded MT Bold", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnX.ForeColor = Color.Transparent;
            btnX.Location = new Point(807, -4);
            btnX.Name = "btnX";
            btnX.Size = new Size(84, 44);
            btnX.TabIndex = 69;
            btnX.Text = "X";
            btnX.UseVisualStyleBackColor = false;
            btnX.Click += btnX_Click;
            // 
            // lblAudienceDashboard
            // 
            lblAudienceDashboard.AutoSize = true;
            lblAudienceDashboard.Font = new Font("Cambria", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAudienceDashboard.Location = new Point(304, 23);
            lblAudienceDashboard.Name = "lblAudienceDashboard";
            lblAudienceDashboard.Size = new Size(340, 40);
            lblAudienceDashboard.TabIndex = 2;
            lblAudienceDashboard.Text = "Audience Dashboard";
            lblAudienceDashboard.Click += label1_Click;
            // 
            // CustomerDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(894, 530);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CustomerDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CustomerDashboard";
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Button btnManageSeat;
        private Button btnFeedback;
        private Button btnBookingTicket;
        private Panel panel1;
        private Label lblAudienceDashboard;
        private Button btnX;
    }
}