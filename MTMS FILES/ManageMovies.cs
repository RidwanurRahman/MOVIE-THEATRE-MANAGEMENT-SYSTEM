using System;
using System.Data;
using System.Windows.Forms;

namespace Movie_Theater_Management_System
{
    public partial class ManageMovies : Form
    {
        private Admin_Dashboard ad;
        private readonly DataAccess Da = new DataAccess();

        public ManageMovies(Admin_Dashboard ad)
        {
            InitializeComponent();
            this.ad = ad;
            this.Load += ManageMovies_Load;
        }

        private void ManageMovies_Load(object sender, EventArgs e)
        {
            try
            {
                txtMovieID.ReadOnly = true;

                if (cmbMGenre.Items.Count == 0)
                {
                    cmbMGenre.Items.Add("Action");
                    cmbMGenre.Items.Add("Adventure");
                    cmbMGenre.Items.Add("Animation");
                    cmbMGenre.Items.Add("Comedy");
                    cmbMGenre.Items.Add("Crime");
                    cmbMGenre.Items.Add("Drama");
                    cmbMGenre.Items.Add("Fantasy");
                    cmbMGenre.Items.Add("Horror");
                    cmbMGenre.Items.Add("Romance");
                    cmbMGenre.Items.Add("Sci-Fi");
                    cmbMGenre.Items.Add("Thriller");
                }

                if (cmbMLanguage.Items.Count == 0)
                {
                    cmbMLanguage.Items.Add("English");
                    cmbMLanguage.Items.Add("Bangla");
                    cmbMLanguage.Items.Add("Hindi");
                    cmbMLanguage.Items.Add("Tamil");
                    cmbMLanguage.Items.Add("Korean");
                }

                if (cmbMStatus.Items.Count == 0)
                {
                    cmbMStatus.Items.Add("Active");
                    cmbMStatus.Items.Add("Inactive");
                    cmbMStatus.Items.Add("Upcoming");
                }

                dgvManageMovies.AutoGenerateColumns = true;
                dgvManageMovies.ReadOnly = true;
                dgvManageMovies.AllowUserToAddRows = false;
                dgvManageMovies.AllowUserToDeleteRows = false;
                dgvManageMovies.MultiSelect = false;
                dgvManageMovies.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;
                dgvManageMovies.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                LoadData();

                txtMovieID.Text =
                    GenerateNextMovieID();

                if (string.IsNullOrWhiteSpace(
                    txtMReleaseDate.Text))
                {
                    txtMReleaseDate.Text =
                        DateTime.Now.ToString("yyyy-MM-dd");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error while loading Manage Movies:\n" +
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
                dgvManageMovies.AutoGenerateColumns = true;
                dgvManageMovies.DataSource = null;

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

                DataTable dt =
                    Da.ExecuteQuery(sql);

                dgvManageMovies.DataSource = dt;

                dgvManageMovies.ReadOnly = true;
                dgvManageMovies.AllowUserToAddRows = false;
                dgvManageMovies.AllowUserToDeleteRows = false;
                dgvManageMovies.MultiSelect = false;
                dgvManageMovies.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;
                dgvManageMovies.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvManageMovies.ClearSelection();
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

        private string GenerateNextMovieID()
        {
            try
            {
                DataTable dt =
                    Da.ExecuteQuery(@"
                        SELECT MovieID
                        FROM ManageMovies
                        WHERE MovieID LIKE 'M%'");

                int maxNumber = 0;

                foreach (DataRow row in dt.Rows)
                {
                    string id =
                        row["MovieID"]?.ToString() ?? "";

                    if (!id.StartsWith(
                        "M",
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

                return "M" +
                    (maxNumber + 1).ToString("D3");
            }
            catch
            {
                return "M001";
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

        private void btnAdd_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(
                    txtMTitle.Text))
                {
                    MessageBox.Show(
                        "Enter Movie Title!",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtMTitle.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(
                    cmbMGenre.Text))
                {
                    MessageBox.Show(
                        "Select Movie Genre!",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    cmbMGenre.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(
                    txtMDuration.Text))
                {
                    MessageBox.Show(
                        "Enter Movie Duration!",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtMDuration.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(
                    txtMReleaseDate.Text))
                {
                    MessageBox.Show(
                        "Enter Movie Release Date!",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtMReleaseDate.Focus();
                    return;
                }

                if (!IsValidDate(
                    txtMReleaseDate.Text.Trim(),
                    out DateTime releaseDate))
                {
                    MessageBox.Show(
                        "Enter a valid date.\nExample: 2026-09-25",
                        "Invalid Date",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtMReleaseDate.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(
                    cmbMLanguage.Text))
                {
                    MessageBox.Show(
                        "Select Movie Language!",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    cmbMLanguage.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(
                    txtMRating.Text))
                {
                    MessageBox.Show(
                        "Enter Movie Rating!",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtMRating.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(
                    cmbMStatus.Text))
                {
                    MessageBox.Show(
                        "Select Movie Status!",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    cmbMStatus.Focus();
                    return;
                }

                string movieId =
                    GenerateNextMovieID();

                txtMovieID.Text =
                    movieId;

                string sql = @"
                    INSERT INTO ManageMovies
                    (
                        MovieID,
                        M_Title,
                        M_Genre,
                        M_Duration,
                        M_ReleaseDate,
                        M_Language,
                        M_Rating,
                        M_Status
                    )
                    VALUES
                    (
                        '" +
                    EscapeSql(movieId) + @"',
                        '" +
                    EscapeSql(
                        txtMTitle.Text.Trim()) + @"',
                        '" +
                    EscapeSql(
                        cmbMGenre.Text.Trim()) + @"',
                        '" +
                    EscapeSql(
                        txtMDuration.Text.Trim()) + @"',
                        '" +
                    releaseDate.ToString(
                        "yyyy-MM-dd") + @"',
                        '" +
                    EscapeSql(
                        cmbMLanguage.Text.Trim()) + @"',
                        '" +
                    EscapeSql(
                        txtMRating.Text.Trim()) + @"',
                        '" +
                    EscapeSql(
                        cmbMStatus.Text.Trim()) + @"'
                    )";

                int result =
                    Da.ExecuteDML(sql);

                if (result > 0)
                {
                    MessageBox.Show(
                        "Movie Added Successfully!\n\n" +
                        "Movie ID: " + movieId,
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadData();
                    ClearAll();
                }
                else
                {
                    MessageBox.Show(
                        "Movie could not be added.",
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
                    txtMovieID.Text))
                {
                    MessageBox.Show(
                        "Select a movie first!",
                        "Update",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (string.IsNullOrWhiteSpace(
                    txtMTitle.Text))
                {
                    MessageBox.Show(
                        "Enter Movie Title!",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtMTitle.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(
                    cmbMGenre.Text))
                {
                    MessageBox.Show(
                        "Select Movie Genre!",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    cmbMGenre.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(
                    txtMDuration.Text))
                {
                    MessageBox.Show(
                        "Enter Movie Duration!",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtMDuration.Focus();
                    return;
                }

                if (!IsValidDate(
                    txtMReleaseDate.Text.Trim(),
                    out DateTime releaseDate))
                {
                    MessageBox.Show(
                        "Enter a valid release date.",
                        "Invalid Date",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtMReleaseDate.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(
                    cmbMLanguage.Text))
                {
                    MessageBox.Show(
                        "Select Movie Language!",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    cmbMLanguage.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(
                    txtMRating.Text))
                {
                    MessageBox.Show(
                        "Enter Movie Rating!",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtMRating.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(
                    cmbMStatus.Text))
                {
                    MessageBox.Show(
                        "Select Movie Status!",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    cmbMStatus.Focus();
                    return;
                }

                string sql = @"
                    UPDATE ManageMovies
                    SET
                        M_Title = '" +
                    EscapeSql(
                        txtMTitle.Text.Trim()) + @"',
                        M_Genre = '" +
                    EscapeSql(
                        cmbMGenre.Text.Trim()) + @"',
                        M_Duration = '" +
                    EscapeSql(
                        txtMDuration.Text.Trim()) + @"',
                        M_ReleaseDate = '" +
                    releaseDate.ToString(
                        "yyyy-MM-dd") + @"',
                        M_Language = '" +
                    EscapeSql(
                        cmbMLanguage.Text.Trim()) + @"',
                        M_Rating = '" +
                    EscapeSql(
                        txtMRating.Text.Trim()) + @"',
                        M_Status = '" +
                    EscapeSql(
                        cmbMStatus.Text.Trim()) + @"'
                    WHERE MovieID = '" +
                    EscapeSql(
                        txtMovieID.Text.Trim()) + "'";

                int result =
                    Da.ExecuteDML(sql);

                if (result > 0)
                {
                    MessageBox.Show(
                        "Movie Updated Successfully!",
                        "Update",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadData();
                    ClearAll();
                }
                else
                {
                    MessageBox.Show(
                        "Movie could not be updated.",
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
                if (dgvManageMovies.CurrentRow == null ||
                    dgvManageMovies.CurrentRow.IsNewRow)
                {
                    MessageBox.Show(
                        "Select a movie first!",
                        "Delete",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                string id =
                    dgvManageMovies.CurrentRow
                    .Cells["MovieID"]
                    .Value?.ToString() ?? "";

                if (string.IsNullOrWhiteSpace(id))
                    return;

                DialogResult result =
                    MessageBox.Show(
                        "Are you sure you want to delete this movie?",
                        "Confirm Delete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;

                string sql =
                    "DELETE FROM ManageMovies " +
                    "WHERE MovieID='" +
                    EscapeSql(id) + "'";

                int deleteResult =
                    Da.ExecuteDML(sql);

                if (deleteResult > 0)
                {
                    MessageBox.Show(
                        "Movie Deleted Successfully!",
                        "Delete",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadData();
                    ClearAll();
                }
                else
                {
                    MessageBox.Show(
                        "Movie could not be deleted.",
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

        private void dgvManageMovies_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvManageMovies.Rows[
                e.RowIndex].IsNewRow)
                return;

            try
            {
                DataGridViewRow row =
                    dgvManageMovies.Rows[
                        e.RowIndex];

                txtMovieID.Text =
                    row.Cells["MovieID"]
                    .Value?.ToString() ?? "";

                txtMTitle.Text =
                    row.Cells["M_Title"]
                    .Value?.ToString() ?? "";

                cmbMGenre.Text =
                    row.Cells["M_Genre"]
                    .Value?.ToString() ?? "";

                txtMDuration.Text =
                    row.Cells["M_Duration"]
                    .Value?.ToString() ?? "";

                txtMReleaseDate.Text =
                    row.Cells["M_ReleaseDate"]
                    .Value?.ToString() ?? "";

                if (DateTime.TryParse(
                    txtMReleaseDate.Text,
                    out DateTime releaseDate))
                {
                    txtMReleaseDate.Text =
                        releaseDate.ToString(
                            "yyyy-MM-dd");
                }

                cmbMLanguage.Text =
                    row.Cells["M_Language"]
                    .Value?.ToString() ?? "";

                txtMRating.Text =
                    row.Cells["M_Rating"]
                    .Value?.ToString() ?? "";

                cmbMStatus.Text =
                    row.Cells["M_Status"]
                    .Value?.ToString() ?? "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not load movie details:\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ClearAll()
        {
            txtMovieID.Text =
                GenerateNextMovieID();

            txtMTitle.Clear();

            cmbMGenre.SelectedIndex = -1;

            txtMDuration.Clear();

            txtMReleaseDate.Text =
                DateTime.Now.ToString(
                    "yyyy-MM-dd");

            cmbMLanguage.SelectedIndex = -1;

            txtMRating.Clear();

            cmbMStatus.SelectedIndex = -1;

            txtSearch.Clear();

            dgvManageMovies.ClearSelection();
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
                        MovieID,
                        M_Title,
                        M_Genre,
                        M_Duration,
                        M_ReleaseDate,
                        M_Language,
                        M_Rating,
                        M_Status
                    FROM ManageMovies
                    WHERE
                        MovieID LIKE '%" +
                    safeValue + @"%'
                        OR M_Title LIKE '%" +
                    safeValue + @"%'
                        OR M_Genre LIKE '%" +
                    safeValue + @"%'
                        OR M_Duration LIKE '%" +
                    safeValue + @"%'
                        OR CONVERT(
                            VARCHAR(50),
                            M_ReleaseDate,
                            120
                        ) LIKE '%" +
                    safeValue + @"%'
                        OR M_Language LIKE '%" +
                    safeValue + @"%'
                        OR M_Rating LIKE '%" +
                    safeValue + @"%'
                        OR M_Status LIKE '%" +
                    safeValue + @"%'
                    ORDER BY MovieID";

                DataTable dt =
                    Da.ExecuteQuery(sql);

                dgvManageMovies.DataSource =
                    dt;

                dgvManageMovies.ReadOnly = true;
                dgvManageMovies.AllowUserToAddRows = false;
                dgvManageMovies.AllowUserToDeleteRows = false;
                dgvManageMovies.MultiSelect = false;
                dgvManageMovies.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;
                dgvManageMovies.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvManageMovies.ClearSelection();
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

        private void lblX_Click(
            object sender,
            EventArgs e)
        {
            this.Hide();

            if (ad != null &&
                !ad.IsDisposed)
            {
                ad.Show();
                ad.BringToFront();
                ad.Activate();
            }
            else
            {
                new Admin_Dashboard().Show();
            }
        }

        private void btnBrowse_Click(
            object sender,
            EventArgs e)
        {
        }

        private void txtSearch_MaskInputRejected(
            object sender,
            MaskInputRejectedEventArgs e)
        {
        }

        private void btnUpdate_Click_1(
            object sender,
            EventArgs e)
        {
            btnUpdate_Click(sender, e);
        }

        private void btnDelete_Click_1(
            object sender,
            EventArgs e)
        {
            btnDelete_Click(sender, e);
        }

        private void btnClear_Click_1(
            object sender,
            EventArgs e)
        {
            btnClear_Click(sender, e);
        }

        private void txtSearch_TextChanged_1(
            object sender,
            EventArgs e)
        {
            txtSearch_TextChanged(sender, e);
        }

        private void dgvManageMovies_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
        }

        private string EscapeSql(string value)
        {
            if (value == null)
                return "";

            return value.Replace(
                "'",
                "''");
        }
    }
}