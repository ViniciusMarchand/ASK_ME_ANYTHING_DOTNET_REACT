using backend.DTO;
using backend.Models;
using backend.Services;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories;

public class QuestionReposipository (ApplicationDbContext context)
{
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<Question>> GetQuestions()
    {
        return await _context.Questions.ToListAsync();
    }

    public async Task<Question> PostQuestion(QuestionDTO question)
    {
        var newQuestion = new Question
        {
            Title = question.Title,
            Body = question.Body,
            UserId = question.UserId
        };

        _context.Questions.Add(newQuestion);
        await _context.SaveChangesAsync();

        return newQuestion;
    }
}