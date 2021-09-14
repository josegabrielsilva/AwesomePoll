using AwesomePoll.Core.Entity;
using AwesomePoll.Core.Interfaces.Repositories.Base;

namespace AwesomePoll.Core.Interfaces.Repositories
{
    public interface IPollVoteRepository : IBaseRepository<PollVotes>
    {
        PollVotes GetByPollId(int pollId);
    }
}
