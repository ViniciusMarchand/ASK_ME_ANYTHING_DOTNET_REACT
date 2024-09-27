using System.Text.Json.Serialization;

namespace backend.Models
{
    public class Comment
    {
        public int Id { get; set; }
        
        [JsonIgnore]
        
        public User User { get; set; } = null!;
        public int UserId { get; set; }

        [JsonIgnore]
        public Answer Answer { get; set; } = null!;
        
        public int? AnswerId { get; set; }

        [JsonIgnore]
        public Question Question { get; set; } = null!;

        public int? QuestionId { get; set; }
        public string Body { get; set; } = string.Empty;
        
    }
}