using Quizz.Domain.Core.Entities;
using System.Collections.Generic;

namespace Quizz.Domain.Infrastructure.Data.Entities
{
    public class EFQuestion
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Type { get; set; }
        public bool IsValid { get; set; }
        public EFAdmin Admin { get; set; }
        public EFLevel Level { get; set; }
        public ICollection<EFAnswerOption> AnswerOptions { get; set; }
        public EFTechnologies Technologies { get; set; }
        public ICollection<EFQuizzTest> QuizzTests { get; set; }
    }
}