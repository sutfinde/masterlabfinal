using Masterlab.Pages.DataClasses;
using Masterlab.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Masterlab.Pages.SignUp
{
    public class StudentViewModel : PageModel
    {
        public List<Instructor> InstructorList { get; set; }
        public List<OfficeHours> OfficeHoursList { get; set; }

        public StudentViewModel()
        {
            InstructorList = new List<Instructor>();
            OfficeHoursList = new List<OfficeHours>();
        }




        public void OnGet()
        {
            SqlDataReader dataReader = DBClass.dataReader();

            while (dataReader.Read())
            {
                InstructorList.Add(new Instructor
                {
                    FirstName = dataReader["FirstName"].ToString(),
                    LastName = dataReader["LastName"].ToString(),
                });

            }
            DBClass.Lab1Connection.Close();

            SqlDataReader dataReader2 = DBClass.dataReader2();


            while (dataReader2.Read())
            {

                OfficeHoursList.Add(new OfficeHours
                {
                    LastName = dataReader2["LastName"].ToString(),
                    Date = dataReader2["Date"].ToString(),
                    StartTime = dataReader2["StartTime"].ToString(),
                    EndTime = dataReader2["EndTime"].ToString()

                });
            }
            DBClass.Lab1Connection.Close();



            //Close remote connection
            DBClass.Lab1Connection.Close();
        }

    }


}

