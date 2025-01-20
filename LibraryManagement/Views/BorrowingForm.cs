using System;
using System.Drawing;
using System.Windows.Forms;
using LibraryManagement.Controllers;
using LibraryManagement.Models;

namespace LibraryManagement.Views
{
    public class BorrowingForm : Form
    {
        private Label lblMemberId, lblBookId;
        private TextBox txtMemberId, txtBookId;
        private Button btnBorrow, btnReturn, btnClear;
        private DataGridView dataGridBorrowing;
        private BorrowingController _borrowingController;

        public BorrowingForm()
        {
            _borrowingController = new BorrowingController();
            InitializeComponents();
            LoadBorrowingRecords();
        }

        private void InitializeComponents()
        {
            // Form properties
            this.Text = "Borrow/Return Books";
            this.Size = new Size(600, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Labels
            lblMemberId = new Label { Text = "Member ID:", Location = new Point(30, 30), Size = new Size(100, 25) };
            lblBookId = new Label { Text = "Book ID:", Location = new Point(30, 70), Size = new Size(100, 25) };

            // TextBoxes
            txtMemberId = new TextBox { Location = new Point(150, 30), Size = new Size(200, 25) };
            txtBookId = new TextBox { Location = new Point(150, 70), Size = new Size(200, 25) };

            // Buttons
            btnBorrow = new Button { Text = "Borrow", Location = new Point(400, 30), Size = new Size(100, 30) };
            btnReturn = new Button { Text = "Return", Location = new Point(400, 70), Size = new Size(100, 30) };
            btnClear = new Button { Text = "Clear", Location = new Point(400, 110), Size = new Size(100, 30) };

            btnBorrow.Click += BtnBorrow_Click;
            btnReturn.Click += BtnReturn_Click;
            btnClear.Click += BtnClear_Click;

            // DataGridView
            dataGridBorrowing = new DataGridView
            {
                Location = new Point(30, 150),
                Size = new Size(520, 200),
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            // Add controls to form
            this.Controls.Add(lblMemberId);
            this.Controls.Add(txtMemberId);
            this.Controls.Add(lblBookId);
            this.Controls.Add(txtBookId);
            this.Controls.Add(btnBorrow);
            this.Controls.Add(btnReturn);
            this.Controls.Add(btnClear);
            this.Controls.Add(dataGridBorrowing);
        }

        private void LoadBorrowingRecords()
        {
            dataGridBorrowing.DataSource = _borrowingController.GetAllBorrowingRecords();
        }

        private void BtnBorrow_Click(object sender, EventArgs e)
        {
            try
            {
                int memberId = int.Parse(txtMemberId.Text);
                int bookId = int.Parse(txtBookId.Text);

                _borrowingController.BorrowBook(memberId, bookId);
                LoadBorrowingRecords();
                ClearFields();
                MessageBox.Show("Book borrowed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridBorrowing.SelectedRows.Count > 0)
                {
                    int borrowingId = Convert.ToInt32(dataGridBorrowing.SelectedRows[0].Cells[0].Value);
                    _borrowingController.ReturnBook(borrowingId);
                    LoadBorrowingRecords();
                    MessageBox.Show("Book returned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please select a record to return.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtMemberId.Clear();
            txtBookId.Clear();
        }
    }
}
