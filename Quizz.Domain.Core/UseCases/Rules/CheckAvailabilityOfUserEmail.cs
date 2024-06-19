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
    public class CheckAvailabilityOfUserEmail : ICheckRule<UserRequest>
    {
        private readonly IUserRepository userRepository;
        private string errorMessage = string.Empty;

        private bool isError => string.IsNullOrWhiteSpace(errorMessage) ? false : true;

        public CheckAvailabilityOfUserEmail( IUserRepository uSerRepository)
        {
            this.userRepository = uSerRepository;
        }
        public string GetErrorMessage()
        {
            return errorMessage;
        }
        public async Task<bool> CheckRule(UserRequest userRequest)
        {
            bool IsNotAvailable = await userRepository.EmailIsNotAvailable(userRequest.EmailAddress);

            if(IsNotAvailable)
            {
                errorMessage += $"Email {userRequest.EmailAddress} is not available";
            }
            return isError;
        }
    }
}
