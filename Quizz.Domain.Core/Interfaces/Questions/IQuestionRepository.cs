using Quizz.Domain.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.Interfaces.Questions
{
    public interface IQuestionRepository : ICRUDRepository<QuestionRequest, QuestionResponse>
    {
        Task<bool> QuestionExists(string content, int? excludedQuestionId = null);
        Task<bool> CheckIfQuestionIsUsedInQuizz(int id);
        Task<List<QuestionResponse>> GetQuestionsByLevelAndTechnology( int levelId, int technologyId, int count);
        Task<List<QuestionResponse>> GetByListIds(List<Quizz_QuestionResponse> quizzQuestionsIdsByQuizzId);
        Task<List<QuestionResponse>> GetListQuestionsByQuizzId(int id);

        Task<bool> SaveCandidateResponseToQuizz(CandidateResponse_Request candidateResponse_Request);
    }
}
