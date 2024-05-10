using Quizz.Domain.Core.Entities;
using System.Collections.Generic;

namespace Quizz.Domain.Infrastructure.Data.Entities
{
    public class EFAnswerOption
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public EFQuestion Question { get; set; }
        public ICollection<EFAnswer> Answers { get; set; }
    }
}