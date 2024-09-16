using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;
using backend.Services;
using backend.DTO;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(ApplicationDbContext context) : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(UserDTO userDto)
        {
            // Converter UserDTO para User
            var user = new User
            {
                // Supondo que UserDTO tem propriedades como Nome, Email, etc.
                Username = userDto.Username,
                Email = userDto.Email,
                Password = userDto.Password,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName
                // Adicione outras propriedades conforme necessário
            };

            // Adicionar a nova entidade ao DbContext
            _context.Users.Add(user);

            // Salvar as alterações no banco de dados
            await _context.SaveChangesAsync();

            // Retornar a resposta com o local da nova entidade criada
            return Ok(user);
        }

    }
}
