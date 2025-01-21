using System;
using System.Drawing;
using System.Windows.Forms;
using LibraryManagement.Models;

namespace LibraryManagement.Views
{
    public class StaffDashboardForm : Form
    {
        private Button btnManageBooks, btnManageMembers, btnBorrowingRecords, btnLogout;
        private Label lblTitle, lblWelcome;
        private Panel headerPanel;
        private Member _currentUser;

        public StaffDashboardForm(Member currentUser)
        {
            _currentUser = currentUser;
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            // Form properties
            this.Text = "Staff Dashboard";
            this.Size = new Size(700, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.BackColor = Color.FromArgb(240, 240, 240);

            // Header panel
            headerPanel = new Panel
            {
                Size = new Size(700, 80),
                BackColor = Color.FromArgb(0, 122, 204),
                Dock = DockStyle.Top
            };
            this.Controls.Add(headerPanel);

            // Title label
            lblTitle = new Label
            {
                Text = "Library Management - Staff Dashboard",
                Font = new Font("Arial", 18, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(180, 20)
            };
            headerPanel.Controls.Add(lblTitle);

            // Welcome label
            lblWelcome = new Label
            {
                Text = $"Welcome, {_currentUser.Name}",
                Font = new Font("Arial", 14, FontStyle.Regular),
                ForeColor = Color.Black,
                AutoSize = true,
                Location = new Point(50, 100)
            };
            this.Controls.Add(lblWelcome);

            // Buttons styling
            btnManageBooks = new Button
            {
                Text = "Manage Books",
                Location = new Point(200, 150),
                Size = new Size(300, 50),
                BackColor = Color.FromArgb(51, 153, 255),
                ForeColor = Color.White,
                Font = new Font("Arial", 12, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat
            };
            btnManageBooks.FlatAppearance.BorderSize = 0;
            btnManageBooks.Click += (s, e) => new BookForm(_currentUser).Show();

            btnManageMembers = new Button
            {
                Text = "Manage Members",
                Location = new Point(200, 220),
                Size = new Size(300, 50),
                BackColor = Color.FromArgb(51, 153, 255),
                ForeColor = Color.White,
                Font = new Font("Arial", 12, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat
            };
            btnManageMembers.FlatAppearance.BorderSize = 0;
            btnManageMembers.Click += (s, e) => new MemberForm(_currentUser).Show();

            btnBorrowingRecords = new Button
            {
                Text = "Borrowing Records",
                Location = new Point(200, 290),
                Size = new Size(300, 50),
                BackColor = Color.FromArgb(51, 153, 255),
                ForeColor = Color.White,
                Font = new Font("Arial", 12, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat
            };
            btnBorrowingRecords.FlatAppearance.BorderSize = 0;
            btnBorrowingRecords.Click += (s, e) => new BorrowingForm(_currentUser).Show();

            btnLogout = new Button
            {
                Text = "Logout",
                Location = new Point(200, 360),
                Size = new Size(300, 50),
                BackColor = Color.Red,
                ForeColor = Color.White,
                Font = new Font("Arial", 12, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat
            };
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.Click += BtnLogout_Click;

            // Adding controls to form
            this.Controls.Add(btnManageBooks);
            this.Controls.Add(btnManageMembers);
            this.Controls.Add(btnBorrowingRecords);
            this.Controls.Add(btnLogout);
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
