using IPReport.Core.Entities;
using IPReport.Core.Entities.IPForensicsReports;
using Microsoft.EntityFrameworkCore;

namespace IPReport.EntityFramework.EntityFramework
{
    public sealed class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<IPForensicsReport> IPForensicsReports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
