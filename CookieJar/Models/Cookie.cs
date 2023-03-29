using System.Text.Json.Serialization;

namespace CookieJar.Models
{
    public class Cookie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; } = string.Empty;

        [JsonIgnore]
        public User User { get; set; }
        public int UserId { get; set; }
        
        public IList<Tag> Tags { get; set; }
    }
}
