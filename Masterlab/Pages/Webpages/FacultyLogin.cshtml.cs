using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Masterlab.Pages.Webpages
{
    public class FacultyLoginModel : PageModel
    {
       
        [BindProperty]
        public int InstructorID { get; set; }
        [BindProperty]
        public string? FirstName { get; set; }
        [BindProperty]
        public string? LastName { get; set; }
        [BindProperty]
        public string? EmailAddress { get; set; }

        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
                        return Page();
        }

        public IActionResult OnPostPopulateToHandler()
        {
            if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName) || string.IsNullOrWhiteSpace(EmailAddress))
            {
                TempData["ErrorMessage"] = "All fields are required and cannot be empty.";
                return Page();
            }

            // Connect to database
            using (SqlConnection connection = new SqlConnection(Masterlab.Pages.DB.DBClass.Lab1ConnString))
            {
                connection.Open();

                // Insert data into Instructor table
                using (SqlCommand command = new SqlCommand("INSERT INTO Instructor (FirstName, LastName," +
                    " EmailAddress) VALUES (@FirstName, @LastName, @EmailAddress)", connection))
                {
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@EmailAddress", EmailAddress);


                    command.ExecuteNonQuery();
                }
            }

            return RedirectToPage("/Index");
        }


        public IActionResult OnPostPopulateHandler()
        {
            ModelState.Clear();
            FirstName = "John";
            LastName = "Doe";
            EmailAddress = "jdoe@gmail.com";
            return Page();
        }

    }

}
