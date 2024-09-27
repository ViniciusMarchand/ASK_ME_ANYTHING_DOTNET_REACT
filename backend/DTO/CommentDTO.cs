using System.ComponentModel.DataAnnotations;

namespace backend.DTO;

public class CommentDTO 
{
    [Required]
    public string Body { get; set; } = string.Empty;
    
    public int AnswerId { get; set; }
    public int QuestionId { get; set; }

    [Required]
    public int UserId { get; set; }
}