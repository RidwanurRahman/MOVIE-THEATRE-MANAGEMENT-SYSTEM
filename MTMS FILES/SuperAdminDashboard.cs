using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Movie_Theater_Management_System
{
    public partial class SuperAdminDashboard : Form
    {
        public SuperAdminDashboard()
        {
            InitializeComponent();
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            ManageUsers manageUsers =
                new ManageUsers(this);

            manageUsers.Show();
            this.Hide();
        }

        private void btnSalesReport_Click(object sender, EventArgs e)
        {
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            this.Hide();

            Login login =
                new Login();

            login.Show();
            login.BringToFront();
            login.Activate();
        }

        private void lblX_Click(object sender, EventArgs e)
        {
            btnX_Click(sender, e);
        }

        private void btnSalesReport_Click_1(object sender, EventArgs e)
        {
            SalesReport salesReport =
            new SalesReport(this);

            salesReport.Show();
            this.Hide();
        }
    }
}