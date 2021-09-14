using System.Collections.Generic;

namespace AwesomePoll.Application.ViewModels
{
    public class PollViewModel
    {
        public PollViewModel(string description, List<PollOptionViewModel> options)
        {
            Description = description;
            Options = options;
        }
        public string Description { get; private set; }
        public List<PollOptionViewModel> Options { get; private set; }
    }
}
