using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Entities;
using Quizz.Domain.Core.Interfaces.Quizz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Infrastructure.InMemory
{
    public class InMemoryQuizzRepository : IQuizzRepository
    {
        private readonly List<QuestionRequest> _questions;
        private readonly List<Quizz_QuestionResponse> _quizz_questions;
        private readonly List<QuizRequest> _quizRequests;

        public InMemoryQuizzRepository()
        {
            _quizRequests = GetInitialQuizzes();
            _quizz_questions = MockData.quizz_QuestionResponses;
        }

        private List<QuizRequest> GetInitialQuizzes()
        {
            return new List<QuizRequest>()
            {
                new()
                {
                    Id = 1,
                    AdminId = 1,
                    AgentId = 1,
                    CandidateId = 1,
                    Completion = 0,
                    IsValid = true,
                    LevelId = 1,
                    NumberOfQuestion = 20,
                    Result = 0,
                    URL = "zkzjkjqkd",
                    TechnologyId = 1,
                    StatusId = 1,

                },
                new()
                {
                    Id = 2,
                    AdminId = 1,
                    AgentId = 2,
                    CandidateId = 2,
                    Completion = 0,
                    IsValid = true,
                    LevelId = 1,
                    NumberOfQuestion = 25,
                    Result = 0,
                    URL = "zkzjkjqkd",
                    TechnologyId = 1,
                    StatusId = 1,

                },
                new()
                {
                    Id = 3,
                    AdminId = 1,
                    AgentId = 1,
                    CandidateId = 3,
                    Completion = 0,
                    IsValid = true,
                    LevelId = 1,
                    NumberOfQuestion = 20,
                    Result = 0,
                    URL = "zkzjkjqkd",
                    TechnologyId = 2,
                    StatusId = 1,

                },
            };

        }

        private List<Quizz_QuestionResponse> GetInitialQuizzQuestion()
        {
            return new List<Quizz_QuestionResponse>
            {
                new Quizz_QuestionResponse
                {
                    QuizId = 1,
                    QuestionId = 1,
                },
                new Quizz_QuestionResponse
                {
                    QuizId = 1,
                    QuestionId = 2,
                },
                new Quizz_QuestionResponse
                {
                    QuizId = 1,
                    QuestionId = 3,
                },
                new Quizz_QuestionResponse
                {
                    QuizId = 1,
                    QuestionId = 4,
                },
            };
        }


        public async Task<QuizResponse> Add(QuizRequest quizRequest)
        {
            await Task.Run(() => _quizRequests.Add(quizRequest));

            return new QuizResponse
            {
                Id = (long)quizRequest.Id,
                NumberOfQuestion = quizRequest.NumberOfQuestion,
                Comment = quizRequest.Comment,
                CompletionLevel = quizRequest.Completion,
                CompletionTime = quizRequest.CompletionTime,
                IsValid = quizRequest.IsValid,
                Result = quizRequest.Result,
                StatusId = quizRequest.StatusId,
                Technologies = new TechnologiesResponse () { Id = quizRequest.TechnologyId },
                Admin = new() { Id = quizRequest.AdminId},
                Level = new() { Id = quizRequest.LevelId},
                Agent = new () { Id = quizRequest.AgentId},
                Candidate = new() { Id= quizRequest.CandidateId},
                URL = quizRequest.URL,
            };
        }

        public Task<bool> Delete(QuizRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<QuizResponse> GenerateQuiz(QuizRequest quizRequest)
        {
            throw new NotImplementedException();
        }

        public Task<List<QuizResponse>> getAll()
        {
            throw new NotImplementedException();
        }

        public Task<QuizResponse> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Quizz_QuestionResponse> GetQuestionsByQuizzId(int id)
        {
            var QuizzQuestions = _quizz_questions.FindAll(q => q.QuizId == id);
            return QuizzQuestions;
        }


        public Task<QuizResponse> Update(QuizRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<List<Quizz_QuestionResponse>> SaveQuestionToQuizz_Question(int id, List<Quizz_QuestionResponse> quiz_Questions)
        {
            foreach (var q in quiz_Questions)
            {
                _quizz_questions.Add(q);
            }
            return Task.FromResult( _quizz_questions);
        }
    }
}
