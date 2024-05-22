using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.Entities
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Comment { get; set; }

        public decimal Completion { get; set; }
        public DateTime CompletionTime { get; set; }
        public bool IsValid { get; set; }
        public int NumberOfQuestion { get; set; }
        public string QuizzNumber { get; set; }
        public decimal Result { get; set; }
        public string URL { get; set; }
        public User Agent { get; set; }
        public User Admin { get; set; }
        public Candidate Candidate { get; set; }
        public Status Status { get; set; }
        public virtual ICollection<Quiz_Question> Quiz_Questions { get; set; }
    }
}
