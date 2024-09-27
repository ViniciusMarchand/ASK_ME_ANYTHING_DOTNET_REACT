using backend.DTO;
using backend.Models;
using backend.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/answer")]
    public class AnswerController (AnswerRepository repository) : ControllerBase
    {   
        private readonly AnswerRepository _repository = repository;

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Answer>>> GetAll()
        {
            var answers = await _repository.GetAll();
            return Ok(answers);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Answer>> Save(AnswerDTO answer)
        {
            var newAnswer = await _repository.Save(answer);
            return Ok(newAnswer);
        }
    }

}
