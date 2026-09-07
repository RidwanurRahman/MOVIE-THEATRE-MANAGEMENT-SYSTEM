using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Movie_Theater_Management_System
{
    public partial class CustomerDashboard : Form
    {
        private Login? lg;
        public CustomerDashboard()
        {
            InitializeComponent();

        }

        public CustomerDashboard(Login lg)
        {
            InitializeComponent();
            this.lg = lg;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnBookingTicket_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Booking_Ticket(this).Show();
        }



        private void btnX_Click(object sender, EventArgs e)
        {
            this.Hide();

            if (lg != null)
            {
                lg.Show();   
            }
            else
            {
                new Login().Show();  
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnFeedback_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Feedback(this).Show();
        }
    }
}
    
