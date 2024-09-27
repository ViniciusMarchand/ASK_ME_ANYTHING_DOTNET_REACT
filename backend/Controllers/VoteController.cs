using backend.DTO;
using backend.Models;
using backend.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers 
{   
    [ApiController]
    [Route("api/vote")]
    public class VoteController(VoteRepository repository) : ControllerBase
    {
        private readonly VoteRepository _repository = repository;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vote>>> GetAll()
        {
            var votes = await _repository.GetAll();
            return Ok(votes);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Vote>> Save(VoteDTO vote)
        {
            var newVote = await _repository.Save(vote);
            return Ok(newVote);
        }
    }
}