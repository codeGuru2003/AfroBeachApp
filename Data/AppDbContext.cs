using AfroBeachApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AfroBeachApp.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=afrobeach.db");
            base.OnConfiguring(optionsBuilder);
        }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
            

        //    base.OnModelCreating(builder);
        //}
        public DbSet<SystemInfo> SystemInfos { get; set; }
        public DbSet<SocialGallery> SocialGalleries { get; set; }
    }
}
