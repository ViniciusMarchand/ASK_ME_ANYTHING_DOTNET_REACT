namespace backend.DTO;

public class QuestionDTO
{
    public string Title { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public int UserId { get; set; }
    // public List<Comment> Comments { get; set; } = new List<Comment>();
    // public List<Vote> Votes { get; set; } = new List<Vote>();
    // public List<Category> Categories { get; set; } = new List<Category>();
}