using AfroBeachApp.Interfaces;
using AfroBeachApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AfroBeachApp.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly ICurrentUserRepository _currentUser;
        public AppDbContext(DbContextOptions options, ICurrentUserRepository currentUser) : base(options)
        {
            _currentUser = currentUser;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=afrobeach.db");
            base.OnConfiguring(optionsBuilder);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ProcessSave();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void ProcessSave()
        {
            DateTime CurrentTime = DateTime.Now;
            foreach (var item in ChangeTracker.Entries().Where(e => e.State == EntityState.Added && e.Entity is AuditTrail))
            {
                var entity = item.Entity as AuditTrail;
                entity.CreatedOn = CurrentTime;
                entity.ModifiedOn = CurrentTime;
                entity.CreatedBy = _currentUser.GetCurrentUser();
                entity.ModifiedBy = _currentUser.GetCurrentUser();
            }
            foreach (var item in ChangeTracker.Entries()
               .Where(e => e.State == EntityState.Modified && e.Entity is AuditTrail))
            {
                var entity = item.Entity as AuditTrail;
                entity.ModifiedOn = CurrentTime;
                entity.ModifiedBy = _currentUser.GetCurrentUser();
                item.Property(nameof(entity.CreatedBy)).IsModified = false;
                item.Property(nameof(entity.CreatedOn)).IsModified = false;
            }
            foreach (var item in ChangeTracker.Entries().Where(e=>e.State == EntityState.Deleted && e.Entity is AuditTrail))
            {
                var entity = item.Entity as AuditTrail;
                entity.DeletedOn = CurrentTime;
                entity.DeletedBy = _currentUser.GetCurrentUser();
                item.Property(nameof(entity.CreatedBy)).IsModified = false;
                item.Property(nameof(entity.CreatedOn)).IsModified = false;
                item.Property(nameof(entity.ModifiedBy)).IsModified = false;
                item.Property(nameof(entity.ModifiedOn)).IsModified = false;
            }
        }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //}

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<SystemInfo> SystemInfos { get; set; }
        public DbSet<SocialGallery> SocialGalleries { get; set; }
        
    }
}
