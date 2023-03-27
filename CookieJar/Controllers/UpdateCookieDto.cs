using CookieJar.Models;

namespace CookieJar.Controllers
{
    public class UpdateCookieDto
    {

        public int Id { get; set; } 
        public string Title { get; set; }
        public string Message { get; set; }
        public int UserId { get; set; }

    }
}
