using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Dto.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.UseCases.Rules.QuestionRules
{
    public class ValidQuestionTypeRule : ICheckQuestionRule<QuestionRequest>
    {
        private string _errorMessage = string.Empty;

        private bool IsError => !string.IsNullOrWhiteSpace(_errorMessage);

        public string GetErrorMessage()
        {
            return _errorMessage;
        }

        public Task<bool> CheckRule(QuestionRequest questionRequest)
        {
            bool isValidType = questionRequest.Type == "MultipleChoice"
                || questionRequest.Type == "SingleChoice"
                || questionRequest.Type == "OpenQuestion";


            if (!isValidType)
            {
                _errorMessage += $"Question with Id '{questionRequest.Type}' does not have any correct type.";
            }

            return Task.FromResult(IsError);
        }
    }
}
