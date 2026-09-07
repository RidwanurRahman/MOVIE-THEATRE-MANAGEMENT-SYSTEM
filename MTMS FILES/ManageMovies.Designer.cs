namespace Movie_Theater_Management_System
{
    partial class ManageMovies
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
            lblManageMovies = new Label();
            lblMovieID = new Label();
            txtMovieID = new MaskedTextBox();
            txtMTitle = new MaskedTextBox();
            lblMTitle = new Label();
            lblMGenre = new Label();
            lblMDuration = new Label();
            lblMLanguage = new Label();
            txtMRating = new MaskedTextBox();
            lblMRating = new Label();
            lblMStatus = new Label();
            lblMReleaseDate = new Label();
            dgvManageMovies = new DataGridView();
            btnAdd = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnClear = new Button();
            txtSearch = new MaskedTextBox();
            lblSearch = new Label();
            cmbMGenre = new ComboBox();
            cmbMLanguage = new ComboBox();
            cmbMStatus = new ComboBox();
            lblX = new Label();
            txtMDuration = new MaskedTextBox();
            txtMReleaseDate = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvManageMovies).BeginInit();
            SuspendLayout();
            // 
            // lblManageMovies
            // 
            lblManageMovies.AutoSize = true;
            lblManageMovies.Font = new Font("Britannic Bold", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblManageMovies.Location = new Point(427, 24);
            lblManageMovies.Name = "lblManageMovies";
            lblManageMovies.Size = new Size(243, 37);
            lblManageMovies.TabIndex = 0;
            lblManageMovies.Text = "Manage Movies";
            // 
            // lblMovieID
            // 
            lblMovieID.AutoSize = true;
            lblMovieID.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMovieID.Location = new Point(59, 123);
            lblMovieID.Name = "lblMovieID";
            lblMovieID.Size = new Size(87, 23);
            lblMovieID.TabIndex = 2;
            lblMovieID.Text = "MovieID";
            // 
            // txtMovieID
            // 
            txtMovieID.Location = new Point(226, 119);
            txtMovieID.Name = "txtMovieID";
            txtMovieID.Size = new Size(213, 27);
            txtMovieID.TabIndex = 3;
            // 
            // txtMTitle
            // 
            txtMTitle.Location = new Point(226, 171);
            txtMTitle.Name = "txtMTitle";
            txtMTitle.Size = new Size(213, 27);
            txtMTitle.TabIndex = 5;
            // 
            // lblMTitle
            // 
            lblMTitle.AutoSize = true;
            lblMTitle.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMTitle.Location = new Point(59, 175);
            lblMTitle.Name = "lblMTitle";
            lblMTitle.Size = new Size(77, 23);
            lblMTitle.TabIndex = 4;
            lblMTitle.Text = "M_Title";
            // 
            // lblMGenre
            // 
            lblMGenre.AutoSize = true;
            lblMGenre.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMGenre.Location = new Point(59, 234);
            lblMGenre.Name = "lblMGenre";
            lblMGenre.Size = new Size(90, 23);
            lblMGenre.TabIndex = 6;
            lblMGenre.Text = "M_Genre";
            // 
            // lblMDuration
            // 
            lblMDuration.AutoSize = true;
            lblMDuration.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMDuration.Location = new Point(59, 288);
            lblMDuration.Name = "lblMDuration";
            lblMDuration.Size = new Size(116, 23);
            lblMDuration.TabIndex = 8;
            lblMDuration.Text = "M_Duration";
            // 
            // lblMLanguage
            // 
            lblMLanguage.AutoSize = true;
            lblMLanguage.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMLanguage.Location = new Point(476, 123);
            lblMLanguage.Name = "lblMLanguage";
            lblMLanguage.Size = new Size(122, 23);
            lblMLanguage.TabIndex = 10;
            lblMLanguage.Text = "M_Language";
            // 
            // txtMRating
            // 
            txtMRating.Location = new Point(622, 171);
            txtMRating.Name = "txtMRating";
            txtMRating.Size = new Size(213, 27);
            txtMRating.TabIndex = 13;
            // 
            // lblMRating
            // 
            lblMRating.AutoSize = true;
            lblMRating.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMRating.Location = new Point(476, 175);
            lblMRating.Name = "lblMRating";
            lblMRating.Size = new Size(93, 23);
            lblMRating.TabIndex = 12;
            lblMRating.Text = "M_Rating";
            // 
            // lblMStatus
            // 
            lblMStatus.AutoSize = true;
            lblMStatus.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMStatus.Location = new Point(476, 224);
            lblMStatus.Name = "lblMStatus";
            lblMStatus.Size = new Size(90, 23);
            lblMStatus.TabIndex = 16;
            lblMStatus.Text = "M_Status";
            // 
            // lblMReleaseDate
            // 
            lblMReleaseDate.AutoSize = true;
            lblMReleaseDate.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMReleaseDate.Location = new Point(59, 343);
            lblMReleaseDate.Name = "lblMReleaseDate";
            lblMReleaseDate.Size = new Size(149, 23);
            lblMReleaseDate.TabIndex = 18;
            lblMReleaseDate.Text = "M_ReleaseDate";
            // 
            // dgvManageMovies
            // 
            dgvManageMovies.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvManageMovies.Location = new Point(-1, 401);
            dgvManageMovies.Name = "dgvManageMovies";
            dgvManageMovies.RowHeadersWidth = 51;
            dgvManageMovies.Size = new Size(1041, 187);
            dgvManageMovies.TabIndex = 20;
            dgvManageMovies.CellContentClick += dgvManageMovies_CellContentClick;
            dgvManageMovies.CellDoubleClick += dgvManageMovies_CellDoubleClick;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.Location = new Point(919, 117);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 42);
            btnAdd.TabIndex = 21;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(919, 224);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 42);
            btnDelete.TabIndex = 22;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click_1;
            // 
            // btnUpdate
            // 
            btnUpdate.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.Location = new Point(919, 171);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 42);
            btnUpdate.TabIndex = 23;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click_1;
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.Location = new Point(919, 274);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 42);
            btnClear.TabIndex = 24;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click_1;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(815, 368);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(213, 27);
            txtSearch.TabIndex = 28;
            txtSearch.MaskInputRejected += txtSearch_MaskInputRejected;
            txtSearch.TextChanged += txtSearch_TextChanged_1;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSearch.Location = new Point(815, 334);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(72, 23);
            lblSearch.TabIndex = 27;
            lblSearch.Text = "Search";
            // 
            // cmbMGenre
            // 
            cmbMGenre.FormattingEnabled = true;
            cmbMGenre.Items.AddRange(new object[] { "Action", "Comedy", "Romantic", "Horror", "Thriller", "Animation", "Adventure" });
            cmbMGenre.Location = new Point(226, 229);
            cmbMGenre.Name = "cmbMGenre";
            cmbMGenre.Size = new Size(213, 28);
            cmbMGenre.TabIndex = 29;
            // 
            // cmbMLanguage
            // 
            cmbMLanguage.FormattingEnabled = true;
            cmbMLanguage.Items.AddRange(new object[] { "English", "Bangla", "Hindi", "Korean", "Japanese", "Chinese", "Tamil", "Telugu" });
            cmbMLanguage.Location = new Point(622, 123);
            cmbMLanguage.Name = "cmbMLanguage";
            cmbMLanguage.Size = new Size(213, 28);
            cmbMLanguage.TabIndex = 30;
            // 
            // cmbMStatus
            // 
            cmbMStatus.FormattingEnabled = true;
            cmbMStatus.Items.AddRange(new object[] { "Now Showing", "Upcoming", "Ended" });
            cmbMStatus.Location = new Point(622, 224);
            cmbMStatus.Name = "cmbMStatus";
            cmbMStatus.Size = new Size(213, 28);
            cmbMStatus.TabIndex = 31;
            // 
            // lblX
            // 
            lblX.AutoSize = true;
            lblX.BackColor = Color.Gray;
            lblX.Font = new Font("Britannic Bold", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblX.ForeColor = SystemColors.Control;
            lblX.Location = new Point(984, 1);
            lblX.Name = "lblX";
            lblX.Size = new Size(56, 37);
            lblX.TabIndex = 1;
            lblX.Text = " X ";
            lblX.Click += lblX_Click;
            // 
            // txtMDuration
            // 
            txtMDuration.Location = new Point(226, 284);
            txtMDuration.Mask = "00:00";
            txtMDuration.Name = "txtMDuration";
            txtMDuration.Size = new Size(213, 27);
            txtMDuration.TabIndex = 36;
            // 
            // txtMReleaseDate
            // 
            txtMReleaseDate.Location = new Point(226, 343);
            txtMReleaseDate.Name = "txtMReleaseDate";
            txtMReleaseDate.Size = new Size(213, 27);
            txtMReleaseDate.TabIndex = 37;
            // 
            // ManageMovies
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 128, 128);
            ClientSize = new Size(1040, 596);
            Controls.Add(txtMReleaseDate);
            Controls.Add(txtMDuration);
            Controls.Add(cmbMStatus);
            Controls.Add(cmbMLanguage);
            Controls.Add(cmbMGenre);
            Controls.Add(txtSearch);
            Controls.Add(lblSearch);
            Controls.Add(btnClear);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(dgvManageMovies);
            Controls.Add(lblMReleaseDate);
            Controls.Add(lblMStatus);
            Controls.Add(txtMRating);
            Controls.Add(lblMRating);
            Controls.Add(lblMLanguage);
            Controls.Add(lblMDuration);
            Controls.Add(lblMGenre);
            Controls.Add(txtMTitle);
            Controls.Add(lblMTitle);
            Controls.Add(txtMovieID);
            Controls.Add(lblMovieID);
            Controls.Add(lblX);
            Controls.Add(lblManageMovies);
            FormBorderStyle = FormBorderStyle.None;
            HelpButton = true;
            Name = "ManageMovies";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ManageMovies";
            Load += ManageMovies_Load;
            ((System.ComponentModel.ISupportInitialize)dgvManageMovies).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblManageMovies;
        private Label lblMovieID;
        private MaskedTextBox txtMovieID;
        private MaskedTextBox txtMTitle;
        private Label lblMTitle;
        private Label lblMGenre;
        private MaskedTextBox txtMDuration1;
        private Label lblMDuration;
        private Label lblMLanguage;
        private MaskedTextBox txtMRating;
        private Label lblMRating;
        private Label lblMStatus;
        private Label lblMReleaseDate;
        private DataGridView dgvManageMovies;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnClear;
        private MaskedTextBox txtSearch;
        private Label lblSearch;
        private ComboBox cmbMGenre;
        private ComboBox cmbMLanguage;
        private ComboBox cmbMStatus;
        private Label lblX;
        private MaskedTextBox txtMDuration;
        private TextBox txtMReleaseDate;

        //private MaskedTextBox txtMDuration;
    }
}