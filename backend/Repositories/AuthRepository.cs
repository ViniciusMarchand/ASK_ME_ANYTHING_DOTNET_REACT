using System.Text.RegularExpressions;
using backend.DTO;
using backend.Models;
using backend.Services;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories;

public class AuthRepository(ApplicationDbContext context, TokenGeneratorService tokenGenerator)
{
    readonly ApplicationDbContext _context = context;
    readonly TokenGeneratorService _tokenGenerator = tokenGenerator;

    public async Task<AccessTokenDTO> Login(UserLoginDTO dto) 
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == dto.Username) ?? throw new KeyNotFoundException("Usuário não encontrado ou senha inválida");

        if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
        {
            throw new KeyNotFoundException("Usuário não encontrado ou senha inválida");
        }

        AccessTokenDTO token = new()
        {
            AccessToken = _tokenGenerator.GenerateToken(user)
        };

        return token;
    }

    public async Task<User> Register(UserDTO dto)
    {
        
        var Password = BCrypt.Net.BCrypt.HashPassword(dto.Password);
        var emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        if (!emailRegex.IsMatch(dto.Email))
            throw new Exception("Invalid email");
        
        var user = new User
        {
            Username = dto.Username,
            Password = Password,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email
        };
        
        try
        {
            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return user;

        } 
        catch (DbUpdateException e)
        {
            var message = e.InnerException?.Message ?? string.Empty;
            if (message.Contains("IX_Users_Username"))
            {
                throw new Exception("Username unavailable");
            }
            else if (message.Contains("IX_Users_Email"))
            {
                throw new Exception("Email unavailable");
            }

            throw new Exception("Erro ao criar usuário.");
        }



    }
}