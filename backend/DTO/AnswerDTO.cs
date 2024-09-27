namespace backend.DTO;

public class AnswerDTO 
{
    public string Body { get; set; } = string.Empty;
    public int QuestionId { get; set; }
    public int UserId { get; set; }
}