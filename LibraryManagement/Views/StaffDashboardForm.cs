using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryManagement.Models;

namespace LibraryManagement.Views
{
    public class StaffDashboardForm : Form
    {

        private Button btnManageBooks, btnManageMembers, btnBorrowingRecords;
        private Member _currentUser;

        public StaffDashboardForm(Member currentUser)
        {
            _currentUser = currentUser;
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Text = "Staff Dashboard";
            this.Size = new Size(600, 400);

            btnManageBooks = new Button { Text = "Manage Books", Location = new Point(50, 50), Size = new Size(200, 40) };
            btnManageBooks.Click += (s, e) => new BookForm(_currentUser).Show();

            btnManageMembers = new Button { Text = "Manage Members", Location = new Point(50, 100), Size = new Size(200, 40) };
            btnManageMembers.Click += (s, e) => new MemberForm(_currentUser).Show();

            btnBorrowingRecords = new Button { Text = "Borrowing Records", Location = new Point(50, 150), Size = new Size(200, 40) };
            btnBorrowingRecords.Click += (s, e) => new BorrowingForm(_currentUser).Show();

            this.Controls.Add(btnManageBooks);
            this.Controls.Add(btnManageMembers);
            this.Controls.Add(btnBorrowingRecords);
        }
    }
}
