using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;
using backend.Services;
using backend.DTO;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(ApplicationDbContext context, TokenGenerator tokenGenerator) : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;

        private readonly TokenGenerator _tokenGenerator = tokenGenerator;

        [HttpPost("Login")]
        public async Task<ActionResult<object>> Login(UserLoginDTO dto)
        {

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == dto.Username && u.Password == dto.Password);
            

            if (user == null)
            {
                return NotFound("Usuário não encontrado");
            }

            return Ok(new {accsesToken = _tokenGenerator.GenerateToken(user)});

        }

    }
}
