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

        public Task<bool> CheckIfQuestionIsUsedInQuizz(int id)
        {
            return context.QuizQuestions.AnyAsync(q => q.QuestionId == id);
        }

        public async Task<bool> Delete(QuestionRequest request)
        {
            if (context.Questions.Any(u => u.Id == request.Id))
            {
                EFQuestion eFQuestion = mapper.Map<EFQuestion>(request);
                context.Questions.Remove(eFQuestion);
                context.SaveChanges();
                return true;
            }
            else return false;
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

        public async Task<bool> QuestionExists(string content, int? excludedQuestionId)
        {
            if (excludedQuestionId.HasValue)
            {
                return await context.Questions
                    .AnyAsync(e => e.Content.Trim().ToLower() == content.Trim().ToLower() && e.Id != excludedQuestionId.Value);
            }

            return await context.Questions
                .AnyAsync(e => e.Content.Trim().ToLower() == content.Trim().ToLower());
        }

        public Task<bool> QuestionExists(long? id)
        {
            throw new NotImplementedException();
        }

        public async Task<QuestionResponse> Update(QuestionRequest request)
        {
            var existingQuestion = await context.Questions
                    .Include(q => q.Responses)  // Include responses to update them as well
                    .SingleOrDefaultAsync(q => q.Id == request.Id);

            if (existingQuestion == null)
            {
                return null;
            }

            // Check if the new content is already taken by another question (excluding the current question itself)
            bool contentExists = await QuestionExists(request.Content, (int?)request.Id);
            if (contentExists)
            {
                return null;
            }

            // Update the question's properties
            existingQuestion.Content = request.Content;
            existingQuestion.Type = request.Type;
            existingQuestion.IsValid = request.IsValid;

            // Clear existing responses and add new ones
            existingQuestion.Responses.Clear();
            if (request.Response != null)
            {
                foreach (var response in request.Response)
                {
                    var efResponse = new EFResponse
                    {
                        Id = (int)response.Id,
                        Content = response.Content,
                        IsCorrect = response.isCorrect
                    };
                    existingQuestion.Responses.Add(efResponse);
                }
            }

            existingQuestion.LevelId = request.LevelId;
            existingQuestion.TechnologyId = request.TechnologyId;

            await context.SaveChangesAsync();

            // Map to QuestionResponse
            var updatedQuestionResponse = mapper.Map<QuestionResponse>(existingQuestion);
            return updatedQuestionResponse;
        }
    }
}
