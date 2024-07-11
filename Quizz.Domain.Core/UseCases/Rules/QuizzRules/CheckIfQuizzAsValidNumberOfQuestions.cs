using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces.Questions;
using Quizz.Domain.Core.Interfaces.Quizz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.UseCases.Rules.QuizzRules
{
    public class CheckIfQuizzAsValidNumberOfQuestions : ICheckQuizzRule<QuizRequest>
    {
        private readonly IQuizzRepository _quizzRepository;
        private string _errorMessage = string.Empty;

        private bool IsError => !string.IsNullOrWhiteSpace(_errorMessage);

        public CheckIfQuizzAsValidNumberOfQuestions(IQuizzRepository quizzRepository)
        {
            _quizzRepository = quizzRepository;
        }

        public async Task<bool> CheckRule(QuizRequest quizRequest)
        {
            var CountQuestions = _quizzRepository.GetQuestionsByQuizzId(quizRequest.Id);

            if (CountQuestions.Count > 30 || CountQuestions.Count < 2)
            {

                _errorMessage += $"Question with content '{quizRequest.NumberOfQuestion}' is not betwwen 20 and 40.";
            }

            return IsError;
        }

        public string GetErrorMessage()
        {
            return _errorMessage;
        }

    }
}
