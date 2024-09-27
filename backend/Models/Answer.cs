namespace backend.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string Body { get; set; } = string.Empty;
        public int UserId { get; set; }
        public int QuestionId { get; set; }
        public bool IsAccepted { get; set; } = false;
    }
}