using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Entities;
using Quizz.Domain.Core.Interfaces.Questions;
using Quizz.Domain.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Infrastructure.InMemory
{
    public class InMemoryQuestionRepository : IQuestionRepository
    {
        private readonly List<QuestionRequest> _questions;

        public InMemoryQuestionRepository()
        {
            _questions = GetInitialQuestions();
        }

        public async Task<QuestionResponse> Add(QuestionRequest request)
        {
            await Task.Run(() => _questions.Add(request));

            return new QuestionResponse
            {
                Id = (long)request.Id,
                Content = request.Content,
                IsValid = request.IsValid,
                Level = null,
                Order = request.Order,
                Response = (List<Response_Response>)(request.Response != null
               ? request.Response.Select(ConvertToResponse).ToList()
               : new List<Response_Response>()),
                Technology = new TechnologiesResponse { Id = request.TechnologyId },
                Type = request.Type,

            };
        }

        public Response_Response ConvertToResponse(Response_Request request)
        {
            return new Response_Response
            {

                Id = (int)request.Id,
                Content = request.Content,
                isCorrect = request.isCorrect,
                Explanation = request.Explanation                
            };
        }

        public Task<bool> Delete(QuestionRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<List<QuestionResponse>> getAll()
        {
            throw new NotImplementedException();
        }

        public async Task<QuestionResponse> GetById(int id)
        {
            var question = _questions.FirstOrDefault(q => q.Id == id);

            if (question == null)
            {
                return null;
            }

            return await Task.FromResult(new QuestionResponse
            {
                Id = (long)question.Id,
                Content = question.Content,
                Type = question.Type,
                IsValid = question.IsValid,
                Order = question.Order,
                Response = (List<Response_Response>)question.Response.Select(r => new Response_Response
                {
                    Id = (int)r.Id,
                    Content = r.Content,
                    Explanation = r.Explanation,
                    isCorrect = r.isCorrect
                }).ToList(),
                Level = new LevelResponse { Id = question.LevelId },
                Technology = new TechnologiesResponse { Id = question.TechnologyId }
            });
        }

        public Task<bool> QuestionExists(string content)
        {
            return Task.Run(() => _questions.Any(q => q.Content.Trim().ToLower() == content.Trim().ToLower()));
        }

        public Task<QuestionResponse> Update(QuestionRequest request)
        {
            throw new NotImplementedException();
        }

        private List<QuestionRequest> GetInitialQuestions()
        {
            return new List<QuestionRequest>
            {
                new QuestionRequest
                {
                    Id = 1,
                    Content = "What is the capital of France?",
                    Type = "MultipleChoice",
                    IsValid = true,
                    Order = 1,
                    AdminId = 1,
                    Response = new List<Response_Request>
                    {
                        new Response_Request { Id = 1, Content = "Paris", isCorrect = true },
                        new Response_Request { Id = 2, Content = "Berlin", isCorrect = false }
                    },
                    LevelId = 1 ,
                    TechnologyId = 2

                },
                new QuestionRequest
                {
                    Id = 2,
                    Content = "What is 2 + 2?",
                    Type = "SingleChoice",
                    IsValid = true,
                    Order = 2,
                    AdminId = 1 ,
                    Response = new List<Response_Request>
                    {
                        new Response_Request { Id = 1, Content = "3", isCorrect = false },
                        new Response_Request { Id = 2, Content = "4", isCorrect = true }
                    },
                    LevelId = 1 ,
                    TechnologyId = 2
                },
                new QuestionRequest
                {
                    Id = 3,
                    Content = "Describe the process of photosynthesis.",
                    Type = "OpenQuestion",
                    IsValid = true,
                    Order = 3,
                    AdminId = 1,
                    Response = new List<Response_Request>(),
                    LevelId = 1 ,
                    TechnologyId = 2

                }
            };
        }
    }
}

