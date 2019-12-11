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
    public partial class RegisterFormView : Form
    {
        public RegisterFormView()
        {
            InitializeComponent();
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
             this.passwordtxt.PasswordChar = '*';
             this.confpasswordtxt.PasswordChar = '*';
        }


        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

      

        private void label5_Click(object sender, EventArgs e)
        {

        }

       


        private void exit(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

      
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                try
                {
                    UserModel userModel = new UserModel();
                    userModel.Name = nametxt.Text;
                    userModel.UserName = usernametxt.Text;
                    userModel.Password = passwordtxt.Text;

                    UserModelManager userModelManager = new UserModelManager();
                    Boolean status = userModelManager.registerUser(userModel);

                    if (status)
                    {
                        MessageBox.Show("User registration Success you can now login");
                        
                    }
                    else
                    {
                        MessageBox.Show("ERROR" + " Database Error");
                    }

                }
                catch (Exception err)
                {
                    MessageBox.Show("ERROR" + err);
                }
            }
        }

      

        private void nametxt_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(nametxt.Text))
            {

               
                epName.SetError(nametxt, "Name should not be left blank!");
                e.Cancel = true;
            }
            else
            {
               
                epName.SetError(nametxt, "");
            }
        }

        private void usernametxt_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(usernametxt.Text))
            {
               
                epUsername.SetError(usernametxt, "Username should not be left blank!");
                e.Cancel = true;
            }
            else
            {
               
                epUsername.SetError(usernametxt, "");
            }
        }

        private void passwordtxt_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(passwordtxt.Text))
            {

                epPassword.SetError(passwordtxt, "Username should not be left blank!");
                e.Cancel = true;
            }
            else
            {

                epPassword.SetError(passwordtxt, "");
            }
        }

        private void confpasswordtxt_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(confpasswordtxt.Text))
            {

                epConfpassword.SetError(confpasswordtxt, "Username should not be left blank!");
                e.Cancel = true;
            }
            else if (passwordtxt.Text != confpasswordtxt.Text) {
                epConfpassword.SetError(confpasswordtxt, "Confirm Password not match with password");
                e.Cancel = true;
            }
            else
            {

                epConfpassword.SetError(confpasswordtxt, "");
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            LoginFormView loginForm = new LoginFormView();
            this.Hide();
            loginForm.ShowDialog();
            this.Close();
        }
    }
}
