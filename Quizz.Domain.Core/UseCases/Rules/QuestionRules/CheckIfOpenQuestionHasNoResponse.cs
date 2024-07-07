using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces.Questions;

namespace Quizz.Domain.Core.UseCases.Rules.QuestionRules
{
    public class CheckIfOpenQuestionHasNoResponse : ICheckQuestionRule<QuestionRequest>
    {
        private string _errorMessage = string.Empty;

        private bool IsError => !string.IsNullOrWhiteSpace(_errorMessage);

        public string GetErrorMessage()
        {
            return _errorMessage;
        }

        public Task<bool> CheckRule(QuestionRequest questionRequest)
        {
            if (questionRequest.Type == "OpenQuestion" && (questionRequest.Response != null && questionRequest.Response.Any()))
            {
                Console.WriteLine(questionRequest.Type + " questionRequest.Type");
                _errorMessage += "Open question should not have predefined responses.";
            }

            return Task.FromResult(IsError);
        }
    }
}