using System;
using System.Data;
using System.Windows.Forms;

namespace Movie_Theater_Management_System
{
    public partial class Login : Form
    {
        DataAccess Da = new DataAccess();

        public static string CurrentUserID = "";
        public static string CurrentUserRole = "";

        public Login()
        {
            InitializeComponent();

            txtPassword.PasswordChar = '*';

            chkShowPassword.CheckedChanged -=
                chkShowPassword_CheckedChanged;

            chkShowPassword.CheckedChanged +=
                chkShowPassword_CheckedChanged;

            llblRegister.LinkClicked -=
                llblRegister_LinkClicked;

            llblRegister.LinkClicked +=
                llblRegister_LinkClicked;
        }

        private void btnLogin_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                string userName =
                    txtUserName.Text.Trim();

                string password =
                    txtPassword.Text;

                if (string.IsNullOrWhiteSpace(
                    userName))
                {
                    MessageBox.Show(
                        "Enter Username!",
                        "Login",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtUserName.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(
                    password))
                {
                    MessageBox.Show(
                        "Enter Password!",
                        "Login",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtPassword.Focus();
                    return;
                }

                string query =
                    "SELECT * FROM [User] " +
                    "WHERE UserName = '" +
                    userName.Replace("'", "''") +
                    "' AND Password = '" +
                    password.Replace("'", "''") +
                    "';";

                DataTable dt =
                    Da.ExecuteQuery(query);

                if (dt == null ||
                    dt.Rows.Count != 1)
                {
                    MessageBox.Show(
                        "Invalid Username or Password.",
                        "Login Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtPassword.SelectAll();
                    txtPassword.Focus();
                    return;
                }

                string status =
                    dt.Rows[0]["Status"]
                    ?.ToString() ?? "";

                if (!status.Equals(
                    "Approved",
                    StringComparison.OrdinalIgnoreCase))
                {
                    CurrentUserID = "";
                    CurrentUserRole = "";

                    MessageBox.Show(
                        "Your account is still pending approval.\n\n" +
                        "Please wait for Super Admin approval before logging in.",
                        "Login Not Allowed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtPassword.SelectAll();
                    txtPassword.Focus();
                    return;
                }

                CurrentUserID =
                    dt.Rows[0]["UserName"]
                    ?.ToString() ?? "";

                CurrentUserRole =
                    dt.Rows[0]["Role"]
                    ?.ToString() ?? "";

                MessageBox.Show(
                    "Login Successful!",
                    "Login",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.Hide();

                if (CurrentUserRole.Equals(
                    "SuperAdmin",
                    StringComparison.OrdinalIgnoreCase))
                {
                    SuperAdminDashboard dashboard =
                        new SuperAdminDashboard();

                    dashboard.Show();
                    dashboard.BringToFront();
                    dashboard.Activate();
                }
                else if (CurrentUserRole.Equals(
                    "Admin",
                    StringComparison.OrdinalIgnoreCase))
                {
                    Admin_Dashboard dashboard =
                        new Admin_Dashboard();

                    dashboard.Show();
                    dashboard.BringToFront();
                    dashboard.Activate();
                }
                else if (
                    CurrentUserRole.Equals(
                        "Audience",
                        StringComparison.OrdinalIgnoreCase) ||
                    CurrentUserRole.Equals(
                        "Customer",
                        StringComparison.OrdinalIgnoreCase))
                {
                    CustomerDashboard dashboard =
                        new CustomerDashboard(this);

                    dashboard.Show();
                    dashboard.BringToFront();
                    dashboard.Activate();
                }
                else
                {
                    MessageBox.Show(
                        "Role not found!",
                        "Login Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    CurrentUserID = "";
                    CurrentUserRole = "";

                    this.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error: " +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void lblClose_Click(
            object sender,
            EventArgs e)
        {
            Application.Exit();
        }

        private void btnX_Click(
            object sender,
            EventArgs e)
        {
            Application.Exit();
        }

        private void chkShowPassword_CheckedChanged(
            object sender,
            EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }

        private void llblRegister_LinkClicked(
            object sender,
            LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Register register =
                    new Register();

                register.Show();
                register.BringToFront();
                register.Activate();

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not open Register page:\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}