using backend.DTO;
using backend.Models;
using backend.Services;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories;

public class AnswerRepository(ApplicationDbContext context)
{
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<Answer>> GetAll()
    {
        return await _context.Answers.ToListAsync();
    }    

    public async Task<Answer> Save(AnswerDTO answer)
    {
        var newAnswer = new Answer
        {
            Body = answer.Body,
            QuestionId = answer.QuestionId,
            UserId = answer.UserId
        };

        _context.Answers.Add(newAnswer);
        await _context.SaveChangesAsync();

        return newAnswer;
    }
}