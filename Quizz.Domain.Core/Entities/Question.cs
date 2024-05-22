using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.Entities
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string Content { get; set; }
        public string Type { get; set; }
        public bool IsValid { get; set; }
        public User Admin { get; set; }
        public Level Level { get; set; }
        public Technology Technology { get; set; }
        public virtual ICollection<Quiz_Question> Quiz_Questions { get; set; }
    }
}
