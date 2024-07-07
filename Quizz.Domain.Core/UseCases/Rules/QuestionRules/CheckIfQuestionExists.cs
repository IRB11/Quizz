using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.UseCases.Rules.QuestionRules
{
    public class CheckIfQuestionExists : ICheckQuestionRule<QuestionRequest>
    {
        private readonly IQuestionRepository _questionRepository;
        private string _errorMessage = string.Empty;

        private bool IsError => !string.IsNullOrWhiteSpace(_errorMessage);

        public CheckIfQuestionExists(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public string GetErrorMessage()
        {
            return _errorMessage;
        }

        public async Task<bool> CheckRule(QuestionRequest questionRequest)
        {
            bool questionExists = await _questionRepository.QuestionExists(questionRequest.Content, (int)questionRequest.Id);

            if (questionExists)
            {
                _errorMessage += $"Question with content '{questionRequest.Content}' already exists.";
            }

            return IsError;
        }
    }

}
