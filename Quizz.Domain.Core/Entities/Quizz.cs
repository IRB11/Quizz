using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.Entities
{
    public class QuizzTest
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
        public Agent Agent { get; set; }
        public Admin Admin { get; set; }
        public Candidate Candidate { get; set; }
        public Status Status { get; set; }
        public Question Question { get; set; }
        public QuizzAnswer QuizzAnswer { get; set; }
    }
}
