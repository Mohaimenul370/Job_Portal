using System.ComponentModel.DataAnnotations;

namespace JP2.Models
{
    public class Job
    {
        public int Id{ set; get; }

        [Required]
        public string JobTitle { set; get; }

        [Required]
        public string JobDescription { set; get; }

        [Required]
        public double Salary { set; get; }

        [Required]
        public string JobLocation { set; get; }

        [Required]
        public DateTime PostDate { set; get; }

        [Required]
        [Display(Name="CompanyName")]
        public int EmployerId { set; get; }

        public User? User { set; get; }  //Navigation Property

        public Employer? Employer { set; get; }

        public Catagory? Catagory { set; get; }

        public Application? Application { set; get; }


    }
}
