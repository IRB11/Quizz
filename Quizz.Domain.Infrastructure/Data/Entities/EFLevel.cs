using Quizz.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Infrastructure.Data.Entities
{
    public class EFLevel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool IsActive { get; set; }

        public int AdminId { get; set; }
        public EFUser Admin { get; set; }

        public ICollection<EFQuestion> Questions { get; set; }
        public ICollection<EFQuiz> Quizzes { get; set; }
    }
}
