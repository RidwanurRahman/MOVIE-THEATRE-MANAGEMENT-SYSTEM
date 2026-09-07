using System;
using System.Data;
using System.Windows.Forms;

namespace Movie_Theater_Management_System
{
    public partial class Manage_Seat : Form
    {
        private Admin_Dashboard? ad;
        private readonly DataAccess Da = new DataAccess();

        public Manage_Seat()
        {
            InitializeComponent();
        }

        public Manage_Seat(Admin_Dashboard ad)
        {
            InitializeComponent();
            this.ad = ad;
        }

        private void Manage_Seat_Load(object sender, EventArgs e)
        {
            try
            {
                txtSeatID.ReadOnly = true;
                txtShowID.ReadOnly = true;

                if (cmbSeatType.Items.Count == 0)
                {
                    cmbSeatType.Items.Add("Regular");
                    cmbSeatType.Items.Add("Premium");
                    cmbSeatType.Items.Add("VIP");
                }

                if (cmbSeatStatus.Items.Count == 0)
                {
                    cmbSeatStatus.Items.Add("Available");
                    cmbSeatStatus.Items.Add("Booked");
                }

                if (string.IsNullOrWhiteSpace(cmbSeatStatus.Text))
                {
                    cmbSeatStatus.SelectedItem = "Available";
                }

                dgvShowDashboard.AutoGenerateColumns = true;
                dgvShowDashboard.ReadOnly = true;
                dgvShowDashboard.AllowUserToAddRows = false;
                dgvShowDashboard.AllowUserToDeleteRows = false;
                dgvShowDashboard.MultiSelect = false;
                dgvShowDashboard.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;
                dgvShowDashboard.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvManageSeat.AutoGenerateColumns = true;
                dgvManageSeat.ReadOnly = true;
                dgvManageSeat.AllowUserToAddRows = false;
                dgvManageSeat.AllowUserToDeleteRows = false;
                dgvManageSeat.MultiSelect = false;
                dgvManageSeat.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;
                dgvManageSeat.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                txtSeatID.Text =
                    GenerateNextSeatID();

                LoadShowDashboard();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error while loading Manage Seat:\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadShowDashboard()
        {
            try
            {
                string sql = @"
                    SELECT
                        ShowID,
                        MovieID,
                        ShowDate,
                        ShowTime,
                        S_HallNo,
                        S_Price,
                        S_TotalSeats,
                        S_AvailableSeats
                    FROM ManageShows
                    ORDER BY ShowID";

                DataTable dt =
                    Da.ExecuteQuery(sql);

                dgvShowDashboard.DataSource =
                    dt;

                dgvShowDashboard.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Show Dashboard Load Error:\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            try
            {
                string sql = @"
                    SELECT
                        SeatID,
                        ShowID,
                        SeatNumber,
                        SeatType,
                        Seat_Status
                    FROM ManageSeat
                    ORDER BY SeatID";

                DataTable dt =
                    Da.ExecuteQuery(sql);

                dgvManageSeat.DataSource =
                    dt;

                dgvManageSeat.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Seat Data Load Error:\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private string GenerateNextSeatID()
        {
            try
            {
                DataTable dt =
                    Da.ExecuteQuery(@"
                        SELECT SeatID
                        FROM ManageSeat
                        WHERE SeatID LIKE 'S%'");

                int maxNumber = 0;

                foreach (DataRow row in dt.Rows)
                {
                    string id =
                        row["SeatID"]?.ToString() ?? "";

                    if (!id.StartsWith(
                        "S",
                        StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    string numberPart =
                        id.Substring(1);

                    if (int.TryParse(
                        numberPart,
                        out int number))
                    {
                        if (number > maxNumber)
                        {
                            maxNumber = number;
                        }
                    }
                }

                return "S" +
                    (maxNumber + 1).ToString("D3");
            }
            catch
            {
                return "S001";
            }
        }

        private void dgvShowDashboard_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvShowDashboard.Rows[e.RowIndex].IsNewRow)
                return;

            try
            {
                DataGridViewRow row =
                    dgvShowDashboard.Rows[
                        e.RowIndex];

                string showId =
                    row.Cells["ShowID"]
                    .Value?.ToString() ?? "";

                if (string.IsNullOrWhiteSpace(showId))
                    return;

                txtShowID.Text =
                    showId;

                txtSeatID.Text =
                    GenerateNextSeatID();

                if (cmbSeatStatus.Items.Count > 0)
                {
                    cmbSeatStatus.SelectedItem =
                        "Available";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not select Show:\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(
                    txtShowID.Text))
                {
                    MessageBox.Show(
                        "Please select a Show from Show Dashboard.",
                        "Show Required",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (string.IsNullOrWhiteSpace(
                    txtSeatNumber.Text))
                {
                    MessageBox.Show(
                        "Enter Seat Number.",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtSeatNumber.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(
                    cmbSeatType.Text))
                {
                    MessageBox.Show(
                        "Select Seat Type.",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    cmbSeatType.Focus();
                    return;
                }

                string seatStatus =
                    cmbSeatStatus.Text;

                if (string.IsNullOrWhiteSpace(
                    seatStatus))
                {
                    seatStatus = "Available";
                }

                string seatId =
                    GenerateNextSeatID();

                txtSeatID.Text =
                    seatId;

                string duplicateSql = @"
                    SELECT COUNT(*) AS SeatCount
                    FROM ManageSeat
                    WHERE ShowID = '" +
                    EscapeSql(
                        txtShowID.Text.Trim()) + @"'
                    AND SeatNumber = '" +
                    EscapeSql(
                        txtSeatNumber.Text.Trim()) + "'";

                DataTable duplicateDt =
                    Da.ExecuteQuery(duplicateSql);

                if (duplicateDt.Rows.Count > 0 &&
                    Convert.ToInt32(
                        duplicateDt.Rows[0]["SeatCount"]) > 0)
                {
                    MessageBox.Show(
                        "This seat number already exists for the selected show.",
                        "Duplicate Seat",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                string sql = @"
                    INSERT INTO ManageSeat
                    (
                        SeatID,
                        ShowID,
                        SeatNumber,
                        SeatType,
                        Seat_Status
                    )
                    VALUES
                    (
                        '" +
                    EscapeSql(seatId) + @"',
                        '" +
                    EscapeSql(
                        txtShowID.Text.Trim()) + @"',
                        '" +
                    EscapeSql(
                        txtSeatNumber.Text.Trim()) + @"',
                        '" +
                    EscapeSql(
                        cmbSeatType.Text.Trim()) + @"',
                        '" +
                    EscapeSql(seatStatus) + @"'
                    )";

                int result =
                    Da.ExecuteDML(sql);

                if (result > 0)
                {
                    MessageBox.Show(
                        "Seat Added Successfully!\n\n" +
                        "Seat ID: " + seatId +
                        "\nShow ID: " + txtShowID.Text,
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadData();
                    LoadShowDashboard();
                    ClearAll();
                }
                else
                {
                    MessageBox.Show(
                        "Seat could not be added.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Add Error:\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(
                    txtSeatID.Text))
                {
                    MessageBox.Show(
                        "Select a seat first.",
                        "Update",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (string.IsNullOrWhiteSpace(
                    txtShowID.Text))
                {
                    MessageBox.Show(
                        "Select a Show first.",
                        "Update",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (string.IsNullOrWhiteSpace(
                    txtSeatNumber.Text))
                {
                    MessageBox.Show(
                        "Enter Seat Number.",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (string.IsNullOrWhiteSpace(
                    cmbSeatType.Text))
                {
                    MessageBox.Show(
                        "Select Seat Type.",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (string.IsNullOrWhiteSpace(
                    cmbSeatStatus.Text))
                {
                    MessageBox.Show(
                        "Select Seat Status.",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                string duplicateSql = @"
                    SELECT COUNT(*) AS SeatCount
                    FROM ManageSeat
                    WHERE ShowID = '" +
                    EscapeSql(
                        txtShowID.Text.Trim()) + @"'
                    AND SeatNumber = '" +
                    EscapeSql(
                        txtSeatNumber.Text.Trim()) + @"'
                    AND SeatID <> '" +
                    EscapeSql(
                        txtSeatID.Text.Trim()) + "'";

                DataTable duplicateDt =
                    Da.ExecuteQuery(
                        duplicateSql);

                if (duplicateDt.Rows.Count > 0 &&
                    Convert.ToInt32(
                        duplicateDt.Rows[0]["SeatCount"]) > 0)
                {
                    MessageBox.Show(
                        "This seat number already exists for the selected show.",
                        "Duplicate Seat",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                string sql = @"
                    UPDATE ManageSeat
                    SET
                        ShowID = '" +
                    EscapeSql(
                        txtShowID.Text.Trim()) + @"',
                        SeatNumber = '" +
                    EscapeSql(
                        txtSeatNumber.Text.Trim()) + @"',
                        SeatType = '" +
                    EscapeSql(
                        cmbSeatType.Text.Trim()) + @"',
                        Seat_Status = '" +
                    EscapeSql(
                        cmbSeatStatus.Text.Trim()) + @"'
                    WHERE SeatID = '" +
                    EscapeSql(
                        txtSeatID.Text.Trim()) + "'";

                int result =
                    Da.ExecuteDML(sql);

                if (result > 0)
                {
                    MessageBox.Show(
                        "Seat Updated Successfully!",
                        "Update",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadData();
                    LoadShowDashboard();
                    ClearAll();
                }
                else
                {
                    MessageBox.Show(
                        "Seat could not be updated.",
                        "Update",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Update Error:\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (dgvManageSeat.CurrentRow == null ||
                    dgvManageSeat.CurrentRow.IsNewRow)
                {
                    MessageBox.Show(
                        "Select a seat first.",
                        "Delete",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                string seatId =
                    dgvManageSeat.CurrentRow
                    .Cells["SeatID"]
                    .Value?.ToString() ?? "";

                string seatStatus =
                    dgvManageSeat.CurrentRow
                    .Cells["Seat_Status"]
                    .Value?.ToString() ?? "";

                string showId =
                    dgvManageSeat.CurrentRow
                    .Cells["ShowID"]
                    .Value?.ToString() ?? "";

                if (string.IsNullOrWhiteSpace(
                    seatId))
                    return;

                DialogResult result =
                    MessageBox.Show(
                        "Are you sure you want to delete this seat?",
                        "Confirm Delete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;

                string sql =
                    "DELETE FROM ManageSeat " +
                    "WHERE SeatID = '" +
                    EscapeSql(seatId) + "'";

                int deleteResult =
                    Da.ExecuteDML(sql);

                if (deleteResult > 0)
                {
                    MessageBox.Show(
                        "Seat Deleted Successfully!",
                        "Delete",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadData();
                    LoadShowDashboard();
                    ClearAll();
                }
                else
                {
                    MessageBox.Show(
                        "Seat could not be deleted.",
                        "Delete",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Delete Error:\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dgvManageSeat_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvManageSeat.Rows[e.RowIndex].IsNewRow)
                return;

            try
            {
                DataGridViewRow row =
                    dgvManageSeat.Rows[
                        e.RowIndex];

                txtSeatID.Text =
                    row.Cells["SeatID"]
                    .Value?.ToString() ?? "";

                txtShowID.Text =
                    row.Cells["ShowID"]
                    .Value?.ToString() ?? "";

                txtSeatNumber.Text =
                    row.Cells["SeatNumber"]
                    .Value?.ToString() ?? "";

                cmbSeatType.Text =
                    row.Cells["SeatType"]
                    .Value?.ToString() ?? "";

                cmbSeatStatus.Text =
                    row.Cells["Seat_Status"]
                    .Value?.ToString() ?? "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not load seat details:\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ClearAll()
        {
            txtSeatID.Text =
                GenerateNextSeatID();

            txtShowID.Clear();
            txtSeatNumber.Clear();

            cmbSeatType.SelectedIndex = -1;

            if (cmbSeatStatus.Items.Count > 0)
            {
                cmbSeatStatus.SelectedItem =
                    "Available";
            }
            else
            {
                cmbSeatStatus.Text =
                    "Available";
            }

            txtSearch.Clear();

            dgvShowDashboard.ClearSelection();
            dgvManageSeat.ClearSelection();
        }

        private void btnClear_Click(
            object sender,
            EventArgs e)
        {
            ClearAll();
        }

        private void txtSearch_TextChanged(
            object sender,
            EventArgs e)
        {
            try
            {
                string value =
                    txtSearch.Text.Trim();

                if (string.IsNullOrWhiteSpace(value))
                {
                    LoadData();
                    return;
                }

                string safeValue =
                    EscapeSql(value);

                string sql = @"
                    SELECT
                        SeatID,
                        ShowID,
                        SeatNumber,
                        SeatType,
                        Seat_Status
                    FROM ManageSeat
                    WHERE
                        SeatID LIKE '%" +
                    safeValue + @"%'
                        OR ShowID LIKE '%" +
                    safeValue + @"%'
                        OR SeatNumber LIKE '%" +
                    safeValue + @"%'
                        OR SeatType LIKE '%" +
                    safeValue + @"%'
                        OR Seat_Status LIKE '%" +
                    safeValue + @"%'
                    ORDER BY SeatID";

                DataTable dt =
                    Da.ExecuteQuery(sql);

                dgvManageSeat.DataSource =
                    dt;

                dgvManageSeat.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvManageSeat.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Search Error:\n" +
                    ex.Message,
                    "Search",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnX_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                this.Hide();

                if (ad != null &&
                    !ad.IsDisposed)
                {
                    ad.WindowState =
                        FormWindowState.Normal;

                    ad.Show();
                    ad.BringToFront();
                    ad.Activate();
                }
                else
                {
                    Admin_Dashboard dashboard =
                        new Admin_Dashboard();

                    dashboard.Show();
                    dashboard.BringToFront();
                    dashboard.Activate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not return to Admin Dashboard:\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void txtSearch_MaskInputRejected(
            object sender,
            MaskInputRejectedEventArgs e)
        {
        }

        private void dgvShowDashboard_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
        }

        private void dgvManageSeat_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
        }

        private string EscapeSql(string value)
        {
            if (value == null)
                return "";

            return value.Replace("'", "''");
        }
    }
}