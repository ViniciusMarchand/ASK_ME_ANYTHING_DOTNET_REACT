using backend.DTO;
using backend.Models;
using backend.Services;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories;

public class VoteRepository(ApplicationDbContext context)
{
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<Vote>> GetAll()
    {
        return await _context.Votes.ToListAsync();
    }

    public async Task<Vote> Save(VoteDTO vote)
    {
        var user = await _context.Users.FindAsync(vote.UserId);

        var newVote = new Vote
        {
            UserId = vote.UserId,
            User = user!,
            VoteType = vote.VoteType,
        };

        if(vote.AnswerId == 0 && vote.QuestionId == 0)
        {
            throw new Exception("Vote must be associated with a question, answer, or comment");
        }

        if(vote.AnswerId != 0)
        {
            var answer = await _context.Answers.FindAsync(vote.AnswerId) ?? throw new Exception("Answer not found");
            newVote.Answer = answer!;
            newVote.AnswerId = answer!.Id;
        }
        else if(vote.QuestionId != 0)
        {
            var question = await _context.Questions.FindAsync(vote.QuestionId) ?? throw new Exception("Question not found");
            newVote.Question = question!;
            newVote.QuestionId = question!.Id;
        }

        _context.Votes.Add(newVote);
        await _context.SaveChangesAsync();

        return newVote;
    }
}