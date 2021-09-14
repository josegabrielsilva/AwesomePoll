using AwesomePoll.Core.Entity.Base;

namespace AwesomePoll.Core.Entity
{
    public class PollVotes : BaseEntity
    {
        public virtual Poll Poll { get; set; }
        public int Votes { get; set; }
    }
}
