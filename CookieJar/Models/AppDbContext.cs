using Microsoft.EntityFrameworkCore;

namespace CookieJar.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cookie_Tag>().HasKey(sc => new { sc.CookieId, sc.TagId });
        }
        public DbSet<User> Users { get; set; }  
        public DbSet<Cookie> Cookies { get; set; }
        public DbSet<Cookie_Tag> Cookies_Tag { get; set;}
        public DbSet<Tag> Tags { get; set; }
    }
}
