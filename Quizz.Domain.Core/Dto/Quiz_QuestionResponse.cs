using Quizz.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.Dto
{
    public class QuizzRequest
    {
        public int QuizId { get; set; }
        public int QuestionId { get; set; }

        public virtual Quiz Quiz { get; set; }
        public virtual Question Question { get; set; }
    }
}
