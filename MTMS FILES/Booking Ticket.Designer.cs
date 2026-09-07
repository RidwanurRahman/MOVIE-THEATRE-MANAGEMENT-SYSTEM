namespace Movie_Theater_Management_System
{
    partial class Booking_Ticket
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
            lblBookingTicket = new Label();
            lblTicketStatus = new Label();
            lblTotalPrice = new Label();
            lblQuantity = new Label();
            dgvBookingTicket = new DataGridView();
            txtSearch = new MaskedTextBox();
            lblSearch = new Label();
            btnClear = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnAdd = new Button();
            txtTotalPrice = new MaskedTextBox();
            txtQuantity = new MaskedTextBox();
            lblBookingDate = new Label();
            lblSeatID = new Label();
            lblShowID = new Label();
            txtUserID = new MaskedTextBox();
            lblUserID = new Label();
            txtBookingID = new MaskedTextBox();
            lblBookingID = new Label();
            txtShowID = new MaskedTextBox();
            txtSeatID = new MaskedTextBox();
            dtpBookingDate = new DateTimePicker();
            button1 = new Button();
            cmbTicketStatus = new ComboBox();
            dgvShowsDashboard = new DataGridView();
            dgvSeatDashboard = new DataGridView();
            lblShowsDashboard = new Label();
            lblSeatDashboard = new Label();
            lblBookingTicket2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvBookingTicket).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvShowsDashboard).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSeatDashboard).BeginInit();
            SuspendLayout();
            // 
            // btnX
            // 
            btnX.BackColor = Color.Red;
            btnX.Font = new Font("Arial Rounded MT Bold", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnX.ForeColor = Color.Transparent;
            btnX.Location = new Point(973, -55);
            btnX.Name = "btnX";
            btnX.Size = new Size(84, 44);
            btnX.TabIndex = 95;
            btnX.Text = "X";
            btnX.UseVisualStyleBackColor = false;
            // 
            // lblBookingTicket
            // 
            lblBookingTicket.Anchor = AnchorStyles.None;
            lblBookingTicket.AutoSize = true;
            lblBookingTicket.Font = new Font("Britannic Bold", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBookingTicket.Location = new Point(565, 13);
            lblBookingTicket.Name = "lblBookingTicket";
            lblBookingTicket.Size = new Size(240, 37);
            lblBookingTicket.TabIndex = 69;
            lblBookingTicket.Text = "Booking Ticket";
            // 
            // lblTicketStatus
            // 
            lblTicketStatus.AutoSize = true;
            lblTicketStatus.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTicketStatus.Location = new Point(25, 483);
            lblTicketStatus.Name = "lblTicketStatus";
            lblTicketStatus.Size = new Size(131, 23);
            lblTicketStatus.TabIndex = 94;
            lblTicketStatus.Text = "Ticket_Status";
            // 
            // lblTotalPrice
            // 
            lblTotalPrice.AutoSize = true;
            lblTotalPrice.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalPrice.Location = new Point(25, 429);
            lblTotalPrice.Name = "lblTotalPrice";
            lblTotalPrice.Size = new Size(103, 23);
            lblTotalPrice.TabIndex = 93;
            lblTotalPrice.Text = "TotalPrice";
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblQuantity.Location = new Point(25, 370);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(90, 23);
            lblQuantity.TabIndex = 92;
            lblQuantity.Text = "Quantity";
            // 
            // dgvBookingTicket
            // 
            dgvBookingTicket.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBookingTicket.Location = new Point(614, 513);
            dgvBookingTicket.Name = "dgvBookingTicket";
            dgvBookingTicket.RowHeadersWidth = 51;
            dgvBookingTicket.Size = new Size(791, 144);
            dgvBookingTicket.TabIndex = 88;
            dgvBookingTicket.CellDoubleClick += dgvBookingTicket_CellDoubleClick;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(1188, 474);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(213, 27);
            txtSearch.TabIndex = 85;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSearch.Location = new Point(1188, 448);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(72, 23);
            lblSearch.TabIndex = 84;
            lblSearch.Text = "Search";
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.Location = new Point(475, 244);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 42);
            btnClear.TabIndex = 82;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.Location = new Point(475, 141);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 42);
            btnUpdate.TabIndex = 81;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(475, 194);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 42);
            btnDelete.TabIndex = 80;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.Location = new Point(475, 87);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 42);
            btnAdd.TabIndex = 79;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtTotalPrice
            // 
            txtTotalPrice.Location = new Point(204, 429);
            txtTotalPrice.Name = "txtTotalPrice";
            txtTotalPrice.Size = new Size(213, 27);
            txtTotalPrice.TabIndex = 78;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(204, 370);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(213, 27);
            txtQuantity.TabIndex = 77;
            // 
            // lblBookingDate
            // 
            lblBookingDate.AutoSize = true;
            lblBookingDate.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBookingDate.Location = new Point(25, 322);
            lblBookingDate.Name = "lblBookingDate";
            lblBookingDate.Size = new Size(128, 23);
            lblBookingDate.TabIndex = 76;
            lblBookingDate.Text = "BookingDate";
            // 
            // lblSeatID
            // 
            lblSeatID.AutoSize = true;
            lblSeatID.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSeatID.Location = new Point(37, 256);
            lblSeatID.Name = "lblSeatID";
            lblSeatID.Size = new Size(70, 23);
            lblSeatID.TabIndex = 75;
            lblSeatID.Text = "SeatID";
            // 
            // lblShowID
            // 
            lblShowID.AutoSize = true;
            lblShowID.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblShowID.Location = new Point(37, 202);
            lblShowID.Name = "lblShowID";
            lblShowID.Size = new Size(80, 23);
            lblShowID.TabIndex = 74;
            lblShowID.Text = "ShowID";
            // 
            // txtUserID
            // 
            txtUserID.Location = new Point(204, 139);
            txtUserID.Name = "txtUserID";
            txtUserID.Size = new Size(213, 27);
            txtUserID.TabIndex = 73;
            // 
            // lblUserID
            // 
            lblUserID.AutoSize = true;
            lblUserID.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserID.Location = new Point(37, 143);
            lblUserID.Name = "lblUserID";
            lblUserID.Size = new Size(74, 23);
            lblUserID.TabIndex = 72;
            lblUserID.Text = "UserID";
            // 
            // txtBookingID
            // 
            txtBookingID.Location = new Point(204, 87);
            txtBookingID.Name = "txtBookingID";
            txtBookingID.Size = new Size(213, 27);
            txtBookingID.TabIndex = 71;
            // 
            // lblBookingID
            // 
            lblBookingID.AutoSize = true;
            lblBookingID.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBookingID.Location = new Point(37, 91);
            lblBookingID.Name = "lblBookingID";
            lblBookingID.Size = new Size(106, 23);
            lblBookingID.TabIndex = 70;
            lblBookingID.Text = "BookingID";
            // 
            // txtShowID
            // 
            txtShowID.Location = new Point(204, 202);
            txtShowID.Name = "txtShowID";
            txtShowID.Size = new Size(213, 27);
            txtShowID.TabIndex = 96;
            // 
            // txtSeatID
            // 
            txtSeatID.Location = new Point(204, 257);
            txtSeatID.Name = "txtSeatID";
            txtSeatID.Size = new Size(213, 27);
            txtSeatID.TabIndex = 97;
            // 
            // dtpBookingDate
            // 
            dtpBookingDate.Format = DateTimePickerFormat.Custom;
            dtpBookingDate.Location = new Point(204, 318);
            dtpBookingDate.Name = "dtpBookingDate";
            dtpBookingDate.Size = new Size(213, 27);
            dtpBookingDate.TabIndex = 98;
            // 
            // button1
            // 
            button1.BackColor = Color.Red;
            button1.Font = new Font("Arial Rounded MT Bold", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Transparent;
            button1.Location = new Point(1344, -3);
            button1.Name = "button1";
            button1.Size = new Size(84, 44);
            button1.TabIndex = 99;
            button1.Text = "X";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // cmbTicketStatus
            // 
            cmbTicketStatus.FormattingEnabled = true;
            cmbTicketStatus.Items.AddRange(new object[] { "Confirmed", "Pending", "Cancelled" });
            cmbTicketStatus.Location = new Point(204, 478);
            cmbTicketStatus.Name = "cmbTicketStatus";
            cmbTicketStatus.Size = new Size(213, 28);
            cmbTicketStatus.TabIndex = 100;
            // 
            // dgvShowsDashboard
            // 
            dgvShowsDashboard.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvShowsDashboard.Location = new Point(614, 129);
            dgvShowsDashboard.Name = "dgvShowsDashboard";
            dgvShowsDashboard.RowHeadersWidth = 51;
            dgvShowsDashboard.Size = new Size(791, 124);
            dgvShowsDashboard.TabIndex = 101;
            dgvShowsDashboard.CellDoubleClick += dgvShowsDashboard_CellDoubleClick;
            // 
            // dgvSeatDashboard
            // 
            dgvSeatDashboard.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSeatDashboard.Location = new Point(614, 301);
            dgvSeatDashboard.Name = "dgvSeatDashboard";
            dgvSeatDashboard.RowHeadersWidth = 51;
            dgvSeatDashboard.Size = new Size(791, 112);
            dgvSeatDashboard.TabIndex = 102;
            dgvSeatDashboard.CellDoubleClick += dgvSeatDashboard_CellDoubleClick;
            // 
            // lblShowsDashboard
            // 
            lblShowsDashboard.AutoSize = true;
            lblShowsDashboard.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblShowsDashboard.Location = new Point(938, 88);
            lblShowsDashboard.Name = "lblShowsDashboard";
            lblShowsDashboard.Size = new Size(173, 23);
            lblShowsDashboard.TabIndex = 103;
            lblShowsDashboard.Text = "Shows Dashboard";
            // 
            // lblSeatDashboard
            // 
            lblSeatDashboard.AutoSize = true;
            lblSeatDashboard.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSeatDashboard.Location = new Point(957, 264);
            lblSeatDashboard.Name = "lblSeatDashboard";
            lblSeatDashboard.Size = new Size(154, 23);
            lblSeatDashboard.TabIndex = 104;
            lblSeatDashboard.Text = "Seat Dashboard";
            // 
            // lblBookingTicket2
            // 
            lblBookingTicket2.AutoSize = true;
            lblBookingTicket2.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBookingTicket2.Location = new Point(973, 478);
            lblBookingTicket2.Name = "lblBookingTicket2";
            lblBookingTicket2.Size = new Size(147, 23);
            lblBookingTicket2.TabIndex = 113;
            lblBookingTicket2.Text = "Booking Ticket";
            // 
            // Booking_Ticket
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 128, 128);
            ClientSize = new Size(1426, 659);
            Controls.Add(lblBookingTicket2);
            Controls.Add(lblSeatDashboard);
            Controls.Add(lblShowsDashboard);
            Controls.Add(dgvSeatDashboard);
            Controls.Add(dgvShowsDashboard);
            Controls.Add(cmbTicketStatus);
            Controls.Add(button1);
            Controls.Add(dtpBookingDate);
            Controls.Add(txtSeatID);
            Controls.Add(txtShowID);
            Controls.Add(btnX);
            Controls.Add(lblBookingTicket);
            Controls.Add(lblTicketStatus);
            Controls.Add(lblTotalPrice);
            Controls.Add(lblQuantity);
            Controls.Add(dgvBookingTicket);
            Controls.Add(txtSearch);
            Controls.Add(lblSearch);
            Controls.Add(btnClear);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(txtTotalPrice);
            Controls.Add(txtQuantity);
            Controls.Add(lblBookingDate);
            Controls.Add(lblSeatID);
            Controls.Add(lblShowID);
            Controls.Add(txtUserID);
            Controls.Add(lblUserID);
            Controls.Add(txtBookingID);
            Controls.Add(lblBookingID);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Booking_Ticket";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Booking_Ticket";
            Load += Booking_Ticket_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBookingTicket).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvShowsDashboard).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSeatDashboard).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnX;
        private Label lblBookingTicket;
        private Label lblTicketStatus;
        private Label lblTotalPrice;
        private Label lblQuantity;
        private DateTimePicker dtpShowTime;
        private DateTimePicker dtpShowDate;
        private DataGridView dgvBookingTicket;
        private MaskedTextBox txtSearch;
        private Label lblSearch;
        private Button btnClear;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnAdd;
        private MaskedTextBox txtTotalPrice;
        private MaskedTextBox txtQuantity;
        private Label lblBookingDate;
        private Label lblSeatID;
        private Label lblShowID;
        private MaskedTextBox txtUserID;
        private Label lblUserID;
        private MaskedTextBox txtBookingID;
        private Label lblBookingID;
        private MaskedTextBox txtShowID;
        private MaskedTextBox txtSeatID;
        private DateTimePicker dtpBookingDate;
        private Button button1;
        private ComboBox cmbTicketStatus;
        private DataGridView dgvShowsDashboard;
        private DataGridView dgvSeatDashboard;
        private Label lblShowsDashboard;
        private Label lblSeatDashboard;
        private Label lblBookingTicket2;
    }
}