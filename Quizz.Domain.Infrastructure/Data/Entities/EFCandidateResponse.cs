using Quizz.Domain.Core.Entities;
using System.Collections.Generic;

namespace Quizz.Domain.Infrastructure.Data.Entities
{
    public class EFCandidateResponse
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool Is_Skipped { get; set; }
        public string Open_Response_Text { get; set; }
        public string Explanation { get; set; }
        public string Comment { get; set; }

        public int QuizId { get; set; }
        public int QuestionId { get; set; }
        public EFQuiz_Question Quiz_Question { get; set; }
    }
}