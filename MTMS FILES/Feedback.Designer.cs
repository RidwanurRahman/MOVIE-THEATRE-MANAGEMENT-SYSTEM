namespace Movie_Theater_Management_System
{
    partial class Feedback
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
            button1 = new Button();
            txtMovieID = new MaskedTextBox();
            lblAudienceFeedback = new Label();
            dgvAudienceFeedback = new DataGridView();
            txtSearch = new MaskedTextBox();
            lblSearch = new Label();
            btnClear = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnAdd = new Button();
            txtFComment = new MaskedTextBox();
            lblFRating = new Label();
            lblMovieID = new Label();
            txtUserID = new MaskedTextBox();
            lblUserID = new Label();
            txtFeedbackID = new MaskedTextBox();
            lblFeedbackID = new Label();
            dtpFReviewDate = new DateTimePicker();
            txtFRating = new MaskedTextBox();
            lblFReviewDate = new Label();
            lblFComment = new Label();
            dgvBookingTickets = new DataGridView();
            lblBookingTickets = new Label();
            lblFeedback = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvAudienceFeedback).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvBookingTickets).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Red;
            button1.Font = new Font("Arial Rounded MT Bold", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Transparent;
            button1.Location = new Point(1087, -2);
            button1.Name = "button1";
            button1.Size = new Size(84, 44);
            button1.TabIndex = 126;
            button1.Text = "X";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // txtMovieID
            // 
            txtMovieID.Location = new Point(183, 207);
            txtMovieID.Name = "txtMovieID";
            txtMovieID.Size = new Size(213, 27);
            txtMovieID.TabIndex = 123;
            // 
            // lblAudienceFeedback
            // 
            lblAudienceFeedback.Anchor = AnchorStyles.None;
            lblAudienceFeedback.AutoSize = true;
            lblAudienceFeedback.Font = new Font("Britannic Bold", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAudienceFeedback.Location = new Point(437, 21);
            lblAudienceFeedback.Name = "lblAudienceFeedback";
            lblAudienceFeedback.Size = new Size(309, 37);
            lblAudienceFeedback.TabIndex = 101;
            lblAudienceFeedback.Text = "Audience_Feedback";
            // 
            // dgvAudienceFeedback
            // 
            dgvAudienceFeedback.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAudienceFeedback.Location = new Point(429, 418);
            dgvAudienceFeedback.Name = "dgvAudienceFeedback";
            dgvAudienceFeedback.RowHeadersWidth = 51;
            dgvAudienceFeedback.Size = new Size(722, 186);
            dgvAudienceFeedback.TabIndex = 119;
            dgvAudienceFeedback.CellDoubleClick += dgvAudienceFeedback_CellDoubleClick;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(938, 373);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(213, 27);
            txtSearch.TabIndex = 117;
            txtSearch.MaskInputRejected += txtSearch_MaskInputRejected;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSearch.Location = new Point(1003, 347);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(72, 23);
            lblSearch.TabIndex = 116;
            lblSearch.Text = "Search";
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.Location = new Point(258, 512);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 42);
            btnClear.TabIndex = 114;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.Location = new Point(49, 504);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 42);
            btnUpdate.TabIndex = 113;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(258, 450);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 42);
            btnDelete.TabIndex = 112;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.Location = new Point(49, 450);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 42);
            btnAdd.TabIndex = 111;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtFComment
            // 
            txtFComment.Location = new Point(183, 314);
            txtFComment.Name = "txtFComment";
            txtFComment.Size = new Size(213, 27);
            txtFComment.TabIndex = 109;
            // 
            // lblFRating
            // 
            lblFRating.AutoSize = true;
            lblFRating.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFRating.Location = new Point(24, 266);
            lblFRating.Name = "lblFRating";
            lblFRating.Size = new Size(87, 23);
            lblFRating.TabIndex = 108;
            lblFRating.Text = "F_Rating";
            // 
            // lblMovieID
            // 
            lblMovieID.AutoSize = true;
            lblMovieID.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMovieID.Location = new Point(16, 207);
            lblMovieID.Name = "lblMovieID";
            lblMovieID.Size = new Size(87, 23);
            lblMovieID.TabIndex = 106;
            lblMovieID.Text = "MovieID";
            // 
            // txtUserID
            // 
            txtUserID.Location = new Point(183, 144);
            txtUserID.Name = "txtUserID";
            txtUserID.Size = new Size(213, 27);
            txtUserID.TabIndex = 105;
            // 
            // lblUserID
            // 
            lblUserID.AutoSize = true;
            lblUserID.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserID.Location = new Point(26, 148);
            lblUserID.Name = "lblUserID";
            lblUserID.Size = new Size(74, 23);
            lblUserID.TabIndex = 104;
            lblUserID.Text = "UserID";
            // 
            // txtFeedbackID
            // 
            txtFeedbackID.Location = new Point(183, 92);
            txtFeedbackID.Name = "txtFeedbackID";
            txtFeedbackID.Size = new Size(213, 27);
            txtFeedbackID.TabIndex = 103;
            // 
            // lblFeedbackID
            // 
            lblFeedbackID.AutoSize = true;
            lblFeedbackID.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFeedbackID.Location = new Point(16, 96);
            lblFeedbackID.Name = "lblFeedbackID";
            lblFeedbackID.Size = new Size(119, 23);
            lblFeedbackID.TabIndex = 102;
            lblFeedbackID.Text = "FeedbackID";
            // 
            // dtpFReviewDate
            // 
            dtpFReviewDate.Format = DateTimePickerFormat.Custom;
            dtpFReviewDate.Location = new Point(183, 371);
            dtpFReviewDate.Name = "dtpFReviewDate";
            dtpFReviewDate.Size = new Size(213, 27);
            dtpFReviewDate.TabIndex = 127;
            // 
            // txtFRating
            // 
            txtFRating.Location = new Point(183, 262);
            txtFRating.Name = "txtFRating";
            txtFRating.Size = new Size(213, 27);
            txtFRating.TabIndex = 128;
            // 
            // lblFReviewDate
            // 
            lblFReviewDate.AutoSize = true;
            lblFReviewDate.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFReviewDate.Location = new Point(24, 373);
            lblFReviewDate.Name = "lblFReviewDate";
            lblFReviewDate.Size = new Size(139, 23);
            lblFReviewDate.TabIndex = 129;
            lblFReviewDate.Text = "F_ReviewDate";
            lblFReviewDate.Click += label1_Click;
            // 
            // lblFComment
            // 
            lblFComment.AutoSize = true;
            lblFComment.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFComment.Location = new Point(24, 314);
            lblFComment.Name = "lblFComment";
            lblFComment.Size = new Size(116, 23);
            lblFComment.TabIndex = 130;
            lblFComment.Text = "F_Comment";
            // 
            // dgvBookingTickets
            // 
            dgvBookingTickets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBookingTickets.Location = new Point(429, 123);
            dgvBookingTickets.Name = "dgvBookingTickets";
            dgvBookingTickets.RowHeadersWidth = 51;
            dgvBookingTickets.Size = new Size(722, 161);
            dgvBookingTickets.TabIndex = 131;
            dgvBookingTickets.CellDoubleClick += dgvBookingTickets_CellDoubleClick;
            // 
            // lblBookingTickets
            // 
            lblBookingTickets.AutoSize = true;
            lblBookingTickets.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBookingTickets.Location = new Point(704, 90);
            lblBookingTickets.Name = "lblBookingTickets";
            lblBookingTickets.Size = new Size(172, 23);
            lblBookingTickets.TabIndex = 136;
            lblBookingTickets.Text = "Booking Ticket(s)";
            // 
            // lblFeedback
            // 
            lblFeedback.AutoSize = true;
            lblFeedback.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFeedback.Location = new Point(692, 378);
            lblFeedback.Name = "lblFeedback";
            lblFeedback.Size = new Size(98, 23);
            lblFeedback.TabIndex = 137;
            lblFeedback.Text = "Feedback";
            // 
            // Feedback
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 128, 128);
            ClientSize = new Size(1169, 606);
            Controls.Add(lblFeedback);
            Controls.Add(lblBookingTickets);
            Controls.Add(dgvBookingTickets);
            Controls.Add(lblFComment);
            Controls.Add(lblFReviewDate);
            Controls.Add(txtFRating);
            Controls.Add(dtpFReviewDate);
            Controls.Add(button1);
            Controls.Add(txtMovieID);
            Controls.Add(lblAudienceFeedback);
            Controls.Add(dgvAudienceFeedback);
            Controls.Add(txtSearch);
            Controls.Add(lblSearch);
            Controls.Add(btnClear);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(txtFComment);
            Controls.Add(lblFRating);
            Controls.Add(lblMovieID);
            Controls.Add(txtUserID);
            Controls.Add(lblUserID);
            Controls.Add(txtFeedbackID);
            Controls.Add(lblFeedbackID);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Feedback";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "-*/";
            Load += Feedback_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAudienceFeedback).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvBookingTickets).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbTicketStatus;
        private Button button1;
        private MaskedTextBox txtSeatID;
        private MaskedTextBox txtMovieID;
        private Label lblAudienceFeedback;
        private Label lblTicketStatus;
        private Label lblTotalPrice;
        private Label lblQuantity;
        private DataGridView dgvAudienceFeedback;
        private MaskedTextBox txtSearch;
        private Label lblSearch;
        private Button btnClear;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnAdd;
        private MaskedTextBox txtTotalPrice;
        private MaskedTextBox txtFComment;
        private Label lblFRating;
        private Label lblSeatID;
        private Label lblMovieID;
        private MaskedTextBox txtUserID;
        private Label lblUserID;
        private MaskedTextBox txtFeedbackID;
        private Label lblFeedbackID;
        private DateTimePicker dtpFReviewDate;
        private MaskedTextBox txtFRating;
        private Label lblFReviewDate;
        private Label lblFComment;
        private DataGridView dgvBookingTickets;
        private Label lblBookingTickets;
        private Label lblFeedback;
    }
}