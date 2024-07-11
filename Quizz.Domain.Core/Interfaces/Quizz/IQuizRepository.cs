using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.Interfaces.Quizz
{
    public interface IQuizzRepository : ICRUDRepository<QuizRequest, QuizResponse>
    {
        List<Quizz_QuestionResponse> GetQuestionsByQuizzId(int id);
        Task<List<Quizz_QuestionResponse>> SaveQuestionToQuizz_Question(int id, List<Quizz_QuestionResponse> quiz_Questions);
    }
}
