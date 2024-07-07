using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces.Questions;

namespace Quizz.Domain.Core.UseCases.Rules.QuestionRules
{
    public class CheckIfMultipleOrSingleChoiceQuestionHasTwoOrFourResponses : ICheckQuestionRule<QuestionRequest>
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
                (questionRequest.Response == null || (questionRequest.Response.Count != 2 && questionRequest.Response.Count != 4)))
            {
                _errorMessage += "Multiple choice or single choice questions must have exactly 2 or 4 responses.";
            }

            return Task.FromResult(IsError);
        }
    }
}