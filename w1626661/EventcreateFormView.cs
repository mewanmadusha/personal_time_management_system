using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using w1626661.enums;
using w1626661.model;

namespace w1626661
{
    
    public partial class EventcreateFormView : Form
    {
        UserModel loggedInUser;
        List<ContactModel> contactModelsDatalist = new List<ContactModel>();
        EventModel editableEvent;
        Boolean eventCreation;
        
        public EventcreateFormView(UserModel user,Boolean createEvent,EventModel eventModel)
        {
            InitializeComponent();
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            loggedInUser = user;
            this.startTimetxt.CustomFormat = "HH:mm";
            this.tableLayoutPanel4.Controls.Add(startTimetxt, 1, 1);
            this.endTimetxt.CustomFormat = "HH:mm";
            this.tableLayoutPanel5.Controls.Add(endTimetxt, 1, 1);

            if (createEvent) {
                eventCreation = createEvent;
                setContactsToCheckBox();
                this.btnEventCreate.Visible = true;
                this.btnUpdateEvent.Visible = false;
            }
            if (!createEvent)
            {

                List<ContactModel> checkedContacts = new List<ContactModel>();
                ContactModelManager checkedContactsManager = new ContactModelManager();
                checkedContacts = checkedContactsManager.getCheckedContacts(eventModel.Event_id);
                setContactsToCheckBoxEditEvent(checkedContacts);
                this.label18.Text = "Update Event";
                eventCreation = false;
                this.editableEvent = eventModel;
               
                this.btnEventCreate.Visible = false;
                this.btnUpdateEvent.Visible = true;
                this.tableLayoutPanel8.Visible = false;
                this.tableLayoutPanel6.Visible = false;
               
                this.label12.Visible = false;
                //set values to editable content

                this.eventTitletxt.Text = editableEvent.Event_title;
                if (editableEvent.Event_variety == "Appointment")
                {
                    this.typeAppointment.Checked = true;

                }
                if (editableEvent.Event_variety == "Task")
                {
                    this.typeTask.Checked = true;

                }

                this.eventDescriptiontxt.Text = editableEvent.Event_description;
                this.locationtxt.Text = editableEvent.Event_location;

                string strDate =Convert.ToString(editableEvent.Event_begin_time);
                string[] strdateLis = strDate.Split(' ');
                string asd;
                string ast;
               
                    asd = strdateLis[0];
                    ast = strdateLis[1] + " " + strdateLis[2];

                //Console.WriteLine(asd,ast);
                this.startDatetxt.Value = DateTime.Parse(asd);
                this.startTimetxt.Value = DateTime.Parse(ast);

                string endDate = Convert.ToString(editableEvent.Event_end_time);
                string[]  enddateLis = endDate.Split(' ');

                string aed = enddateLis[0];
                string aet = enddateLis[1]+" "+ enddateLis[2];

                this.endDatetxt.Value = DateTime.Parse(aed);
                this.endTimetxt.Value = DateTime.Parse(aet);



            }

           
           

        }

        private void setContactsToCheckBox()
        {
            ContactModelManager contactModelManager = new ContactModelManager();
            this.contactModelsDatalist = contactModelManager.getAllContacts(loggedInUser.Id);
            foreach (ContactModel contact in contactModelsDatalist)
            {
                contactCheckedListBox.Items.Add(contact.ContactName);
            }
        }

        private void setContactsToCheckBoxEditEvent(List<ContactModel> contactCheck)
        {
            ContactModelManager contactModelManager = new ContactModelManager();
            this.contactModelsDatalist = contactModelManager.getAllContacts(loggedInUser.Id);
            int i = 0;

            foreach (ContactModel contact in contactModelsDatalist)
            {
                contactCheckedListBox.Items.Add(contact.ContactName);

                foreach (ContactModel checkedContacts in contactCheck)
                {
                    if (contact.ContactId == checkedContacts.ContactId)
                    {
                        contactCheckedListBox.SetItemChecked(i, true);
                    }
                }

                i++;
            }
        }


        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            DashboardView dashboardView = new DashboardView(loggedInUser);
            this.Hide();
            dashboardView.ShowDialog();
            this.Close();
        }

