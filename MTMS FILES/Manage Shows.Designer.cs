namespace Movie_Theater_Management_System
{
    partial class Manage_Shows
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
            cmbSHallNo = new ComboBox();
            txtSearch = new MaskedTextBox();
            lblSearch = new Label();
            btnClear = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnAdd = new Button();
            txtSTotalSeats = new MaskedTextBox();
            txtSPrice = new MaskedTextBox();
            lblSHallNo = new Label();
            lblShowTime = new Label();
            lblShowDate = new Label();
            txtMovieID = new MaskedTextBox();
            lblMovieID = new Label();
            txtShowID = new MaskedTextBox();
            lblShowID = new Label();
            lblX = new Label();
            dgvManageShows = new DataGridView();
            dtpShowTime = new DateTimePicker();
            txtSAvailableSeats = new MaskedTextBox();
            lblSPrice = new Label();
            lblSTotalSeats = new Label();
            lblSAvailableSeats = new Label();
            lblManageMovies = new Label();
            btnX = new Button();
            dgvMovieDashboard = new DataGridView();
            lblMovieDashboard = new Label();
            lblShowsDashboard = new Label();
            txtShowDate = new MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)dgvManageShows).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMovieDashboard).BeginInit();
            SuspendLayout();
            // 
            // cmbSHallNo
            // 
            cmbSHallNo.FormattingEnabled = true;
            cmbSHallNo.Items.AddRange(new object[] { "H1", "H2", "H3", "H4", "VIP1", "VIP2" });
            cmbSHallNo.Location = new Point(203, 311);
            cmbSHallNo.Name = "cmbSHallNo";
            cmbSHallNo.Size = new Size(213, 28);
            cmbSHallNo.TabIndex = 58;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(985, 416);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(165, 27);
            txtSearch.TabIndex = 56;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSearch.Location = new Point(985, 390);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(72, 23);
            lblSearch.TabIndex = 55;
            lblSearch.Text = "Search";
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.Location = new Point(898, 97);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 42);
            btnClear.TabIndex = 53;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.Location = new Point(781, 97);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 42);
            btnUpdate.TabIndex = 52;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(667, 97);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 42);
            btnDelete.TabIndex = 51;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.Location = new Point(546, 97);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 42);
            btnAdd.TabIndex = 50;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtSTotalSeats
            // 
            txtSTotalSeats.Location = new Point(203, 418);
            txtSTotalSeats.Name = "txtSTotalSeats";
            txtSTotalSeats.Size = new Size(213, 27);
            txtSTotalSeats.TabIndex = 46;
            // 
            // txtSPrice
            // 
            txtSPrice.Location = new Point(203, 359);
            txtSPrice.Name = "txtSPrice";
            txtSPrice.Size = new Size(213, 27);
            txtSPrice.TabIndex = 44;
            // 
            // lblSHallNo
            // 
            lblSHallNo.AutoSize = true;
            lblSHallNo.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSHallNo.Location = new Point(17, 311);
            lblSHallNo.Name = "lblSHallNo";
            lblSHallNo.Size = new Size(89, 23);
            lblSHallNo.TabIndex = 42;
            lblSHallNo.Text = "S_HallNo";
            // 
            // lblShowTime
            // 
            lblShowTime.AutoSize = true;
            lblShowTime.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblShowTime.Location = new Point(17, 266);
            lblShowTime.Name = "lblShowTime";
            lblShowTime.Size = new Size(107, 23);
            lblShowTime.TabIndex = 40;
            lblShowTime.Text = "ShowTime";
            // 
            // lblShowDate
            // 
            lblShowDate.AutoSize = true;
            lblShowDate.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblShowDate.Location = new Point(17, 212);
            lblShowDate.Name = "lblShowDate";
            lblShowDate.Size = new Size(102, 23);
            lblShowDate.TabIndex = 39;
            lblShowDate.Text = "ShowDate";
            // 
            // txtMovieID
            // 
            txtMovieID.Location = new Point(203, 149);
            txtMovieID.Name = "txtMovieID";
            txtMovieID.Size = new Size(213, 27);
            txtMovieID.TabIndex = 38;
            // 
            // lblMovieID
            // 
            lblMovieID.AutoSize = true;
            lblMovieID.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMovieID.Location = new Point(17, 153);
            lblMovieID.Name = "lblMovieID";
            lblMovieID.Size = new Size(87, 23);
            lblMovieID.TabIndex = 37;
            lblMovieID.Text = "MovieID";
            // 
            // txtShowID
            // 
            txtShowID.Location = new Point(203, 97);
            txtShowID.Name = "txtShowID";
            txtShowID.Size = new Size(213, 27);
            txtShowID.TabIndex = 36;
            // 
            // lblShowID
            // 
            lblShowID.AutoSize = true;
            lblShowID.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblShowID.Location = new Point(17, 101);
            lblShowID.Name = "lblShowID";
            lblShowID.Size = new Size(80, 23);
            lblShowID.TabIndex = 35;
            lblShowID.Text = "ShowID";
            // 
            // lblX
            // 
            lblX.AutoSize = true;
            lblX.BackColor = Color.Gray;
            lblX.Font = new Font("Britannic Bold", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblX.ForeColor = SystemColors.Control;
            lblX.Location = new Point(1012, 8);
            lblX.Name = "lblX";
            lblX.Size = new Size(56, 37);
            lblX.TabIndex = 34;
            lblX.Text = " X ";
            // 
            // dgvManageShows
            // 
            dgvManageShows.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvManageShows.Location = new Point(467, 449);
            dgvManageShows.Name = "dgvManageShows";
            dgvManageShows.RowHeadersWidth = 51;
            dgvManageShows.Size = new Size(691, 194);
            dgvManageShows.TabIndex = 61;
            dgvManageShows.CellDoubleClick += dgvManageShows_CellDoubleClick;
            // 
            // dtpShowTime
            // 
            dtpShowTime.Format = DateTimePickerFormat.Time;
            dtpShowTime.Location = new Point(203, 267);
            dtpShowTime.Name = "dtpShowTime";
            dtpShowTime.ShowUpDown = true;
            dtpShowTime.Size = new Size(213, 27);
            dtpShowTime.TabIndex = 63;
            // 
            // txtSAvailableSeats
            // 
            txtSAvailableSeats.Location = new Point(203, 472);
            txtSAvailableSeats.Name = "txtSAvailableSeats";
            txtSAvailableSeats.Size = new Size(213, 27);
            txtSAvailableSeats.TabIndex = 64;
            // 
            // lblSPrice
            // 
            lblSPrice.AutoSize = true;
            lblSPrice.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSPrice.Location = new Point(17, 359);
            lblSPrice.Name = "lblSPrice";
            lblSPrice.Size = new Size(74, 23);
            lblSPrice.TabIndex = 65;
            lblSPrice.Text = "S_Price";
            // 
            // lblSTotalSeats
            // 
            lblSTotalSeats.AutoSize = true;
            lblSTotalSeats.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSTotalSeats.Location = new Point(17, 418);
            lblSTotalSeats.Name = "lblSTotalSeats";
            lblSTotalSeats.Size = new Size(121, 23);
            lblSTotalSeats.TabIndex = 66;
            lblSTotalSeats.Text = "S_TotalSeats";
            // 
            // lblSAvailableSeats
            // 
            lblSAvailableSeats.AutoSize = true;
            lblSAvailableSeats.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSAvailableSeats.Location = new Point(17, 472);
            lblSAvailableSeats.Name = "lblSAvailableSeats";
            lblSAvailableSeats.Size = new Size(161, 23);
            lblSAvailableSeats.TabIndex = 67;
            lblSAvailableSeats.Text = "S_AvailableSeats";
            // 
            // lblManageMovies
            // 
            lblManageMovies.Anchor = AnchorStyles.None;
            lblManageMovies.AutoSize = true;
            lblManageMovies.Font = new Font("Britannic Bold", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblManageMovies.Location = new Point(435, 9);
            lblManageMovies.Name = "lblManageMovies";
            lblManageMovies.Size = new Size(236, 37);
            lblManageMovies.TabIndex = 33;
            lblManageMovies.Text = "Manage Shows";
            // 
            // btnX
            // 
            btnX.BackColor = Color.Red;
            btnX.Font = new Font("Arial Rounded MT Bold", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnX.ForeColor = Color.Transparent;
            btnX.Location = new Point(1080, -2);
            btnX.Name = "btnX";
            btnX.Size = new Size(84, 44);
            btnX.TabIndex = 68;
            btnX.Text = "X";
            btnX.UseVisualStyleBackColor = false;
            btnX.Click += btnX_Click;
            // 
            // dgvMovieDashboard
            // 
            dgvMovieDashboard.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMovieDashboard.Location = new Point(467, 186);
            dgvMovieDashboard.Name = "dgvMovieDashboard";
            dgvMovieDashboard.RowHeadersWidth = 51;
            dgvMovieDashboard.Size = new Size(691, 165);
            dgvMovieDashboard.TabIndex = 69;
            dgvMovieDashboard.CellContentDoubleClick += dgvMovieDashboard_CellDoubleClick;
            // 
            // lblMovieDashboard
            // 
            lblMovieDashboard.AutoSize = true;
            lblMovieDashboard.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMovieDashboard.Location = new Point(723, 151);
            lblMovieDashboard.Name = "lblMovieDashboard";
            lblMovieDashboard.Size = new Size(171, 23);
            lblMovieDashboard.TabIndex = 70;
            lblMovieDashboard.Text = "Movie Dashboard";
            // 
            // lblShowsDashboard
            // 
            lblShowsDashboard.AutoSize = true;
            lblShowsDashboard.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblShowsDashboard.Location = new Point(732, 416);
            lblShowsDashboard.Name = "lblShowsDashboard";
            lblShowsDashboard.Size = new Size(173, 23);
            lblShowsDashboard.TabIndex = 71;
            lblShowsDashboard.Text = "Shows Dashboard";
            // 
            // txtShowDate
            // 
            txtShowDate.Location = new Point(203, 212);
            txtShowDate.Name = "txtShowDate";
            txtShowDate.Size = new Size(213, 27);
            txtShowDate.TabIndex = 72;
            // 
            // Manage_Shows
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 128, 128);
            ClientSize = new Size(1162, 641);
            Controls.Add(txtShowDate);
            Controls.Add(lblShowsDashboard);
            Controls.Add(lblMovieDashboard);
            Controls.Add(dgvMovieDashboard);
            Controls.Add(btnX);
            Controls.Add(lblManageMovies);
            Controls.Add(lblSAvailableSeats);
            Controls.Add(lblSTotalSeats);
            Controls.Add(lblSPrice);
            Controls.Add(txtSAvailableSeats);
            Controls.Add(dtpShowTime);
            Controls.Add(dgvManageShows);
            Controls.Add(cmbSHallNo);
            Controls.Add(txtSearch);
            Controls.Add(lblSearch);
            Controls.Add(btnClear);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(txtSTotalSeats);
            Controls.Add(txtSPrice);
            Controls.Add(lblSHallNo);
            Controls.Add(lblShowTime);
            Controls.Add(lblShowDate);
            Controls.Add(txtMovieID);
            Controls.Add(lblMovieID);
            Controls.Add(txtShowID);
            Controls.Add(lblShowID);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Manage_Shows";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Manage_Shows";
            Load += ManageShows_Load;
            ((System.ComponentModel.ISupportInitialize)dgvManageShows).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMovieDashboard).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox cmbSHallNo;
        private MaskedTextBox txtSearch;
        private Label lblSearch;
        private Button btnClear;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnAdd;
        private MaskedTextBox txtMReleaseDate;
        private Label lblMReleaseDate;
        private Label lblMStatus;
        private MaskedTextBox txtSTotalSeats;
        private Label lblMPosterPath;
        private MaskedTextBox txtSPrice;
        private Label lblMRating;
        private Label lblSHallNo;
        private Label lblShowTime;
        private Label lblShowDate;
        private MaskedTextBox txtMovieID;
        private Label lblMovieID;
        private MaskedTextBox txtShowID;
        private Label lblShowID;
        private Label lblX;
        private DataGridView dgvManageShows;
        private DateTimePicker dtpShowTime;
        private MaskedTextBox txtSAvailableSeats;
        private Label lblSPrice;
        private Label lblSTotalSeats;
        private Label lblSAvailableSeats;
        private Label lblManageMovies;
        private Button btnX;
        private DataGridView dgvMovieDashboard;
        private Label lblMovieDashboard;
        private Label lblShowsDashboard;
        private MaskedTextBox txtShowDate;
    }
}