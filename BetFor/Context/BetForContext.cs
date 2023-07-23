using BetFor.Entities;
using Microsoft.EntityFrameworkCore;

namespace BetFor.Context
{
    public class BetForContext : DbContext
    {
        public BetForContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Client> Client { get; set; }
        public DbSet<Tour> Tour { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}