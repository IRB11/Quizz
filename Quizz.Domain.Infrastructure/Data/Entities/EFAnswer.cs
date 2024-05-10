using Quizz.Domain.Core.Entities;
using System.Collections.Generic;

namespace Quizz.Domain.Infrastructure.Data.Entities
{
    public class EFAnswer
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public string Explanation { get; set; }
        public EFAnswerOption Option { get; set; }
        public ICollection<EFQuizzAnswer> QuizzAnswers { get; set; }
    }
}