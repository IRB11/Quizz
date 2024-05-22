using Microsoft.EntityFrameworkCore;
using Quizz.Domain.Core.Entities;
using System;
using System.Collections.Generic;

namespace Quizz.Domain.Infrastructure.Data.Entities
{
    public class EFQuiz
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        [Precision(18, 2)]
        public decimal Completion { get; set; }
        public DateTime CompletionTime { get; set; }
        public bool IsValid { get; set; }
        public int NumberOfQuestion { get; set; }
        public string QuizzNumber { get; set; }
        [Precision(18, 2)]
        public decimal Result { get; set; }
        public string URL { get; set; }

        public int AgentId { get; set; }
        public EFUser Agent { get; set; }

        public int AdminId { get; set; }
        public EFUser Admin { get; set; }

        public int CandidateId { get; set; }
        public EFCandidate Candidate { get; set; }

        public int StatusId { get; set; }
        public EFStatus Status { get; set; }

        public int TechnologyId { get; set; }
        public EFTechnology Technology { get; set; }

        public ICollection<EFQuestion> Questions { get; set; }
        public ICollection<EFQuiz_Question> Quiz_Questions { get; set; }
    }
}