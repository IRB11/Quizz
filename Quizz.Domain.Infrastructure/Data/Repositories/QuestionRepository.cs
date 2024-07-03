using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces.Questions;
using Quizz.Domain.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Infrastructure.Data.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {

        private readonly Context context;
        private readonly IMapper mapper;

        public QuestionRepository(Context context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<QuestionResponse> Add(QuestionRequest questionRequest)
        {
            EFQuestion efQuestion = mapper.Map<EFQuestion>(questionRequest);
            context.Questions.Add(efQuestion);
            await context.SaveChangesAsync();
            QuestionResponse questionResponse = mapper.Map<QuestionResponse>(efQuestion);
            return questionResponse;
        }

        public Task<bool> Delete(QuestionRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<List<QuestionResponse>> getAll()
        {
            var efQuestions = context.Questions.Include(q => q.Technology).Include(q => q.Level).Include(q => q.Responses).ToList();
            var questions = mapper.Map<List<QuestionResponse>>(efQuestions);
            return questions;
        }

        public async Task<QuestionResponse> GetById(int id)
        {
            var efQuestion = await context.Questions.Include(q => q.Technology).Include(q => q.Level).Include(q => q.Responses).SingleOrDefaultAsync(q => q.Id == id);
            QuestionResponse questionResponse = mapper.Map<QuestionResponse> (efQuestion);
            return questionResponse;
        }

        public async Task<bool> QuestionExists(string content)
        {
            return await context.Questions.AnyAsync(e => e.Content.Trim().ToLower() == content.Trim().ToLower());
        }

        public Task<QuestionResponse> Update(QuestionRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
