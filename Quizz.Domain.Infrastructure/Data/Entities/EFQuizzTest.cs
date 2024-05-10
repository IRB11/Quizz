using Quizz.Domain.Core.Entities;
using System;
using System.Collections.Generic;

namespace Quizz.Domain.Infrastructure.Data.Entities
{
    public class EFQuizzTest
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
        public EFAgent Agent { get; set; }
        public EFAdmin Admin { get; set; }
        public EFCandidate Candidate { get; set; }
        public EFStatus Status { get; set; }
        public ICollection<EFQuestion> Questions { get; set; }
        public ICollection<EFQuizzAnswer> QuizzAnswers { get; set; }
    }
}