using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Masterlab.Pages.Faculty
{
    public class SchedulingModel : PageModel
    {
        [BindProperty] public int OfficeHoursID { get; set; }
        [BindProperty] public DateTime Date { get; set; }
        [BindProperty] public DateTime StartTime { get; set; }
        [BindProperty] public DateTime EndTime { get; set; }
        [BindProperty] public String? Purpose { get; set; }

        [BindProperty] public int InstructorID { get; set; }

        public String? DateTimeMessage { get; set; }

        public void OnPostDateAndTime()
        {
            // Form processing logic here
            DateTimeMessage = "The Date for office hours will be: " + Date.ToString("MM/dd/yy");
            DateTimeMessage += ", The Begin Time: " + StartTime.ToString("hh:mm tt");
            DateTimeMessage += ", The End Time: " + EndTime.ToString("hh:mm tt");
            // Connect to database
            using (SqlConnection connection = new SqlConnection(Masterlab.Pages.DB.DBClass.Lab1ConnString))
            {
                connection.Open();

                // Insert data into Instructor table
                using (SqlCommand command = new SqlCommand("INSERT INTO OfficeHours (OfficeHoursID, Date, StartTime, EndTime, Purpose, InstructorID) VALUES (@OfficeHoursID, @Date, @StartTime, @EndTime, @Purpose, @InstructorID)", connection))
                {
                    command.Parameters.AddWithValue("@OfficeHoursID", OfficeHoursID);
                    command.Parameters.AddWithValue("@Date", Date);
                    command.Parameters.AddWithValue("@StartTime", StartTime);
                    command.Parameters.AddWithValue("@EndTime", EndTime);
                    command.Parameters.AddWithValue("@Purpose", Purpose);
                    command.Parameters.AddWithValue("@InstructorID", InstructorID);


                    command.ExecuteNonQuery();
                }
            }
        }


    }
}