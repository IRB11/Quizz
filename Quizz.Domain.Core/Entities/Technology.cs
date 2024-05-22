using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.Entities
{
    public class Technology
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Quiz> Quizzes { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
