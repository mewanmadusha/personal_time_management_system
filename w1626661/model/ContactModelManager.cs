using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w1626661.model
{
    class ContactModelManager
    {
        public Boolean addContact(ContactModel contact)
        {

            DBconnection dBconnection = new DBconnection();
            dBconnection.sqlConnection.ConnectionString = dBconnection.dataString;
            dBconnection.sqlConnection.Open();

            string register_user = "INSERT INTO Contact (name, mobileNo, email,userId) " +
                                     "Values (@data1, @data2, @data3,@data4)";



            try
            {
                dBconnection.sqlCommand.Connection = dBconnection.sqlConnection;
                dBconnection.sqlCommand.CommandText = register_user;

                dBconnection.sqlCommand.Parameters.AddWithValue("@data1", contact.ContactName);
                dBconnection.sqlCommand.Parameters.AddWithValue("@data2", contact.MobileNo);
                dBconnection.sqlCommand.Parameters.AddWithValue("@data3", contact.Email);
                dBconnection.sqlCommand.Parameters.AddWithValue("@data4", contact.UserId);


                int rowsAdded = dBconnection.sqlCommand.ExecuteNonQuery();

                dBconnection.sqlConnection.Close();

                if (rowsAdded > 0)
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

        internal List<ContactModel> getCheckedContacts(int event_id)
        {
            List<ContactModel> contactData = new List<ContactModel>();
            DBconnection dBconnection = new DBconnection();
            dBconnection.sqlConnection.ConnectionString = dBconnection.dataString;
            dBconnection.sqlConnection.Open();

            //string delete_Event = " DELETE from Event  Where id = @eventIdEvent";
            string check_contact_inuse = "SELECT * FROM Event_contact_selection WHERE eventId = '" + event_id + "'";
            string get_Contact_inuse = " SELECT * from Contact  WHERE Id = @contactId";
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
                foreach (DataRow row in dataTable.Rows)
                {
                    Console.WriteLine(Convert.ToInt32(row["contactId"]));


                    //dBconnection.sqlCommand.Parameters.AddWithValue("@contactId", Convert.ToInt32(row["contactId"]));
                    //dBconnection.sqlCommand.Parameters.AddWithValue("@eventId", Convert.ToInt32(row["eventId"]));
                    SqlDataAdapter sqlAdap = new SqlDataAdapter("SELECT * FROM Contact WHERE Id = '" + Convert.ToInt32(row["contactId"]) + "'", dBconnection.sqlConnection);

                    DataTable dataTable1 = new DataTable();
                    sqlAdap.Fill(dataTable1);
                    foreach (DataRow rowdata in dataTable1.Rows)
                    {

                        ContactModel contact = new ContactModel();

                        contact.ContactId = Convert.ToInt32(rowdata["Id"]);
                        contact.ContactName = rowdata["name"].ToString();
                        contact.Email = rowdata["email"].ToString();
                        contact.MobileNo = rowdata["mobileNO"].ToString();
                        contact.UserId = Convert.ToInt32(rowdata["userId"]);

                      

                        contactData.Add(contact);
                    }

                }
                dBconnection.sqlConnection.Close();
            }


            return contactData;
        }

        internal List<string> getContactListwithNumber(int event_id)
        {
            List<string> contactData = new List<string>();
            DBconnection dBconnection = new DBconnection();
            dBconnection.sqlConnection.ConnectionString = dBconnection.dataString;
            dBconnection.sqlConnection.Open();

            //string delete_Event = " DELETE from Event  Where id = @eventIdEvent";
            string check_contact_inuse = "SELECT * FROM Event_contact_selection WHERE eventId = '" + event_id + "'";
            string get_Contact_inuse = " SELECT * from Contact  WHERE Id = @contactId";
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
                foreach (DataRow row in dataTable.Rows)
                {
                    Console.WriteLine(Convert.ToInt32(row["contactId"]));

                    
                    //dBconnection.sqlCommand.Parameters.AddWithValue("@contactId", Convert.ToInt32(row["contactId"]));
                    //dBconnection.sqlCommand.Parameters.AddWithValue("@eventId", Convert.ToInt32(row["eventId"]));
                    SqlDataAdapter sqlAdap = new SqlDataAdapter("SELECT * FROM Contact WHERE Id = '" + Convert.ToInt32(row["contactId"]) + "'", dBconnection.sqlConnection);

                    DataTable dataTable1 = new DataTable();
                    sqlAdap.Fill(dataTable1);
                    foreach (DataRow rowdata in dataTable1.Rows) {
                        
                        
                        String contact = rowdata["name"].ToString() + "->" + rowdata["mobileNo"].ToString();
                        contactData.Add(contact);
                    }

                }
                dBconnection.sqlConnection.Close();
            }


            return contactData;
          
        }

        public List<ContactModel> getAllContacts(int userId)
        {

            List<ContactModel> contactModelsList = new List<ContactModel>();
            DBconnection dBconnection = new DBconnection();
            dBconnection.sqlConnection.ConnectionString = dBconnection.dataString;
            dBconnection.sqlConnection.Open();

            string login_user = "SELECT * FROM Contact WHERE userId = '" + userId + "'";


            dBconnection.sqlCommand.Connection = dBconnection.sqlConnection;



            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(login_user, dBconnection.sqlConnection);



            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            dBconnection.sqlConnection.Close();
            try
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    ContactModel contact = new ContactModel();

                    contact.ContactId = Convert.ToInt32(row["Id"]);
                    contact.ContactName = row["name"].ToString();
                    contact.Email = row["email"].ToString();
                    contact.MobileNo = row["mobileNO"].ToString();
                    contact.UserId = Convert.ToInt32(row["userId"]);

                    contactModelsList.Add(contact);

                }

                return contactModelsList;
            }
            catch (Exception err) {
                return contactModelsList = null;
            }
        }

        internal bool updateContact(ContactModel contact)
        {
            DBconnection dBconnection = new DBconnection();
            dBconnection.sqlConnection.ConnectionString = dBconnection.dataString;
            dBconnection.sqlConnection.Open();

            string update_user = "UPDATE Contact SET name = @data1, mobileNo = @data2, email= @data3 Where id = @contactId";




            try
            {
                dBconnection.sqlCommand.Connection = dBconnection.sqlConnection;
                dBconnection.sqlCommand.CommandText = update_user;

                dBconnection.sqlCommand.Parameters.AddWithValue("@data1", contact.ContactName);
                dBconnection.sqlCommand.Parameters.AddWithValue("@data2", contact.MobileNo);
                dBconnection.sqlCommand.Parameters.AddWithValue("@data3", contact.Email);
                dBconnection.sqlCommand.Parameters.AddWithValue("@contactId", contact.ContactId);


                int rowsAdded = dBconnection.sqlCommand.ExecuteNonQuery();

                dBconnection.sqlConnection.Close();

                if (rowsAdded > 0)
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

        internal bool deleteContact(ContactModel contact)
        {
            DBconnection dBconnection = new DBconnection();
            dBconnection.sqlConnection.ConnectionString = dBconnection.dataString;
            dBconnection.sqlConnection.Open();

            string delete_Contact = " DELETE from Contact  Where id = @contactId";
            string check_contact_inuse = "SELECT * FROM Event_contact_selection WHERE contactId = '" + contact.ContactId + "'";

            //check contact inuse

            dBconnection.sqlCommand.Connection = dBconnection.sqlConnection;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(check_contact_inuse, dBconnection.sqlConnection);

            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            dBconnection.sqlConnection.Close();

            if (dataTable.Rows.Count > 0)
            {

                return false;
            }
            else {

                try
                {
                    dBconnection.sqlConnection.Open();

                    dBconnection.sqlCommand.Connection = dBconnection.sqlConnection;
                    dBconnection.sqlCommand.CommandText = delete_Contact;
                    dBconnection.sqlCommand.Parameters.AddWithValue("@contactId", contact.ContactId);


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


           
        }

        internal bool deleteByEventContact(int event_id)
        {

            DBconnection dBconnection = new DBconnection();
            dBconnection.sqlConnection.ConnectionString = dBconnection.dataString;
            dBconnection.sqlConnection.Open();

            string delete_Contact = " DELETE from Event_contact_selection  Where contactId = @contactId";
            string check_contact_inuse = "SELECT * FROM Event_contact_selection WHERE eventId = '" + event_id + "'";

            //check contact inuse

            dBconnection.sqlCommand.Connection = dBconnection.sqlConnection;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(check_contact_inuse, dBconnection.sqlConnection);

            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            dBconnection.sqlConnection.Close();

            try
            {
                dBconnection.sqlConnection.Open();
                foreach (DataRow row in dataTable.Rows)
                {

                    dBconnection.sqlCommand.Parameters.Clear();
                    dBconnection.sqlCommand.Connection = dBconnection.sqlConnection;
                    dBconnection.sqlCommand.CommandText = delete_Contact;
                    dBconnection.sqlCommand.Parameters.AddWithValue("@contactId", Convert.ToInt32(row["contactId"]));


                    int rowsEffect = dBconnection.sqlCommand.ExecuteNonQuery();




                }
                dBconnection.sqlConnection.Close();

                return true;
            }
            catch (Exception err) {
                Console.Write(err);
                return false;
            }
          






        }
    
    }
}
