using Masterlab.Pages.DataClasses;
using Masterlab.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Masterlab.Pages.Webpages
{
    public class StudentIndexModel : PageModel
    {
        public List<Student> StudentList { get; set; }

        // Constructor
        public StudentIndexModel()
        {
            StudentList = new List<Student>();
        }

        public void OnGet()
        {
            SqlDataReader dataReader = DBClass.dataReader();

            while (dataReader.Read())
            {
                StudentList.Add(new Student
                {
                    StudentID = Int32.Parse(dataReader["StudentID"].ToString()),
                    FirstName = dataReader["FirstName"].ToString(),
                    LastName = dataReader["LastName"].ToString(),
                    Phone = dataReader["Phone"].ToString()
                });
            }

            // Close our remote connection
            DBClass.Lab1Connection.Close();
        }
    }
}
