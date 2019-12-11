using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using w1626661.model;

namespace w1626661.dynamic
{
    public partial class EventFormController : UserControl
    {
        UserModel loggedInUser;
        Boolean btnstatus;
        List<ContactModel> contactModelsDatalist;
        Boolean validationLast = false;
        public EventFormController(UserModel user)
        {
            InitializeComponent();
            loggedInUser = user;
            btnstatus = false;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.startTimetxt.CustomFormat = "HH:mm";
            this.tableLayoutPanel4.Controls.Add(startTimetxt, 1, 1);
            this.endTimetxt.CustomFormat = "HH:mm";
            this.tableLayoutPanel5.Controls.Add(endTimetxt, 1, 1);
            setContactsToCheckBox();
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

        public String event_vareity
        {
           
            get
            {
                string flagType = null;
                if (this.typeAppointment.Checked) {
                    flagType= "a";
                }
                else if (this.typeTask.Checked) {
                    flagType = "b";
                }
                return flagType ;
            }
        }

        public int recuring_vareity
        {

            get
            {
                int flagType = 0;
                if (this.typeOnetime.Checked)
                {
                    flagType = 1;
                }
                else if (this.typeDaily.Checked)
                {
                    flagType =2;
                }
                else if (this.typeWeekly.Checked)
                {
                    flagType = 3;
                }
                return flagType;
            }
        }

        public String event_title
        {
            get
            {
                return this.eventTitletxt.Text;
            }
        }

        public String event_description
        {
            get
            {
                return this.eventDescriptiontxt.Text;
            }
        }

        public String event_location
        {
            get
            {
                return this.locationtxt.Text;
            }
        }

        public int recur_freq
        {
            get
            {
                return Convert.ToInt32(this.recureFreq.Value);
            }
        }

        public DateTime start_time
        {
            get
            {
                string start_time = this.startTimetxt.Value.ToString("HH:mm");
                string start_date = this.startDatetxt.Value.ToString("yyyy-MM-dd");
                DateTime start_date_time = DateTime.Parse(start_date + " " + start_time);
                return start_date_time;
            }
        }

        public DateTime end_time
        {
            get
            {
                string end_time = this.endTimetxt.Value.ToString("HH:mm");
                string end_date = this.endDatetxt.Value.ToString("yyyy-MM-dd");

                DateTime end_date_time = DateTime.Parse(end_date + " " + end_time);

                return end_date_time;
            }
        }

        public List<string> contact_list {
            get
            {
                List<string> contactListName=new List<string>();
                foreach (string contactName in contactCheckedListBox.CheckedItems)
                {
                    contactListName.Add(contactName);
                }
                return contactListName;
             }
        }


        private void typeTask_Validating(object sender, CancelEventArgs e)
        {
            if (!typeAppointment.Checked && !typeTask.Checked)

            {

                ep.SetError(tableLayoutPanel3, "Event type should not be left blank!");
                e.Cancel = true;
            }
            else
            {

                ep.SetError(tableLayoutPanel3, "");
            }
        }

        private void eventTitletxt_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(eventTitletxt.Text))
            {

                ep.SetError(eventTitletxt, "Event title should not be left blank!");
                e.Cancel = true;
            }
            else
            {

                ep.SetError(eventTitletxt, "");
            }
        }

        private void eventDescriptiontxt_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(eventDescriptiontxt.Text))
            {

                ep.SetError(eventDescriptiontxt, "Event description should not be left blank!");
                e.Cancel = true;
            }
            else
            {

                ep.SetError(eventDescriptiontxt, "");
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

                ep.SetError(tableLayoutPanel5, "Start time end time issue!");
                e.Cancel = true;
            }
            else
            {

                ep.SetError(tableLayoutPanel5, "");
            }
        }

        private void typeOnetime_Validating(object sender, CancelEventArgs e)
        {
            
                if (!typeDaily.Checked && !typeWeekly.Checked && !typeOnetime.Checked)

                {

                    ep.SetError(tableLayoutPanel7, "Recuring Option should not be left blank!");
                    e.Cancel = true;
                }
                else
                {

                    ep.SetError(tableLayoutPanel7, "");
                }
            }

        private void contactCheckedListBox_Validating(object sender, CancelEventArgs e)
        {

            if (contactCheckedListBox.CheckedIndices.Count == 0)
            {
                ep.SetError(contactCheckedListBox, "Pick atleast one contact");
                e.Cancel = true;
            }
            else
            {

                ep.SetError(contactCheckedListBox, "");
            }
        }

        private void locationtxt_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(locationtxt.Text))
            {

                ep.SetError(locationtxt, "Location should not be left blank!");
                e.Cancel = true;
            }
            else
            {

                ep.SetError(locationtxt, "");
            }
        }

        private void btnEventCreate_Click(object sender, EventArgs e)
        {
            btnstatus = false;
            if (ValidateChildren(ValidationConstraints.Enabled) && date_check)
            {
                btnstatus = true;
                this.validationLast = true;
            }
            else {
                this.validationLast = false;
            }
           
        }

         public Boolean validation {
            get
            {
                return this.validationLast;
            }
        }

        public Boolean date_check
        {
            get
            {
                return dateValidationStatus(this.start_time, this.end_time);
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

        private void typeOnetime_CheckedChanged(object sender, EventArgs e)
        {
            recureFreq.Visible = false;
        }

        private void typeWeekly_CheckedChanged(object sender, EventArgs e)
        {
            recureFreq.Visible = true;
        }

        private void typeDaily_CheckedChanged(object sender, EventArgs e)
        {
            recureFreq.Visible = true;
        }
    }

}
