using BetFor.Entities;
using Microsoft.EntityFrameworkCore;

namespace BetFor.Context
{
    public class BetForContext : DbContext
    {
        public BetForContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Configuration> Configuration { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Tour> Tour { get; set; }
        public DbSet<ClientTour> ClientTour { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetCommonProperties();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void SetCommonProperties()
        {
            var entries = ChangeTracker.Entries().Where(e => e.Entity is BetForBase && e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in entries)
            {
                var entity = (BetForBase)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    entity.EntryTime = System.DateTime.Now;
                }
            }
        }
    }
}