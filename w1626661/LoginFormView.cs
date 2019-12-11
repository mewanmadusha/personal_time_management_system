using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using w1626661.model;

namespace w1626661
{
    public partial class LoginFormView : Form
    {
        public LoginFormView()
        {
            InitializeComponent();
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
        }

     
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoginFormView_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                try
                {
                    string username=logUsernametxt.Text;
                    string password=logPasswordtxt.Text;

                    UserModelManager userModelManager = new UserModelManager();
                    Boolean status = userModelManager.loginUser(username,password);

                    if (status)
                    {
                        MessageBox.Show("User login Success");

                        


                        UserModelManager userModelManager1 = new UserModelManager();
                        UserModel loginuser = userModelManager1.getUser(username);

                        this.Hide();

                        DashboardView dashboardView = new DashboardView(loginuser);
                        dashboardView.ShowDialog();
                        this.Close();


                    }
                    else
                    {
                        MessageBox.Show("ERROR" + "Password Mismatch");
                    }

                }
                catch (Exception err)
                {
                    MessageBox.Show("ERROR" + err);
                }
            }
        }

        private void logUsernametxt_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(logUsernametxt.Text))
            {

                epLogin.SetError(logUsernametxt, "Username should not be left blank!");
                e.Cancel = true;
            }
            else
            {

                epLogin.SetError(logUsernametxt, "");
            }
        }

        private void logPasswordtxt_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(logPasswordtxt.Text))
            {

                epLogin.SetError(logPasswordtxt, "Password Should not be empty");
                e.Cancel = true;
            }
            else
            {

                epLogin.SetError(logPasswordtxt, "");
            }

        }

        private void label7_Click(object sender, EventArgs e)
        {
            RegisterFormView registerForm = new RegisterFormView();
            this.Hide();
            registerForm.ShowDialog();
            this.Close();
        }
    }
}
