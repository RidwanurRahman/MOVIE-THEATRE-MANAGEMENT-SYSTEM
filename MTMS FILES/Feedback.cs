using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace Movie_Theater_Management_System
{
    public partial class Feedback : Form
    {
        private CustomerDashboard? cd;
        private readonly DataAccess Da = new DataAccess();

        private string loggedInUserId = "";

        public Feedback()
        {
            InitializeComponent();
        }

        public Feedback(CustomerDashboard cd)
        {
            InitializeComponent();
            this.cd = cd;
        }

        private void Feedback_Load(object sender, EventArgs e)
        {
            try
            {
                loggedInUserId = Login.CurrentUserID;

                txtFeedbackID.ReadOnly = true;
                txtUserID.ReadOnly = true;
                txtMovieID.ReadOnly = true;

                txtFeedbackID.Text =
                    GenerateNextFeedbackID();

                txtUserID.Text =
                    loggedInUserId;

                txtMovieID.Clear();
                txtFRating.Clear();
                txtFComment.Clear();

                dtpFReviewDate.Value =
                    DateTime.Now;

                dgvBookingTickets.AutoGenerateColumns = true;
                dgvBookingTickets.ReadOnly = true;
                dgvBookingTickets.AllowUserToAddRows = false;
                dgvBookingTickets.AllowUserToDeleteRows = false;
                dgvBookingTickets.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;
                dgvBookingTickets.MultiSelect = false;
                dgvBookingTickets.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvAudienceFeedback.AutoGenerateColumns = true;
                dgvAudienceFeedback.ReadOnly = true;
                dgvAudienceFeedback.AllowUserToAddRows = false;
                dgvAudienceFeedback.AllowUserToDeleteRows = false;
                dgvAudienceFeedback.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;
                dgvAudienceFeedback.MultiSelect = false;
                dgvAudienceFeedback.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                LoadBookingTickets();
                LoadFeedbackData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error while loading Feedback:\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private string GenerateNextFeedbackID()
        {
            try
            {
                DataTable dt =
                    Da.ExecuteQuery(
                        "SELECT FeedbackID FROM AudienceFeedback");

                int maxNumber = 0;

                foreach (DataRow row in dt.Rows)
                {
                    string id =
                        row["FeedbackID"]?.ToString() ?? "";

                    if (!id.StartsWith(
                        "F",
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

                return "F" +
                    (maxNumber + 1).ToString("D3");
            }
            catch
            {
                return "F001";
            }
        }

        private void LoadBookingTickets()
        {
            try
            {
                loggedInUserId =
                    Login.CurrentUserID;

                if (string.IsNullOrWhiteSpace(
                    loggedInUserId))
                {
                    dgvBookingTickets.DataSource =
                        null;
                    return;
                }

                string userId =
                    EscapeSql(loggedInUserId);

                string sql = @"
                    SELECT
                        b.BookingID,
                        b.UserID,
                        b.ShowID,
                        b.SeatID,
                        m.MovieID,
                        m.M_Title AS MovieTitle,
                        b.BookingDate,
                        b.Quantity,
                        b.TotalPrice,
                        b.Ticket_Status
                    FROM BookingTicket b
                    INNER JOIN ManageShows s
                        ON b.ShowID = s.ShowID
                    INNER JOIN ManageMovies m
                        ON s.MovieID = m.MovieID
                    WHERE b.UserID = '" +
                    userId + @"'
                    ORDER BY b.BookingID DESC";

                DataTable dt =
                    Da.ExecuteQuery(sql);

                dgvBookingTickets.DataSource =
                    dt;

                dgvBookingTickets.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Booking Ticket Load Error:\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadFeedbackData()
        {
            try
            {
                loggedInUserId =
                    Login.CurrentUserID;

                if (string.IsNullOrWhiteSpace(
                    loggedInUserId))
                {
                    dgvAudienceFeedback.DataSource =
                        null;
                    return;
                }

                string userId =
                    EscapeSql(loggedInUserId);

                string sql = @"
                    SELECT
                        f.FeedbackID,
                        f.UserID,
                        f.MovieID,
                        m.M_Title AS MovieTitle,
                        f.F_Rating,
                        f.F_Comment,
                        f.F_ReviewDate
                    FROM AudienceFeedback f
                    LEFT JOIN ManageMovies m
                        ON f.MovieID = m.MovieID
                    WHERE f.UserID = '" +
                    userId + @"'
                    ORDER BY f.FeedbackID DESC";

                DataTable dt =
                    Da.ExecuteQuery(sql);

                dgvAudienceFeedback.DataSource =
                    dt;

                dgvAudienceFeedback.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Feedback Load Error:\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dgvBookingTickets_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvBookingTickets.Rows[e.RowIndex].IsNewRow)
                return;

            try
            {
                DataGridViewRow row =
                    dgvBookingTickets.Rows[
                        e.RowIndex];

                string status =
                    row.Cells["Ticket_Status"]
                    .Value?.ToString() ?? "";

                if (!string.Equals(
                    status,
                    "Confirmed",
                    StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(
                        "You can review only confirmed bookings.",
                        "Review Not Allowed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                string movieId =
                    row.Cells["MovieID"]
                    .Value?.ToString() ?? "";

                if (string.IsNullOrWhiteSpace(
                    movieId))
                {
                    MessageBox.Show(
                        "Movie ID was not found for this booking.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                txtUserID.Text =
                    loggedInUserId;

                txtMovieID.Text =
                    movieId;

                MessageBox.Show(
                    "Movie selected successfully.\n\n" +
                    "Movie ID: " + movieId +
                    "\nMovie: " +
                    (row.Cells["MovieTitle"]
                    .Value?.ToString() ?? ""),
                    "Movie Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not select movie:\n" +
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
                    txtMovieID.Text))
                {
                    MessageBox.Show(
                        "Please select a movie from a confirmed booking.",
                        "Movie Required",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (string.IsNullOrWhiteSpace(
                    txtFRating.Text))
                {
                    MessageBox.Show(
                        "Please enter a rating.",
                        "Rating Required",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtFRating.Focus();
                    return;
                }

                if (!decimal.TryParse(
                    txtFRating.Text.Trim(),
                    NumberStyles.Number,
                    CultureInfo.CurrentCulture,
                    out decimal rating))
                {
                    if (!decimal.TryParse(
                        txtFRating.Text.Trim(),
                        NumberStyles.Number,
                        CultureInfo.InvariantCulture,
                        out rating))
                    {
                        MessageBox.Show(
                            "Rating must be a numeric value.",
                            "Invalid Rating",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        txtFRating.Focus();
                        return;
                    }
                }

                if (string.IsNullOrWhiteSpace(
                    txtFComment.Text))
                {
                    MessageBox.Show(
                        "Please write a comment.",
                        "Comment Required",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtFComment.Focus();
                    return;
                }

                string userId =
                    EscapeSql(loggedInUserId);

                string movieId =
                    EscapeSql(txtMovieID.Text);

                string bookingCheckSql = @"
                    SELECT COUNT(*) AS BookingCount
                    FROM BookingTicket b
                    INNER JOIN ManageShows s
                        ON b.ShowID = s.ShowID
                    WHERE b.UserID = '" +
                    userId + @"'
                      AND s.MovieID = '" +
                    movieId + @"'
                      AND b.Ticket_Status = 'Confirmed'";

                DataTable bookingCheck =
                    Da.ExecuteQuery(
                        bookingCheckSql);

                int bookingCount =
                    Convert.ToInt32(
                        bookingCheck.Rows[0][
                            "BookingCount"]);

                if (bookingCount <= 0)
                {
                    MessageBox.Show(
                        "You can review only a movie from your confirmed bookings.",
                        "Review Not Allowed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                string duplicateCheckSql = @"
                    SELECT COUNT(*) AS ReviewCount
                    FROM AudienceFeedback
                    WHERE UserID = '" +
                    userId + @"'
                      AND MovieID = '" +
                    movieId + "'";

                DataTable duplicateCheck =
                    Da.ExecuteQuery(
                        duplicateCheckSql);

                int reviewCount =
                    Convert.ToInt32(
                        duplicateCheck.Rows[0][
                            "ReviewCount"]);

                if (reviewCount > 0)
                {
                    MessageBox.Show(
                        "You have already reviewed this movie.",
                        "Duplicate Review",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                string feedbackId =
                    GenerateNextFeedbackID();

                string ratingText =
                    rating.ToString(
                        CultureInfo.InvariantCulture);

                string sql = @"
                    INSERT INTO AudienceFeedback
                    (
                        FeedbackID,
                        UserID,
                        MovieID,
                        F_Rating,
                        F_Comment,
                        F_ReviewDate
                    )
                    VALUES
                    (
                        '" +
                    EscapeSql(feedbackId) + @"',
                        '" +
                    userId + @"',
                        '" +
                    movieId + @"',
                        '" +
                    ratingText + @"',
                        '" +
                    EscapeSql(
                        txtFComment.Text.Trim()) + @"',
                        '" +
                    dtpFReviewDate.Value.ToString(
                        "yyyy-MM-dd") + @"'
                    )";

                int result =
                    Da.ExecuteDML(sql);

                if (result > 0)
                {
                    MessageBox.Show(
                        "Review Added Successfully!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadBookingTickets();
                    LoadFeedbackData();
                    ClearAll();
                }
                else
                {
                    MessageBox.Show(
                        "Review could not be added.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error adding review:\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dgvAudienceFeedback_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvAudienceFeedback.Rows[e.RowIndex].IsNewRow)
                return;

            try
            {
                DataGridViewRow row =
                    dgvAudienceFeedback.Rows[
                        e.RowIndex];

                txtFeedbackID.Text =
                    row.Cells["FeedbackID"]
                    .Value?.ToString() ?? "";

                txtUserID.Text =
                    Login.CurrentUserID;

                txtMovieID.Text =
                    row.Cells["MovieID"]
                    .Value?.ToString() ?? "";

                txtFRating.Text =
                    row.Cells["F_Rating"]
                    .Value?.ToString() ?? "";

                txtFComment.Text =
                    row.Cells["F_Comment"]
                    .Value?.ToString() ?? "";

                if (DateTime.TryParse(
                    row.Cells["F_ReviewDate"]
                    .Value?.ToString(),
                    out DateTime reviewDate))
                {
                    dtpFReviewDate.Value =
                        reviewDate;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not load review details:\n" +
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
                    txtFeedbackID.Text))
                {
                    MessageBox.Show(
                        "Select a review first.",
                        "Update",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (string.IsNullOrWhiteSpace(
                    txtMovieID.Text))
                {
                    MessageBox.Show(
                        "Movie ID is required.",
                        "Update",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (string.IsNullOrWhiteSpace(
                    txtFRating.Text))
                {
                    MessageBox.Show(
                        "Please enter a rating.",
                        "Rating Required",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtFRating.Focus();
                    return;
                }

                if (!decimal.TryParse(
                    txtFRating.Text.Trim(),
                    NumberStyles.Number,
                    CultureInfo.CurrentCulture,
                    out decimal rating))
                {
                    if (!decimal.TryParse(
                        txtFRating.Text.Trim(),
                        NumberStyles.Number,
                        CultureInfo.InvariantCulture,
                        out rating))
                    {
                        MessageBox.Show(
                            "Rating must be a numeric value.",
                            "Invalid Rating",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        txtFRating.Focus();
                        return;
                    }
                }

                if (string.IsNullOrWhiteSpace(
                    txtFComment.Text))
                {
                    MessageBox.Show(
                        "Please write a comment.",
                        "Comment Required",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtFComment.Focus();
                    return;
                }

                string ratingText =
                    rating.ToString(
                        CultureInfo.InvariantCulture);

                string sql = @"
                    UPDATE AudienceFeedback
                    SET
                        F_Rating = '" +
                    ratingText + @"',
                        F_Comment = '" +
                    EscapeSql(
                        txtFComment.Text.Trim()) + @"',
                        F_ReviewDate = '" +
                    dtpFReviewDate.Value.ToString(
                        "yyyy-MM-dd") + @"'
                    WHERE FeedbackID = '" +
                    EscapeSql(
                        txtFeedbackID.Text) + @"'
                      AND UserID = '" +
                    EscapeSql(
                        loggedInUserId) + "'";

                int result =
                    Da.ExecuteDML(sql);

                if (result > 0)
                {
                    MessageBox.Show(
                        "Review updated successfully!",
                        "Update",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadFeedbackData();
                    ClearAll();
                }
                else
                {
                    MessageBox.Show(
                        "Review could not be updated.",
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
                if (dgvAudienceFeedback.CurrentRow == null ||
                    dgvAudienceFeedback.CurrentRow.IsNewRow)
                {
                    MessageBox.Show(
                        "Select a review first.",
                        "Delete",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                string feedbackId =
                    dgvAudienceFeedback
                    .CurrentRow
                    .Cells["FeedbackID"]
                    .Value?.ToString() ?? "";

                if (string.IsNullOrWhiteSpace(
                    feedbackId))
                    return;

                DialogResult result =
                    MessageBox.Show(
                        "Are you sure you want to delete this review?",
                        "Confirm Delete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;

                string sql = @"
                    DELETE FROM AudienceFeedback
                    WHERE FeedbackID = '" +
                    EscapeSql(feedbackId) + @"'
                      AND UserID = '" +
                    EscapeSql(
                        Login.CurrentUserID) + "'";

                int deleted =
                    Da.ExecuteDML(sql);

                if (deleted > 0)
                {
                    MessageBox.Show(
                        "Review deleted successfully!",
                        "Delete",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadFeedbackData();
                    ClearAll();
                }
                else
                {
                    MessageBox.Show(
                        "Review could not be deleted.",
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
            ClearAll();
        }

        private void ClearAll()
        {
            loggedInUserId =
                Login.CurrentUserID;

            txtFeedbackID.Text =
                GenerateNextFeedbackID();

            txtUserID.Text =
                loggedInUserId;

            txtMovieID.Clear();
            txtFRating.Clear();
            txtFComment.Clear();
            txtSearch.Clear();

            dtpFReviewDate.Value =
                DateTime.Now;

            dgvBookingTickets.ClearSelection();
            dgvAudienceFeedback.ClearSelection();

            LoadFeedbackData();
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
                    dgvAudienceFeedback.DataSource =
                        null;
                    return;
                }

                string value =
                    txtSearch.Text.Trim();

                if (string.IsNullOrWhiteSpace(value))
                {
                    LoadFeedbackData();
                    return;
                }

                string safeValue =
                    EscapeSql(value);

                string userId =
                    EscapeSql(loggedInUserId);

                string sql = @"
                    SELECT
                        f.FeedbackID,
                        f.UserID,
                        f.MovieID,
                        m.M_Title AS MovieTitle,
                        f.F_Rating,
                        f.F_Comment,
                        f.F_ReviewDate
                    FROM AudienceFeedback f
                    LEFT JOIN ManageMovies m
                        ON f.MovieID = m.MovieID
                    WHERE f.UserID = '" +
                    userId + @"'
                      AND (
                            f.FeedbackID LIKE '%" +
                    safeValue + @"%'
                            OR f.MovieID LIKE '%" +
                    safeValue + @"%'
                            OR m.M_Title LIKE '%" +
                    safeValue + @"%'
                            OR CONVERT(
                                VARCHAR(50),
                                f.F_Rating
                            ) LIKE '%" +
                    safeValue + @"%'
                            OR f.F_Comment LIKE '%" +
                    safeValue + @"%'
                            OR CONVERT(
                                VARCHAR(50),
                                f.F_ReviewDate,
                                120
                            ) LIKE '%" +
                    safeValue + @"%'
                          )
                    ORDER BY f.FeedbackID DESC";

                DataTable dt =
                    Da.ExecuteQuery(sql);

                dgvAudienceFeedback.DataSource =
                    dt;

                dgvAudienceFeedback.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvAudienceFeedback.ClearSelection();
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

        private void button1_Click(
            object sender,
            EventArgs e)
        {
            this.Hide();

            if (cd != null)
            {
                cd.Show();
                cd.BringToFront();
                cd.Activate();
            }
            else
            {
                this.Close();
            }
        }

        private void label1_Click(
            object sender,
            EventArgs e)
        {
        }

        private void txtSearch_MaskInputRejected(
            object sender,
            MaskInputRejectedEventArgs e)
        {
        }

        private void dgvShowsDashboard_CellDoubleClick(
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