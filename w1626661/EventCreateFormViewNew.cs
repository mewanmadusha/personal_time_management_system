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
using w1626661.enums;
using w1626661.model;

namespace w1626661
{
    public partial class EventCreateFormViewNew : Form
    {
        UserModel loggedInUser;
        List<ContactModel> contactModelsDatalist = new List<ContactModel>();
        public EventCreateFormViewNew(UserModel user)
        {
            InitializeComponent();
            loggedInUser = user;
            this.lablename.Text = loggedInUser.Name;
            getAllContacts();
        }

        private void getAllContacts()
        {
            ContactModelManager contactModelManager = new ContactModelManager();
            this.contactModelsDatalist = contactModelManager.getAllContacts(loggedInUser.Id);
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int quantity = Convert.ToInt32(this.selectNumber.Value);

            for (int i = 0; i < quantity; i++)
            {

                EventFormController efc = new EventFormController(loggedInUser);
                // uc.Size = new Size(100, 20);
                //efc.Location = new Point(200, 200 + (i * 20));
                efc.btnEventCreate.Click += button_action_create;
                this.flowLayoutPanel1.Controls.Add(efc);
            }
        }


        private void button_action_create(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button temp = (Button)sender;
                // FlowLayoutPanel flowLayout = (FlowLayoutPanel)temp.Parent;
                TableLayoutPanel tableLayoutPanel = (TableLayoutPanel)temp.Parent;
                TableLayoutPanel tableLayoutPanel1 = (TableLayoutPanel)tableLayoutPanel.Parent;

                EventFormController eventFormController = (EventFormController)tableLayoutPanel1.Parent;
                //   MessageBox.Show(sender.ToString());

                if (eventFormController.validation)
                {

                    //data retrive
                    //Console.WriteLine("aa");
                    EventModel eventModel = new EventModel();
                    EventModelManager em = new EventModelManager();
                    int recuringId = em.getEventLatestId();
                    //int recId = eventModel.getEventId() + 1;
                    string title = eventFormController.event_title;
                    string description = eventFormController.event_description;
                    string location = eventFormController.event_location;
                    DateTime begin_time = eventFormController.start_time;
                    DateTime end_Time = eventFormController.end_time;

                    string event_type = "";
                    if (eventFormController.event_vareity == "a")
                    {

                        event_type = EventVareityEnum.Appointment.ToString();
                    }
                    if (eventFormController.event_vareity == "b")
                    {

                        event_type = EventVareityEnum.Task.ToString();
                    }

                    int userId = loggedInUser.Id;
                    int recuring_vareity = eventFormController.recuring_vareity;

                    int recurring_time = eventFormController.recur_freq;

                    List<string> pickedContactNames = eventFormController.contact_list;
                    /////////////


                    Boolean addEventStatus = false;
                    //daily
                    if (recuring_vareity == 2)
                    {

                        for (int i = 0; i < recurring_time; i++)

                        {
                            List<ContactModel> pickedContactsList = new List<ContactModel>();
                            Console.WriteLine("daily");
                            Console.WriteLine("event vareity=" + event_type + "  recuring Vareity=" + recuring_vareity);

                            foreach (string contactName in pickedContactNames)
                            {
                                Console.WriteLine(contactName);
                                foreach (ContactModel contact in this.contactModelsDatalist)
                                {
                                    if (contactName == contact.ContactName)
                                    {
                                        ContactModel contactTemp = new ContactModel();
                                        contactTemp = contact;
                                        pickedContactsList.Add(contactTemp);
                                    }

                                }

                            }


                            /////////////call modelmanager methode
                            EventModel eventModel1 = new EventModel();
                            eventModel1.Event_title = title;
                            eventModel1.Event_description = description;
                            eventModel1.Event_begin_time = begin_time.AddDays(i);
                            eventModel1.Event_end_time = end_Time.AddDays(i);
                            eventModel1.Event_location = location;
                            eventModel1.Event_variety = event_type;
                            eventModel1.Event_recuring_variety = recuring_vareity;
                            eventModel1.UserId = loggedInUser.Id;



                            EventModelManager eventModelManager = new EventModelManager();


                            addEventStatus = eventModelManager.addevent(eventModel1, pickedContactsList, recuringId);
                        }
                    }
                    //weekly
                    if (recuring_vareity == 3)
                    {

                        for (int i = 0; i < recurring_time; i++)
                        {
                            List<ContactModel> pickedContactsList = new List<ContactModel>();


                            Console.WriteLine("event vareity=" + recuring_vareity + "  recuring Vareity=" + recurring_time);

                            foreach (string contactName in pickedContactNames)
                            {
                                Console.WriteLine(contactName);
                                foreach (ContactModel contact in this.contactModelsDatalist)
                                {
                                    if (contactName == contact.ContactName)
                                    {
                                        ContactModel contactTemp = new ContactModel();
                                        contactTemp = contact;
                                        pickedContactsList.Add(contactTemp);
                                    }

                                }

                            }


                            /////////////call modelmanager methode
                            EventModel eventModel2 = new EventModel();
                            eventModel2.Event_title = title;
                            eventModel2.Event_description = description;
                            eventModel2.Event_begin_time = begin_time.AddDays(7 * i);
                            eventModel2.Event_end_time = end_Time.AddDays(7 * i);
                            eventModel2.Event_location = location;
                            eventModel2.Event_variety = event_type;
                            eventModel2.Event_recuring_variety = recuring_vareity;
                            eventModel2.UserId = loggedInUser.Id;



                            EventModelManager eventModelManager = new EventModelManager();

                            addEventStatus = eventModelManager.addevent(eventModel2, pickedContactsList, recuringId);

                        }

                    }
                    if (recuring_vareity == 1)
                    {
                        List<ContactModel> pickedContactsList = new List<ContactModel>();

                        Console.WriteLine("event vareity=" + recuring_vareity + "  recuring Vareity=" + recuring_vareity);

                        foreach (string contactName in pickedContactNames)
                        {
                            Console.WriteLine(contactName);
                            foreach (ContactModel contact in this.contactModelsDatalist)
                            {
                                if (contactName == contact.ContactName)
                                {
                                    ContactModel contactTemp = new ContactModel();
                                    contactTemp = contact;
                                    pickedContactsList.Add(contactTemp);
                                }

                            }

                        }


                        /////////////call modelmanager methode
                        /////////////call modelmanager methode
                        EventModel eventModel3 = new EventModel();
                        eventModel3.Event_title = title;
                        eventModel3.Event_description = description;
                        eventModel3.Event_begin_time = begin_time;
                        eventModel3.Event_end_time = end_Time;
                        eventModel3.Event_location = location;
                        eventModel3.Event_variety = event_type;
                        eventModel3.Event_recuring_variety = recuring_vareity;
                        eventModel3.UserId = loggedInUser.Id;



                        EventModelManager eventModelManager = new EventModelManager();

                        addEventStatus = eventModelManager.addevent(eventModel3, pickedContactsList, 0);

                    }

                    if (addEventStatus)
                    {
                        MessageBox.Show("Successfully Addes Event");
                        eventFormController.Hide();
                        
                    }
                    else
                    {
                        MessageBox.Show("Database Error");
                    }



                }
                else {
                    MessageBox.Show("Validation Error");
                }
                
            }

        }

        private void btnAdcontact_Click(object sender, EventArgs e)
        {
            EventView eventViewManage = new EventView(loggedInUser);
            this.Hide();
            eventViewManage.ShowDialog();
            this.Close();
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
