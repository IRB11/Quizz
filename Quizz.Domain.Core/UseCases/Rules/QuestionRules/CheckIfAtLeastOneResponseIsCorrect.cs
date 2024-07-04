using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces.Questions;

namespace Quizz.Domain.Core.UseCases.Rules.QuestionRules
{
    public class CheckIfAtLeastOneResponseIsCorrect : ICheckQuestionRule<QuestionRequest>
    {
        private string _errorMessage = string.Empty;

        private bool IsError => !string.IsNullOrWhiteSpace(_errorMessage);

        public string GetErrorMessage()
        {
            return _errorMessage;
        }

        public Task<bool> CheckRule(QuestionRequest questionRequest)
        {
            if ((questionRequest.Type == "MultipleChoice" || questionRequest.Type == "SingleChoice") &&
                (questionRequest.Response == null || questionRequest.Response.Any(r => r.isCorrect) == false) )
            { 

                _errorMessage += $"Question with Id '{questionRequest.Id}' and Content '{questionRequest.Content}' does not have any correct response2";
            }

            return Task.FromResult(IsError);
        }
    }
}