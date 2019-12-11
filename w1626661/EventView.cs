using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using w1626661.dynamic;
using w1626661.model;

namespace w1626661
{
    public partial class EventView : Form
    {
        UserModel loggedInUser;
        List<EventModel> EventModelsList = new List<EventModel>();
        public EventView(UserModel user)
        {
            InitializeComponent();
            loggedInUser = user;
            this.lablename.Text = user.Name;

            //genarate data via thread
            Console.WriteLine("Start");
            Thread loadDataThread = new Thread(ShowEvents);
            loadDataThread.Start();
            //MessageBox.Show("Retive Data");

        }

        private void ShowEvents()
        {
            EventModelManager eventModelManager = new EventModelManager();
            EventModelsList = eventModelManager.getAllEvents(loggedInUser.Id);

            //int quantity = contactModelsList.Count;
            int i = 0;
            foreach (EventModel eventModel in EventModelsList)
            {
                ContactModelManager contactModelManager = new ContactModelManager();
                List<string> contactsData= contactModelManager.getContactListwithNumber(eventModel.Event_id);

                EventDisplayController edc = new EventDisplayController();
                // uc.Size = new Size(100, 20);
                edc.Location = new Point(200, 200 + (i * 20));
                string contact="";
                foreach (string data in contactsData) {
                    contact += data + ", ";
                }
                edc.lblContact.Text=contact;
                edc.lblTitle.Text = eventModel.Event_title;
                edc.lblDescription.Text = eventModel.Event_description;
                edc.lblVareity.Text = eventModel.Event_variety;
                edc.lblDateStart.Text = Convert.ToString(eventModel.Event_begin_time);
                edc.lblDateEnd.Text = Convert.ToString(eventModel.Event_end_time);
                edc.lblLocation.Text = eventModel.Event_location;
                edc.lblId.Text = Convert.ToString(eventModel.Event_id);
                edc.lblRecurVareity.Text = Convert.ToString(eventModel.Event_recuring_variety);
                if (eventModel.Event_recuring_variety == 1)
                {
                    edc.lblRecuringType.Text = "Once";
                }
                else if (eventModel.Event_recuring_variety == 2)
                {
                    edc.lblRecuringType.Text = "Daily";
                }
                else if (eventModel.Event_recuring_variety == 3)
                {
                    edc.lblRecuringType.Text = "Weekly";
                }


                edc.btnEditEvent.Click += button_action_edit_event;
                edc.btnDeleteEvent.Click += button_action_delete_event;
               

                //flowLayoutPanel1.Controls.Add(edc);

                //use thread to get ui data
               
                this.flowLayoutPanel1.Invoke((MethodInvoker)delegate {
                    // Running on the UI thread
                    this.flowLayoutPanel1.Controls.Add(edc);
                });

                i++;
            }

            
        }

        private void button_action_edit_event(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button temp = (Button)sender;
                // FlowLayoutPanel flowLayout = (FlowLayoutPanel)temp.Parent;
                TableLayoutPanel tableLayoutPanel = (TableLayoutPanel)temp.Parent;
                //   MessageBox.Show(sender.ToString());
                //TableLayoutPanel tableLayoutPanel1 = (TableLayoutPanel)tableLayoutPanel.Parent;

                EventDisplayController eventDisplayController = (EventDisplayController)tableLayoutPanel.Parent;

                string description = eventDisplayController.description;
                string title = eventDisplayController.title;
                string location = eventDisplayController.location;
                // Int32 contactNumber = Convert.ToInt32(m.ContactNumber);
                string eventVareity = eventDisplayController.EventVareity;

                
                DateTime startingTime = DateTime.Parse(eventDisplayController.startingTime);
                DateTime EndingTime = DateTime.Parse(eventDisplayController.EndingTime);

                int eventId = Convert.ToInt32(eventDisplayController.id);

                int userId = loggedInUser.Id;
                int recureType=0;

                if (eventDisplayController.recurType == "Daily")
                {
                    recureType = 2;
                }
                else if (eventDisplayController.recurType == "weekly")
                {
                    recureType = 3;
                }
                else if (eventDisplayController.recurType == "Once")
                {
                    recureType = 1;
                }

                //edit recuring events
               // if(re)

                    //MessageBox.Show(name + email + mobileNo);
                    if (MessageBox.Show("Do you wish to edit Event ", "Edit Event",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    EventModel eventModel = new EventModel();

                    eventModel.Event_title = title;
                    eventModel.Event_description = description;
                    eventModel.Event_begin_time = startingTime;
                    eventModel.Event_end_time = EndingTime;
                    eventModel.Event_location = location;
                    eventModel.Event_variety = eventVareity;
                    eventModel.Event_recuring_variety = recureType;
                    
                    eventModel.UserId = userId;
                    eventModel.Event_id = eventId;

                    Boolean create = false;

                    EventcreateFormView eventView = new EventcreateFormView(loggedInUser, create, eventModel);
                    this.Hide();
                    eventView.ShowDialog();
                    this.Close();
                }
            }

        }
        private void button_action_delete_event(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button temp = (Button)sender;
                // FlowLayoutPanel flowLayout = (FlowLayoutPanel)temp.Parent;
                TableLayoutPanel tableLayoutPanel = (TableLayoutPanel)temp.Parent;
                //   MessageBox.Show(sender.ToString());
                

                EventDisplayController eventDisplayController = (EventDisplayController)tableLayoutPanel.Parent;


                string event_id = eventDisplayController.id;
              

                int userId = loggedInUser.Id;

                //MessageBox.Show(name + email + mobileNo);
                if (MessageBox.Show("Do you wish to delete Contact ", "Delete Eevent",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    
                  

                    EventModelManager eventModelManager = new EventModelManager();
                    Boolean deleteStatus = eventModelManager.deleteEvent(event_id,userId);


                    if (deleteStatus)
                    {
                        MessageBox.Show("Successfully deleted Event");
                        EventView eventView = new EventView(loggedInUser);
                        this.Hide();
                        eventView.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Db error");
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
    }
}
