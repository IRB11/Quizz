using Quizz.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.Dto
{
    public class AgentResponse
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public Admin Admin { get; set; }
        public Candidate Candidate { get; set; }
        public QuizzTest QuizzTest { get; set; }
    }
}
