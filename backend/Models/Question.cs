using System.Text.Json.Serialization;

namespace backend.Models;

public class Question
{
    public  int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public bool IsEdited { get; set; }
    public int UserId { get; set; }

    [JsonIgnore]
    public User User { get; set; } = null!;

    public List<Answer> Answers { get; set; } = [];
    public List<Comment> Comments { get; set; } = [];
    public List<Vote> Votes { get; set; } = [];
    public int CategoryId { get; set; }

    [JsonIgnore]
    public Category Category { get; set; } = null!;
}
