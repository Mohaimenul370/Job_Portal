using System.ComponentModel.DataAnnotations;

namespace JP2.Models
{
    public class Catagory
    {
        public int Id { get; set; }

        [Required]
        public string CatagoryName { get; set; }

        public List<Job>? Jobs { get; set; } //Navigation Property

    }
}
