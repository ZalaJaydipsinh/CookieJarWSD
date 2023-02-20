using System.ComponentModel.DataAnnotations;

namespace CookieJar.Models
{
    public class Cookie_Tag
    {
       
        public int? TagId { get; set; }  
        public Tag? Tag { get; set; }


        public int? CookieId { get; set; }
        public Cookie? Cookie { get; set; }
    }
}
