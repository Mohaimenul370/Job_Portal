using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JP2.Models
{
    public class Application
    {
        public int Id { set; get; }

        [Required]
        public DateTime ApplicationDate { set; get; }

        // File to be uploaded
        public string JobTitle { set; get; }

        [Display(Name = "JobTitle")]
        public int JobId { get; set; }  //Foreign Key

        [Display(Name = "User Email")]
        public int UserId { get; set; } //Foreign Key

        public User? User { set; get; } //Navigatin property

        //[ForeignKey("JobTitle")]
        public Job? Job { set; get; }
    }
}
