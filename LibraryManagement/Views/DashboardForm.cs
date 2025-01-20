//using System;
//using System.Drawing;
//using System.Windows.Forms;
//using LibraryManagement.Models;

//namespace LibraryManagement.Views
//{
//    public class DashboardForm : Form
//    {
//        private Label lblTitle;
//        private Button btnBooks;
//        private Button btnMembers;
//        private Button btnBorrowing;
//        private Button btnLogout;
//        private Member _currentUser;


//        public DashboardForm(Member currentUser)
//        {
//            InitializeComponents();
//            //ApplyRoleBasedAccess();

//        }
    

//        private void InitializeComponents()
//        {
//            // Form properties
//            this.Text = "Library Dashboard";
//            this.Size = new Size(500, 350);
//            this.StartPosition = FormStartPosition.CenterScreen;
//            this.FormBorderStyle = FormBorderStyle.FixedDialog;
//            this.MaximizeBox = false;
//            this.MinimizeBox = false;

//            // Title Label
//            lblTitle = new Label();
//            lblTitle.Text = "Library Management System";
//            lblTitle.Font = new Font("Arial", 16, FontStyle.Bold);
//            lblTitle.AutoSize = true;
//            lblTitle.Location = new Point(100, 30);

//            // Books Button
//            btnBooks = new Button();
//            btnBooks.Text = "Manage Books";
//            btnBooks.Size = new Size(150, 40);
//            btnBooks.Location = new Point(170, 90);
//            btnBooks.Click += BtnBooks_Click;

//            // Members Button
//            btnMembers = new Button();
//            btnMembers.Text = "Manage Members";
//            btnMembers.Size = new Size(150, 40);
//            btnMembers.Location = new Point(170, 140);
//            btnMembers.Click += BtnMembers_Click;

//            // Borrowing Button
//            btnBorrowing = new Button();
//            btnBorrowing.Text = "Borrow/Return Books";
//            btnBorrowing.Size = new Size(150, 40);
//            btnBorrowing.Location = new Point(170, 190);
//            btnBorrowing.Click += BtnBorrowing_Click;

//            // Logout Button
//            btnLogout = new Button();
//            btnLogout.Text = "Logout";
//            btnLogout.Size = new Size(100, 30);
//            btnLogout.Location = new Point(200, 250);
//            btnLogout.Click += BtnLogout_Click;

//            // Add Controls to Form
//            this.Controls.Add(lblTitle);
//            this.Controls.Add(btnBooks);
//            this.Controls.Add(btnMembers);
//            this.Controls.Add(btnBorrowing);
//            this.Controls.Add(btnLogout);
//        }

//        private void BtnBooks_Click(object sender, EventArgs e)
//        {
//            BookForm bookForm = new BookForm();
//            bookForm.Show();
//        }

//        private void BtnMembers_Click(object sender, EventArgs e)
//        {
//            MemberForm memberForm = new MemberForm();
//            memberForm.Show();
//        }

//        private void BtnBorrowing_Click(object sender, EventArgs e)
//        {
//            BorrowingForm borrowingForm = new BorrowingForm();
//            borrowingForm.Show();
//        }

//        private void BtnLogout_Click(object sender, EventArgs e)
//        {
//            this.Close();
//            LoginForm loginForm = new LoginForm();
//            loginForm.Show();
//        }
//    }
//}
