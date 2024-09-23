namespace backend.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AnswerId { get; set; }
        public int QuestionId { get; set; }
        public string Body { get; set; } = string.Empty;
    }
}