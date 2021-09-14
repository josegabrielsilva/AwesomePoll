using AwesomePoll.Core.Entity.Base;
using System.Collections.Generic;

namespace AwesomePoll.Core.Entity
{
    public class Poll : BaseEntity
    {
        public string Description { get; set; }
        public virtual List<PollOption> Options { get; set; }
    }
}
