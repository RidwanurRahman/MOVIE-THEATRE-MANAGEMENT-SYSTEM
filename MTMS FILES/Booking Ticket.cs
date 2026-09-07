using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace Movie_Theater_Management_System
{
    public partial class Booking_Ticket : Form
    {
        private CustomerDashboard? cd;
        private readonly DataAccess Da = new DataAccess();

        private string loggedInUserId = "";
        private decimal selectedShowPrice = 0;

        public Booking_Ticket()
        {
            InitializeComponent();
        }

        public Booking_Ticket(CustomerDashboard cd)
        {
            InitializeComponent();
            this.cd = cd;
        }

        private void Booking_Ticket_Load(object sender, EventArgs e)
        {
            try
            {
                loggedInUserId = Login.CurrentUserID;

                txtBookingID.ReadOnly = true;
                txtUserID.ReadOnly = true;
                txtShowID.ReadOnly = true;
                txtSeatID.ReadOnly = true;
                txtTotalPrice.ReadOnly = true;

                txtBookingID.Text =
                    GenerateNextBookingID();

                txtUserID.Text =
                    loggedInUserId;

                txtQuantity.ReadOnly = false;
                txtQuantity.Text = "1";

                txtTotalPrice.Text = "0";

                dtpBookingDate.Value =
                    DateTime.Now;

                cmbTicketStatus.Items.Clear();
                cmbTicketStatus.Items.Add("Confirmed");
                cmbTicketStatus.Items.Add("Pending");
                cmbTicketStatus.Items.Add("Cancelled");
                cmbTicketStatus.SelectedIndex = 0;
                cmbTicketStatus.Enabled = true;

                dgvShowsDashboard.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvSeatDashboard.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvBookingTicket.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvShowsDashboard.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvSeatDashboard.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvBookingTicket.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvShowsDashboard.MultiSelect = false;
                dgvSeatDashboard.MultiSelect = false;
                dgvBookingTicket.MultiSelect = false;

                txtQuantity.TextChanged -=
                    txtQuantity_TextChanged;

                txtQuantity.TextChanged +=
                    txtQuantity_TextChanged;

                LoadShowsDashboard();
                LoadBookingData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error while loading Booking Ticket:\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void button1_Click(
            object sender,
            EventArgs e)
        {
            if (cd != null)
            {
                this.Hide();
                cd.Show();
                cd.BringToFront();
                cd.Activate();
            }
            else
            {
                this.Close();
            }
        }

        private string GenerateNextBookingID()
        {
            try
            {
                DataTable dt =
                    Da.ExecuteQuery(
                        "SELECT BookingID FROM BookingTicket");

                int maxNumber = 0;

                foreach (DataRow row in dt.Rows)
                {
                    string id =
                        row["BookingID"]?.ToString() ?? "";

                    if (!id.StartsWith(
                        "BI",
                        StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    string numberPart =
                        id.Substring(2);

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

                return "BI" +
                    (maxNumber + 1).ToString("D3");
            }
            catch
            {
                return "BI001";
            }
        }

        private void LoadShowsDashboard()
        {
            try
            {
                string sql = @"
                    SELECT
                        s.ShowID,
                        s.MovieID,
                        m.M_Title AS MovieTitle,
                        s.ShowDate,
                        s.ShowTime,
                        s.S_HallNo,
                        s.S_Price,
                        s.S_TotalSeats,
                        s.S_AvailableSeats
                    FROM ManageShows s
                    LEFT JOIN ManageMovies m
                        ON s.MovieID = m.MovieID
                    ORDER BY s.ShowDate, s.ShowTime";

                DataTable dt =
                    Da.ExecuteQuery(sql);

                dgvShowsDashboard.DataSource =
                    dt;

                dgvShowsDashboard.ClearSelection();
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

        private void LoadSeatsDashboard(
            string showId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(showId))
                {
                    dgvSeatDashboard.DataSource = null;
                    return;
                }

                string safeShowId =
                    EscapeSql(showId);

                string sql = @"
                    SELECT
                        SeatID,
                        ShowID,
                        SeatNumber,
                        SeatType,
                        Seat_Status
                    FROM ManageSeat
                    WHERE ShowID = '" +
                    safeShowId + @"'
                    AND Seat_Status = 'Available'
                    ORDER BY SeatNumber";

                DataTable dt =
                    Da.ExecuteQuery(sql);

                dgvSeatDashboard.DataSource =
                    dt;

                dgvSeatDashboard.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Seat Dashboard Load Error:\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadBookingData()
        {
            try
            {
                loggedInUserId =
                    Login.CurrentUserID;

                if (string.IsNullOrWhiteSpace(
                    loggedInUserId))
                {
                    dgvBookingTicket.DataSource =
                        null;
                    return;
                }

                string safeUserId =
                    EscapeSql(loggedInUserId);

                string sql = @"
                    SELECT
                        BookingID,
                        UserID,
                        ShowID,
                        SeatID,
                        BookingDate,
                        Quantity,
                        TotalPrice,
                        Ticket_Status
                    FROM BookingTicket
                    WHERE UserID = '" +
                    safeUserId + @"'
                    ORDER BY BookingID DESC";

                DataTable dt =
                    Da.ExecuteQuery(sql);

                dgvBookingTicket.DataSource =
                    dt;

                dgvBookingTicket.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Booking Data Load Error:\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dgvShowsDashboard_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvShowsDashboard.Rows[e.RowIndex].IsNewRow)
                return;

            try
            {
                DataGridViewRow row =
                    dgvShowsDashboard.Rows[
                        e.RowIndex];

                string showId =
                    row.Cells["ShowID"]
                    .Value?.ToString() ?? "";

                string priceText =
                    row.Cells["S_Price"]
                    .Value?.ToString() ?? "";

                string availableSeats =
                    row.Cells["S_AvailableSeats"]
                    .Value?.ToString() ?? "";

                if (string.IsNullOrWhiteSpace(showId))
                    return;

                decimal price;

                if (!decimal.TryParse(
                    priceText,
                    NumberStyles.Any,
                    CultureInfo.CurrentCulture,
                    out price))
                {
                    if (!decimal.TryParse(
                        priceText,
                        NumberStyles.Any,
                        CultureInfo.InvariantCulture,
                        out price))
                    {
                        MessageBox.Show(
                            "Invalid show price.",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        return;
                    }
                }

                if (int.TryParse(
                    availableSeats,
                    out int available) &&
                    available <= 0)
                {
                    MessageBox.Show(
                        "This show has no available seats.",
                        "No Seats Available",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtShowID.Clear();
                    txtSeatID.Clear();

                    selectedShowPrice = 0;

                    txtTotalPrice.Text = "0";

                    dgvSeatDashboard.DataSource =
                        null;

                    return;
                }

                txtShowID.Text =
                    showId;

                selectedShowPrice =
                    price;

                txtSeatID.Clear();

                UpdateTotalPrice();

                LoadSeatsDashboard(showId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not select show:\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dgvSeatDashboard_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvSeatDashboard.Rows[e.RowIndex].IsNewRow)
                return;

            try
            {
                if (string.IsNullOrWhiteSpace(
                    txtShowID.Text))
                {
                    MessageBox.Show(
                        "Please select a show first.",
                        "Show Required",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                DataGridViewRow row =
                    dgvSeatDashboard.Rows[
                        e.RowIndex];

                string seatId =
                    row.Cells["SeatID"]
                    .Value?.ToString() ?? "";

                string seatShowId =
                    row.Cells["ShowID"]
                    .Value?.ToString() ?? "";

                string seatStatus =
                    row.Cells["Seat_Status"]
                    .Value?.ToString() ?? "";

                if (string.IsNullOrWhiteSpace(seatId))
                    return;

                if (!string.Equals(
                    txtShowID.Text,
                    seatShowId,
                    StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(
                        "This seat does not belong to the selected show.",
                        "Invalid Seat",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (!string.Equals(
                    seatStatus,
                    "Available",
                    StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(
                        "This seat is not available.",
                        "Seat Unavailable",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                txtSeatID.Text =
                    seatId;

                if (string.IsNullOrWhiteSpace(
                    txtQuantity.Text) ||
                    !int.TryParse(
                        txtQuantity.Text,
                        out int quantity) ||
                    quantity <= 0)
                {
                    txtQuantity.Text = "1";
                }

                UpdateTotalPrice();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not select seat:\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void txtQuantity_TextChanged(
            object sender,
            EventArgs e)
        {
            UpdateTotalPrice();
        }

        private void UpdateTotalPrice()
        {
            if (!int.TryParse(
                txtQuantity.Text,
                out int quantity))
            {
                txtTotalPrice.Text = "0";
                return;
            }

            if (quantity <= 0)
            {
                txtTotalPrice.Text = "0";
                return;
            }

            decimal totalPrice =
                selectedShowPrice * quantity;

            txtTotalPrice.Text =
                totalPrice.ToString("0.00");
        }

        private void btnAdd_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                loggedInUserId =
                    Login.CurrentUserID;

                txtUserID.Text =
                    loggedInUserId;

                if (string.IsNullOrWhiteSpace(
                    loggedInUserId))
                {
                    MessageBox.Show(
                        "Customer ID not found. Please login again.",
                        "Login Required",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (string.IsNullOrWhiteSpace(
                    txtShowID.Text))
                {
                    MessageBox.Show(
                        "Please select a show.",
                        "Show Required",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (string.IsNullOrWhiteSpace(
                    txtSeatID.Text))
                {
                    MessageBox.Show(
                        "Please select a seat.",
                        "Seat Required",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (!int.TryParse(
                    txtQuantity.Text,
                    out int quantity) ||
                    quantity <= 0)
                {
                    MessageBox.Show(
                        "Quantity must be greater than 0.",
                        "Invalid Quantity",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtQuantity.Focus();
                    return;
                }

                if (selectedShowPrice <= 0)
                {
                    MessageBox.Show(
                        "Please select a valid show.",
                        "Price Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (cmbTicketStatus.SelectedItem == null)
                {
                    MessageBox.Show(
                        "Please select Ticket Status.",
                        "Status Required",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                string status =
                    cmbTicketStatus.SelectedItem
                    .ToString() ?? "Pending";

                string showId =
                    EscapeSql(txtShowID.Text);

                string seatId =
                    EscapeSql(txtSeatID.Text);

                string userId =
                    EscapeSql(loggedInUserId);

                string seatCheckSql = @"
                    SELECT COUNT(*) AS SeatCount
                    FROM ManageSeat
                    WHERE SeatID = '" +
                    seatId + @"'
                    AND ShowID = '" +
                    showId + @"'
                    AND Seat_Status = 'Available'";

                DataTable seatCheck =
                    Da.ExecuteQuery(
                        seatCheckSql);

                if (seatCheck.Rows.Count == 0 ||
                    Convert.ToInt32(
                        seatCheck.Rows[0][
                            "SeatCount"]) == 0)
                {
                    MessageBox.Show(
                        "This seat is no longer available.",
                        "Seat Unavailable",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    LoadSeatsDashboard(
                        txtShowID.Text);

                    return;
                }

                string bookingId =
                    GenerateNextBookingID();

                decimal totalPrice =
                    selectedShowPrice * quantity;

                txtBookingID.Text =
                    bookingId;

                txtTotalPrice.Text =
                    totalPrice.ToString("0.00");

                string insertSql = @"
                    INSERT INTO BookingTicket
                    (
                        BookingID,
                        UserID,
                        ShowID,
                        SeatID,
                        BookingDate,
                        Quantity,
                        TotalPrice,
                        Ticket_Status
                    )
                    VALUES
                    (
                        '" +
                    EscapeSql(bookingId) + @"',
                        '" +
                    userId + @"',
                        '" +
                    showId + @"',
                        '" +
                    seatId + @"',
                        '" +
                    dtpBookingDate.Value
                        .ToString("yyyy-MM-dd") + @"',
                        '" +
                    quantity + @"',
                        '" +
                    totalPrice.ToString(
                        CultureInfo.InvariantCulture) + @"',
                        '" +
                    EscapeSql(status) + @"'
                    )";

                int bookingResult =
                    Da.ExecuteDML(insertSql);

                if (bookingResult <= 0)
                {
                    MessageBox.Show(
                        "Booking could not be added.",
                        "Booking Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                if (status == "Confirmed")
                {
                    string updateSeatSql = @"
                        UPDATE ManageSeat
                        SET Seat_Status = 'Booked'
                        WHERE SeatID = '" +
                        seatId + @"'
                        AND ShowID = '" +
                        showId + @"'
                        AND Seat_Status = 'Available'";

                    int seatResult =
                        Da.ExecuteDML(
                            updateSeatSql);

                    if (seatResult <= 0)
                    {
                        Da.ExecuteDML(
                            "DELETE FROM BookingTicket " +
                            "WHERE BookingID = '" +
                            EscapeSql(bookingId) +
                            "'");

                        MessageBox.Show(
                            "Seat could not be booked.",
                            "Booking Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        LoadSeatsDashboard(
                            txtShowID.Text);

                        return;
                    }

                    string updateShowSql = @"
                        UPDATE ManageShows
                        SET S_AvailableSeats =
                            CAST(S_AvailableSeats AS INT) - 1
                        WHERE ShowID = '" +
                        showId + @"'
                        AND ISNUMERIC(S_AvailableSeats) = 1
                        AND CAST(S_AvailableSeats AS INT) > 0";

                    Da.ExecuteDML(
                        updateShowSql);
                }

                MessageBox.Show(
                    "Booking Added Successfully!\n\n" +
                    "Booking ID: " + bookingId +
                    "\nUser ID: " + loggedInUserId +
                    "\nShow ID: " + txtShowID.Text +
                    "\nSeat ID: " + txtSeatID.Text +
                    "\nQuantity: " + quantity +
                    "\nTotal Price: " +
                    totalPrice.ToString("0.00") +
                    "\nStatus: " + status,
                    "Booking Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadShowsDashboard();
                LoadBookingData();

                ClearBookingFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Booking Error:\n" +
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
                loggedInUserId =
                    Login.CurrentUserID;

                if (string.IsNullOrWhiteSpace(
                    txtBookingID.Text))
                {
                    MessageBox.Show(
                        "Select a booking first.",
                        "Update",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (string.IsNullOrWhiteSpace(
                    loggedInUserId))
                {
                    MessageBox.Show(
                        "Customer ID not found. Please login again.",
                        "Login Required",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (cmbTicketStatus.SelectedItem == null)
                {
                    MessageBox.Show(
                        "Please select Ticket Status.",
                        "Status Required",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (!int.TryParse(
                    txtQuantity.Text,
                    out int quantity) ||
                    quantity <= 0)
                {
                    MessageBox.Show(
                        "Quantity must be greater than 0.",
                        "Invalid Quantity",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtQuantity.Focus();
                    return;
                }

                string newStatus =
                    cmbTicketStatus.SelectedItem
                    .ToString() ?? "Pending";

                decimal price =
                    selectedShowPrice;

                if (price <= 0 &&
                    decimal.TryParse(
                        txtTotalPrice.Text,
                        NumberStyles.Any,
                        CultureInfo.CurrentCulture,
                        out decimal oldTotal))
                {
                    price =
                        oldTotal / quantity;
                }

                if (price <= 0)
                {
                    MessageBox.Show(
                        "Invalid show price.",
                        "Price Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                decimal totalPrice =
                    price * quantity;

                string bookingId =
                    EscapeSql(txtBookingID.Text);

                string oldDataSql = @"
                    SELECT
                        ShowID,
                        SeatID,
                        Quantity,
                        Ticket_Status
                    FROM BookingTicket
                    WHERE BookingID = '" +
                    bookingId + @"'
                    AND UserID = '" +
                    EscapeSql(
                        loggedInUserId) + "'";

                DataTable oldData =
                    Da.ExecuteQuery(
                        oldDataSql);

                if (oldData.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "Booking not found.",
                        "Update",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                string oldShowId =
                    oldData.Rows[0]["ShowID"]
                    ?.ToString() ?? "";

                string oldSeatId =
                    oldData.Rows[0]["SeatID"]
                    ?.ToString() ?? "";

                string oldStatus =
                    oldData.Rows[0]["Ticket_Status"]
                    ?.ToString() ?? "";

                if (oldStatus == "Confirmed" &&
                    newStatus != "Confirmed")
                {
                    string releaseSeatSql = @"
                        UPDATE ManageSeat
                        SET Seat_Status = 'Available'
                        WHERE SeatID = '" +
                        EscapeSql(oldSeatId) + @"'
                        AND ShowID = '" +
                        EscapeSql(oldShowId) + @"'
                        AND Seat_Status = 'Booked'";

                    Da.ExecuteDML(
                        releaseSeatSql);

                    string increaseShowSql = @"
                        UPDATE ManageShows
                        SET S_AvailableSeats =
                            CAST(S_AvailableSeats AS INT) + 1
                        WHERE ShowID = '" +
                        EscapeSql(oldShowId) + @"'
                        AND ISNUMERIC(S_AvailableSeats) = 1";

                    Da.ExecuteDML(
                        increaseShowSql);
                }

                if (oldStatus != "Confirmed" &&
                    newStatus == "Confirmed")
                {
                    string seatCheckSql = @"
                        SELECT COUNT(*) AS SeatCount
                        FROM ManageSeat
                        WHERE SeatID = '" +
                        EscapeSql(oldSeatId) + @"'
                        AND ShowID = '" +
                        EscapeSql(oldShowId) + @"'
                        AND Seat_Status = 'Available'";

                    DataTable seatCheck =
                        Da.ExecuteQuery(
                            seatCheckSql);

                    if (seatCheck.Rows.Count == 0 ||
                        Convert.ToInt32(
                            seatCheck.Rows[0][
                                "SeatCount"]) == 0)
                    {
                        MessageBox.Show(
                            "This seat is not available anymore.",
                            "Update Failed",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        LoadSeatsDashboard(
                            oldShowId);

                        return;
                    }

                    string bookSeatSql = @"
                        UPDATE ManageSeat
                        SET Seat_Status = 'Booked'
                        WHERE SeatID = '" +
                        EscapeSql(oldSeatId) + @"'
                        AND ShowID = '" +
                        EscapeSql(oldShowId) + @"'
                        AND Seat_Status = 'Available'";

                    Da.ExecuteDML(
                        bookSeatSql);

                    string decreaseShowSql = @"
                        UPDATE ManageShows
                        SET S_AvailableSeats =
                            CAST(S_AvailableSeats AS INT) - 1
                        WHERE ShowID = '" +
                        EscapeSql(oldShowId) + @"'
                        AND ISNUMERIC(S_AvailableSeats) = 1
                        AND CAST(S_AvailableSeats AS INT) > 0";

                    Da.ExecuteDML(
                        decreaseShowSql);
                }

                string updateSql = @"
                    UPDATE BookingTicket
                    SET
                        BookingDate = '" +
                    dtpBookingDate.Value
                        .ToString("yyyy-MM-dd") + @"',
                        Quantity = '" +
                    quantity + @"',
                        TotalPrice = '" +
                    totalPrice.ToString(
                        CultureInfo.InvariantCulture) + @"',
                        Ticket_Status = '" +
                    EscapeSql(newStatus) + @"'
                    WHERE BookingID = '" +
                    bookingId + @"'
                    AND UserID = '" +
                    EscapeSql(
                        loggedInUserId) + "'";

                int result =
                    Da.ExecuteDML(updateSql);

                if (result > 0)
                {
                    MessageBox.Show(
                        "Booking updated successfully!",
                        "Update",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadShowsDashboard();
                    LoadBookingData();

                    ClearBookingFields();
                }
                else
                {
                    MessageBox.Show(
                        "Booking could not be updated.",
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
                if (dgvBookingTicket.CurrentRow == null ||
                    dgvBookingTicket.CurrentRow.IsNewRow)
                {
                    MessageBox.Show(
                        "Select a booking first.",
                        "Delete",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                string bookingId =
                    dgvBookingTicket
                    .CurrentRow
                    .Cells["BookingID"]
                    .Value?.ToString() ?? "";

                string showId =
                    dgvBookingTicket
                    .CurrentRow
                    .Cells["ShowID"]
                    .Value?.ToString() ?? "";

                string seatId =
                    dgvBookingTicket
                    .CurrentRow
                    .Cells["SeatID"]
                    .Value?.ToString() ?? "";

                string status =
                    dgvBookingTicket
                    .CurrentRow
                    .Cells["Ticket_Status"]
                    .Value?.ToString() ?? "";

                if (string.IsNullOrWhiteSpace(
                    bookingId))
                    return;

                DialogResult result =
                    MessageBox.Show(
                        "Are you sure you want to delete this booking?",
                        "Confirm Delete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;

                string deleteSql = @"
                    DELETE FROM BookingTicket
                    WHERE BookingID = '" +
                    EscapeSql(bookingId) + @"'
                    AND UserID = '" +
                    EscapeSql(
                        Login.CurrentUserID) + "'";

                int deleteResult =
                    Da.ExecuteDML(deleteSql);

                if (deleteResult > 0)
                {
                    if (status == "Confirmed")
                    {
                        string releaseSeatSql = @"
                            UPDATE ManageSeat
                            SET Seat_Status = 'Available'
                            WHERE SeatID = '" +
                            EscapeSql(seatId) + @"'
                            AND ShowID = '" +
                            EscapeSql(showId) + @"'
                            AND Seat_Status = 'Booked'";

                        Da.ExecuteDML(
                            releaseSeatSql);

                        string increaseShowSql = @"
                            UPDATE ManageShows
                            SET S_AvailableSeats =
                                CAST(S_AvailableSeats AS INT) + 1
                            WHERE ShowID = '" +
                            EscapeSql(showId) + @"'
                            AND ISNUMERIC(S_AvailableSeats) = 1";

                        Da.ExecuteDML(
                            increaseShowSql);
                    }

                    MessageBox.Show(
                        "Booking deleted successfully!",
                        "Delete",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadShowsDashboard();
                    LoadBookingData();

                    ClearBookingFields();
                }
                else
                {
                    MessageBox.Show(
                        "Booking could not be deleted.",
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

        private void btnClear_Click(
            object sender,
            EventArgs e)
        {
            ClearBookingFields();
        }

        private void ClearBookingFields()
        {
            loggedInUserId =
                Login.CurrentUserID;

            txtBookingID.Text =
                GenerateNextBookingID();

            txtUserID.Text =
                loggedInUserId;

            txtShowID.Clear();
            txtSeatID.Clear();

            txtQuantity.Text = "1";

            selectedShowPrice = 0;

            txtTotalPrice.Text = "0";

            dtpBookingDate.Value =
                DateTime.Now;

            if (cmbTicketStatus.Items.Count > 0)
                cmbTicketStatus.SelectedIndex = 0;

            dgvSeatDashboard.DataSource = null;

            dgvShowsDashboard.ClearSelection();
            dgvBookingTicket.ClearSelection();
        }

        private void txtSearch_TextChanged(
            object sender,
            EventArgs e)
        {
            try
            {
                loggedInUserId =
                    Login.CurrentUserID;

                if (string.IsNullOrWhiteSpace(
                    loggedInUserId))
                {
                    dgvBookingTicket.DataSource =
                        null;
                    return;
                }

                string value =
                    txtSearch.Text.Trim();

                if (string.IsNullOrWhiteSpace(value))
                {
                    LoadBookingData();
                    return;
                }

                string safeValue =
                    EscapeSql(value);

                string sql = @"
                    SELECT
                        BookingID,
                        UserID,
                        ShowID,
                        SeatID,
                        BookingDate,
                        Quantity,
                        TotalPrice,
                        Ticket_Status
                    FROM BookingTicket
                    WHERE UserID = '" +
                    EscapeSql(
                        loggedInUserId) + @"'
                    AND (
                        BookingID LIKE '%" +
                    safeValue + @"%'
                        OR ShowID LIKE '%" +
                    safeValue + @"%'
                        OR SeatID LIKE '%" +
                    safeValue + @"%'
                        OR CONVERT(
                            VARCHAR(30),
                            BookingDate,
                            120
                        ) LIKE '%" +
                    safeValue + @"%'
                        OR CONVERT(
                            VARCHAR(30),
                            Quantity
                        ) LIKE '%" +
                    safeValue + @"%'
                        OR CONVERT(
                            VARCHAR(30),
                            TotalPrice
                        ) LIKE '%" +
                    safeValue + @"%'
                        OR Ticket_Status LIKE '%" +
                    safeValue + @"%'
                    )
                    ORDER BY BookingID DESC";

                DataTable dt =
                    Da.ExecuteQuery(sql);

                dgvBookingTicket.DataSource =
                    dt;

                dgvBookingTicket.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvBookingTicket.ClearSelection();
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

        private void dgvBookingTicket_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvBookingTicket.Rows[e.RowIndex].IsNewRow)
                return;

            try
            {
                DataGridViewRow row =
                    dgvBookingTicket.Rows[
                        e.RowIndex];

                txtBookingID.Text =
                    row.Cells["BookingID"]
                    .Value?.ToString() ?? "";

                txtUserID.Text =
                    Login.CurrentUserID;

                txtShowID.Text =
                    row.Cells["ShowID"]
                    .Value?.ToString() ?? "";

                txtSeatID.Text =
                    row.Cells["SeatID"]
                    .Value?.ToString() ?? "";

                if (DateTime.TryParse(
                    row.Cells["BookingDate"]
                    .Value?.ToString(),
                    out DateTime bookingDate))
                {
                    dtpBookingDate.Value =
                        bookingDate;
                }

                if (int.TryParse(
                    row.Cells["Quantity"]
                    .Value?.ToString(),
                    out int quantity))
                {
                    txtQuantity.Text =
                        quantity.ToString();
                }
                else
                {
                    txtQuantity.Text = "1";
                }

                string showId =
                    txtShowID.Text;

                DataTable priceData =
                    Da.ExecuteQuery(
                        "SELECT S_Price " +
                        "FROM ManageShows " +
                        "WHERE ShowID = '" +
                        EscapeSql(showId) +
                        "'");

                if (priceData.Rows.Count > 0)
                {
                    decimal.TryParse(
                        priceData.Rows[0]["S_Price"]
                        ?.ToString(),
                        NumberStyles.Any,
                        CultureInfo.CurrentCulture,
                        out selectedShowPrice);
                }

                UpdateTotalPrice();

                string status =
                    row.Cells["Ticket_Status"]
                    .Value?.ToString() ?? "";

                if (!string.IsNullOrWhiteSpace(status))
                {
                    cmbTicketStatus.SelectedItem =
                        status;
                }

                LoadSeatsDashboard(
                    txtShowID.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not load booking details:\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dgvShowsDashboard_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
        }

        private void dgvSeatDashboard_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
        }

        private string EscapeSql(
            string value)
        {
            if (value == null)
                return "";

            return value.Replace(
                "'",
                "''");
        }
    }
}