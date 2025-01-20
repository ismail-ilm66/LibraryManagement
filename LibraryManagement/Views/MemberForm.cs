using System;
using System.Drawing;
using System.Windows.Forms;
using LibraryManagement.Controllers;
using LibraryManagement.Models;

namespace LibraryManagement.Views
{
    public class MemberForm : Form
    {
        private Label lblName, lblMembershipId, lblPassword, lblPhoneNumber, lblAddress;
        private TextBox txtName, txtMembershipId, txtPassword, txtPhoneNumber, txtAddress;
        private Button btnAdd, btnUpdate, btnDelete, btnClear;
        private DataGridView dataGridMembers;
        private MemberController _memberController;
        private Member _currentUser;


        public MemberForm(Member currentUser)
        {
            _currentUser = currentUser;

            _memberController = new MemberController();
            InitializeComponents();
            LoadMembers();
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
            this.Text = "Manage Members";
            this.Size = new Size(650, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Labels
            lblName = new Label { Text = "Name:", Location = new Point(30, 30), Size = new Size(100, 25) };
            lblMembershipId = new Label { Text = "Membership ID:", Location = new Point(30, 70), Size = new Size(100, 25) };
            lblPassword = new Label { Text = "Password:", Location = new Point(30, 110), Size = new Size(100, 25) };
            lblPhoneNumber = new Label { Text = "Phone Number:", Location = new Point(30, 150), Size = new Size(100, 25) };
            lblAddress = new Label { Text = "Address:", Location = new Point(30, 190), Size = new Size(100, 25) };

            // TextBoxes
            txtName = new TextBox { Location = new Point(150, 30), Size = new Size(200, 25) };
            txtMembershipId = new TextBox { Location = new Point(150, 70), Size = new Size(200, 25) };
            txtPassword = new TextBox { Location = new Point(150, 110), Size = new Size(200, 25), PasswordChar = '*' };
            txtPhoneNumber = new TextBox { Location = new Point(150, 150), Size = new Size(200, 25) };
            txtAddress = new TextBox { Location = new Point(150, 190), Size = new Size(200, 25) };

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
            dataGridMembers = new DataGridView
            {
                Location = new Point(30, 240),
                Size = new Size(570, 200),
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };
            dataGridMembers.CellClick += DataGridMembers_CellClick;

            // Add controls to form
            this.Controls.Add(lblName);
            this.Controls.Add(txtName);
            this.Controls.Add(lblMembershipId);
            this.Controls.Add(txtMembershipId);
            this.Controls.Add(lblPassword);
            this.Controls.Add(txtPassword);
            this.Controls.Add(lblPhoneNumber);
            this.Controls.Add(txtPhoneNumber);
            this.Controls.Add(lblAddress);
            this.Controls.Add(txtAddress);
            this.Controls.Add(btnAdd);
            this.Controls.Add(btnUpdate);
            this.Controls.Add(btnDelete);
            this.Controls.Add(btnClear);
            this.Controls.Add(dataGridMembers);
        }

        private void LoadMembers()
        {
            dataGridMembers.DataSource = _memberController.GetAllMembers();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
              try
    {
        var member = new Member
        {
            Name = txtName.Text,
            MembershipID = txtMembershipId.Text,
            Password = txtPassword.Text,
            PhoneNumber = txtPhoneNumber.Text,
            Address = txtAddress.Text
        };
        _memberController.AddMember(member);
        LoadMembers();
        ClearFields();
        MessageBox.Show("Member added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridMembers.SelectedRows.Count > 0)
                {
                    int memberId = Convert.ToInt32(dataGridMembers.SelectedRows[0].Cells[0].Value);
                    var member = new Member
                    {
                        MemberId = memberId,
                        Name = txtName.Text,
                        MembershipID = txtMembershipId.Text,
                        Password = txtPassword.Text,
                        PhoneNumber = txtPhoneNumber.Text,
                        Address = txtAddress.Text
                    };
                    _memberController.UpdateMember(member);
                    LoadMembers();
                    ClearFields();
                    MessageBox.Show("Member updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please select a member to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridMembers.SelectedRows.Count > 0)
                {
                    int memberId = Convert.ToInt32(dataGridMembers.SelectedRows[0].Cells[0].Value);
                    _memberController.DeleteMember(memberId);
                    LoadMembers();
                    ClearFields();
                    MessageBox.Show("Member deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please select a member to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void DataGridMembers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtName.Text = dataGridMembers.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtMembershipId.Text = dataGridMembers.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtPassword.Text = dataGridMembers.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtPhoneNumber.Text = dataGridMembers.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtAddress.Text = dataGridMembers.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
        }

        private void ClearFields()
        {
            txtName.Clear();
            txtMembershipId.Clear();
            txtPassword.Clear();
            txtPhoneNumber.Clear();
            txtAddress.Clear();
        }
    }
}
