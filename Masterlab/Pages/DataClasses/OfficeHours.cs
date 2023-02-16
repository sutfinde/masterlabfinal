using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Masterlab.Pages.DataClasses
{
    public class OfficeHours
    {
        //OfficeHours attributes

        [Display(Name = "Office Hour selection")]
        public int OfficeHoursID { get; set; }
        public String? Date { get; set; }
        public String? StartTime { get; set; }
        public String? EndTime { get; set; }
        public string Purpose { get; set; }
        public int InstructorID { get; set; }

        public String? LastName { get; set; }


    }
}
