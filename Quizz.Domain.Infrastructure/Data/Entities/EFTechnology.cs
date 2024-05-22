using Quizz.Domain.Core.Entities;
using System.Collections.Generic;

namespace Quizz.Domain.Infrastructure.Data.Entities
{
    public class EFTechnology 
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int AdminId { get; set; }
        public EFUser Admin { get; set; }

        public ICollection<EFQuestion> Questions { get; set; }
        public ICollection<EFQuiz> Quizzes { get; set; }
    }
}