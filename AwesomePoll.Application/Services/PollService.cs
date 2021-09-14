using AutoMapper;
using AwesomePoll.Application.InputModels;
using AwesomePoll.Core.DTOs;
using AwesomePoll.Core.Entity;
using AwesomePoll.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AwesomePoll.Application.Services
{
    public class PollService : IPollService
    {
        private readonly IMapper _mapper;
        private readonly IPollRepository _pollRepository;
        private readonly IPollVoteRepository _pollVoteRepository;

        public PollService(IPollRepository pollRepository, IPollVoteRepository pollVoteRepository,
            IMapper mapper)
        {
            _pollRepository = pollRepository;
            _pollVoteRepository = pollVoteRepository;
            _mapper = mapper;
        }

        public Task<int> AddPoll(PollInputModel poll)
        {
            var options = new List<PollOption>();

            poll.Options.ForEach(option => options.Add(new PollOption() 
            { 
                Description = option.Description
            }));

            var pollEnity = new Poll()
            {
                Description = poll.Description,
                Options = options,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            int id = _pollRepository.Insert(pollEnity);

            return Task.FromResult(id);
        }

        public Task<PollDTO> GetById(int id)
        {
            var response = _pollRepository.GetById(id);
            return Task.FromResult(response == null ? null : _mapper.Map<PollDTO>(response));
        }

        public bool SaveVote(int pollId)
        {
            var pollVote= _pollVoteRepository.GetByPollId(pollId);
            pollVote.Votes++;
            pollVote.UpdatedAt = DateTime.Now;
            int response = _pollVoteRepository.Update(pollVote);
            return response > 0;
        }
    }
}
