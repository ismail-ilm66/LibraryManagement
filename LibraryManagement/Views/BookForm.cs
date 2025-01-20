using System;
using System.Drawing;
using System.Windows.Forms;
using LibraryManagement.Controllers;
using LibraryManagement.Models;

namespace LibraryManagement.Views
{
    public class BookForm : Form
    {
        private Label lblTitle, lblAuthor, lblGenre, lblISBN, lblCopies;
        private TextBox txtTitle, txtAuthor, txtGenre, txtISBN, txtCopies;
        private Button btnAdd, btnUpdate, btnDelete, btnClear;
        private DataGridView dataGridBooks;
        private BookController _bookController;
        private Member _currentUser;



        public BookForm(Member currentUser)
        {
            _currentUser = currentUser;
            _bookController = new BookController();
            InitializeComponents();
            LoadBooks();
            ApplyRoleBasedAccess();
        }
        private void ApplyRoleBasedAccess()
        {
            if (_currentUser.Role != "Staff")
            {
                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void InitializeComponents()
        {
            // Form properties
            this.Text = "Manage Books";
            this.Size = new Size(600, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Labels
            lblTitle = new Label { Text = "Title:", Location = new Point(30, 30), Size = new Size(80, 25) };
            lblAuthor = new Label { Text = "Author:", Location = new Point(30, 70), Size = new Size(80, 25) };
            lblGenre = new Label { Text = "Genre:", Location = new Point(30, 110), Size = new Size(80, 25) };
            lblISBN = new Label { Text = "ISBN:", Location = new Point(30, 150), Size = new Size(80, 25) };
            lblCopies = new Label { Text = "Available Copies:", Location = new Point(30, 190), Size = new Size(120, 25) };

            // TextBoxes
            txtTitle = new TextBox { Location = new Point(150, 30), Size = new Size(200, 25) };
            txtAuthor = new TextBox { Location = new Point(150, 70), Size = new Size(200, 25) };
            txtGenre = new TextBox { Location = new Point(150, 110), Size = new Size(200, 25) };
            txtISBN = new TextBox { Location = new Point(150, 150), Size = new Size(200, 25) };
            txtCopies = new TextBox { Location = new Point(150, 190), Size = new Size(200, 25) };

            // Buttons
            btnAdd = new Button { Text = "Add", Location = new Point(400, 30), Size = new Size(100, 30) };
            btnUpdate = new Button { Text = "Update", Location = new Point(400, 70), Size = new Size(100, 30) };
            btnDelete = new Button { Text = "Delete", Location = new Point(400, 110), Size = new Size(100, 30) };
            btnClear = new Button { Text = "Clear", Location = new Point(400, 150), Size = new Size(100, 30) };

            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            btnClear.Click += BtnClear_Click;

            // DataGridView
            dataGridBooks = new DataGridView
            {
                Location = new Point(30, 240),
                Size = new Size(520, 200),
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };
            dataGridBooks.CellClick += DataGridBooks_CellClick;

            // Add controls to form
            this.Controls.Add(lblTitle);
            this.Controls.Add(txtTitle);
            this.Controls.Add(lblAuthor);
            this.Controls.Add(txtAuthor);
            this.Controls.Add(lblGenre);
            this.Controls.Add(txtGenre);
            this.Controls.Add(lblISBN);
            this.Controls.Add(txtISBN);
            this.Controls.Add(lblCopies);
            this.Controls.Add(txtCopies);
            this.Controls.Add(btnAdd);
            this.Controls.Add(btnUpdate);
            this.Controls.Add(btnDelete);
            this.Controls.Add(btnClear);
            this.Controls.Add(dataGridBooks);


        }

        private void LoadBooks()
        {
            dataGridBooks.DataSource = _bookController.GetAllBooks();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var book = new Book
            {
                Title = txtTitle.Text,
                Author = txtAuthor.Text,
                Genre = txtGenre.Text,
                ISBN = txtISBN.Text,
                AvailableCopies = int.Parse(txtCopies.Text)
            };
            _bookController.AddBook(book);
            LoadBooks();
            ClearFields();
            MessageBox.Show("Book added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridBooks.SelectedRows.Count > 0)
            {
                int bookId = Convert.ToInt32(dataGridBooks.SelectedRows[0].Cells[0].Value);
                var book = new Book
                {
                    BookId = bookId,
                    Title = txtTitle.Text,
                    Author = txtAuthor.Text,
                    Genre = txtGenre.Text,
                    ISBN = txtISBN.Text,
                    AvailableCopies = int.Parse(txtCopies.Text)
                };
                _bookController.UpdateBook(book);
                LoadBooks();
                ClearFields();
                MessageBox.Show("Book updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridBooks.SelectedRows.Count > 0)
            {
                int bookId = Convert.ToInt32(dataGridBooks.SelectedRows[0].Cells[0].Value);
                _bookController.DeleteBook(bookId);
                LoadBooks();
                ClearFields();
                MessageBox.Show("Book deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void DataGridBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtTitle.Text = dataGridBooks.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtAuthor.Text = dataGridBooks.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtGenre.Text = dataGridBooks.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtISBN.Text = dataGridBooks.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtCopies.Text = dataGridBooks.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
        }

        private void ClearFields()
        {
            txtTitle.Clear();
            txtAuthor.Clear();
            txtGenre.Clear();
            txtISBN.Clear();
            txtCopies.Clear();
        }
    }
}
