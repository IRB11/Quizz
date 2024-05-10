using System.Collections.Generic;

namespace Quizz.Domain.Infrastructure.Data.Entities
{
    public class EFQuizzAnswer
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public ICollection<EFAnswer> Answers { get; set; }
        public EFQuizzTest QuizzTest { get; set; }
    }
}