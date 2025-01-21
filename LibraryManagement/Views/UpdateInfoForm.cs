using System;
using System.Drawing;
using System.Windows.Forms;
using LibraryManagement.Models;
using LibraryManagement.Controllers;

namespace LibraryManagement.Views
{
    public class UpdateInfoForm : Form
    {
        private Label lblPhone, lblAddress;
        private TextBox txtPhone, txtAddress;
        private Button btnUpdate;
        private MemberController _memberController;
        private Member _currentUser;

        public UpdateInfoForm(Member currentUser)
        {
            _currentUser = currentUser;
            _memberController = new MemberController();

            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Text = "Update Contact Info";
            this.Size = new Size(400, 250);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            lblPhone = new Label { Text = "Phone Number:", Location = new Point(30, 30), Size = new Size(100, 25) };
            lblAddress = new Label { Text = "Address:", Location = new Point(30, 70), Size = new Size(100, 25) };

            txtPhone = new TextBox { Location = new Point(150, 30), Size = new Size(200, 25), Text = _currentUser.PhoneNumber };
            txtAddress = new TextBox { Location = new Point(150, 70), Size = new Size(200, 25), Text = _currentUser.Address };

            btnUpdate = new Button { Text = "Update", Location = new Point(130, 130), Size = new Size(100, 30) };
            btnUpdate.Click += BtnUpdate_Click;

            this.Controls.Add(lblPhone);
            this.Controls.Add(txtPhone);
            this.Controls.Add(lblAddress);
            this.Controls.Add(txtAddress);
            this.Controls.Add(btnUpdate);
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            _currentUser.PhoneNumber = txtPhone.Text;
            _currentUser.Address = txtAddress.Text;
            _memberController.UpdateMember(_currentUser);
            MessageBox.Show("Contact information updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
