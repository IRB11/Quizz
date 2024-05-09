using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.Entities
{
    public class Answer
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public string Explanation { get; set; }
        public AnswerOption Option { get; set; }
        public QuizzAnswer QuizzAnswer { get; set; }

    }
}
