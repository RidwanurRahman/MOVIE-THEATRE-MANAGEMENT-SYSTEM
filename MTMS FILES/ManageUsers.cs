using System;
using System.Data;
using System.Windows.Forms;

namespace Movie_Theater_Management_System
{
    public partial class ManageUsers : Form
    {
        private SuperAdminDashboard sad;
        private readonly DataAccess Da = new DataAccess();

        public ManageUsers()
        {
            InitializeComponent();

            this.Load -= ManageUsers_Load;
            this.Load += ManageUsers_Load;

            dgvManageUsers.CellDoubleClick -=
                dgvManageUsers_CellDoubleClick;

            dgvManageUsers.CellDoubleClick +=
                dgvManageUsers_CellDoubleClick;
        }

        public ManageUsers(
            SuperAdminDashboard sad)
        {
            InitializeComponent();

            this.sad = sad;

            this.Load -= ManageUsers_Load;
            this.Load += ManageUsers_Load;

            dgvManageUsers.CellDoubleClick -=
                dgvManageUsers_CellDoubleClick;

            dgvManageUsers.CellDoubleClick +=
                dgvManageUsers_CellDoubleClick;
        }

        private void ManageUsers_Load(
            object sender,
            EventArgs e)
        {
            try
            {
                txtUserName.ReadOnly = true;
                txtPassword.ReadOnly = true;

                if (cmbRole.Items.Count == 0)
                {
                    cmbRole.Items.Add("SuperAdmin");
                    cmbRole.Items.Add("Admin");
                    cmbRole.Items.Add("Audience");
                    cmbRole.Items.Add("Customer");
                }

                cmbRole.SelectedIndex = -1;

                dgvManageUsers.AutoGenerateColumns = true;
                dgvManageUsers.ReadOnly = true;
                dgvManageUsers.AllowUserToAddRows = false;
                dgvManageUsers.AllowUserToDeleteRows = false;
                dgvManageUsers.MultiSelect = false;
                dgvManageUsers.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;
                dgvManageUsers.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error while loading Manage Users:\n" +
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
                        UserName,
                        Password,
                        Role,
                        Status
                    FROM dbo.[User]
                    ORDER BY UserName";

                DataTable dt =
                    Da.ExecuteQuery(sql);

                dgvManageUsers.DataSource = null;
                dgvManageUsers.AutoGenerateColumns = true;
                dgvManageUsers.DataSource = dt;

                dgvManageUsers.ReadOnly = true;
                dgvManageUsers.AllowUserToAddRows = false;
                dgvManageUsers.AllowUserToDeleteRows = false;
                dgvManageUsers.MultiSelect = false;
                dgvManageUsers.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;
                dgvManageUsers.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                if (dgvManageUsers.Columns.Contains(
                    "UserName"))
                {
                    dgvManageUsers.Columns["UserName"]
                        .HeaderText = "UserName";
                }

                if (dgvManageUsers.Columns.Contains(
                    "Password"))
                {
                    dgvManageUsers.Columns["Password"]
                        .HeaderText = "Password";
                }

                if (dgvManageUsers.Columns.Contains(
                    "Role"))
                {
                    dgvManageUsers.Columns["Role"]
                        .HeaderText = "Role";
                }

                if (dgvManageUsers.Columns.Contains(
                    "Status"))
                {
                    dgvManageUsers.Columns["Status"]
                        .HeaderText = "Status";
                }

                dgvManageUsers.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "User Data Load Error:\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dgvManageUsers_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvManageUsers.Rows[
                e.RowIndex].IsNewRow)
                return;

