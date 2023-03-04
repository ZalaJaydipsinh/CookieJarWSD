using CookieJar.Models;

namespace CookieJar.Controllers
{
    public class CreateCookieDto
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public int UserId { get; set; }

    }
}
