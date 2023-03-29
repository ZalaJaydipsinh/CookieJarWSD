using System.Text.Json.Serialization;

namespace CookieJar.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public IList<Cookie> Cookies { get; set; }
    }
}
