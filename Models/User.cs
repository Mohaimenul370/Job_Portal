using System.ComponentModel.DataAnnotations;

namespace JP2.Models
{
    public class User
    {
        public int Id { set; get; }

        [Required]
        public string UserName { set; get; }

        [Required]
        public string UserEmail { set; get; }

        [Required]
        public long UserPhoneNum { set; get; }

        [Required]
        public DateTime UserDoB { set; get; }

        public List<Job>? Jobs { get; set; } //Navigation Property

        public List<Application>? Applications { get; set; }
    }
}
