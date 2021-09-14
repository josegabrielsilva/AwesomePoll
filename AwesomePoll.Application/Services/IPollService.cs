using AwesomePoll.Application.InputModels;
using AwesomePoll.Core.DTOs;
using System.Threading.Tasks;

namespace AwesomePoll.Application.Services
{
    public interface IPollService
    {
        Task<int> AddPoll(PollInputModel poll);
        Task<PollDTO> GetById(int id);
        bool SaveVote(int pollId);
    }
}
