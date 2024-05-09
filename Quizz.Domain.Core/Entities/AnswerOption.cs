using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.Entities
{
    public class AnswerOption
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public Question Question { get; set; }
        public Answer Answer { get; set; }
    }
}
