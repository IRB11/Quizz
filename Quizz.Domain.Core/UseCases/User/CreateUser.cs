using AutoMapper;
using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces.IUser;
using Quizz.Domain.Core.Services;

namespace Quizz.Domain.Core.UseCases.User
{
    public class CreateUser : ICreateUser
    {
        private readonly IUserRepository userRepository;
        private readonly IEnumerable<ICheckRuleUser<UserRequest>> rules;
        private readonly JWTService jwtService;


        public CreateUser(IUserRepository userRepository, JWTService jWTService, IEnumerable<ICheckRuleUser<UserRequest>> rules)
        {
            this.rules = rules;
            this.userRepository = userRepository;
            jwtService = jWTService;
        }

        public async Task<UserResponse> Handle(UserRequest createUserRequest)
        {
            if (CheckIfRulesAreNotOK()) return null;

            var response = await userRepository.Add(createUserRequest);

            if (response == null)
            {
                return null;
            }

            response.Token = jwtService.GetToken(response);

            return response;

            #region Rules
            bool CheckIfRulesAreNotOK()
            {
                if (CheckIfRuleNotRespected(createUserRequest))
                {
                    List<string> errorList = new List<string>();
                    rules.ToList().ForEach(r =>
                    {
                        string currentErrorMessage = r.GetErrorMessage();
                        if (!string.IsNullOrWhiteSpace(currentErrorMessage))
                        {
                            errorList.Add(currentErrorMessage);
                        }
                    });

                    return true;
                }

                return false;
            }

            bool CheckIfRuleNotRespected(UserRequest userRequest)
            {
                return rules.Any(r => r.CheckRule(userRequest).ConfigureAwait(false).GetAwaiter().GetResult() == true);
            }
            #endregion
        }
    }
}
