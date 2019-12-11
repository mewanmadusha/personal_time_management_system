using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w1626661
{
    class DBconnection
    {
        public SqlConnection sqlConnection = new SqlConnection();
        public SqlCommand sqlCommand = new SqlCommand();
        //public string dataString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\madus\OneDrive\Desktop\CW_DEPLOY\w1626661\w1626661\EAD_w1626661.mdf';Integrated Security=True";

        public string dataString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\madus\source\repos\w1626661\w1626661\EAD_w1626661.mdf';Integrated Security=True";

    }
}
    