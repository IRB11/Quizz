using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces.Questions;
using Quizz.Domain.Infrastructure.Data.Entities;
using Quizz.Domain.Infrastructure.InMemory;
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

        public async Task<List<QuestionResponse>> GetByListIds(List<Quizz_QuestionResponse> quizzQuestionsIdsByQuizzId)
        {
            List<QuestionResponse> listquestions = new();
            foreach (var item in quizzQuestionsIdsByQuizzId)
            {
                var efQuestion = context.Questions.FirstOrDefault(q => q.Id == item.QuestionId);
                var question = mapper.Map<QuestionResponse>(efQuestion);
                listquestions.Add(question);
            }
            return listquestions;
        }

        public async Task<List<int>> GetListQuestionsByQuizzId(int quizzId)
        {
            using (context)
            {
                var questions = await context.Quizzes
                    .Where(q => q.Id == quizzId)
                    .SelectMany(q => q.Quiz_Questions)
                    .Select(qq => qq.Question.Id)
                    .ToListAsync();
                Console.WriteLine(questions.Count);
                return questions;
            }
        }

        public Task<List<QuestionResponse>> GetQuestionsByLevelAndTechnology(int levelId, int technologyId, int count)
        {
            var efQuestions = context.Questions
                            .Where(q => q.LevelId == levelId && q.TechnologyId == technologyId)
                            .OrderBy(q => Guid.NewGuid())
                            .Take(count)
                            .ToList();
                            return Task.FromResult(mapper.Map<List<QuestionResponse>>(efQuestions));
        }

        public Task<List<QuestionResponse>> GetRandomQuestions(int levelId, int technologyId, int numberOfQuestions)
        {
            throw new NotImplementedException();
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

        public Task<bool> SaveCandidateResponseToQuizz(List<CandidateResponse_Request> candidateResponses_Request)
        {
            var eFCandidateResponse = mapper.Map<List<EFCandidateResponse>>(candidateResponses_Request);

            try
            {
                foreach (var item in eFCandidateResponse)
                {
                    context.CandidateResponses.Add(item);
                    context.SaveChanges();
                }
                return Task.FromResult(true);
            }
            catch (Exception)
            {

                throw;
            }

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
