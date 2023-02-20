using Microsoft.VisualBasic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CookieJar.Models
{
    public class Cookie
    {
        [Key]
        [Required]
        public int CookieId { get; set; }

        [Required]
        public int UserId { get; set; }
        public User? Users { get; set; }

        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Message { get; set; }

        [Required]
        public int IsPublic { get; set; }

        [Required]
        [Timestamp]
        public DateTime? Timestamp { get; set; }

        public IList<Cookie_Tag> Cookie_Tag { get; set; }
    }
}
