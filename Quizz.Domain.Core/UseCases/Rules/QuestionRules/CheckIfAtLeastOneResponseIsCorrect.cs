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
            // Check if the question type is not "OpenQuestion" and validate the responses
            bool has1CorrectResponse = questionRequest.Type != "OpenQuestion";
            Console.WriteLine(has1CorrectResponse + "  has1CorrectResponse");            
            bool has1TypetResponse = questionRequest.Response != null;
            Console.WriteLine(has1TypetResponse + "  has1TypetResponse");            
            bool has1nullResponse = questionRequest.Response != null;
            Console.WriteLine(has1nullResponse + "  has1nullResponse");


            bool hasCorrectResponse = questionRequest.Type != "OpenQuestion" &&
                                      questionRequest.Response != null &&
                                      questionRequest.Response.Any() &&
                                      questionRequest.Response.Any(r => r.isCorrect);


            // Debug information to verify the logic
            Console.WriteLine($"Question Type: {questionRequest.Type}");  // Outputs the type of the question
            Console.WriteLine($"Responses Count: {questionRequest.Response?.Count}");  // Outputs the number of responses
            Console.WriteLine($"Has Correct Response: {hasCorrectResponse}");  // Outputs whether there is a correct response


            if ((questionRequest.Type == "MultipleChoice" || questionRequest.Type == "SingleChoice") &&
                (questionRequest.Response == null || questionRequest.Response.Any(r => r.isCorrect) == false) )
            { 

                _errorMessage += $"Question with Id '{questionRequest.Id}' and Content '{questionRequest.Content}' does not have any correct response2";
            }

            return Task.FromResult(IsError);
        }
    }
}