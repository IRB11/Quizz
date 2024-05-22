using Quizz.Domain.Core.Entities;
using System.Collections.Generic;

namespace Quizz.Domain.Infrastructure.Data.Entities
{
    public class EFQuiz_Question
    {


        public int QuizId { get; set; }
        public EFQuiz Quiz { get; set; }

        public int QuestionId { get; set; }
        public EFQuestion Question { get; set; }
        public ICollection<EFCandidateResponse> CandidateResponses { get; set; }
    }
}