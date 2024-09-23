namespace backend.Models
{
    public class Vote
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        public int VoteType { get; set; }
    }
}