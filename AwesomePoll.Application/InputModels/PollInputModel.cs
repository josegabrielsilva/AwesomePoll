using AwesomePoll.Application.ViewModels;
using System.Collections.Generic;

namespace AwesomePoll.Application.InputModels
{
    public class PollInputModel
    {
        public string Description { get; set; }
        public List<PollOptionViewModel> Options { get; set; }
    }
}
