using Microsoft.EntityFrameworkCore;

namespace BountyApi.Models
{
    public class BountyContext : DbContext
    {
        public BountyContext(DbContextOptions<BountyContext> options)
            : base(options)
        {
        }

        public DbSet<Bounty> Bounties { get; set; }
    }
}
