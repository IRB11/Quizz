using Quizz.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.Dto
{
    public class QuestionRequest
    {
        public long? Id { get; set; }
        public string Content { get; set; }
        public string Type { get; set; }
        public bool IsValid { get; set; }
        public int Order {  get; set; }
        public User Admin { get; set; }
        public ICollection<Response>? Response { get; set; }
        public Level Level { get; set; }
        public Technology Technology { get; set;}
    }
}
