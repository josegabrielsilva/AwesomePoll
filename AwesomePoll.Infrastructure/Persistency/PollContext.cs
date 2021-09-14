using AwesomePoll.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace AwesomePoll.Infrastructure.Persistency
{
    public class PollContext : DbContext
    {
        public PollContext(DbContextOptions<PollContext> options) : base(options) { }

        public DbSet<Poll> Polls { get;set; }
        public DbSet<PollOption> PollOptions { get; set; }
        public DbSet<PollVotes> PollVotes{ get; set; }
    }
}
