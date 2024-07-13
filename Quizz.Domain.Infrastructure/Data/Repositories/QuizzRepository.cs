using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces.Quizz;
using Quizz.Domain.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Infrastructure.Data.Repositories
{
    public class QuizzRepository : IQuizzRepository
    {
        private readonly IMapper mapper;
        private readonly Context context;

        public QuizzRepository(Context context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<QuizResponse> Add(QuizRequest request)
        {
            EFQuiz eFQuiz= mapper.Map<EFQuiz>(request);
            context.Quizzes.Add(eFQuiz);
            await context.SaveChangesAsync();
            QuizResponse response = mapper.Map<QuizResponse>(eFQuiz);
            return response;
        }

        public Task<bool> Delete(QuizRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<List<QuizResponse>> getAll()
        {
            throw new NotImplementedException();
        }

        public async Task<QuizResponse> GetById(int id)
        {
            var eFQuizz = await context.Quizzes.SingleOrDefaultAsync(q => q.Id == id);
            QuizResponse quizResponse = mapper.Map<QuizResponse>(eFQuizz);
            return quizResponse;
        }

        public  List<Quizz_QuestionResponse> GetQuestionsByQuizzId(int id)
        {
            var efQuestions = context.QuizQuestions.Where(x => x.QuizId == id).ToList();
            var quizz_QuestionResponses = mapper.Map<List<Quizz_QuestionResponse>>(efQuestions);
            return quizz_QuestionResponses;
        }

        public async Task<List<Quizz_QuestionResponse>> SaveQuestionToQuizz_Question(int id, List<Quizz_QuestionResponse> quiz_Questions)
        {
            var efQuizQuestions = mapper.Map<List<EFQuiz_Question>>(quiz_Questions);
            await context.AddRangeAsync(efQuizQuestions);
            await context.SaveChangesAsync();
            return quiz_Questions;
        }

        public Task<QuizResponse> Update(QuizRequest request)
        {
            throw new NotImplementedException();
        }

    }
}
