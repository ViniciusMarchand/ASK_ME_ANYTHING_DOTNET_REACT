using backend.DTO;
using backend.Models;
using backend.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/comment")]
    public class CommentController(CommentRepository repository) : ControllerBase
    {
        private readonly CommentRepository _repository = repository;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> GetAll()
        {
            var comments = await _repository.GetAll();
            return Ok(comments);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Comment>> Save(CommentDTO comment)
        {
            var newComment = await _repository.Save(comment);
            return Ok(newComment);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<Comment>> Delete(int id)
        {
            var comment = await _repository.Delete(id);
            return Ok(comment);
        }
    }
}