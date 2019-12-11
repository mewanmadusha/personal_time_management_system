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
    //contact view show all corresponding contacts that already inserted by user
    //contact dadta will show dynamically
    //there is also delete and edit button with each dynamic contact view cotroller
    public partial class ContactView : Form
    {
        UserModel loggedInUser;
        List<ContactModel> contactModelsList = new List<ContactModel>();
        public ContactView(UserModel user)
        {
            InitializeComponent();
            loggedInUser = user;
            this.lablename.Text = loggedInUser.Name;
            this.ShowContacts();
        }

        private void ShowContacts()
        {
            ContactModelManager contactModelManager = new ContactModelManager();
            contactModelsList = contactModelManager.getAllContacts(loggedInUser.Id);

            //int quantity = contactModelsList.Count;
            int i = 0;
            foreach (ContactModel contact in contactModelsList)
            {

                ContactDisplayController cdc = new ContactDisplayController();
                // uc.Size = new Size(100, 20);
                cdc.Location = new Point(200, 200 + (i * 20));
                

                cdc.lblName.Text = contact.ContactName;
                cdc.lblEmail.Text = contact.Email;
                cdc.lblMobileno.Text = contact.MobileNo;
                cdc.lblId.Text = contact.ContactId.ToString();

                cdc.btnEdit.Click += button_action_edit;
                cdc.btnDelete.Click += button_action_delete;
               // cdc.btnDelete.Click += button_action_delete;

                this.flowLayoutPanel1.Controls.Add(cdc);
                i++;
            }
        }

        private void button_action_edit(object sender, EventArgs e)
        {
              if (sender is Button)
                {
                    Button temp = (Button)sender;
                // FlowLayoutPanel flowLayout = (FlowLayoutPanel)temp.Parent;
                TableLayoutPanel tableLayoutPanel = (TableLayoutPanel)temp.Parent;
                //   MessageBox.Show(sender.ToString());
                TableLayoutPanel tableLayoutPanel1 = (TableLayoutPanel)tableLayoutPanel.Parent;

                ContactDisplayController contactDisplayController = (ContactDisplayController)tableLayoutPanel1.Parent;

                    string name = contactDisplayController.name;
                    string email = contactDisplayController.email;
                    // Int32 contactNumber = Convert.ToInt32(m.ContactNumber);
                    string mobileNo = contactDisplayController.mobileNo;
                    string id = contactDisplayController.id;

                    int userId = loggedInUser.Id;

                //MessageBox.Show(name + email + mobileNo);
                if (MessageBox.Show("Do you wish to edit Contact "+name, "Edit Contact",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    ContactModel contact = new ContactModel();
                    contact.ContactName = name;
                    contact.MobileNo = mobileNo;
                    contact.Email = email;
                    contact.UserId = userId;
                    contact.ContactId =Convert.ToInt32(id);

                    Boolean create = false;

                    ContactcreateFormView contactView = new ContactcreateFormView(loggedInUser, create, contact);
                    this.Hide();
                    contactView.ShowDialog();
                    this.Close();
                }
            }

        }

        private void button_action_delete(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button temp = (Button)sender;
                // FlowLayoutPanel flowLayout = (FlowLayoutPanel)temp.Parent;
                TableLayoutPanel tableLayoutPanel = (TableLayoutPanel)temp.Parent;
                //   MessageBox.Show(sender.ToString());
                TableLayoutPanel tableLayoutPanel1 = (TableLayoutPanel)tableLayoutPanel.Parent;

                ContactDisplayController contactDisplayController = (ContactDisplayController)tableLayoutPanel1.Parent;

                string name = contactDisplayController.name;
                string id = contactDisplayController.id;

                int userId = loggedInUser.Id;

                //MessageBox.Show(name + email + mobileNo);
                if (MessageBox.Show("Do you wish to delete Contact " + name, "",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    ContactModel contact = new ContactModel();
                  
                    contact.UserId = userId;
                    contact.ContactId = Convert.ToInt32(id);

                    ContactModelManager contactModelManager = new ContactModelManager();
                    Boolean deleteStatus= contactModelManager.deleteContact(contact);


                    if (deleteStatus)
                    {
                        MessageBox.Show("Successfully deleted Contact");
                        ContactView contactView = new ContactView(loggedInUser);
                        this.Hide();
                        contactView.ShowDialog();
                        this.Close();
                    }
                    else {
                        MessageBox.Show("Current Contact Already use in some events please Go back and delete events");
                    }

                   
                }
            }





        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            DashboardView dashboardView = new DashboardView(loggedInUser);
            this.Hide();
            dashboardView.ShowDialog();
            this.Close();
        }

        private void btnAdcontact_Click(object sender, EventArgs e)
        {
            Boolean create = true;
            ContactModel contact = null;
            ContactcreateFormView contactView = new ContactcreateFormView(loggedInUser, create, contact);
            this.Hide();
            contactView.ShowDialog();
            this.Close();
        }
    }
}
