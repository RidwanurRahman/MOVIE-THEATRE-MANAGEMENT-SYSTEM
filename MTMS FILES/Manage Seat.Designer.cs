namespace Movie_Theater_Management_System
{
    partial class Manage_Seat
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
            cmbSeatType = new ComboBox();
            txtSearch = new MaskedTextBox();
            lblSearch = new Label();
            btnClear = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnAdd = new Button();
            lblSeatType = new Label();
            txtSeatNumber = new MaskedTextBox();
            lblSeatNumber = new Label();
            txtShowID = new MaskedTextBox();
            lblShowID = new Label();
            lblSeatID = new Label();
            lblManageSeat = new Label();
            dgvManageSeat = new DataGridView();
            lblSeatStatus = new Label();
            txtSeatID = new MaskedTextBox();
            cmbSeatStatus = new ComboBox();
            btnX = new Button();
            dgvShowDashboard = new DataGridView();
            lblSeatDashboard = new Label();
            lblShowDashboard = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvManageSeat).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvShowDashboard).BeginInit();
            SuspendLayout();
            // 
            // cmbSeatType
            // 
            cmbSeatType.FormattingEnabled = true;
            cmbSeatType.Items.AddRange(new object[] { "Regular", "Premium", "VIP", "Couple" });
            cmbSeatType.Location = new Point(182, 286);
            cmbSeatType.Name = "cmbSeatType";
            cmbSeatType.Size = new Size(213, 28);
            cmbSeatType.TabIndex = 49;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(975, 389);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(213, 27);
            txtSearch.TabIndex = 47;
            txtSearch.MaskInputRejected += txtSearch_MaskInputRejected;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSearch.Location = new Point(975, 359);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(72, 23);
            lblSearch.TabIndex = 46;
            lblSearch.Text = "Search";
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.Location = new Point(304, 499);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 42);
            btnClear.TabIndex = 44;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.Location = new Point(164, 498);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 42);
            btnUpdate.TabIndex = 43;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(304, 444);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 42);
            btnDelete.TabIndex = 42;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.Location = new Point(164, 444);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 42);
            btnAdd.TabIndex = 41;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // lblSeatType
            // 
            lblSeatType.AutoSize = true;
            lblSeatType.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSeatType.Location = new Point(36, 286);
            lblSeatType.Name = "lblSeatType";
            lblSeatType.Size = new Size(96, 23);
            lblSeatType.TabIndex = 40;
            lblSeatType.Text = "SeatType";
            // 
            // txtSeatNumber
            // 
            txtSeatNumber.Location = new Point(182, 228);
            txtSeatNumber.Name = "txtSeatNumber";
            txtSeatNumber.Size = new Size(213, 27);
            txtSeatNumber.TabIndex = 39;
            // 
            // lblSeatNumber
            // 
            lblSeatNumber.AutoSize = true;
            lblSeatNumber.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSeatNumber.Location = new Point(36, 232);
            lblSeatNumber.Name = "lblSeatNumber";
            lblSeatNumber.Size = new Size(125, 23);
            lblSeatNumber.TabIndex = 38;
            lblSeatNumber.Text = "SeatNumber";
            // 
            // txtShowID
            // 
            txtShowID.Location = new Point(182, 169);
            txtShowID.Name = "txtShowID";
            txtShowID.Size = new Size(213, 27);
            txtShowID.TabIndex = 37;
            // 
            // lblShowID
            // 
            lblShowID.AutoSize = true;
            lblShowID.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblShowID.Location = new Point(36, 173);
            lblShowID.Name = "lblShowID";
            lblShowID.Size = new Size(80, 23);
            lblShowID.TabIndex = 36;
            lblShowID.Text = "ShowID";
            // 
            // lblSeatID
            // 
            lblSeatID.AutoSize = true;
            lblSeatID.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSeatID.Location = new Point(36, 121);
            lblSeatID.Name = "lblSeatID";
            lblSeatID.Size = new Size(70, 23);
            lblSeatID.TabIndex = 35;
            lblSeatID.Text = "SeatID";
            // 
            // lblManageSeat
            // 
            lblManageSeat.AutoSize = true;
            lblManageSeat.Font = new Font("Britannic Bold", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblManageSeat.Location = new Point(540, 19);
            lblManageSeat.Name = "lblManageSeat";
            lblManageSeat.Size = new Size(207, 37);
            lblManageSeat.TabIndex = 33;
            lblManageSeat.Text = "Manage Seat";
            // 
            // dgvManageSeat
            // 
            dgvManageSeat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvManageSeat.Location = new Point(464, 422);
            dgvManageSeat.Name = "dgvManageSeat";
            dgvManageSeat.RowHeadersWidth = 51;
            dgvManageSeat.Size = new Size(734, 176);
            dgvManageSeat.TabIndex = 51;
            dgvManageSeat.CellDoubleClick += dgvManageSeat_CellDoubleClick;
            // 
            // lblSeatStatus
            // 
            lblSeatStatus.AutoSize = true;
            lblSeatStatus.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSeatStatus.Location = new Point(36, 339);
            lblSeatStatus.Name = "lblSeatStatus";
            lblSeatStatus.Size = new Size(112, 23);
            lblSeatStatus.TabIndex = 52;
            lblSeatStatus.Text = "Seat_Status";
            // 
            // txtSeatID
            // 
            txtSeatID.Location = new Point(182, 117);
            txtSeatID.Name = "txtSeatID";
            txtSeatID.Size = new Size(213, 27);
            txtSeatID.TabIndex = 54;
            // 
            // cmbSeatStatus
            // 
            cmbSeatStatus.FormattingEnabled = true;
            cmbSeatStatus.Items.AddRange(new object[] { "Available", "Booked", "Reserved", "Maintenance" });
            cmbSeatStatus.Location = new Point(182, 339);
            cmbSeatStatus.Name = "cmbSeatStatus";
            cmbSeatStatus.Size = new Size(213, 28);
            cmbSeatStatus.TabIndex = 55;
            // 
            // btnX
            // 
            btnX.BackColor = Color.Red;
            btnX.Font = new Font("Arial Rounded MT Bold", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnX.ForeColor = Color.Transparent;
            btnX.Location = new Point(1149, -2);
            btnX.Name = "btnX";
            btnX.Size = new Size(84, 44);
            btnX.TabIndex = 69;
            btnX.Text = "X";
            btnX.UseVisualStyleBackColor = false;
            btnX.Click += btnX_Click;
            // 
            // dgvShowDashboard
            // 
            dgvShowDashboard.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvShowDashboard.Location = new Point(464, 154);
            dgvShowDashboard.Name = "dgvShowDashboard";
            dgvShowDashboard.RowHeadersWidth = 51;
            dgvShowDashboard.Size = new Size(734, 144);
            dgvShowDashboard.TabIndex = 70;
            dgvShowDashboard.CellDoubleClick += dgvShowDashboard_CellDoubleClick;
            // 
            // lblSeatDashboard
            // 
            lblSeatDashboard.AutoSize = true;
            lblSeatDashboard.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSeatDashboard.Location = new Point(771, 393);
            lblSeatDashboard.Name = "lblSeatDashboard";
            lblSeatDashboard.Size = new Size(154, 23);
            lblSeatDashboard.TabIndex = 71;
            lblSeatDashboard.Text = "Seat Dashboard";
            // 
            // lblShowDashboard
            // 
            lblShowDashboard.AutoSize = true;
            lblShowDashboard.Font = new Font("Cambria", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblShowDashboard.Location = new Point(737, 117);
            lblShowDashboard.Name = "lblShowDashboard";
            lblShowDashboard.Size = new Size(164, 23);
            lblShowDashboard.TabIndex = 72;
            lblShowDashboard.Text = "Show Dashboard";
            // 
            // Manage_Seat
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 128, 128);
            ClientSize = new Size(1231, 671);
            Controls.Add(lblShowDashboard);
            Controls.Add(lblSeatDashboard);
            Controls.Add(dgvShowDashboard);
            Controls.Add(btnX);
            Controls.Add(cmbSeatStatus);
            Controls.Add(txtSeatID);
            Controls.Add(lblSeatStatus);
            Controls.Add(dgvManageSeat);
            Controls.Add(cmbSeatType);
            Controls.Add(txtSearch);
            Controls.Add(lblSearch);
            Controls.Add(btnClear);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(lblSeatType);
            Controls.Add(txtSeatNumber);
            Controls.Add(lblSeatNumber);
            Controls.Add(txtShowID);
            Controls.Add(lblShowID);
            Controls.Add(lblSeatID);
            Controls.Add(lblManageSeat);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Manage_Seat";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Manage_Seat";
            Load += Manage_Seat_Load;
            ((System.ComponentModel.ISupportInitialize)dgvManageSeat).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvShowDashboard).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox cmbSeatType;
        private MaskedTextBox txtSearch;
        private Label lblSearch;
        private Button btnClear;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnAdd;
        private Label lblSeatType;
        private MaskedTextBox txtSeatNumber;
        private Label lblSeatNumber;
        private MaskedTextBox txtShowID;
        private Label lblShowID;
        private Label lblSeatID;
        private Label lblManageSeat;
        private DataGridView dgvManageSeat;
        private Label lblSeatStatus;
        private MaskedTextBox txtSeatID;
        private ComboBox cmbSeatStatus;
        private Button btnX;
        private DataGridView dgvShowDashboard;
        private Label lblSeatDashboard;
        private Label lblShowDashboard;
    }
}