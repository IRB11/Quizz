using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces;
using Quizz.Domain.Core.Interfaces.Questions;
using System.ComponentModel.DataAnnotations;

namespace Quizz.Domain.Core.UseCases.Rules.QuestionRules
{
    public class CheckIfQuestionIsUsedInQuiz : ICheckQuestionRule<QuestionRequest>
    {
        private readonly IQuestionRepository _questionRepository;
        private string _errorMessage = string.Empty;

        private bool IsError => !string.IsNullOrWhiteSpace(_errorMessage);

        public CheckIfQuestionIsUsedInQuiz(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<bool> CheckRule(QuestionRequest questionRequest)
        {
            bool questionIsUsed = await _questionRepository.CheckIfQuestionIsUsedInQuizz((int)questionRequest.Id);

            if (questionIsUsed)
            {
                questionRequest.IsValid = false;
                await _questionRepository.Update(questionRequest);
                _errorMessage += $"Question with content '{questionRequest.Content}' already used.";
            }

            return IsError;
        }

        public string GetErrorMessage()
        {
            return _errorMessage;
        }
    }
}
