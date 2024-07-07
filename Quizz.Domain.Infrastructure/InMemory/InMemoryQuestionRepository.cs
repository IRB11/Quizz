using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Entities;
using Quizz.Domain.Core.Interfaces.Questions;

namespace Quizz.Domain.Infrastructure.InMemory
{
    public class InMemoryQuestionRepository : IQuestionRepository
    {
        private readonly List<QuestionRequest> _questions;
        private readonly List<Quizz_QuestionRequest> _quizz_questions;

        public InMemoryQuestionRepository()
        {
            _questions = GetInitialQuestions();
            _quizz_questions = GetInitialQuizzQuestions();
        }

        private List<Quizz_QuestionRequest> GetInitialQuizzQuestions()
        {
            return new List<Quizz_QuestionRequest>()
            { 
                new Quizz_QuestionRequest()
                {
                    QuizId = 1,
                    QuestionId = 1,
                   
                },
                new Quizz_QuestionRequest()
                {
                    QuizId = 1,
                    QuestionId = 2,
                },
                new Quizz_QuestionRequest()
                {
                    QuizId = 1,
                    QuestionId = 3,
                },
                new Quizz_QuestionRequest()
                {
                    QuizId = 1,
                    QuestionId = 5,
                },
                new Quizz_QuestionRequest()
                {
                    QuizId = 2,
                    QuestionId = 1,
                },
                new Quizz_QuestionRequest()
                {
                    QuizId = 2,
                    QuestionId = 2,
                },
                new Quizz_QuestionRequest()
                {
                    QuizId = 2,
                    QuestionId = 3,
                },
                new Quizz_QuestionRequest()
                {
                    QuizId = 2,
                    QuestionId = 4,
                }
            };
        }

        public async Task<QuestionResponse> Add(QuestionRequest request)
        {
            await Task.Run(() => _questions.Add(request));

            return new QuestionResponse
            {
                Id = (long)request.Id,
                Content = request.Content,
                IsValid = request.IsValid,
                Level = new LevelResponse() { Id = request.LevelId },
                Order = request.Order,
                Response = (List<Response_Response>)(request.Response != null
               ? request.Response.Select(ConvertToResponse).ToList()
               : new List<Response_Response>()),
                Technology = new TechnologiesResponse { Id = request.TechnologyId },
                Type = request.Type,

            };
        }

        public void ClearQuestions()
        {
            _questions.Clear();
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
            return Task.Run(() =>
            {               
                if (_questions.Any(q => q.Id == request.Id))
                {
                    _questions.Remove(request);
                }
                return true;
            });
        }

        public async Task<List<QuestionResponse>> getAll()
        {
            var questionResponses = _questions.Select(question => new QuestionResponse
            {
                Id = (long)question.Id,
                Content = question.Content,
                IsValid = question.IsValid,
                Level = new LevelResponse { Id = question.LevelId },
                Order = question.Order,
                Response = (List<Response_Response>)question.Response.Select(r => new Response_Response
                {
                    Id = (int)r.Id,
                    Content = r.Content,
                    Explanation = r.Explanation,
                    isCorrect = r.isCorrect
                }).ToList(),
                Technology = new() { Id = question.TechnologyId },
                Type = question.Type,
            }).ToList();

            return await Task.FromResult(questionResponses);
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

        public Task<bool> QuestionExists(string content, int? id = null)
        {
            return Task.Run(() => _questions.Any(q => q.Content.Trim().ToLower() == content.Trim().ToLower()));
        }

        public Task<bool> CheckIfQuestionIsUsedInQuizz(int id)
        {
            return Task.Run(() => _quizz_questions.Any(q => q.QuestionId == id));
        }

        public async Task<QuestionResponse> Update(QuestionRequest request)
        {
            var response = new QuestionResponse();

            try
            {
                await Task.Run(() =>
                {
                    lock (_questions)
                    {
                        int index = _questions.FindIndex(q => q.Id == request.Id);

                        if (index >= 0)
                        {
                            _questions.RemoveAt(index);
                            var updatedQuestion = new QuestionRequest
                            {
                                Id = request.Id,
                                Content = request.Content,
                                Type = request.Type,
                                IsValid = request.IsValid,
                                Order = request.Order,
                                AdminId = request.AdminId,
                                Response = request.Response?.Select(r => new Response_Request
                                {
                                    Id = (long)r.Id,
                                    Content = r.Content,
                                    isCorrect = r.isCorrect
                                }).ToList(),
                                LevelId = request.LevelId,
                                TechnologyId = request.TechnologyId
                            };
                            _questions.Add(updatedQuestion);
                            response = MapToResponse(updatedQuestion);
                        }
                        else
                        {
                            response.Id = -1;
                            response.Content = "Question not found.";
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                response.Id = -1;
                response.Content = $"An error occurred: {ex.Message}";
            }

            return response;
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

        private QuestionResponse MapToResponse(QuestionRequest question)
        {
            return new QuestionResponse
            {
                Id = (long)question.Id,
                Content = question.Content,
                Type = question.Type,
                IsValid = question.IsValid,
                Order = question.Order,
                Response = MapToResponseResponseList((List<Response_Request>)question.Response),
                Level = new() { Id = question.LevelId},
                Technology = new() { Id = question.TechnologyId },
            };
        }

        private List<Response_Response> MapToResponseResponseList(List<Response_Request> responseRequests)
        {
            return responseRequests?.Select(r => new Response_Response
            {
                Id = (long)r.Id,
                Content = r.Content,
                isCorrect = r.isCorrect
            }).ToList();
        }
    }
}

