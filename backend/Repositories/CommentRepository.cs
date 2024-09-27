using backend.DTO;
using backend.Models;
using backend.Services;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories;

public class CommentRepository(ApplicationDbContext context)
{
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<Comment>> GetAll()
    {
        return await _context.Comments.ToListAsync();
    }

    public async Task<Comment> Save(CommentDTO comment)
    {
        var user = await _context.Users.FindAsync(comment.UserId);

        var newComment = new Comment
        {
            Body = comment.Body,
            UserId = comment.UserId,
            User = user!,
        };

        if(comment.QuestionId == 0 && comment.AnswerId == 0)
        {
            throw new Exception("Comment must be associated with a question or answer");
        }   

        if(comment.AnswerId != 0)
        {
            var answer = await _context.Answers.FindAsync(comment.AnswerId);
            newComment.Answer = answer!;
            newComment.AnswerId = answer!.Id;
        }
        else if(comment.QuestionId != 0)
        {
            var question = await _context.Questions.FindAsync(comment.QuestionId);
            newComment.Question = question!;
            newComment.QuestionId = question!.Id;
        }

        _context.Comments.Add(newComment);
        await _context.SaveChangesAsync();

        return newComment;
    }
}