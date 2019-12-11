using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w1626661.model
{
    class EventModelManager
    {
        //add event to the db
        public Boolean addevent(EventModel eventModel,List<ContactModel> contactsList,int recuringId)
        {

            DBconnection dBconnection = new DBconnection();
            dBconnection.sqlConnection.ConnectionString = dBconnection.dataString;
            dBconnection.sqlConnection.Open();

            string add_event = "INSERT INTO Event (event_title, event_description, begin_time,end_time,location,event_variety,recuring_variety,userId,recuring_id) " +
                                     "Values (@data1, @data2, @data3,@data4,@data5,@data6,@data7,@data8,@data9); SELECT SCOPE_IDENTITY()";

            string add_event_contact_selection= "INSERT INTO Event_Contact_selection (contactId, eventId) " +
                                     "Values (@data2_1, @data2_2)";

          

            try
            {
                dBconnection.sqlCommand.Parameters.Clear();

                dBconnection.sqlCommand.Connection = dBconnection.sqlConnection;
                dBconnection.sqlCommand.CommandText = add_event;

                dBconnection.sqlCommand.Parameters.AddWithValue("@data1", eventModel.Event_title);
                dBconnection.sqlCommand.Parameters.AddWithValue("@data2", eventModel.Event_description);
                dBconnection.sqlCommand.Parameters.AddWithValue("@data3", eventModel.Event_begin_time);
                dBconnection.sqlCommand.Parameters.AddWithValue("@data4", eventModel.Event_end_time);
                dBconnection.sqlCommand.Parameters.AddWithValue("@data5", eventModel.Event_location);
                dBconnection.sqlCommand.Parameters.AddWithValue("@data6", eventModel.Event_variety);
                dBconnection.sqlCommand.Parameters.AddWithValue("@data7", eventModel.Event_recuring_variety);
                dBconnection.sqlCommand.Parameters.AddWithValue("@data8", eventModel.UserId);
                dBconnection.sqlCommand.Parameters.AddWithValue("@data9", recuringId);


                //int rowsAdded = dBconnection.sqlCommand.ExecuteNonQuery();



                int eventId = Convert.ToInt32(dBconnection.sqlCommand.ExecuteScalar());

                dBconnection.sqlConnection.Close();


                Console.WriteLine("event id"+eventId);

                int rowsAdd_contact_selection = 0;

                if (contactsList!=null) {

                    dBconnection.sqlCommand.Connection = dBconnection.sqlConnection;
                    dBconnection.sqlConnection.Open();
                    foreach (ContactModel contact in contactsList) {
                        Console.WriteLine(contact.ContactId);


                        dBconnection.sqlCommand.Parameters.Clear();

                        dBconnection.sqlCommand.CommandText = add_event_contact_selection;
                        dBconnection.sqlCommand.Parameters.AddWithValue("@data2_1", contact.ContactId);
                        dBconnection.sqlCommand.Parameters.AddWithValue("@data2_2", eventId);
                        rowsAdd_contact_selection += dBconnection.sqlCommand.ExecuteNonQuery();


                    }
                    dBconnection.sqlConnection.Close();
                    Console.WriteLine("contacts rows" + rowsAdd_contact_selection);
                }

                if (eventId > 0 )
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        //get following week events from db
        //to show in dashboard 
        internal List<EventModel> getFollowingWeekEvents(int id)
        {
            List<EventModel> eventModelsList = new List<EventModel>();
            DBconnection dBconnection = new DBconnection();
            dBconnection.sqlConnection.ConnectionString = dBconnection.dataString;
            dBconnection.sqlConnection.Open();

            DateTime today = DateTime.Now;
            string currentDateTime = today.ToString("yyyy-MM-dd HH:mm");
            string upTosavenDayTime = today.AddDays(7).ToString("yyyy-MM-dd HH:mm");

            string get_all_event = "SELECT * FROM Event WHERE begin_time  < '" + upTosavenDayTime +"'AND begin_time >'"+ currentDateTime+"' AND userId = '" + id + "' ORDER BY begin_time ASC";


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


        //to get currently last id in db and if user add recuring event corresponding recuring events save with first id that create with recur id
        //to identify recuring events
        public int getEventLatestId()
        {
            int eventId = 0;
            DBconnection dBconnection = new DBconnection();
            dBconnection.sqlConnection.ConnectionString = dBconnection.dataString;
            dBconnection.sqlConnection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT top 1 * FROM Event order by Id Desc", dBconnection.sqlConnection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);


            foreach (DataRow row in dt.Rows)
            {
                eventId = Convert.ToInt32(row["Id"]);

            }

            dBconnection.sqlConnection.Close();
            return eventId;


        }

        //get  all events from db

        internal List<EventModel> getAllEvents(int userId)
        {
            List<EventModel> eventModelsList = new List<EventModel>();
            DBconnection dBconnection = new DBconnection();
            dBconnection.sqlConnection.ConnectionString = dBconnection.dataString;
            dBconnection.sqlConnection.Open();

            DateTime today = DateTime.Now;
            string currentDateTime = today.ToString("yyyy-MM-dd HH:mm");

            string get_all_event = "SELECT * FROM Event WHERE userId = '" + userId + "' AND begin_time > '" + currentDateTime + "'ORDER BY begin_time ASC";


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

                    eventTemp.Event_id   = Convert.ToInt32(row["Id"]);
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

        internal List<EventModel> getAllPastEvents(int userId)
        {
            List<EventModel> eventModelsList = new List<EventModel>();
            DBconnection dBconnection = new DBconnection();
            dBconnection.sqlConnection.ConnectionString = dBconnection.dataString;
            dBconnection.sqlConnection.Open();

            DateTime today = DateTime.Now;
            string currentDateTime = today.ToString("yyyy-MM-dd HH:mm");

            string get_all_event = "SELECT * FROM Event WHERE userId = '" + userId + "' AND begin_time < '" + currentDateTime + "'ORDER BY begin_time ASC";


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

        //update event
        internal bool updateEvent(EventModel eventModel,EventModel previousEvent, List<ContactModel> pickedContactsList)
        {
            DBconnection dBconnection = new DBconnection();
            dBconnection.sqlConnection.ConnectionString = dBconnection.dataString;
            dBconnection.sqlConnection.Open();

            string add_event = "UPDATE Event SET event_title = @data1, event_description=@data2, begin_time=@data3,end_time=@data4,location=@data5,event_variety=@data6,recuring_variety=@data7,userId=@data8 Where id = @eventId; SELECT SCOPE_IDENTITY()";
            string add_event_contact_selection = "INSERT INTO Event_Contact_selection (contactId, eventId) " +
                                    "Values (@data2_1, @data2_2)";
            //"UPDATE Contact SET name = @data1, mobileNo = @data2, email= @data3 Where id = @contactId"
            try
            {
                dBconnection.sqlCommand.Connection = dBconnection.sqlConnection;
                dBconnection.sqlCommand.CommandText = add_event;

                dBconnection.sqlCommand.Parameters.AddWithValue("@data1", eventModel.Event_title);
                dBconnection.sqlCommand.Parameters.AddWithValue("@data2", eventModel.Event_description);
                dBconnection.sqlCommand.Parameters.AddWithValue("@data3", eventModel.Event_begin_time);
                dBconnection.sqlCommand.Parameters.AddWithValue("@data4", eventModel.Event_end_time);
                dBconnection.sqlCommand.Parameters.AddWithValue("@data5", eventModel.Event_location);
                dBconnection.sqlCommand.Parameters.AddWithValue("@data6", eventModel.Event_variety);
                dBconnection.sqlCommand.Parameters.AddWithValue("@data7", previousEvent.Event_recuring_variety);
                dBconnection.sqlCommand.Parameters.AddWithValue("@data8", previousEvent.UserId);
                dBconnection.sqlCommand.Parameters.AddWithValue("@eventId", eventModel.Event_id);



                //int rowsAdded = dBconnection.sqlCommand.ExecuteNonQuery();

                int rowsUpdated = dBconnection.sqlCommand.ExecuteNonQuery();

                //int eventId = Convert.ToInt32(dBconnection.sqlCommand.ExecuteScalar());

                dBconnection.sqlConnection.Close();


                // Console.WriteLine("event id" + eventId);
                int rowsAdd_contact_selection = 0;
                if (pickedContactsList!=null) {
                    dBconnection.sqlCommand.Connection = dBconnection.sqlConnection;
                    dBconnection.sqlConnection.Open();
                    foreach (ContactModel contact in pickedContactsList)
                    {
                        Console.WriteLine(contact.ContactId);


                        dBconnection.sqlCommand.Parameters.Clear();

                        dBconnection.sqlCommand.CommandText = add_event_contact_selection;
                        dBconnection.sqlCommand.Parameters.AddWithValue("@data2_1", contact.ContactId);
                        dBconnection.sqlCommand.Parameters.AddWithValue("@data2_2", eventModel.Event_id);
                        rowsAdd_contact_selection += dBconnection.sqlCommand.ExecuteNonQuery();


                    }
                    dBconnection.sqlConnection.Close();
                }
                Console.WriteLine("contacts rows" + rowsAdd_contact_selection);



                if (rowsUpdated > 0 )
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }


        //delete event
        internal bool deleteEvent(string event_id, int userId)
        {
            DBconnection dBconnection = new DBconnection();
            dBconnection.sqlConnection.ConnectionString = dBconnection.dataString;
            dBconnection.sqlConnection.Open();

            string delete_Event = " DELETE from Event  Where id = @eventIdEvent";
            string check_contact_inuse = "SELECT * FROM Event_contact_selection WHERE eventId = '" + event_id + "'";
            string delete_Contact_inuse = " DELETE from Event_contact_selection  WHERE contactId = @contactId AND eventId=@eventId";
            //check contact inuse

            dBconnection.sqlCommand.Connection = dBconnection.sqlConnection;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(check_contact_inuse, dBconnection.sqlConnection);

            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            dBconnection.sqlConnection.Close();


            

            if (dataTable.Rows.Count > 0)
            
            {
                dBconnection.sqlConnection.Open();
                dBconnection.sqlCommand.Connection = dBconnection.sqlConnection;
                foreach (DataRow row in dataTable.Rows) {
                    dBconnection.sqlCommand.Parameters.Clear();

                    dBconnection.sqlCommand.CommandText = delete_Contact_inuse;
                    dBconnection.sqlCommand.Parameters.AddWithValue("@contactId", Convert.ToInt32(row["contactId"]));
                    dBconnection.sqlCommand.Parameters.AddWithValue("@eventId", Convert.ToInt32(row["eventId"]));
                    int rowsEffect = dBconnection.sqlCommand.ExecuteNonQuery();
                   

                }
                dBconnection.sqlConnection.Close();
            }
            

                try
                {
                    dBconnection.sqlConnection.Open();

                    dBconnection.sqlCommand.Connection = dBconnection.sqlConnection;
                    dBconnection.sqlCommand.CommandText = delete_Event;
                    dBconnection.sqlCommand.Parameters.AddWithValue("@eventIdEvent", event_id);


                    int rowsEffect = dBconnection.sqlCommand.ExecuteNonQuery();

                    dBconnection.sqlConnection.Close();

                    if (rowsEffect > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }
            



        }

        internal List<EventModel> getFollowingMonthEvents(int id)
        {
            List<EventModel> eventModelsList = new List<EventModel>();
            DBconnection dBconnection = new DBconnection();
            dBconnection.sqlConnection.ConnectionString = dBconnection.dataString;
            dBconnection.sqlConnection.Open();

            DateTime today = DateTime.Now;
            string currentDateTime = today.ToString("yyyy-MM-dd HH:mm");
            string upTosavenDayTime = today.AddDays(30).ToString("yyyy-MM-dd HH:mm");

            string get_all_event = "SELECT * FROM Event WHERE begin_time  < '" + upTosavenDayTime + "'AND begin_time >'" + currentDateTime + "' AND userId = '" + id + "' ORDER BY begin_time ASC";


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
