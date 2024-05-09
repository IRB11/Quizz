using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.Entities
{
    public class QuizzAnswer
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public Answer Answer { get; set; }
        public Quizz Quizz { get; set; }
    }
}
