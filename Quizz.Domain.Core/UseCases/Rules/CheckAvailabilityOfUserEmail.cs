using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces.IUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.UseCases.Rules
{
    public class CheckAvailabilityOfUserEmail : ICheckRuleUser<UserRequest>
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
            var OldUserInfo = await userRepository.GetById((int)userRequest.Id);

            if (OldUserInfo!= null && OldUserInfo.EmailAddress != userRequest.EmailAddress )
            {
                if (userRequest == null) { }
                bool EmailAlreadyExist = await userRepository.EmailAlreadyExist(userRequest.EmailAddress);

                if (EmailAlreadyExist)
                {
                    errorMessage += $"Email {userRequest.EmailAddress} is not available";
                }
                return isError;
            }
            return false;
        }

        public async Task<bool> CheckRule(int id)
        {
            bool IdExist = await userRepository.IdIsNotAvailable(id);
            if (!IdExist)
            {
                errorMessage += $"Id {id} is not available";
            }

            return isError;
        }
    }
}
