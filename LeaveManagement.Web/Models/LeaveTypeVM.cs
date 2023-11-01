using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Web.Models
{
    public class LeaveTypeVM
    {
        public int Id { get; set; }

        [Display(Name = "Leave Type Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Default Number Of Days")]
        [Required]
        [Range(typeof(int), "1", "25", ErrorMessage = "The value must be between 1 and 25")]
        public int DefaultDays { get; set; }
    }
}
