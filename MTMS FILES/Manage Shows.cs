using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace Movie_Theater_Management_System
{
    public partial class Manage_Shows : Form
    {
        private readonly DataAccess Da = new DataAccess();
        private DataGridView? movieDashboard;

        public Manage_Shows()
        {
            InitializeComponent();
            this.Load += ManageShows_Load;
        }

        private void ManageShows_Load(object sender, EventArgs e)
        {
            try
            {
                txtShowID.ReadOnly = true;
                txtMovieID.ReadOnly = true;
                txtSAvailableSeats.ReadOnly = false;

                txtShowID.Text =
                    GenerateNextShowID();

                if (string.IsNullOrWhiteSpace(
                    txtShowDate.Text))
                {
                    txtShowDate.Text =
                        DateTime.Now.ToString("yyyy-MM-dd");
                }

                if (string.IsNullOrWhiteSpace(
                    txtSAvailableSeats.Text))
                {
                    txtSAvailableSeats.Text = "0";
                }

                SetupMovieDashboard();
                LoadMovieDashboard();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error while loading Manage Shows:\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private DataGridView? FindMovieDashboard(
            Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is DataGridView dgv)
                {
                    string name =
                        dgv.Name ?? "";

                    if (name.IndexOf(
                        "Movie",
                        StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        return dgv;
                    }
                }

                if (control.HasChildren)
                {
                    DataGridView? result =
                        FindMovieDashboard(control);

                    if (result != null)
                    {
                        return result;
                    }
                }
            }

            return null;
        }

        private void SetupMovieDashboard()
        {
            movieDashboard =
                FindMovieDashboard(this);

            if (movieDashboard == null)
                return;

            movieDashboard.AutoGenerateColumns = true;
            movieDashboard.ReadOnly = true;
            movieDashboard.AllowUserToAddRows = false;
            movieDashboard.AllowUserToDeleteRows = false;
            movieDashboard.MultiSelect = false;
            movieDashboard.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            movieDashboard.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            movieDashboard.CellDoubleClick -=
                MovieDashboard_CellDoubleClick;

            movieDashboard.CellDoubleClick +=
                MovieDashboard_CellDoubleClick;
        }

        private void LoadMovieDashboard()
        {
            if (movieDashboard == null)
                return;

            string sql = @"
                SELECT
                    MovieID,
                    M_Title,
                    M_Genre,
                    M_Duration,
                    M_ReleaseDate,
                    M_Language,
                    M_Rating,
                    M_Status
                FROM ManageMovies
                ORDER BY MovieID";

            movieDashboard.DataSource =
                Da.ExecuteQuery(sql);

            movieDashboard.ClearSelection();
        }

        private void LoadData()
        {
            try
            {
                dgvManageShows.AutoGenerateColumns =
                    true;

                dgvManageShows.DataSource = null;

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

                dgvManageShows.DataSource = dt;

                dgvManageShows.ReadOnly = true;
                dgvManageShows.AllowUserToAddRows = false;
                dgvManageShows.AllowUserToDeleteRows = false;
                dgvManageShows.MultiSelect = false;
                dgvManageShows.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;
                dgvManageShows.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvManageShows.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Load Error:\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private string GenerateNextShowID()
        {
            try
            {
                DataTable dt =
                    Da.ExecuteQuery(@"
                        SELECT ShowID
                        FROM ManageShows
                        WHERE ShowID LIKE 'Sh%'");

                int maxNumber = 0;

                foreach (DataRow row in dt.Rows)
                {
                    string id =
                        row["ShowID"]
                        ?.ToString() ?? "";

                    if (!id.StartsWith(
                        "Sh",
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

                return "Sh" +
                    (maxNumber + 1).ToString("D3");
            }
            catch
            {
                return "Sh001";
            }
        }

        private bool IsValidDate(
            string value,
            out DateTime date)
        {
            return DateTime.TryParse(
                value,
                out date);
        }

        private void MovieDashboard_CellDoubleClick(
            object? sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            try
            {
                if (movieDashboard == null)
                    return;

                if (movieDashboard.Rows[
                    e.RowIndex].IsNewRow)
                    return;

                DataGridViewRow row =
                    movieDashboard.Rows[
                        e.RowIndex];

                string movieId =
                    row.Cells["MovieID"]
                    .Value?.ToString() ?? "";

                if (string.IsNullOrWhiteSpace(
                    movieId))
                    return;

                txtMovieID.Text =
                    movieId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not select Movie ID:\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
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
                        ShowID,
                        MovieID,
                        ShowDate,
                        ShowTime,
                        S_HallNo,
                        S_Price,
                        S_TotalSeats,
                        S_AvailableSeats
                    FROM ManageShows
                    WHERE
                        ShowID LIKE '%" +
                    safeValue + @"%'
                        OR MovieID LIKE '%" +
                    safeValue + @"%'
                        OR CONVERT(
                            VARCHAR(50),
                            ShowDate,
                            120
                        ) LIKE '%" +
                    safeValue + @"%'
                        OR CONVERT(
                            VARCHAR(50),
                            ShowTime,
                            108
                        ) LIKE '%" +
                    safeValue + @"%'
                        OR S_HallNo LIKE '%" +
                    safeValue + @"%'
                        OR CONVERT(
                            VARCHAR(50),
                            S_Price
                        ) LIKE '%" +
                    safeValue + @"%'
                        OR CONVERT(
                            VARCHAR(50),
                            S_TotalSeats
                        ) LIKE '%" +
                    safeValue + @"%'
                        OR CONVERT(
                            VARCHAR(50),
                            S_AvailableSeats
                        ) LIKE '%" +
                    safeValue + @"%'
                    ORDER BY ShowID";

                DataTable dt =
                    Da.ExecuteQuery(sql);

                dgvManageShows.DataSource =
                    dt;

                dgvManageShows.ClearSelection();
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

        private void btnAdd_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(
                    txtMovieID.Text))
                {
                    MessageBox.Show(
                        "Please select a Movie from Movie Dashboard.",
                        "Movie Required",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (string.IsNullOrWhiteSpace(
                    txtShowDate.Text))
                {
                    MessageBox.Show(
                        "Enter Show Date.",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtShowDate.Focus();
                    return;
                }

                if (!IsValidDate(
                    txtShowDate.Text.Trim(),
                    out DateTime showDate))
                {
                    MessageBox.Show(
                        "Enter a valid date.",
                        "Invalid Date",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtShowDate.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(
                    txtSPrice.Text))
                {
                    MessageBox.Show(
                        "Enter Show Price.",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtSPrice.Focus();
                    return;
                }

                if (!decimal.TryParse(
                    txtSPrice.Text.Trim(),
                    out decimal price) ||
                    price < 0)
                {
                    MessageBox.Show(
                        "Enter a valid Show Price.",
                        "Invalid Price",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtSPrice.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(
                    txtSTotalSeats.Text))
                {
                    MessageBox.Show(
                        "Enter Total Seats.",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtSTotalSeats.Focus();
                    return;
                }

                if (!int.TryParse(
                    txtSTotalSeats.Text.Trim(),
                    out int totalSeats) ||
                    totalSeats <= 0)
                {
                    MessageBox.Show(
                        "Total Seats must be greater than 0.",
                        "Invalid Seats",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtSTotalSeats.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(
                    txtSAvailableSeats.Text))
                {
                    MessageBox.Show(
                        "Enter Available Seats.",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtSAvailableSeats.Focus();
                    return;
                }

                if (!int.TryParse(
                    txtSAvailableSeats.Text.Trim(),
                    out int availableSeats) ||
                    availableSeats < 0 ||
                    availableSeats > totalSeats)
                {
                    MessageBox.Show(
                        "Available Seats must be between 0 and Total Seats.",
                        "Invalid Seats",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtSAvailableSeats.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(
                    cmbSHallNo.Text))
                {
                    MessageBox.Show(
                        "Select Hall Number.",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    cmbSHallNo.Focus();
                    return;
                }

                string showId =
                    GenerateNextShowID();

                txtShowID.Text =
                    showId;

                string sql = @"
                    INSERT INTO ManageShows
                    (
                        ShowID,
                        MovieID,
                        ShowDate,
                        ShowTime,
                        S_HallNo,
                        S_Price,
                        S_TotalSeats,
                        S_AvailableSeats
                    )
                    VALUES
                    (
                        '" +
                    EscapeSql(showId) + @"',
                        '" +
                    EscapeSql(
                        txtMovieID.Text.Trim()) + @"',
                        '" +
                    showDate.ToString(
                        "yyyy-MM-dd") + @"',
                        '" +
                    dtpShowTime.Value.ToString(
                        "HH:mm:ss") + @"',
                        '" +
                    EscapeSql(
                        cmbSHallNo.Text.Trim()) + @"',
                        '" +
                    price.ToString(
                        CultureInfo.InvariantCulture) + @"',
                        '" +
                    totalSeats + @"',
                        '" +
                    availableSeats + @"'
                    )";

                int result =
                    Da.ExecuteDML(sql);

                if (result > 0)
                {
                    MessageBox.Show(
                        "Show Added Successfully!\n\n" +
                        "Show ID: " + showId,
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadData();
                    ClearAll();
                }
                else
                {
                    MessageBox.Show(
                        "Show could not be added.",
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
                    txtShowID.Text))
                {
                    MessageBox.Show(
                        "Select a show first.",
                        "Update",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (string.IsNullOrWhiteSpace(
                    txtMovieID.Text))
                {
                    MessageBox.Show(
                        "Select a movie first.",
                        "Update",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (!IsValidDate(
                    txtShowDate.Text.Trim(),
                    out DateTime showDate))
                {
                    MessageBox.Show(
                        "Enter a valid Show Date.",
                        "Invalid Date",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtShowDate.Focus();
                    return;
                }

                if (!decimal.TryParse(
                    txtSPrice.Text.Trim(),
                    out decimal price) ||
                    price < 0)
                {
                    MessageBox.Show(
                        "Enter a valid Show Price.",
                        "Invalid Price",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtSPrice.Focus();
                    return;
                }

                if (!int.TryParse(
                    txtSTotalSeats.Text.Trim(),
                    out int totalSeats) ||
                    totalSeats <= 0)
                {
                    MessageBox.Show(
                        "Enter a valid Total Seats.",
                        "Invalid Seats",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtSTotalSeats.Focus();
                    return;
                }

                if (!int.TryParse(
                    txtSAvailableSeats.Text.Trim(),
                    out int availableSeats) ||
                    availableSeats < 0 ||
                    availableSeats > totalSeats)
                {
                    MessageBox.Show(
                        "Available Seats must be between 0 and Total Seats.",
                        "Invalid Seats",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtSAvailableSeats.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(
                    cmbSHallNo.Text))
                {
                    MessageBox.Show(
                        "Select Hall Number.",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    cmbSHallNo.Focus();
                    return;
                }

                string sql = @"
                    UPDATE ManageShows
                    SET
                        MovieID = '" +
                    EscapeSql(
                        txtMovieID.Text.Trim()) + @"',
                        ShowDate = '" +
                    showDate.ToString(
                        "yyyy-MM-dd") + @"',
                        ShowTime = '" +
                    dtpShowTime.Value.ToString(
                        "HH:mm:ss") + @"',
                        S_HallNo = '" +
                    EscapeSql(
                        cmbSHallNo.Text.Trim()) + @"',
                        S_Price = '" +
                    price.ToString(
                        CultureInfo.InvariantCulture) + @"',
                        S_TotalSeats = '" +
                    totalSeats + @"',
                        S_AvailableSeats = '" +
                    availableSeats + @"'
                    WHERE ShowID = '" +
                    EscapeSql(
                        txtShowID.Text.Trim()) + "'";

                int result =
                    Da.ExecuteDML(sql);

                if (result > 0)
                {
                    MessageBox.Show(
                        "Show Updated Successfully!",
                        "Update",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadData();
                    ClearAll();
                }
                else
                {
                    MessageBox.Show(
                        "Show could not be updated.",
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
                if (dgvManageShows.CurrentRow == null ||
                    dgvManageShows.CurrentRow.IsNewRow)
                {
                    MessageBox.Show(
                        "Select a show first.",
                        "Delete",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                string showId =
                    dgvManageShows
                    .CurrentRow
                    .Cells["ShowID"]
                    .Value?.ToString() ?? "";

                if (string.IsNullOrWhiteSpace(
                    showId))
                    return;

                DialogResult result =
                    MessageBox.Show(
                        "Are you sure you want to delete this show?",
                        "Confirm Delete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;

                string sql =
                    "DELETE FROM ManageShows " +
                    "WHERE ShowID='" +
                    EscapeSql(showId) + "'";

                int deleteResult =
                    Da.ExecuteDML(sql);

                if (deleteResult > 0)
                {
                    MessageBox.Show(
                        "Show Deleted Successfully!",
                        "Delete",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadData();
                    ClearAll();
                }
                else
                {
                    MessageBox.Show(
                        "Show could not be deleted.",
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

        private void dgvManageShows_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvManageShows.Rows[
                e.RowIndex].IsNewRow)
                return;

            try
            {
                DataGridViewRow row =
                    dgvManageShows.Rows[
                        e.RowIndex];

                txtShowID.Text =
                    row.Cells["ShowID"]
                    .Value?.ToString() ?? "";

                txtMovieID.Text =
                    row.Cells["MovieID"]
                    .Value?.ToString() ?? "";

                txtShowDate.Text =
                    row.Cells["ShowDate"]
                    .Value?.ToString() ?? "";

                if (DateTime.TryParse(
                    row.Cells["ShowTime"]
                    .Value?.ToString(),
                    out DateTime showTime))
                {
                    dtpShowTime.Value =
                        showTime;
                }

                cmbSHallNo.Text =
                    row.Cells["S_HallNo"]
                    .Value?.ToString() ?? "";

                txtSPrice.Text =
                    row.Cells["S_Price"]
                    .Value?.ToString() ?? "";

                txtSTotalSeats.Text =
                    row.Cells["S_TotalSeats"]
                    .Value?.ToString() ?? "";

                txtSAvailableSeats.Text =
                    row.Cells["S_AvailableSeats"]
                    .Value?.ToString() ?? "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not load show details:\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ClearAll()
        {
            txtShowID.Text =
                GenerateNextShowID();

            txtMovieID.Clear();

            txtShowDate.Text =
                DateTime.Now.ToString("yyyy-MM-dd");

            dtpShowTime.Value =
                DateTime.Now;

            cmbSHallNo.SelectedIndex = -1;

            txtSPrice.Clear();
            txtSTotalSeats.Clear();
            txtSAvailableSeats.Clear();

            txtSearch.Clear();

            if (movieDashboard != null)
            {
                movieDashboard.ClearSelection();
            }

            dgvManageShows.ClearSelection();
        }

        private void btnClear_Click(
            object sender,
            EventArgs e)
        {
            ClearAll();
        }

        private void btnX_Click(
            object sender,
            EventArgs e)
        {
            this.Hide();

            Admin_Dashboard ad =
                new Admin_Dashboard();

            ad.Show();
            ad.BringToFront();
            ad.Activate();
        }

        private void dgvMovieDashboard_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            MovieDashboard_CellDoubleClick(
                sender,
                e);
        }

        private void dgvMovieDashboard_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
        }

        private void txtSearch_MaskInputRejected(
            object sender,
            MaskInputRejectedEventArgs e)
        {
        }

        private void dgvManageShows_CellContentClick(
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