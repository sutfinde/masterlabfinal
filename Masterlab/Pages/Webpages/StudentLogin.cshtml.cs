using Masterlab.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text;

namespace Masterlab.Pages.Webpages
{
    public class StudentLoginModel : PageModel
    {
        [BindProperty]
        public int StudentID { get; set; }
        [BindProperty]
        [Required]
        public string FirstName { get; set; }
        [BindProperty]
        [Required]
        public string LastName { get; set; }
        [BindProperty]
        [Required]
        public string Phone { get; set; }

        public void OnGet()
        {

        }
                public IActionResult OnPost()
        {
            {
                StringBuilder errorMessage = new StringBuilder();

                if (string.IsNullOrWhiteSpace(FirstName))
                    errorMessage.Append("First name is required. ");

                if (string.IsNullOrWhiteSpace(LastName))
                    errorMessage.Append("Last name is required. ");

                if (string.IsNullOrWhiteSpace(Phone))
                    errorMessage.Append("Phone Number is required. ");

                if (errorMessage.Length > 0)
                {
                    ModelState.AddModelError("", errorMessage.ToString());
                    return Page();
                }

                try
                {
                    using (SqlConnection connection = new SqlConnection(DBClass.Lab1ConnString))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand("INSERT INTO Student (FirstName, LastName, Phone) VALUES (@FirstName, @LastName, @Phone)", connection))
                        {
                            command.Parameters.AddWithValue("@FirstName", FirstName);
                            command.Parameters.AddWithValue("@LastName", LastName);
                            command.Parameters.AddWithValue("@Phone", Phone);
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (SqlException ex)
                {
                    TempData["ErrorMessage"] = "Error inserting data into database: " + ex.Message;
                    return Page();
                }

                return RedirectToPage("/Index");
            }
        }

        public IActionResult OnPostPopulateHandler()
        {
            ModelState.Clear();
            FirstName = "Jane";
            LastName = "Doe";
            Phone = "123-456-7890";
            return Page();
        }
    }

}
