using System.ComponentModel.DataAnnotations;

namespace backend.DTO;

public class QuestionDTO
{
    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Body { get; set; } = string.Empty;

    [Required]
    public int UserId { get; set; }

    [Required]
    public int CategoryId { get; set; }
    // public List<Comment> Comments { get; set; } = new List<Comment>();
    // public List<Vote> Votes { get; set; } = new List<Vote>();
    // public List<Category> Categories { get; set; } = new List<Category>();
}