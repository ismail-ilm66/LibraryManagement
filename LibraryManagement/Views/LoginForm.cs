using System;
using System.Drawing;
using System.Windows.Forms;
using LibraryManagement.Controllers;

namespace LibraryManagement.Views
{
    public class LoginForm : Form
    {
        private Label lblMembershipId;
        private Label lblPassword;
        private TextBox txtMembershipId;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnExit;
        private MemberController _memberController;

        public LoginForm()
        {
            _memberController = new MemberController();
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            // Form properties
            this.Text = "Library Login";
            this.Size = new Size(400, 300);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Membership ID Label
            lblMembershipId = new Label();
            lblMembershipId.Text = "Membership ID:";
            lblMembershipId.Location = new Point(50, 50);
            lblMembershipId.Size = new Size(100, 25);

            // Membership ID TextBox
            txtMembershipId = new TextBox();
            txtMembershipId.Location = new Point(170, 50);
            txtMembershipId.Size = new Size(150, 25);

            // Password Label
            lblPassword = new Label();
            lblPassword.Text = "Password:";
            lblPassword.Location = new Point(50, 100);
            lblPassword.Size = new Size(100, 25);

            // Password TextBox
            txtPassword = new TextBox();
            txtPassword.Location = new Point(170, 100);
            txtPassword.Size = new Size(150, 25);
            txtPassword.PasswordChar = '*';

            // Login Button
            btnLogin = new Button();
            btnLogin.Text = "Login";
            btnLogin.Location = new Point(100, 180);
            btnLogin.Size = new Size(80, 30);
            btnLogin.Click += BtnLogin_Click;

            // Exit Button
            btnExit = new Button();
            btnExit.Text = "Exit";
            btnExit.Location = new Point(200, 180);
            btnExit.Size = new Size(80, 30);
            btnExit.Click += BtnExit_Click;

            // Add Controls to the Form
            this.Controls.Add(lblMembershipId);
            this.Controls.Add(txtMembershipId);
            this.Controls.Add(lblPassword);
            this.Controls.Add(txtPassword);
            this.Controls.Add(btnLogin);
            this.Controls.Add(btnExit);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string membershipId = txtMembershipId.Text;
                string password = txtPassword.Text;

                var member = _memberController.Login(membershipId, password);

                if (member.Role == "Staff")
                {
                    StaffDashboardForm staffDashboard = new StaffDashboardForm(member);
                    staffDashboard.Show();
                }
                else if (member.Role == "Member")
                {
                    MemberDashboardForm memberDashboard = new MemberDashboardForm(member);
                    memberDashboard.Show();
                }

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
