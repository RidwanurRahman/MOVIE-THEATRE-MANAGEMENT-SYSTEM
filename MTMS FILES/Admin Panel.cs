using System;
using System.Windows.Forms;

namespace Movie_Theater_Management_System
{
    public partial class Admin_Dashboard : Form
    {
        private Login? Lg;
        public Admin_Dashboard()
        {
            InitializeComponent();
        }

        public Admin_Dashboard(Login lg)
        {
            InitializeComponent();
            this.Lg = lg;
        }

    
        private void btnManageMovies_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ManageMovies(this).Show();  
        }

       
        private void btnManageShows_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Manage_Shows().Show();           }

        
        private void btnManageSeat_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Manage_Seat().Show();   
        }

      
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (Lg != null)
            {
                Lg.Show();
            }
            else
            {
                new Login().Show();
            }
        }

        private void lblX_Click(object sender, EventArgs e)
        {
            this.Hide();

            if (Lg != null)
            {
                Lg.Show();   
            }
            else
            {
                new Login().Show();  
            }
        }
    }
}