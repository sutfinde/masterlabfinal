using Masterlab.Pages.DataClasses;
using System.Data.SqlClient;

namespace Masterlab.Pages.DB
{
    public class DBClass
    {
        // Connection at Data Field Level
        public static SqlConnection Lab1Connection = new SqlConnection();
        // Connection String
        // www.connectionstrings.com
        public static readonly String? Lab1ConnString = "Server=Localhost;Database=Lab1;Trusted_Connection=True";


        // Connection Methods:
        public static SqlDataReader dataReader()
        {
            SqlCommand cmdUserRead = new SqlCommand();
            cmdUserRead.Connection = Lab1Connection;
            cmdUserRead.Connection.ConnectionString = Lab1ConnString;
            //query to get distinct instructor
            cmdUserRead.CommandText = "SELECT DISTINCT FirstName,Instructor.LastName FROM INSTRUCTOR INNER JOIN OFFICEHOURS ON INSTRUCTOR.INSTRUCTORID=OFFICEHOURS.INSTRUCTORID\r\n";
            cmdUserRead.Connection.Open();
            SqlDataReader tempReader = cmdUserRead.ExecuteReader();
            return tempReader;
        }
        public static SqlDataReader dataReader2()
        {
            SqlCommand cmdUserRead = new SqlCommand();
            cmdUserRead.Connection = Lab1Connection;
            cmdUserRead.Connection.ConnectionString = Lab1ConnString;
            //query to join officeHours table and instructor
            cmdUserRead.CommandText = "SELECT * FROM INSTRUCTOR INNER JOIN OFFICEHOURS ON INSTRUCTOR.INSTRUCTORID=OFFICEHOURS.INSTRUCTORID";
            cmdUserRead.Connection.Open();
            SqlDataReader tempReader = cmdUserRead.ExecuteReader();
            return tempReader;
        }
    }
}