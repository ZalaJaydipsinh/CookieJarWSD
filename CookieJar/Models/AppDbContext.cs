using Microsoft.EntityFrameworkCore;

namespace CookieJar.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        public DbSet<User> Users { get; set; }  
        public DbSet<Cookie> Cookies { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
