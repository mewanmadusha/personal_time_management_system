using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using w1626661.dynamic;
using w1626661.model;

namespace w1626661
{
    public partial class ContactcreateFormView : Form
    {
        UserModel loggedInUser;
        Boolean createStatus;
        ContactModel editableConact;
        public ContactcreateFormView(UserModel userModel,Boolean create,ContactModel contact)
        {
            InitializeComponent();
            this.btnHome.FlatAppearance.BorderSize = 0;
            loggedInUser = userModel;
            this.lablename.Text = loggedInUser.Name;
            this.createStatus = create;

            if (createStatus) {
                groupBox1.Visible = true;
            }

            if (!createStatus) {
                groupBox1.Visible = false;
                this.label2.Text = "Manage Current Contact";
                editableConact = contact;
                viewEditForm(contact);
            }
        }

        //view edit functionality
        private void viewEditForm(ContactModel contact)
        {
            ContactFormController cfc = new ContactFormController();
            // uc.Size = new Size(100, 20);
            //new function
         


            cfc.mobilenumbertxt.Text = contact.MobileNo;
            cfc.contactNametxt.Text = contact.ContactName;
            cfc.emailtxt.Text = contact.Email;

          
            cfc.btnCreateContact.Click += button_action_edit;
            this.flowLayoutPanel1.Controls.Add(cfc);
        }

        private void btnAdcontact_Click(object sender, EventArgs e)
        {
            int quantity = Convert.ToInt32(this.selectNumber.Value);

            for (int i = 0; i < quantity; i++)
            {
              
                ContactFormController cfc = new ContactFormController();
                // uc.Size = new Size(100, 20);
                cfc.Location = new Point(200, 200 + (i * 20));
                cfc.btnCreateContact.Click += button_action;
                this.flowLayoutPanel1.Controls.Add(cfc);
            }
        }

        private void button_action(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button temp = (Button)sender;
                // FlowLayoutPanel flowLayout = (FlowLayoutPanel)temp.Parent;
                ContactFormController contactFormController = (ContactFormController)temp.Parent;
                //   MessageBox.Show(sender.ToString());
                String name = contactFormController.name;
                String email = contactFormController.email;
                // Int32 contactNumber = Convert.ToInt32(m.ContactNumber);
                String mobileNo = contactFormController.mobileNo;
                
                int userId = loggedInUser.Id;

               // MessageBox.Show("Do you wish to add this Contact");


                if (name != "" && email != "")

                {
                    if (MessageBox.Show("Do you wish to Add this Contact ", "Add Contact",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                   MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                    {
                        ContactModel contact = new ContactModel();
                        contact.ContactName = name;
                        contact.MobileNo = mobileNo;
                        contact.Email = email;
                        contact.UserId = userId;


                        ContactModelManager contactModelManager = new ContactModelManager();
                        Boolean status = contactModelManager.addContact(contact);

                        if (status)
                        {
                            MessageBox.Show("Successfully Added Cotact to Database");
                            contactFormController.Hide();

                        }
                        else
                        {
                            MessageBox.Show("DataBase Error");
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Name And Email Cannot be Empty");
                }
            }

        }

        private void button_action_edit(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button temp = (Button)sender;
                // FlowLayoutPanel flowLayout = (FlowLayoutPanel)temp.Parent;
                ContactFormController contactFormController = (ContactFormController)temp.Parent;
                //   MessageBox.Show(sender.ToString());
                String name = contactFormController.name;
                String email = contactFormController.email;
                // Int32 contactNumber = Convert.ToInt32(m.ContactNumber);
                String mobileNo = contactFormController.mobileNo;

                int userId = loggedInUser.Id;

                MessageBox.Show(name + email + mobileNo);


                if (name != "" && email != "")

                {
                    if (MessageBox.Show("Do you wish to Add this Contact ", "Add Contact",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                  MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                    {
                        ContactModel contact = new ContactModel();
                        contact.ContactName = name;
                        contact.MobileNo = mobileNo;
                        contact.Email = email;
                        contact.UserId = userId;
                        contact.ContactId = editableConact.ContactId;


                        ContactModelManager contactModelManager = new ContactModelManager();
                        Boolean status = contactModelManager.updateContact(contact);

                        if (status)
                        {
                            MessageBox.Show("Successfully Updated Contact");

                        }
                        else
                        {
                            MessageBox.Show("Database Error");
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Name and Email cannot be empty");
                }
            }

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnHome_Click_1(object sender, EventArgs e)
        {
            DashboardView dashboardView = new DashboardView(loggedInUser);
            this.Hide();
            dashboardView.ShowDialog();
            this.Close();
        }
    }
}
