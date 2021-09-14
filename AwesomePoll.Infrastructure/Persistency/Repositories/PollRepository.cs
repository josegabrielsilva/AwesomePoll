using AwesomePoll.Core.Entity;
using AwesomePoll.Core.Interfaces.Repositories;
using System.Linq;

namespace AwesomePoll.Infrastructure.Persistency.Repositories
{
    public class PollRepository : IPollRepository
    {
        private readonly PollContext _context;
        public PollRepository(PollContext context)
        {
            _context = context;
        }
        public Poll GetById(int id)
        {
            Poll poll = _context
                .Polls
                .First(x => x.Id == id);

            return poll;
        }

        public int Insert(Poll entity)
        {
            _context.Polls.Add(entity);
            _context.PollOptions.AddRange(entity.Options);
            _context.SaveChanges();
            return entity.Id;
        }

        public int Update(Poll entity)
        {
            _context.Update(entity);
            return _context.SaveChanges();
        }
    }
}