        private void btnEventCreate_Click(object sender, EventArgs e)
        {
            //recuring daily=1 weekly=2
            //type enumdata
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                string start_time = this.startTimetxt.Value.ToString("HH:mm");
                string start_date = this.startDatetxt.Value.ToString("yyyy-MM-dd");
                string end_time = this.endTimetxt.Value.ToString("HH:mm");
                string end_date = this.endDatetxt.Value.ToString("yyyy-MM-dd");
                DateTime start_date_time = DateTime.Parse(start_date + " " + start_time);
                DateTime end_date_time = DateTime.Parse(end_date + " " + end_time);

                Boolean isdateValidationStatus = dateValidationStatus(start_date_time, end_date_time);
                if (isdateValidationStatus)
                {

                    /////////////////initialize data
              

                    EventModelManager em = new EventModelManager();
                    int recuringId = em.getEventLatestId();

                    int recuring_variety = 1; //default recuring one time
                    string event_variety = "";//appoinment or task

                    if (typeDaily.Checked)
                    {
                        recuring_variety = 2;//daily
                    }
                    else if (typeWeekly.Checked)
                    {
                        recuring_variety = 3;//weekly
                    }
                    else if (typeOnetime.Checked)
                    {
                        recuring_variety = 1;//once

                    }

                    if (typeAppointment.Checked)
                    {
                        event_variety = EventVareityEnum.Appointment.ToString();
                    }
                    else if (typeTask.Checked)
                    {
                        event_variety = EventVareityEnum.Task.ToString();
                    }

                    int recureVal = Convert.ToInt32(recureFreq.Value);
                    Boolean addEventStatus = false;
                    //daily
                    if (recuring_variety == 2)
                    {

                        for (int i = 0; i < recureVal; i++)

                        {
                            List<ContactModel> pickedContactsList = new List<ContactModel>();
                            Console.WriteLine("daily");
                            Console.WriteLine("event vareity=" + event_variety + "  recuring Vareity=" + recuring_variety);

                            foreach (string contactName in contactCheckedListBox.CheckedItems)
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
                            EventModel eventModel = new EventModel();
                            eventModel.Event_title = eventTitletxt.Text;
                            eventModel.Event_description = eventDescriptiontxt.Text;
                            eventModel.Event_begin_time = start_date_time.AddDays(i);
                            eventModel.Event_end_time = end_date_time.AddDays(i);
                            eventModel.Event_location = locationtxt.Text;
                            eventModel.Event_variety = event_variety;
                            eventModel.Event_recuring_variety = recuring_variety;
                            eventModel.UserId = loggedInUser.Id;



                            EventModelManager eventModelManager = new EventModelManager();
                            

                            addEventStatus = eventModelManager.addevent(eventModel, pickedContactsList,recuringId);
                        }
                    }
                    //weekly
                    if (recuring_variety == 3)
                    {

                        for (int i = 0; i < recureVal; i++)
                        {
                            List<ContactModel> pickedContactsList = new List<ContactModel>();


                            Console.WriteLine("event vareity=" + event_variety + "  recuring Vareity=" + recuring_variety);

                            foreach (string contactName in contactCheckedListBox.CheckedItems)
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
                            EventModel eventModel = new EventModel();
                            eventModel.Event_title = eventTitletxt.Text;
                            eventModel.Event_description = eventDescriptiontxt.Text;
                            eventModel.Event_begin_time = start_date_time.AddDays(7 * i);
                            eventModel.Event_end_time = end_date_time.AddDays(7 * i);
                            eventModel.Event_location = locationtxt.Text;
                            eventModel.Event_variety = event_variety;
                            eventModel.Event_recuring_variety = recuring_variety;
                            eventModel.UserId = loggedInUser.Id;



                            EventModelManager eventModelManager = new EventModelManager();

                            addEventStatus = eventModelManager.addevent(eventModel, pickedContactsList, recuringId);

                        }

                    }
                    if (recuring_variety == 1)
                    {
                        List<ContactModel> pickedContactsList = new List<ContactModel>();

                        Console.WriteLine("event vareity=" + event_variety + "  recuring Vareity=" + recuring_variety);

                        foreach (string contactName in contactCheckedListBox.CheckedItems)
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
                        EventModel eventModel = new EventModel();
                        eventModel.Event_title = eventTitletxt.Text;
                        eventModel.Event_description = eventDescriptiontxt.Text;
                        eventModel.Event_begin_time = start_date_time;
                        eventModel.Event_end_time = end_date_time;
                        eventModel.Event_location = locationtxt.Text;
                        eventModel.Event_variety = event_variety;
                        eventModel.Event_recuring_variety = recuring_variety;
                        eventModel.UserId = loggedInUser.Id;



                        EventModelManager eventModelManager = new EventModelManager();

                        addEventStatus = eventModelManager.addevent(eventModel, pickedContactsList,0);

                    }

                    if (addEventStatus)
                    {
                        MessageBox.Show("Successfully Addes Event");
                    }
                    else
                    {
                        MessageBox.Show("Database Error");
                    }

                }



            }
            else {
                MessageBox.Show("Please Fill Required Fields ");
            }

            
        }

        private Boolean dateValidationStatus(DateTime start_date_time, DateTime end_date_time)
        {

            EventModelManager eventModelManager = new EventModelManager();
            List<EventModel> eventModelsList = eventModelManager.getAllEvents(loggedInUser.Id);
            DateTime beginTime = new DateTime();
            DateTime endTime = new DateTime();

            Boolean checkBeginTime = false;
            Boolean checkEndTime = false;

            

            foreach (EventModel eventModel in eventModelsList)
            {
                if (start_date_time >= eventModel.Event_begin_time && end_date_time < eventModel.Event_end_time)
                {
                    beginTime = eventModel.Event_begin_time;
                    endTime = eventModel.Event_end_time;
                    checkBeginTime = true;
                    break;
                }
                else
                {
                    checkBeginTime = false;
                    if (end_date_time >= eventModel.Event_begin_time && end_date_time < eventModel.Event_end_time)
                    {
                        beginTime = eventModel.Event_begin_time;
                        endTime = eventModel.Event_end_time;
                        checkEndTime = true;
                        break;
                    }
                    else
                    {
                        checkEndTime = false;
                    }
                }
            }


            if (!checkBeginTime && !checkEndTime)
            {
                return true;
            }
            else
            {
                MessageBox.Show("There is already have event for you from " + start_date_time.ToString() + " to " + endTime.ToString() +
                    ". Choose  another time slot!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        private Boolean dateValidationStatusUpdate(DateTime start_date_time, DateTime end_date_time)
        {
            
            EventModelManager eventModelManager = new EventModelManager();
            List<EventModel> eventModelsList = eventModelManager.getAllEvents(loggedInUser.Id);
            DateTime beginTime = new DateTime();
            DateTime endTime = new DateTime();

            Boolean checkBeginTime = false;
            Boolean checkEndTime = false;



            foreach (EventModel eventModel in eventModelsList)
            {
                if (editableEvent.Event_id != eventModel.Event_id) {
                    if (start_date_time >= eventModel.Event_begin_time && end_date_time < eventModel.Event_end_time)
                    {
                        beginTime = eventModel.Event_begin_time;
                        endTime = eventModel.Event_end_time;
                        checkBeginTime = true;
                        break;
                    }
                    else
                    {
                        checkBeginTime = false;
                        if (end_date_time >= eventModel.Event_begin_time && end_date_time < eventModel.Event_end_time)
                        {
                            beginTime = eventModel.Event_begin_time;
                            endTime = eventModel.Event_end_time;
                            checkEndTime = true;
                            break;
                        }
                        else
                        {
                            checkEndTime = false;
                        }
                    }
                }
            }
               


            if (!checkBeginTime && !checkEndTime)
            {
                return true;
            }
            else
            {
                MessageBox.Show("There is already have event for you from " + start_date_time.ToString() + " to " + endTime.ToString() +
                    ". Choose  another time slot!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        private void eventTitletxt_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(eventTitletxt.Text))
            {

                errorProvidereventCreate.SetError(eventTitletxt, "Event title should not be left blank!");
                e.Cancel = true;
            }
            else
            {

                errorProvidereventCreate.SetError(eventTitletxt, "");
            }
        }

        private void eventDescriptiontxt_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(eventDescriptiontxt.Text))
            {

                errorProvidereventCreate.SetError(eventDescriptiontxt, "Event description should not be left blank!");
                e.Cancel = true;
            }
            else
            {

                errorProvidereventCreate.SetError(eventDescriptiontxt, "");
            }
        }

        private void typeTask_Validating(object sender, CancelEventArgs e)
        {
            if (!typeAppointment.Checked && !typeTask.Checked)

            {

                errorProvidereventCreate.SetError(tableLayoutPanel3, "Event type should not be left blank!");
                e.Cancel = true;
            }
            else
            {

                errorProvidereventCreate.SetError(tableLayoutPanel3, "");
            }
           
         }

        private void endTimetxt_Validating(object sender, CancelEventArgs e)
        {
            string start_time = this.startTimetxt.Value.ToString("HH:mm");
            string start_date = this.startDatetxt.Value.ToString("yyyy-MM-dd");
            string end_time = this.endTimetxt.Value.ToString("HH:mm");
            string end_date = this.endDatetxt.Value.ToString("yyyy-MM-dd");
            DateTime start_date_time = DateTime.Parse(start_date + " " + start_time);
            DateTime end_date_time = DateTime.Parse(end_date + " " + end_time);

            if ((start_date_time >= end_date_time))
            {

                errorProvidereventCreate.SetError(tableLayoutPanel5, "Start time end time issue!");
                e.Cancel = true;
            }
            else
            {

                errorProvidereventCreate.SetError(tableLayoutPanel5, "");
            }
            
        }

        private void typeOnetime_Validating(object sender, CancelEventArgs e)
        {
            if (this.eventCreation)
            {
                if (!typeDaily.Checked && !typeWeekly.Checked && !typeOnetime.Checked)

                {

                    errorProvidereventCreate.SetError(tableLayoutPanel7, "Recuring Option should not be left blank!");
                    e.Cancel = true;
                }
                else
                {

                    errorProvidereventCreate.SetError(tableLayoutPanel7, "");
                }
            }
            else {
                errorProvidereventCreate.SetError(tableLayoutPanel7, "");
            }
        }

        private void locationtxt_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(locationtxt.Text))
            {

                errorProvidereventCreate.SetError(locationtxt, "Location should not be left blank!");
                e.Cancel = true;
            }
            else
            {

                errorProvidereventCreate.SetError(locationtxt, "");
            }
        }

        private void contactCheckedListBox_Validating(object sender, CancelEventArgs e)
        {
          
                if (contactCheckedListBox.CheckedIndices.Count == 0)
                {
                    errorProvidereventCreate.SetError(contactCheckedListBox, "Pick atleast one contact");
                    e.Cancel = true;
                }
                else
                {

                    errorProvidereventCreate.SetError(contactCheckedListBox, "");
                }
           
        }

        private void btnUpdateEvent_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                string start_time = this.startTimetxt.Value.ToString("HH:mm");
                string start_date = this.startDatetxt.Value.ToString("yyyy-MM-dd");
                string end_time = this.endTimetxt.Value.ToString("HH:mm");
                string end_date = this.endDatetxt.Value.ToString("yyyy-MM-dd");
                DateTime start_date_time = DateTime.Parse(start_date + " " + start_time);
                DateTime end_date_time = DateTime.Parse(end_date + " " + end_time);

                Boolean isdateValidationStatus = dateValidationStatusUpdate(start_date_time, end_date_time);
                if (isdateValidationStatus)
                {

                    ContactModelManager cmm = new ContactModelManager();
                    Boolean status= cmm.deleteByEventContact(editableEvent.Event_id);
                  
                        /////////////////initialize data
                        List<ContactModel> pickedContactsList = new List<ContactModel>();
                        //int recuring_variety = 1; //default recuring one time
                        string event_variety = "";//appoinment or task



                        if (typeAppointment.Checked)
                        {
                            event_variety = EventVareityEnum.Appointment.ToString();
                        }
                        else if (typeTask.Checked)
                        {
                            event_variety = EventVareityEnum.Task.ToString();
                        }

                        Console.WriteLine("event vareity=" + event_variety);

                        foreach (string contactName in contactCheckedListBox.CheckedItems)
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
                        EventModel eventModel = new EventModel();
                        eventModel.Event_title = eventTitletxt.Text;
                        eventModel.Event_description = eventDescriptiontxt.Text;
                        eventModel.Event_begin_time = start_date_time;
                        eventModel.Event_end_time = end_date_time;
                        eventModel.Event_location = locationtxt.Text;
                        eventModel.Event_variety = event_variety;

                        eventModel.UserId = loggedInUser.Id;
                        eventModel.Event_id = editableEvent.Event_id;



                        EventModelManager eventModelManager = new EventModelManager();

                        Boolean addEventStatus = eventModelManager.updateEvent(eventModel, editableEvent, pickedContactsList);

                        if (addEventStatus)
                        {
                            
                        }
                        else
                        {
                            MessageBox.Show("Database Error");
                        }

                  
                }
                else
                {
                    MessageBox.Show("Selected time slot already picked select different time slot");
                }


            }
            else
            {
                MessageBox.Show("Please Fill Required fields");
            }

        }

        private void typeOnetime_CheckedChanged(object sender, EventArgs e)
        {
            recureFreq.Visible=false;
        }

        private void typeDaily_CheckedChanged(object sender, EventArgs e)
        {
            recureFreq.Visible=true;
        }

        private void typeWeekly_CheckedChanged(object sender, EventArgs e)
        {
            recureFreq.Visible = true;
        }
    }
}
