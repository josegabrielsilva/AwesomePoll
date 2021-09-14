using AwesomePoll.Application.InputModels;
using AwesomePoll.Application.Services;
using AwesomePoll.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AwesomePoll.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollController : ControllerBase
    {
        private readonly IPollService _pollService;
        public PollController(IPollService pollSerivice)
        {
            _pollService = pollSerivice;
        }

        [HttpPost]
        public async Task<ActionResult> New(PollInputModel poll)
        {
            int id = 0;
            try
            {
                id = await _pollService.AddPoll(poll);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return CreatedAtAction(nameof(Get), new { id = id }, poll);
        }

        [HttpGet]
        [Route("id")]
        public async Task<ActionResult> Get(int id)
        {
            PollViewModel poll;
            try
            {
                if (id == 0)
                    return NotFound();

                var pollResponse = await _pollService.GetById(id);

                if (pollResponse == null)
                    return NotFound();

                var options = new List<PollOptionViewModel>();

                pollResponse.Options.ForEach(option => options.Add(new PollOptionViewModel()
                { 
                    Description = option.Description
                }));

                poll = new PollViewModel(pollResponse.Description, options);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(poll);
        }

        [HttpPost]
        [Route("{pollId}/vote")]
        public ActionResult Vote(int pollId)
        {
            try
            {
                bool voteRegistredWithSuccefully = _pollService.SaveVote(pollId);

                if (!voteRegistredWithSuccefully)
                    return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return NoContent();
        }
    }
}
