using System.ComponentModel.DataAnnotations;

namespace JP2.Models
{
    public class Employer
    {
        public int Id { set; get; }

        [Required]
        public string CompanyName { set; get; }

        [Required]
        public string CompanyDescription { set; get;}

        [Required]
        public string CompanyWebsite { set; get; }

        public List<Job>? Jobs { set; get; } //Navigation Property
    }
}
