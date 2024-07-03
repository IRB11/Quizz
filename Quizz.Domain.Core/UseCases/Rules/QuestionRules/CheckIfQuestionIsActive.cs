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
    public class CheckIfQuestionIsActive : ICheckQuestionRule<QuestionRequest>
    {
        private string _errorMessage = string.Empty;

        private bool IsError => !string.IsNullOrWhiteSpace(_errorMessage);

        public string GetErrorMessage()
        {
            return _errorMessage;
        }

        public Task<bool> CheckRule(QuestionRequest questionRequest)
        {
            bool isActive = questionRequest.IsValid;

            if (!isActive)
            {
                _errorMessage += $"Question with Id '{questionRequest.Id}' does not have any correct response.";
            }

            return Task.FromResult(IsError);
        }
    }
}
