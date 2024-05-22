using Microsoft.AspNetCore.Razor.TagHelpers;
using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.UseCases.Rules
{
    public class CheckAvailabilityOfIdentifiant : ICheckRule<LevelRequest>
    {
        private readonly ILevelRepository levelRepository;
        private string errorMessage = string.Empty;

        private bool isError => string.IsNullOrWhiteSpace(errorMessage) ? false : true;

        public CheckAvailabilityOfIdentifiant(ILevelRepository levelRepository)
        {
            this.levelRepository = levelRepository;
        }

        public string GetErrorMessage()
        {
            return errorMessage;
        }

        public async Task<bool> CheckRule(LevelRequest levelRequest)
        {
           bool IsNotAvailable = await levelRepository.IdIsNotAvailable(levelRequest.Id);

           if(IsNotAvailable)
            {
                errorMessage += $"Id {levelRequest.Id} is not available";
            }
           return isError;
        }
    }
}
