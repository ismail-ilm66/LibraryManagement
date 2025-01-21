using System;
using System.Drawing;
using System.Windows.Forms;
using LibraryManagement.Models;
using LibraryManagement.Controllers;

namespace LibraryManagement.Views
{
    public class MemberDashboardForm : Form
    {
        private Label lblWelcome;
        private Button btnViewBooks, btnBorrowBook, btnReturnBook, btnUpdateInfo, btnLogout;
        private Member _currentUser;
        private BorrowingController _borrowingController;
        private MemberController _memberController;

        public MemberDashboardForm(Member currentUser)
        {
            _currentUser = currentUser;
            _borrowingController = new BorrowingController();
            _memberController = new MemberController();

            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Text = "Member Dashboard";
            this.Size = new Size(600, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.BackColor = Color.LightBlue;

            lblWelcome = new Label
            {
                Text = $"Welcome, {_currentUser.Name}",
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.Black,
                AutoSize = true,
                Location = new Point(200, 30)
            };

            btnViewBooks = new Button
            {
                Text = "View Available Books",
                Location = new Point(50, 80),
                Size = new Size(200, 40)
            };
            btnViewBooks.Click += BtnViewBooks_Click;

            btnBorrowBook = new Button
            {
                Text = "Borrow Book",
                Location = new Point(50, 130),
                Size = new Size(200, 40)
            };
            btnBorrowBook.Click += BtnBorrowBook_Click;

            btnReturnBook = new Button
            {
                Text = "Return Book",
                Location = new Point(50, 180),
                Size = new Size(200, 40)
            };
            btnReturnBook.Click += BtnReturnBook_Click;

            btnUpdateInfo = new Button
            {
                Text = "Update Contact Info",
                Location = new Point(50, 230),
                Size = new Size(200, 40)
            };
            btnUpdateInfo.Click += BtnUpdateInfo_Click;

            btnLogout = new Button
            {
                Text = "Logout",
                Location = new Point(50, 280),
                Size = new Size(200, 40),
                BackColor = Color.Red,
                ForeColor = Color.White
            };
            btnLogout.Click += BtnLogout_Click;

            this.Controls.Add(lblWelcome);
            this.Controls.Add(btnViewBooks);
            this.Controls.Add(btnBorrowBook);
            this.Controls.Add(btnReturnBook);
            this.Controls.Add(btnUpdateInfo);
            this.Controls.Add(btnLogout);
        }

        private void BtnViewBooks_Click(object sender, EventArgs e)
        {
            BookForm bookForm = new BookForm(_currentUser);
            bookForm.Show();
        }

        private void BtnBorrowBook_Click(object sender, EventArgs e)
        {
            BorrowingForm borrowingForm = new BorrowingForm(_currentUser);
            borrowingForm.Show();
        }

        private void BtnReturnBook_Click(object sender, EventArgs e)
        {
            ReturnBookForm returnBookForm = new ReturnBookForm(_currentUser);
            returnBookForm.Show();
        }

        private void BtnUpdateInfo_Click(object sender, EventArgs e)
        {
            UpdateInfoForm updateInfoForm = new UpdateInfoForm(_currentUser);
            updateInfoForm.Show();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
