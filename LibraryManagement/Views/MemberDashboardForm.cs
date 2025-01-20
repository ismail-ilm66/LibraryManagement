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
    public class MemberDashboardForm : Form
    {
        private Button btnViewBooks, btnBorrowBook, btnReturnBook, btnUpdateInfo; 
        private Member _currentUser;

        public MemberDashboardForm(Member currentUser)

        {
            _currentUser = currentUser;
            this.Text = "Member Dashboard";
            this.Size = new Size(600, 400);

            btnViewBooks = new Button { Text = "View Books", Location = new Point(50, 50), Size = new Size(200, 40) };
            btnViewBooks.Click += (s, e) => new BookForm(_currentUser).Show();

            btnBorrowBook = new Button { Text = "Borrow Book", Location = new Point(50, 100), Size = new Size(200, 40) };
            btnBorrowBook.Click += (s, e) => new BorrowingForm(_currentUser).Show();

            btnReturnBook = new Button { Text = "Return Book", Location = new Point(50, 150), Size = new Size(200, 40) };

            btnUpdateInfo = new Button { Text = "Update Contact Info", Location = new Point(50, 200), Size = new Size(200, 40) };

            this.Controls.Add(btnViewBooks);
            this.Controls.Add(btnBorrowBook);
            this.Controls.Add(btnReturnBook);
            this.Controls.Add(btnUpdateInfo);
        }
    }
}