            try
            {
                DataGridViewRow row =
                    dgvManageUsers.Rows[
                        e.RowIndex];

                txtUserName.Text =
                    row.Cells["UserName"]
                    .Value?.ToString() ?? "";

                txtPassword.Text =
                    row.Cells["Password"]
                    .Value?.ToString() ?? "";

                cmbRole.Text =
                    row.Cells["Role"]
                    .Value?.ToString() ?? "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not load user details:\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnApprove_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(
                    txtUserName.Text))
                {
                    MessageBox.Show(
                        "Select a user first.",
                        "Approve",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                string userName =
                    txtUserName.Text.Trim();

                if (userName.Equals(
                    "SA001",
                    StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(
                        "SA001 is already an approved Super Admin.",
                        "Approve",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
                }

                string checkSql =
                    "SELECT Status " +
                    "FROM dbo.[User] " +
                    "WHERE UserName = '" +
                    EscapeSql(userName) +
                    "'";

                DataTable statusDt =
                    Da.ExecuteQuery(checkSql);

                if (statusDt.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "User not found.",
                        "Approve",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                string currentStatus =
                    statusDt.Rows[0]["Status"]
                    ?.ToString() ?? "";

                if (currentStatus.Equals(
                    "Approved",
                    StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(
                        "This user is already approved.",
                        "Approve",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
                }

                string sql =
                    "UPDATE dbo.[User] " +
                    "SET Status = 'Approved' " +
                    "WHERE UserName = '" +
                    EscapeSql(userName) +
                    "'";

                int result =
                    Da.ExecuteDML(sql);

                if (result > 0)
                {
                    MessageBox.Show(
                        "User approved successfully!",
                        "Approve",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadData();
                    ClearUserFields();
                }
                else
                {
                    MessageBox.Show(
                        "User could not be approved.",
                        "Approve",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Approve Error:\n" +
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
                    txtUserName.Text))
                {
                    MessageBox.Show(
                        "Select a user first.",
                        "Update",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (string.IsNullOrWhiteSpace(
                    cmbRole.Text))
                {
                    MessageBox.Show(
                        "Select a role.",
                        "Update",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                string userName =
                    txtUserName.Text.Trim();

                string newRole =
                    cmbRole.Text.Trim();

                if (userName.Equals(
                    "SA001",
                    StringComparison.OrdinalIgnoreCase) &&
                    !newRole.Equals(
                        "SuperAdmin",
                        StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(
                        "SA001 must remain SuperAdmin.",
                        "Restricted",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                string sql =
                    "UPDATE dbo.[User] " +
                    "SET Role = '" +
                    EscapeSql(newRole) +
                    "' " +
                    "WHERE UserName = '" +
                    EscapeSql(userName) +
                    "'";

                int result =
                    Da.ExecuteDML(sql);

                if (result > 0)
                {
                    MessageBox.Show(
                        "User role updated successfully!",
                        "Update",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadData();
                    ClearUserFields();
                }
                else
                {
                    MessageBox.Show(
                        "User role could not be updated.",
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

        private void btnUpdate_Click_1(
            object sender,
            EventArgs e)
        {
            btnUpdate_Click(sender, e);
        }

        private void btnDelete_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(
                    txtUserName.Text))
                {
                    MessageBox.Show(
                        "Select a user first.",
                        "Delete",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                string userName =
                    txtUserName.Text.Trim();

                if (userName.Equals(
                    "SA001",
                    StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(
                        "Super Admin cannot be deleted.",
                        "Restricted",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                DialogResult result =
                    MessageBox.Show(
                        "Are you sure you want to delete this user?",
                        "Confirm Delete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;

                string sql =
                    "DELETE FROM dbo.[User] " +
                    "WHERE UserName = '" +
                    EscapeSql(userName) +
                    "'";

                int deleted =
                    Da.ExecuteDML(sql);

                if (deleted > 0)
                {
                    MessageBox.Show(
                        "User deleted successfully!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadData();
                    ClearUserFields();
                }
                else
                {
                    MessageBox.Show(
                        "User could not be deleted.",
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

        private void ClearUserFields()
        {
            txtUserName.Clear();
            txtPassword.Clear();
            cmbRole.SelectedIndex = -1;

            dgvManageUsers.ClearSelection();
        }

        private void ClearAll()
        {
            txtUserName.Clear();
            txtPassword.Clear();
            cmbRole.SelectedIndex = -1;
            txtSearch.Clear();

            LoadData();

            dgvManageUsers.ClearSelection();
        }

        private void txtSearch_TextChanged(
            object sender,
            EventArgs e)
        {
            try
            {
                string value =
                    txtSearch.Text.Trim();

                if (string.IsNullOrWhiteSpace(
                    value))
                {
                    LoadData();
                    return;
                }

                string safeValue =
                    EscapeSql(value);

                string sql = @"
                    SELECT
                        UserName,
                        Password,
                        Role,
                        Status
                    FROM dbo.[User]
                    WHERE
                        UserName LIKE '%" +
                    safeValue + @"%'
                        OR Role LIKE '%" +
                    safeValue + @"%'
                        OR Status LIKE '%" +
                    safeValue + @"%'
                    ORDER BY UserName";

                DataTable dt =
                    Da.ExecuteQuery(sql);

                dgvManageUsers.DataSource =
                    dt;

                dgvManageUsers.ReadOnly = true;
                dgvManageUsers.AllowUserToAddRows = false;
                dgvManageUsers.AllowUserToDeleteRows = false;
                dgvManageUsers.MultiSelect = false;
                dgvManageUsers.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;
                dgvManageUsers.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvManageUsers.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Search Error:\n" +
                    ex.Message,
                    "Error",
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

                if (sad != null &&
                    !sad.IsDisposed)
                {
                    sad.WindowState =
                        FormWindowState.Normal;

                    sad.Show();
                    sad.BringToFront();
                    sad.Activate();
                }
                else
                {
                    SuperAdminDashboard dashboard =
                        new SuperAdminDashboard();

                    dashboard.Show();
                    dashboard.BringToFront();
                    dashboard.Activate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not return to Super Admin Dashboard:\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnX_Click_1(
            object sender,
            EventArgs e)
        {
            btnX_Click(sender, e);
        }

        private void lblX_Click(
            object sender,
            EventArgs e)
        {
            btnX_Click(sender, e);
        }

        private void txtSearch_MaskInputRejected(
            object sender,
            MaskInputRejectedEventArgs e)
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