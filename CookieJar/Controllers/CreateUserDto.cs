using CookieJar.Models;

namespace CookieJar.Controllers
{
    public class CreateUserDto
    {

        public string Name { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

    }
}
