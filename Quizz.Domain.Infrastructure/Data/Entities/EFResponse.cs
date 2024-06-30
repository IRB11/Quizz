using Quizz.Domain.Core.Entities;
using System.Collections.Generic;

namespace Quizz.Domain.Infrastructure.Data.Entities
{
    public class EFResponse
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool IsCorrect { get; set; }

        public int QuestionId { get; set; }
        public EFQuestion Question { get; set; }
    }
}