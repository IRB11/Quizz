using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces.IUser;

namespace Quizz.Domain.Core.UseCases.User
{
    public class UpdateUser : IUpdateUser
    {
        private readonly IEnumerable<ICheckRuleUser<UserRequest>> _rules;
        private readonly IUserRepository _userRepository;

        public UpdateUser(IUserRepository userRepository, IEnumerable<ICheckRuleUser<UserRequest>> rules)
        {
            _userRepository = userRepository;
            _rules = rules;
        }
        public async Task<UserResponse> Handle(UserRequest userRequest)
        {
            if (CheckIfRulesAreNotOK()) return null;

            return await _userRepository.Update(userRequest);



            bool CheckIfRulesAreNotOK()
            {
                if (CheckIfRuleNotRespected(userRequest))
                {
                    List<string> errorList = new List<string>();
                    _rules.ToList().ForEach(r =>
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
                return _rules.Any(r => r.CheckRule(userRequest).ConfigureAwait(false).GetAwaiter().GetResult() == true);
            }
        }
    }
}
