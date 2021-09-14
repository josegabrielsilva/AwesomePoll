using System.Collections.Generic;

namespace AwesomePoll.Core.DTOs
{
    public class PollDTO
    {
        public string Description { get; set; }
        public virtual List<PollOptionDTO> Options { get; set; }
    }
}
