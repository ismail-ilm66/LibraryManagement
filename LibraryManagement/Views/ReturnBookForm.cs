using System;
using System.Drawing;
using System.Windows.Forms;
using LibraryManagement.Models;
using LibraryManagement.Controllers;

namespace LibraryManagement.Views
{
    public class ReturnBookForm : Form
    {
        private Label lblBorrowingId;
        private TextBox txtBorrowingId;
        private Button btnReturn;
        private BorrowingController _borrowingController;
        private Member _currentUser;

        public ReturnBookForm(Member currentUser)
        {
            _currentUser = currentUser;
            _borrowingController = new BorrowingController();

            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Text = "Return Book";
            this.Size = new Size(400, 200);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            lblBorrowingId = new Label { Text = "Enter Borrowing ID:", Location = new Point(30, 30), Size = new Size(150, 25) };
            txtBorrowingId = new TextBox { Location = new Point(180, 30), Size = new Size(150, 25) };

            btnReturn = new Button { Text = "Return", Location = new Point(130, 80), Size = new Size(100, 30) };
            btnReturn.Click += BtnReturn_Click;

            this.Controls.Add(lblBorrowingId);
            this.Controls.Add(txtBorrowingId);
            this.Controls.Add(btnReturn);
        }

        private void BtnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                int borrowingId = int.Parse(txtBorrowingId.Text);
                _borrowingController.ReturnBook(borrowingId);
                MessageBox.Show("Book returned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
