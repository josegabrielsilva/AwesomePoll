using AwesomePoll.Core.Entity;
using AwesomePoll.Core.Interfaces.Repositories;
using System;
using System.Linq;

namespace AwesomePoll.Infrastructure.Persistency.Repositories
{
    public class PollVoteRepository : IPollVoteRepository
    {
        private readonly PollContext _context;
        public PollVoteRepository(PollContext context)
        {
            _context = context;
        }

        public PollVotes GetById(int id)
        {
            throw new NotImplementedException();
        }

        public PollVotes GetByPollId(int pollId)
        {
            return _context.PollVotes.First(x => x.Id == pollId);
        }

        public int Insert(PollVotes entity)
        {
            throw new NotImplementedException();
        }

        public int Update(PollVotes entity)
        {
            _context.Update(entity);
            return _context.SaveChanges();
        }
    }
}
