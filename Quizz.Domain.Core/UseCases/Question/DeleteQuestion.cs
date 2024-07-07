using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Entities;
using Quizz.Domain.Core.Interfaces;
using Quizz.Domain.Core.Interfaces.Questions;

namespace Quizz.Domain.Core.UseCases.Question
{
    public class DeleteQuestion : IDeleteQuestion
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly ILevelRepository _levelRepository;
        private readonly List<ICheckQuestionRule<QuestionRequest>> _rules;

        public DeleteQuestion(IQuestionRepository questionRepository,ILevelRepository levelRepository, List<ICheckQuestionRule<QuestionRequest>> rules)
        {
            _questionRepository = questionRepository;
            _levelRepository = levelRepository;
            _rules = rules;
        }

        public async  Task<QuestionResponse> Handle(QuestionRequest questionRequest)
        {

            if (CheckIfQuestionIsUsed(questionRequest))
            {
                questionRequest.IsValid = false;
                await _questionRepository.Update(questionRequest);
                LevelResponse QuestionLevel = await _levelRepository.GetLevelById(questionRequest.LevelId);

                return new QuestionResponse()
                {
                    Id = (long)questionRequest.Id,
                    Content = questionRequest.Content,
                    IsValid = questionRequest.IsValid,
                    Level = QuestionLevel,
                    Order = questionRequest.Order,
                    Response = ConvertResponses((List<Response_Request>)questionRequest.Response),
                    Technology = new TechnologiesResponse() { Id = questionRequest.TechnologyId },
                    Type = questionRequest.Type,
                };
            }

            else
            { 
                await _questionRepository.Delete(questionRequest);
                return null;
            }

            bool CheckIfQuestionIsUsed(QuestionRequest questionRequest)
            {
                return _questionRepository.CheckIfQuestionIsUsedInQuizz((int)questionRequest.Id).ConfigureAwait(false).GetAwaiter().GetResult();
            }

            List<Response_Response> ConvertResponses(List<Response_Request> responses)
            {
                return responses.Select(response => new Response_Response
                {
                    Id = (long)response.Id,
                    Content = response.Content,
                    isCorrect = response.isCorrect
                }).ToList();
            }
        }
    }
}
