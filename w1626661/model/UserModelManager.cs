using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w1626661.model
{
    class UserModelManager
    {
        //register user with password encryption
        //also check user name alredy picked or not
        public Boolean registerUser(UserModel user) {

            DBconnection dBconnection = new DBconnection();
            dBconnection.sqlConnection.ConnectionString = dBconnection.dataString;

            Boolean alreadyHavingUser = false;

            string checkAlreadyUsername= "SELECT * FROM Users WHERE UserName = '" + user.UserName + "'";

            string register_user = "INSERT INTO Users (name, username, password) " +
                                     "Values (@data1, @data2, @data3)";

            try {
                dBconnection.sqlCommand.Connection = dBconnection.sqlConnection;


                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(checkAlreadyUsername, dBconnection.sqlConnection);


                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count>0)
                {
                    alreadyHavingUser = true;
                }
               
            }
            catch (Exception ex) {
                dBconnection.sqlConnection.Close();
            }

            if (alreadyHavingUser!=true)
            {
                try
                {
                    dBconnection.sqlConnection.Open();
                    dBconnection.sqlCommand.Connection = dBconnection.sqlConnection;
                    dBconnection.sqlCommand.CommandText = register_user;

                    dBconnection.sqlCommand.Parameters.AddWithValue("@data1", user.Name);
                    dBconnection.sqlCommand.Parameters.AddWithValue("@data2", user.UserName);
                    dBconnection.sqlCommand.Parameters.AddWithValue("@data3", user.Password);


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
            else {
                return false;
            }
            }

        //login user with password decription
        public Boolean loginUser(string username,string password) {

            DBconnection dBconnection = new DBconnection();
            dBconnection.sqlConnection.ConnectionString = dBconnection.dataString;
            dBconnection.sqlConnection.Open();

            

            string login_user = "SELECT * FROM Users WHERE UserName = '" + username + "'";



            dBconnection.sqlCommand.Connection = dBconnection.sqlConnection;
           
           
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(login_user, dBconnection.sqlConnection);
            

            DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                  dBconnection.sqlConnection.Close();

             foreach (DataRow row in dataTable.Rows)
                {
                    string loginpassword = PasswordEncryption.decryptPassword(row["password"].ToString());
                    if (loginpassword.Equals(password))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }


            return false;
           
        }

        public UserModel getUser(string username) {

            UserModel user = new UserModel();
            DBconnection dBconnection = new DBconnection();
            dBconnection.sqlConnection.ConnectionString = dBconnection.dataString;
            dBconnection.sqlConnection.Open();

            string login_user = "SELECT * FROM Users WHERE UserName = '" + username + "'";


            dBconnection.sqlCommand.Connection = dBconnection.sqlConnection;
           
           

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(login_user, dBconnection.sqlConnection);

           

            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            dBconnection.sqlConnection.Close();

                foreach (DataRow row in dataTable.Rows)
                {
                    user.Id= Convert.ToInt32(row["Id"]);
                    user.Name= row["name"].ToString();
                    user.UserName= row["username"].ToString();
                    user.Password = row["password"].ToString();

                }
            
            return user;
        }

    }
}
