using backend.DTO;
using backend.Models;
using backend.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/answer")]
    public class AnswerController (AnswerRepository repository) : ControllerBase
    {   
        private readonly AnswerRepository _repository = repository;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Answer>>> GetAll()
        {
            var answers = await _repository.GetAll();
            return Ok(answers);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchEntity(int id, [FromBody] JsonPatchDocument<Answer> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var answer = await _repository.GetById(id);
            if (answer == null)
            {
                return NotFound();
            }

            patchDoc.ApplyTo(answer);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            await _repository.Update(answer);

            return NoContent();
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Answer>> Save(AnswerDTO answer)
        {
            var newAnswer = await _repository.Save(answer);
            return Ok(newAnswer);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Answer>> Delete(int id)
        {
            var answer = await _repository.Delete(id);
            return Ok(answer);
        }
    }

}
