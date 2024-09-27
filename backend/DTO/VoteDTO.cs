using System.ComponentModel.DataAnnotations;

namespace backend.DTO;

public class VoteDTO
{
    [Required]
    public int UserId { get; set; }

    public int AnswerId { get; set; }
    public int QuestionId { get; set; }

    [Required]
    public int VoteType { get; set; }
}