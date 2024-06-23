using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.UseCases.Rules
{
    public class CheckAvailabilityOfLevelId : ICheckRuleLevel<LevelRequest>
    {
        private readonly ILevelRepository levelRepository;
        private string errorMessage = string.Empty;

        private bool isError => string.IsNullOrWhiteSpace(errorMessage) ? false : true;

        public CheckAvailabilityOfLevelId( ILevelRepository levelRepository)
        {
            this.levelRepository = levelRepository;
        }

        public async Task<bool> CheckRule(LevelRequest levelRequest)
        {
            bool IsNotAvailable = await levelRepository.ContentIsNotAvailable(levelRequest.Content);

            if (IsNotAvailable)
            {
                errorMessage += $"Content {levelRequest.Content} is not available";
            }

            return isError;
        }

        public string GetErrorMessage()
        {
            return errorMessage;
        }

        public async Task<bool> CheckRule(int id)
        {
            bool IdExist = await levelRepository.IdIsNotAvailable(id);
            if (IdExist)
            {
                errorMessage += $"Id {id} is not available";
            }

            return isError;
        }
    }
}
