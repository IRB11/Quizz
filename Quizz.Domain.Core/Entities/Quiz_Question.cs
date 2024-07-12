using Quizz.Domain.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.Entities
{
    public class Quiz_Question
    {
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public int CandidateResponseId { get; set; }
        public ICollection<CandidateResponse> CandidateResponse { get; set; }
    }
}
