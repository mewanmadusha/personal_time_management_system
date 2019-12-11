using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using w1626661.dynamic;
using w1626661.model;

namespace w1626661
{
    public partial class DashboardView : Form
    {
        UserModel loggedInUser;
        List<EventModel> followinWeekEvent = new List<EventModel>();
        public DashboardView(UserModel user)
        {
            InitializeComponent();
            loggedInUser = user;
            this.lablename.Text= loggedInUser.Name;

            getFollowingSevenDayEvents();
        }

        private void getFollowingSevenDayEvents()
        {
            EventModelManager eventModelManager = new EventModelManager();
            EventSummaryViewController eventSummaryView = new EventSummaryViewController();
            followinWeekEvent = eventModelManager.getFollowingWeekEvents(loggedInUser.Id);

            //int quantity = contactModelsList.Count;
            int i = 0;
            foreach (EventModel eventModel in followinWeekEvent)
            {

                EventSummaryViewController ecc = new EventSummaryViewController();
                // uc.Size = new Size(100, 20);
                ecc.Location = new Point(200, 200 + (i * 20));

                ecc.lblDate.Text = eventModel.Event_begin_time.Day.ToString();
                ecc.lblFullDate.Text = eventModel.Event_begin_time.Date.ToString();
                ecc.lblTime.Text = eventModel.Event_begin_time.TimeOfDay.ToString()+" TO "+ eventModel.Event_end_time.TimeOfDay.ToString();
                ecc.lblTitle.Text = eventModel.Event_title;
                ecc.lblDescription.Text = eventModel.Event_description;

               
                // cdc.btnDelete.Click += button_action_delete;

                this.flowLayoutPanel1.Controls.Add(ecc);
                i++;
            }
        }

        private void btnAdEvent_Click_1(object sender, EventArgs e)
        {
            Boolean evetCreaete = true;
            EventModel eventModel = null;
            EventcreateFormView eventView = new EventcreateFormView(loggedInUser,evetCreaete,eventModel);
            this.Hide();
            eventView.ShowDialog();
            this.Close();
        }

        //private void btnAdEvent_Click_1(object sender, EventArgs e)
        //{
        //    Boolean evetCreaete = true;
        //    EventModel eventModel = null;
        //    EventcreateFormView eventView = new EventcreateFormView(loggedInUser, evetCreaete, eventModel);
        //    this.Hide();
        //    eventView.ShowDialog();
        //    this.Close();
        //}

        private void btnAdcontact_Click(object sender, EventArgs e)
        {
            Boolean create = true;
            ContactModel contact = null;
            ContactcreateFormView contactView = new ContactcreateFormView(loggedInUser,create,contact);
            this.Hide();
            contactView.ShowDialog();
            this.Close();
        }

        private void btnManageContact_Click_1(object sender, EventArgs e)
        {
            ContactView contactViewManage = new ContactView(loggedInUser);
            this.Hide();
            contactViewManage.ShowDialog();
            this.Close();
        }

        private void btnManageEvent_Click(object sender, EventArgs e)
        {
            EventView eventViewManage = new EventView(loggedInUser);
            this.Hide();
            eventViewManage.ShowDialog();
            this.Close();
        }

        private void btnPrediction_Click(object sender, EventArgs e)
        {
            PredictionTimeView predictionTimeView = new PredictionTimeView(loggedInUser);
            this.Hide();
            predictionTimeView.ShowDialog();
            this.Close();
        }

        private void roundButton1_Click(object sender, EventArgs e)
        {
            EventCreateFormViewNew eventCreateFormViewNew = new EventCreateFormViewNew(loggedInUser);
            this.Hide();
            eventCreateFormViewNew.ShowDialog();
            this.Close();
        }

        private void roundButton2_Click(object sender, EventArgs e)
        {
            LoginFormView loginFormView = new LoginFormView();
            this.Hide();
            loginFormView.ShowDialog();
            this.Close();
        }
    }

   
}
