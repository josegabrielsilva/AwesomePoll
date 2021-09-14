using AutoMapper;
using AwesomePoll.Application.ViewModels;
using AwesomePoll.Core.DTOs;
using AwesomePoll.Core.Entity;

namespace AwesomePoll.Application
{
    public class ProfileMapping : Profile
    {
        public ProfileMapping()
        {
            CreateMap<Poll, PollDTO>()
               .ReverseMap();

            CreateMap<PollDTO, PollViewModel>()
                .ReverseMap();

            CreateMap<PollOption, PollOptionDTO>()
                .ReverseMap();

            CreateMap<PollOptionDTO, PollOptionViewModel>()
                .ReverseMap();

            CreateMap<PollVotes, PollVotesDTO>()
                .ReverseMap();
            CreateMap<PollVotesDTO, PollVotesViewModel>()
                .ReverseMap();
        }
    }
}
