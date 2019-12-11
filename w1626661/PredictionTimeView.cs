using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using w1626661.model;

namespace w1626661
{
    public partial class PredictionTimeView : Form
    {
        UserModel loggedInUser;
        double SE_allEventCount = 0;
        double ST_eventHours = 0;
        double MT_avgTimeperEvent = 0;
        double NW_numberOfWeeks = 0;
        double EW_eventsPerWeeek = 0;
        double NW_numberofWeeks = 0;
        double MTPW_meanTimeUsagePerWeek = 0;
        double prediction_followingFourWeek = 0;
        public PredictionTimeView(UserModel user)
        {
            InitializeComponent();
            loggedInUser = user;
            setPredictionEventData();
        }

        private void setPredictionEventData()

        {
            DateTime today = DateTime.Now;
            string currentDateTime = today.ToString("yyyy-MM-dd HH:mm");

            


            PredictionModelManager predictionModelManager = new PredictionModelManager();

            List<EventModel> eventModelList = new List<EventModel>();

            eventModelList= predictionModelManager.getAllPastEvents(loggedInUser);

            if (eventModelList != null)
            {
                SE_allEventCount = eventModelList.Count();
                foreach (EventModel eventModel in eventModelList)
                {
                    DateTime start = eventModel.Event_begin_time;
                    DateTime end = eventModel.Event_end_time;

                    double minutesgap = end.Subtract(start).TotalMinutes;
                    Console.WriteLine(minutesgap);
                    ST_eventHours += minutesgap;
                }

                MT_avgTimeperEvent = ST_eventHours / SE_allEventCount;

                EventModel firstEvent = eventModelList.First();

                //get Weeks
                DateTime firstDate = firstEvent.Event_begin_time;
                DateTime lastDate = DateTime.Now;
                NW_numberofWeeks = (lastDate - firstDate).TotalDays / 7;


                EW_eventsPerWeeek = SE_allEventCount / NW_numberofWeeks;
                MTPW_meanTimeUsagePerWeek = MT_avgTimeperEvent * EW_eventsPerWeeek;
                prediction_followingFourWeek = MTPW_meanTimeUsagePerWeek * 4;



                this.lblNoOfPastEvent.Text = Convert.ToString(SE_allEventCount);


                this.lblAvgHoursPerEvent.Text = Convert.ToString(Convert.ToInt32(MT_avgTimeperEvent) / 60) + ":" + Convert.ToString(Convert.ToInt32(MT_avgTimeperEvent) % 60);

                this.lblAvgEventsPerWeek.Text = Convert.ToString(EW_eventsPerWeeek);
                this.lblMeanTimeperWeek.Text = Convert.ToString(Convert.ToInt32(MTPW_meanTimeUsagePerWeek) / 60) + ":" + Convert.ToString(Convert.ToInt32(MTPW_meanTimeUsagePerWeek) % 60);
                this.lblAvgTimePerMonth.Text = Convert.ToString(Convert.ToInt32(prediction_followingFourWeek) / 60) + ":" + Convert.ToString(Convert.ToInt32(prediction_followingFourWeek) % 60);


                //Console.WriteLine(ST_eventHours+ SE_allEventCount+" "+ MT_avgTimeperEvent+" "+totalWeeks);
            }
            else {

                MessageBox.Show("There are no past Events");
                DashboardView dashboardView = new DashboardView(loggedInUser);
                this.Hide();
                dashboardView.ShowDialog();
                this.Close();
            }

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void roundButton1_ClickAsync(object sender, EventArgs e)
        {
            Console.WriteLine("Start");
            var time = await Task.Run(() => this.predictionTimeGenarate());
            MessageBox.Show("Successfully Genarate File");
        }

        private int predictionTimeGenarate()
        {
            
            StreamWriter sw = new StreamWriter("PredictionReport.dat", false, Encoding.UTF8);     

            try
            {
                sw.WriteLine("Today is : " + DateTime.Now + "\n" + "Name :"+loggedInUser.Name+"\n\n");
                sw.WriteLine("--------------EVENT MANAGEMENT TIME PREDICTION RESULT-------------");

                sw.WriteLine("\n");
                sw.WriteLine("-------------------------------------------------------------------");
           
                sw.WriteLine("Number Of Past Events            |  "+ Convert.ToString(SE_allEventCount));
                sw.WriteLine("\n");
                sw.WriteLine("-------------------------------------------------------------------");
            
                sw.WriteLine("Average Hours per Event          |  " + Convert.ToString(Convert.ToInt32(MT_avgTimeperEvent) / 60) + ":" + Convert.ToString(Convert.ToInt32(MT_avgTimeperEvent) % 60)+"  Hours/event");
                sw.WriteLine("\n");
                sw.WriteLine("-------------------------------------------------------------------");
              
                sw.WriteLine("Average Events per Week          |  " + Convert.ToString(EW_eventsPerWeeek) + "  Events/Week");
                sw.WriteLine("\n");
                sw.WriteLine("-------------------------------------------------------------------");
             
                sw.WriteLine("Mean Time Usage Per Week         |  " + Convert.ToString(Convert.ToInt32(MTPW_meanTimeUsagePerWeek) / 60) + ":" + Convert.ToString(Convert.ToInt32(MTPW_meanTimeUsagePerWeek) % 60) + "  Hours/Week");
                sw.WriteLine("\n");
                sw.WriteLine("-------------------------------------------------------------------");
         
                sw.WriteLine("*******Average Hours per Month   |  " + Convert.ToString(Convert.ToInt32(prediction_followingFourWeek) / 60) + ":" + Convert.ToString(Convert.ToInt32(prediction_followingFourWeek) % 60) + "  Hours/Month********");
                sw.WriteLine("\n");
                sw.WriteLine("-------------------------------------------------------------------");

            }
            catch (Exception ex)
            {
                MessageBox.Show("File Write Error");
            }
            finally { sw.Close(); }
            return 1;
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
