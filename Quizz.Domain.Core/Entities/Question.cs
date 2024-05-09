using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Type { get; set; }
        public bool IsValid { get; set; }
        public Admin Admin { get; set; }
        public Level Level { get; set; }
        public AnswerOption AnswerOption { get; set; }
        public Technologies Technologies { get; set; }
        public QuizzTest QuizzTest { get; set; }
    }
}
