using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w1626661.model
{
    class PredictionModelManager
    {
        //for the prediction get past events form current date time
        //with acending order
        internal List<EventModel> getAllPastEvents(UserModel loggedInUser)
        {
            List<EventModel> eventModelsList = new List<EventModel>();
            DBconnection dBconnection = new DBconnection();
            dBconnection.sqlConnection.ConnectionString = dBconnection.dataString;
            dBconnection.sqlConnection.Open();

            DateTime today = DateTime.Now;
            string currentDateTime = today.ToString("yyyy-MM-dd HH:mm");

            string get_all_event = "SELECT * FROM Event WHERE begin_time  < '" + currentDateTime + "' AND userId = '" + loggedInUser.Id + "' ORDER BY begin_time ASC";


            dBconnection.sqlCommand.Connection = dBconnection.sqlConnection;



            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(get_all_event, dBconnection.sqlConnection);



            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            dBconnection.sqlConnection.Close();
            try
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    EventModel eventTemp = new EventModel();

                    eventTemp.Event_id = Convert.ToInt32(row["Id"]);
                    eventTemp.Event_title = row["event_title"].ToString();
                    eventTemp.Event_description = row["event_description"].ToString();
                    eventTemp.Event_begin_time = Convert.ToDateTime(row["begin_time"]);
                    eventTemp.Event_end_time = Convert.ToDateTime(row["end_time"]);
                    eventTemp.Event_location = row["location"].ToString();
                    eventTemp.Event_variety = row["event_variety"].ToString();
                    eventTemp.Event_recuring_variety = Convert.ToInt32(row["recuring_variety"]);
                    eventTemp.UserId = Convert.ToInt32(row["userId"]);

                    eventModelsList.Add(eventTemp);

                }

                return eventModelsList;
            }
            catch (Exception err)
            {
                return eventModelsList = null;
            }
        }
    }
}
