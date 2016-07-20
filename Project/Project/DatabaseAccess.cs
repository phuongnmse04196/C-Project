using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Project
{
    class DatabaseAccess
    {
        SqlConnection myConnection;
        public void openConnection()
        {
            myConnection = new SqlConnection("user id=sa;" +
                                       "password=sa;server=localhost;" +
                                       "Trusted_Connection=yes;" +
                                       "database=HotelReservation; " +
                                       "connection timeout=30");
            try
            {
                myConnection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public bool login(String id, String password, bool authority)
        {
            SqlCommand myCommand = new SqlCommand("Select * from Login WHERE LoginId =  '" + id + "'", myConnection);
            SqlDataReader datareader = myCommand.ExecuteReader();
            if (datareader.HasRows)
            {
                datareader.Read();
                if (datareader["LoginPassword"].ToString().Equals(password))
                {
                    if ((bool)datareader["Roles"] == authority)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
