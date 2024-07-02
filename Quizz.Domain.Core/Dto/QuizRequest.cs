using Quizz.Domain.Core.Entities;

namespace Quizz.Domain.Core.Dto
{
    public class QuizRequest
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public decimal Completion { get; set; }
        public DateTime CompletionTime { get; set; }
        public bool IsValid { get; set; }
        public int NumberOfQuestion { get; set; }
        public string QuizzNumber { get; set; }
        public decimal Result { get; set; }
        public string URL { get; set; }

        public int AgentId { get; set; }
        public User Agent { get; set; }

        public int AdminId { get; set; }
        public User Admin { get; set; }

        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }

        public int StatusId { get; set; }
        public Status Status { get; set; }

        public int TechnologyId { get; set; }
        public Technology Technology { get; set; }

        public ICollection<Quiz_Question> Quiz_Questions { get; set; }
    }
}
