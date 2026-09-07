namespace Movie_Theater_Management_System
{
    partial class SalesReport
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
            btnX = new Button();
            txtSearch = new MaskedTextBox();
            lblSearch = new Label();
            btnPrintReport = new Button();
            btnGenerateReport = new Button();
            lblSalesReportDashboard = new Label();
            dgvSalesReport = new DataGridView();
            txtTotalRevenue = new MaskedTextBox();
            txtTotalConfirmedBookings = new MaskedTextBox();
            lblTotalConfirmedBookings = new Label();
            lblTotalRevenue = new Label();
            lblSalesReport = new Label();
            lblAverageBookingValue = new Label();
            lblTotalTicketsSold = new Label();
            txtTotalTicketsSold = new TextBox();
            txtAverageBookingValue = new TextBox();
            btnClear1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSalesReport).BeginInit();
            SuspendLayout();
            // 
            // btnX
            // 
            btnX.BackColor = Color.Red;
            btnX.Font = new Font("Arial Rounded MT Bold", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnX.ForeColor = Color.Transparent;
            btnX.Location = new Point(953, -2);
            btnX.Name = "btnX";
            btnX.Size = new Size(84, 44);
            btnX.TabIndex = 113;
            btnX.Text = "X";
            btnX.UseVisualStyleBackColor = false;
            btnX.Click += btnX_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(671, 342);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(184, 27);
            txtSearch.TabIndex = 111;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSearch.Location = new Point(671, 311);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(72, 23);
            lblSearch.TabIndex = 110;
            lblSearch.Text = "Search";
            // 
            // btnPrintReport
            // 
            btnPrintReport.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrintReport.Location = new Point(771, 162);
            btnPrintReport.Name = "btnPrintReport";
            btnPrintReport.Size = new Size(206, 42);
            btnPrintReport.TabIndex = 107;
            btnPrintReport.Text = "Print Report";
            btnPrintReport.UseVisualStyleBackColor = true;
            // 
            // btnGenerateReport
            // 
            btnGenerateReport.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGenerateReport.Location = new Point(771, 106);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(206, 42);
            btnGenerateReport.TabIndex = 105;
            btnGenerateReport.Text = "Generate Report";
            btnGenerateReport.UseVisualStyleBackColor = true;
            btnGenerateReport.Click += btnGenerateReport_Click;
            // 
            // lblSalesReportDashboard
            // 
            lblSalesReportDashboard.AutoSize = true;
            lblSalesReportDashboard.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSalesReportDashboard.Location = new Point(268, 346);
            lblSalesReportDashboard.Name = "lblSalesReportDashboard";
            lblSalesReportDashboard.Size = new Size(229, 23);
            lblSalesReportDashboard.TabIndex = 104;
            lblSalesReportDashboard.Text = "Sales Report Dashboard";
            // 
            // dgvSalesReport
            // 
            dgvSalesReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSalesReport.Location = new Point(44, 380);
            dgvSalesReport.Name = "dgvSalesReport";
            dgvSalesReport.RowHeadersWidth = 51;
            dgvSalesReport.Size = new Size(811, 144);
            dgvSalesReport.TabIndex = 103;
            dgvSalesReport.CellDoubleClick += dgvSalesReport_CellDoubleClick;
            // 
            // txtTotalRevenue
            // 
            txtTotalRevenue.Location = new Point(362, 116);
            txtTotalRevenue.Name = "txtTotalRevenue";
            txtTotalRevenue.Size = new Size(281, 27);
            txtTotalRevenue.TabIndex = 102;
            // 
            // txtTotalConfirmedBookings
            // 
            txtTotalConfirmedBookings.Location = new Point(362, 168);
            txtTotalConfirmedBookings.Name = "txtTotalConfirmedBookings";
            txtTotalConfirmedBookings.Size = new Size(281, 27);
            txtTotalConfirmedBookings.TabIndex = 100;
            // 
            // lblTotalConfirmedBookings
            // 
            lblTotalConfirmedBookings.AutoSize = true;
            lblTotalConfirmedBookings.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalConfirmedBookings.Location = new Point(53, 172);
            lblTotalConfirmedBookings.Name = "lblTotalConfirmedBookings";
            lblTotalConfirmedBookings.Size = new Size(245, 23);
            lblTotalConfirmedBookings.TabIndex = 99;
            lblTotalConfirmedBookings.Text = "Total Confirmed Bookings";
            // 
            // lblTotalRevenue
            // 
            lblTotalRevenue.AutoSize = true;
            lblTotalRevenue.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalRevenue.Location = new Point(53, 120);
            lblTotalRevenue.Name = "lblTotalRevenue";
            lblTotalRevenue.Size = new Size(140, 23);
            lblTotalRevenue.TabIndex = 98;
            lblTotalRevenue.Text = "Total Revenue";
            // 
            // lblSalesReport
            // 
            lblSalesReport.AutoSize = true;
            lblSalesReport.Font = new Font("Britannic Bold", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSalesReport.Location = new Point(343, 31);
            lblSalesReport.Name = "lblSalesReport";
            lblSalesReport.Size = new Size(206, 37);
            lblSalesReport.TabIndex = 97;
            lblSalesReport.Text = "Sales Report";
            // 
            // lblAverageBookingValue
            // 
            lblAverageBookingValue.AutoSize = true;
            lblAverageBookingValue.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAverageBookingValue.Location = new Point(53, 277);
            lblAverageBookingValue.Name = "lblAverageBookingValue";
            lblAverageBookingValue.Size = new Size(219, 23);
            lblAverageBookingValue.TabIndex = 114;
            lblAverageBookingValue.Text = "Average Booking Value";
            // 
            // lblTotalTicketsSold
            // 
            lblTotalTicketsSold.AutoSize = true;
            lblTotalTicketsSold.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalTicketsSold.Location = new Point(53, 231);
            lblTotalTicketsSold.Name = "lblTotalTicketsSold";
            lblTotalTicketsSold.Size = new Size(170, 23);
            lblTotalTicketsSold.TabIndex = 115;
            lblTotalTicketsSold.Text = "Total Tickets Sold\n";
            // 
            // txtTotalTicketsSold
            // 
            txtTotalTicketsSold.Location = new Point(362, 227);
            txtTotalTicketsSold.Name = "txtTotalTicketsSold";
            txtTotalTicketsSold.Size = new Size(281, 27);
            txtTotalTicketsSold.TabIndex = 116;
            // 
            // txtAverageBookingValue
            // 
            txtAverageBookingValue.Location = new Point(362, 273);
            txtAverageBookingValue.Name = "txtAverageBookingValue";
            txtAverageBookingValue.Size = new Size(281, 27);
            txtAverageBookingValue.TabIndex = 117;
            // 
            // btnClear1
            // 
            btnClear1.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear1.Location = new Point(885, 227);
            btnClear1.Name = "btnClear1";
            btnClear1.Size = new Size(92, 42);
            btnClear1.TabIndex = 118;
            btnClear1.Text = "Clear";
            btnClear1.UseVisualStyleBackColor = true;
            btnClear1.Click += btnClear1_Click;
            // 
            // SalesReport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 128, 128);
            ClientSize = new Size(1037, 553);
            Controls.Add(btnClear1);
            Controls.Add(txtAverageBookingValue);
            Controls.Add(txtTotalTicketsSold);
            Controls.Add(lblTotalTicketsSold);
            Controls.Add(lblAverageBookingValue);
            Controls.Add(btnX);
            Controls.Add(txtSearch);
            Controls.Add(lblSearch);
            Controls.Add(btnPrintReport);
            Controls.Add(btnGenerateReport);
            Controls.Add(lblSalesReportDashboard);
            Controls.Add(dgvSalesReport);
            Controls.Add(txtTotalRevenue);
            Controls.Add(txtTotalConfirmedBookings);
            Controls.Add(lblTotalConfirmedBookings);
            Controls.Add(lblTotalRevenue);
            Controls.Add(lblSalesReport);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SalesReport";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SalesReport";
            Load += SalesReport_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSalesReport).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnX;
        private MaskedTextBox txtSearch;
        private Label lblSearch;
        private Button btnClear1;
        private Button btnPrintReport;
        private Button btnGenerateReport;
        private Label lblSalesReportDashboard;
        private DataGridView dgvSalesReport;
        private MaskedTextBox txtTotalRevenue;
        private MaskedTextBox txtTotalConfirmedBookings;
        private Label lblTotalConfirmedBookings;
        private Label lblTotalRevenue;
        private Label lblSalesReport;
        private Label lblAverageBookingValue;
        private Label lblTotalTicketsSold;
        private TextBox txtTotalTicketsSold;
        private TextBox txtAverageBookingValue;
    }
}