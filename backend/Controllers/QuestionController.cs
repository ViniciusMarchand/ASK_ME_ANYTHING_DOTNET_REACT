using Microsoft.AspNetCore.Mvc;
using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Authorization;
using backend.DTO;
using backend.Repositories;

namespace backend.Controllers
{
    [Route("api/question")]
    [ApiController]
    public class QuestionController(ApplicationDbContext context, QuestionReposipository repository) : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;
        
        private readonly QuestionReposipository _repository = repository;

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestions()
        {
            var questions = await _repository.GetQuestions();
            return Ok(questions);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Question>> PostQuestion(QuestionDTO question)
        {
            var newQuestion = await _repository.Save(question);

            if(newQuestion.User == null)
            {
                return BadRequest("User not found");
            }

            return Ok(newQuestion);

        }
    }
}
