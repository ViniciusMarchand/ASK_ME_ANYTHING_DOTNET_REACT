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
        return await _context.Questions.Include(q => q.Answers).Include(q => q.Comments).Include(q => q.Votes).ToListAsync();
    }

    public async Task<Question> Save(QuestionDTO question)
    {
        var user = await _context.Users.FindAsync(question.UserId);
        var category = await _context.Categories.FindAsync(question.CategoryId);
        
        var newQuestion = new Question
        {
            Title = question.Title,
            Body = question.Body,
            User = user!,
            UserId = question.UserId,
            Category = category!,
            CategoryId = category!.Id,
        };

        _context.Questions.Add(newQuestion);
        await _context.SaveChangesAsync();

        return newQuestion;
    }

    public async Task<Question> Delete(int id)
    {
        var question = await _context.Questions.FindAsync(id) ?? throw new Exception("Question not found");

        _context.Questions.Remove(question);
        await _context.SaveChangesAsync();

        return question;
    }
}