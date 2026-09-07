using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Movie_Theater_Management_System
{
    public partial class SalesReport : Form
    {
        private SuperAdminDashboard sad;
        private readonly DataAccess Da = new DataAccess();
        private readonly PrintDocument printDocument = new PrintDocument();
        private int printRowIndex = 0;

        public SalesReport()
        {
            InitializeComponent();
            SetupEvents();
        }

        public SalesReport(SuperAdminDashboard sad)
        {
            InitializeComponent();
            this.sad = sad;
            SetupEvents();
        }

        private void SetupEvents()
        {
            this.Load -= SalesReport_Load;
            this.Load += SalesReport_Load;

            dgvSalesReport.CellDoubleClick -= dgvSalesReport_CellDoubleClick;
            dgvSalesReport.CellDoubleClick += dgvSalesReport_CellDoubleClick;

            btnGenerateReport.Click -= btnGenerateReport_Click;
            btnGenerateReport.Click += btnGenerateReport_Click;

            btnPrintReport.Click -= btnPrintReport_Click;
            btnPrintReport.Click += btnPrintReport_Click;

            btnClear1.Click -= btnClear1_Click;
            btnClear1.Click += btnClear1_Click;

            btnX.Click -= btnX_Click;
            btnX.Click += btnX_Click;

            printDocument.PrintPage -= PrintDocument_PrintPage;
            printDocument.PrintPage += PrintDocument_PrintPage;
        }

        private void SalesReport_Load(
            object sender,
            EventArgs e)
        {
            try
            {
                txtTotalRevenue.ReadOnly = true;
                txtTotalConfirmedBookings.ReadOnly = true;
                txtTotalTicketsSold.ReadOnly = true;
                txtAverageBookingValue.ReadOnly = true;

                dgvSalesReport.AutoGenerateColumns = true;
                dgvSalesReport.ReadOnly = true;
                dgvSalesReport.AllowUserToAddRows = false;
                dgvSalesReport.AllowUserToDeleteRows = false;
                dgvSalesReport.MultiSelect = false;
                dgvSalesReport.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;
                dgvSalesReport.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                LoadSalesReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Sales Report Load Error:\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private string GetSearchCondition()
        {
            string search =
                txtSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(search))
                return "";

            string safeSearch =
                EscapeSql(search);

            return @"
                AND
                (
                    b.BookingID LIKE '%" + safeSearch + @"%'
                    OR b.UserID LIKE '%" + safeSearch + @"%'
                    OR b.ShowID LIKE '%" + safeSearch + @"%'
                    OR m.M_Title LIKE '%" + safeSearch + @"%'
                    OR b.SeatID LIKE '%" + safeSearch + @"%'
                    OR CONVERT(
                        VARCHAR(50),
                        b.BookingDate,
                        120
                    ) LIKE '%" + safeSearch + @"%'
                    OR CONVERT(
                        VARCHAR(50),
                        b.Quantity
                    ) LIKE '%" + safeSearch + @"%'
                    OR CONVERT(
                        VARCHAR(50),
                        b.TotalPrice
                    ) LIKE '%" + safeSearch + @"%'
                    OR b.Ticket_Status LIKE '%" + safeSearch + @"%'
                )";
        }

        private void LoadSalesReport()
        {
            try
            {
                string searchCondition =
                    GetSearchCondition();

                string sql = @"
                    SELECT
                        b.BookingID,
                        b.UserID,
                        b.ShowID,
                        m.M_Title AS Movie,
                        b.SeatID,
                        b.BookingDate,
                        b.Quantity,
                        b.TotalPrice,
                        b.Ticket_Status
                    FROM dbo.BookingTicket b
                    INNER JOIN dbo.ManageShows s
                        ON b.ShowID = s.ShowID
                    INNER JOIN dbo.ManageMovies m
                        ON s.MovieID = m.MovieID
                    WHERE b.Ticket_Status = 'Confirmed'
                    " + searchCondition + @"
                    ORDER BY b.BookingDate DESC";

                DataTable dt =
                    Da.ExecuteQuery(sql);

                dgvSalesReport.DataSource = null;
                dgvSalesReport.AutoGenerateColumns = true;
                dgvSalesReport.DataSource = dt;

                dgvSalesReport.ReadOnly = true;
                dgvSalesReport.AllowUserToAddRows = false;
                dgvSalesReport.AllowUserToDeleteRows = false;
                dgvSalesReport.MultiSelect = false;
                dgvSalesReport.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;
                dgvSalesReport.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                if (dgvSalesReport.Columns.Contains("BookingID"))
                {
                    dgvSalesReport.Columns["BookingID"]
                        .HeaderText = "Booking ID";
                }

                if (dgvSalesReport.Columns.Contains("UserID"))
                {
                    dgvSalesReport.Columns["UserID"]
                        .HeaderText = "User ID";
                }

                if (dgvSalesReport.Columns.Contains("ShowID"))
                {
                    dgvSalesReport.Columns["ShowID"]
                        .HeaderText = "Show ID";
                }

                if (dgvSalesReport.Columns.Contains("Movie"))
                {
                    dgvSalesReport.Columns["Movie"]
                        .HeaderText = "Movie";
                }

                if (dgvSalesReport.Columns.Contains("SeatID"))
                {
                    dgvSalesReport.Columns["SeatID"]
                        .HeaderText = "Seat ID";
                }

                if (dgvSalesReport.Columns.Contains("BookingDate"))
                {
                    dgvSalesReport.Columns["BookingDate"]
                        .HeaderText = "Booking Date";
                }

                if (dgvSalesReport.Columns.Contains("Quantity"))
                {
                    dgvSalesReport.Columns["Quantity"]
                        .HeaderText = "Quantity";
                }

                if (dgvSalesReport.Columns.Contains("TotalPrice"))
                {
                    dgvSalesReport.Columns["TotalPrice"]
                        .HeaderText = "Total Price";
                }

                if (dgvSalesReport.Columns.Contains("Ticket_Status"))
                {
                    dgvSalesReport.Columns["Ticket_Status"]
                        .HeaderText = "Status";
                }

                dgvSalesReport.ClearSelection();

                LoadSummary(searchCondition);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Report Load Error:\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadSummary(
            string searchCondition)
        {
            try
            {
                string revenueSql = @"
                    SELECT
                        ISNULL(
                            SUM(
                                CAST(
                                    b.TotalPrice
                                    AS DECIMAL(18,2)
                                )
                            ),
                            0
                        )
                    FROM dbo.BookingTicket b
                    INNER JOIN dbo.ManageShows s
                        ON b.ShowID = s.ShowID
                    INNER JOIN dbo.ManageMovies m
                        ON s.MovieID = m.MovieID
                    WHERE b.Ticket_Status = 'Confirmed'
                    " + searchCondition;

                string bookingSql = @"
                    SELECT
                        COUNT(*)
                    FROM dbo.BookingTicket b
                    INNER JOIN dbo.ManageShows s
                        ON b.ShowID = s.ShowID
                    INNER JOIN dbo.ManageMovies m
                        ON s.MovieID = m.MovieID
                    WHERE b.Ticket_Status = 'Confirmed'
                    " + searchCondition;

                string ticketSql = @"
                    SELECT
                        ISNULL(
                            SUM(
                                CAST(
                                    b.Quantity
                                    AS INT
                                )
                            ),
                            0
                        )
                    FROM dbo.BookingTicket b
                    INNER JOIN dbo.ManageShows s
                        ON b.ShowID = s.ShowID
                    INNER JOIN dbo.ManageMovies m
                        ON s.MovieID = m.MovieID
                    WHERE b.Ticket_Status = 'Confirmed'
                    " + searchCondition;

                DataTable revenueDt =
                    Da.ExecuteQuery(revenueSql);

                DataTable bookingDt =
                    Da.ExecuteQuery(bookingSql);

                DataTable ticketDt =
                    Da.ExecuteQuery(ticketSql);

                decimal totalRevenue = 0;
                int totalBookings = 0;
                int totalTickets = 0;

                if (revenueDt.Rows.Count > 0)
                {
                    decimal.TryParse(
                        revenueDt.Rows[0][0]
                        .ToString(),
                        out totalRevenue);
                }

                if (bookingDt.Rows.Count > 0)
                {
                    int.TryParse(
                        bookingDt.Rows[0][0]
                        .ToString(),
                        out totalBookings);
                }

                if (ticketDt.Rows.Count > 0)
                {
                    int.TryParse(
                        ticketDt.Rows[0][0]
                        .ToString(),
                        out totalTickets);
                }

                decimal averageBookingValue = 0;

                if (totalBookings > 0)
                {
                    averageBookingValue =
                        totalRevenue /
                        totalBookings;
                }

                txtTotalRevenue.Text =
                    totalRevenue.ToString("0.00");

                txtTotalConfirmedBookings.Text =
                    totalBookings.ToString();

                txtTotalTicketsSold.Text =
                    totalTickets.ToString();

                txtAverageBookingValue.Text =
                    averageBookingValue.ToString("0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Summary Error:\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnGenerateReport_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                LoadSalesReport();

                MessageBox.Show(
                    "Sales report generated successfully!",
                    "Generate Report",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Generate Report Error:\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dgvSalesReport_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvSalesReport.Rows[
                e.RowIndex].IsNewRow)
                return;

            try
            {
                DataGridViewRow row =
                    dgvSalesReport.Rows[
                        e.RowIndex];

                string bookingId =
                    row.Cells["BookingID"]
                    .Value?.ToString() ?? "";

                string userId =
                    row.Cells["UserID"]
                    .Value?.ToString() ?? "";

                string showId =
                    row.Cells["ShowID"]
                    .Value?.ToString() ?? "";

                string movie =
                    row.Cells["Movie"]
                    .Value?.ToString() ?? "";

                string seatId =
                    row.Cells["SeatID"]
                    .Value?.ToString() ?? "";

                string bookingDate =
                    row.Cells["BookingDate"]
                    .Value?.ToString() ?? "";

                string quantity =
                    row.Cells["Quantity"]
                    .Value?.ToString() ?? "";

                string totalPrice =
                    row.Cells["TotalPrice"]
                    .Value?.ToString() ?? "";

                string status =
                    row.Cells["Ticket_Status"]
                    .Value?.ToString() ?? "";

                MessageBox.Show(
                    "Booking ID: " + bookingId +
                    "\nUser ID: " + userId +
                    "\nShow ID: " + showId +
                    "\nMovie: " + movie +
                    "\nSeat ID: " + seatId +
                    "\nBooking Date: " + bookingDate +
                    "\nQuantity: " + quantity +
                    "\nTotal Price: " + totalPrice +
                    "\nStatus: " + status,
                    "Sales Details",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Sales Details Error:\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnPrintReport_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (dgvSalesReport.DataSource == null ||
                    dgvSalesReport.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "There is no sales data to print.",
                        "Print Report",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                printRowIndex = 0;

                using (PrintPreviewDialog preview =
                       new PrintPreviewDialog())
                {
                    preview.Document =
                        printDocument;

                    preview.StartPosition =
                        FormStartPosition.CenterScreen;

                    preview.Width = 1000;
                    preview.Height = 700;

                    preview.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Print Report Error:\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void PrintDocument_PrintPage(
            object sender,
            PrintPageEventArgs e)
        {
            using (Font titleFont =
                   new Font(
                       "Arial",
                       18,
                       FontStyle.Bold))
            using (Font headerFont =
                   new Font(
                       "Arial",
                       10,
                       FontStyle.Bold))
            using (Font normalFont =
                   new Font(
                       "Arial",
                       9))
            {
                float left =
                    e.MarginBounds.Left;

                float top =
                    e.MarginBounds.Top;

                e.Graphics.DrawString(
                    "Sales Report",
                    titleFont,
                    Brushes.Black,
                    left,
                    top);

                top += 35;

                e.Graphics.DrawString(
                    "Total Revenue: " +
                    txtTotalRevenue.Text,
                    normalFont,
                    Brushes.Black,
                    left,
                    top);

                top += 22;

                e.Graphics.DrawString(
                    "Confirmed Bookings: " +
                    txtTotalConfirmedBookings.Text,
                    normalFont,
                    Brushes.Black,
                    left,
                    top);

                top += 22;

                e.Graphics.DrawString(
                    "Tickets Sold: " +
                    txtTotalTicketsSold.Text,
                    normalFont,
                    Brushes.Black,
                    left,
                    top);

                top += 22;

                e.Graphics.DrawString(
                    "Average Booking Value: " +
                    txtAverageBookingValue.Text,
                    normalFont,
                    Brushes.Black,
                    left,
                    top);

                top += 35;

                e.Graphics.DrawString(
                    "Booking ID",
                    headerFont,
                    Brushes.Black,
                    left,
                    top);

                e.Graphics.DrawString(
                    "User ID",
                    headerFont,
                    Brushes.Black,
                    left + 80,
                    top);

                e.Graphics.DrawString(
                    "Show ID",
                    headerFont,
                    Brushes.Black,
                    left + 145,
                    top);

                e.Graphics.DrawString(
                    "Movie",
                    headerFont,
                    Brushes.Black,
                    left + 210,
                    top);

                e.Graphics.DrawString(
                    "Qty",
                    headerFont,
                    Brushes.Black,
                    left + 360,
                    top);

                e.Graphics.DrawString(
                    "Price",
                    headerFont,
                    Brushes.Black,
                    left + 400,
                    top);

                top += 25;

                while (printRowIndex <
                       dgvSalesReport.Rows.Count)
                {
                    DataGridViewRow row =
                        dgvSalesReport.Rows[
                            printRowIndex];

                    if (row.IsNewRow)
                    {
                        printRowIndex++;
                        continue;
                    }

                    string bookingId =
                        row.Cells["BookingID"]
                        .Value?.ToString() ?? "";

                    string userId =
                        row.Cells["UserID"]
                        .Value?.ToString() ?? "";

                    string showId =
                        row.Cells["ShowID"]
                        .Value?.ToString() ?? "";

                    string movie =
                        row.Cells["Movie"]
                        .Value?.ToString() ?? "";

                    string quantity =
                        row.Cells["Quantity"]
                        .Value?.ToString() ?? "";

                    string price =
                        row.Cells["TotalPrice"]
                        .Value?.ToString() ?? "";

                    e.Graphics.DrawString(
                        bookingId,
                        normalFont,
                        Brushes.Black,
                        left,
                        top);

                    e.Graphics.DrawString(
                        userId,
                        normalFont,
                        Brushes.Black,
                        left + 80,
                        top);

                    e.Graphics.DrawString(
                        showId,
                        normalFont,
                        Brushes.Black,
                        left + 145,
                        top);

                    e.Graphics.DrawString(
                        movie,
                        normalFont,
                        Brushes.Black,
                        left + 210,
                        top);

                    e.Graphics.DrawString(
                        quantity,
                        normalFont,
                        Brushes.Black,
                        left + 360,
                        top);

                    e.Graphics.DrawString(
                        price,
                        normalFont,
                        Brushes.Black,
                        left + 400,
                        top);

                    top += 22;
                    printRowIndex++;

                    if (top + 25 >
                        e.MarginBounds.Bottom)
                    {
                        e.HasMorePages = true;
                        return;
                    }
                }

                e.HasMorePages = false;
            }
        }

        private void btnClear1_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                txtSearch.Clear();

                txtTotalRevenue.Clear();
                txtTotalConfirmedBookings.Clear();
                txtTotalTicketsSold.Clear();
                txtAverageBookingValue.Clear();

                dgvSalesReport.DataSource =
                    null;

                MessageBox.Show(
                    "Sales report cleared successfully!",
                    "Clear",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Clear Error:\n" +
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