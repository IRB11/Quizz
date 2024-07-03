using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Entities;
using Quizz.Domain.Core.Interfaces.Questions;
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
                Response = request.Response != null
               ? request.Response.Select(r => ConvertToResponse(r)).ToList()
               : new List<Response>(),
                Technology = null,
                Type = request.Type,

            };
        }

        public Response ConvertToResponse(Response_Request request)
        {
            return new Response
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

        public Task<QuestionResponse> GetById(int id)
        {
            throw new NotImplementedException();
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

