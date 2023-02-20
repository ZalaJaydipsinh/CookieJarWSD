using System.ComponentModel.DataAnnotations;

namespace CookieJar.Models
{
    public class Tag
    {

        [Key]
        [Required]
        public int TagId { get; set; }

        [Required]
        public int UserId { get; set; }
        public User? Users { get; set; }

        [Required]
        public string? Name { get; set; }

        public IList<Cookie_Tag> Cookie_Tag { get; set; }
    }
}
