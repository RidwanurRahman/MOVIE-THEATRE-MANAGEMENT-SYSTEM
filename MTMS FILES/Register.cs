using System;
using System.Data;
using System.Windows.Forms;

namespace Movie_Theater_Management_System
{
    public partial class Register : Form
    {
        private readonly DataAccess Da = new DataAccess();

        public Register()
        {
            InitializeComponent();

            if (cmbRole.Items.Count == 0)
            {
                cmbRole.Items.Add("Customer");
                cmbRole.SelectedIndex = 0;
            }
        }

        private void btnRegister_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                string userName =
                    txtUserName.Text.Trim();

                string password =
                    txtPassword.Text;

                string role =
                    "Customer";

                if (string.IsNullOrWhiteSpace(
                    userName))
                {
                    MessageBox.Show(
                        "Enter Username!",
                        "Registration",
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
                        "Registration",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtPassword.Focus();
                    return;
                }

                if (userName.Length < 3)
                {
                    MessageBox.Show(
                        "Username must contain at least 3 characters.",
                        "Registration",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtUserName.Focus();
                    return;
                }

                DataTable existingUser =
                    Da.ExecuteQuery(
                        "SELECT COUNT(*) AS UserCount " +
                        "FROM dbo.[User] " +
                        "WHERE UserName = '" +
                        EscapeSql(userName) +
                        "'");

                int userCount =
                    Convert.ToInt32(
                        existingUser.Rows[0]["UserCount"]);

                if (userCount > 0)
                {
                    MessageBox.Show(
                        "This username already exists.",
                        "Registration",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtUserName.Focus();
                    return;
                }

                string sql = @"
                    INSERT INTO dbo.[User]
                    (
                        UserName,
                        Password,
                        Role,
                        Status
                    )
                    VALUES
                    (
                        '" +
                    EscapeSql(userName) + @"',
                        '" +
                    EscapeSql(password) + @"',
                        '" +
                    EscapeSql(role) + @"',
                        'Pending'
                    )";

                int result =
                    Da.ExecuteDML(sql);

                if (result > 0)
                {
                    MessageBox.Show(
                        "Registration successful!\n\n" +
                        "Your account is waiting for Super Admin approval.\n" +
                        "You cannot login until your account is approved.",
                        "Registration Successful",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    txtUserName.Clear();
                    txtPassword.Clear();

                    if (cmbRole.Items.Count > 0)
                        cmbRole.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show(
                        "Registration failed.",
                        "Registration",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Registration Error:\n" +
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
            this.Hide();

            Login login =
                new Login();

            login.Show();
            login.BringToFront();
            login.Activate();
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