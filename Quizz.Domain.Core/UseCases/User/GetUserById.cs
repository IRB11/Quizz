using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces.IUser;

namespace Quizz.Domain.Core.UseCases.User
{
    public class GetUserById : IGetUserById
    {
        private readonly IUserRepository _userRepository;
        private readonly IEnumerable<ICheckRuleUser<UserRequest>> _rules;

        public GetUserById(IUserRepository userRepository, IEnumerable<ICheckRuleUser<UserRequest>> checkRules)
        {
            _rules = checkRules;
            _userRepository = userRepository;
        }
        public async Task<UserResponse> Handle(int id)
        {
            if (CheckIfRulesAreNotOK()) return null;

            return await _userRepository.GetById(id);



            bool CheckIfRulesAreNotOK()
            {
                if (CheckIfRuleNotRespected(id))
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

            bool CheckIfRuleNotRespected(int id)
            {
                return _rules.Any(r => r.CheckRule(id).ConfigureAwait(false).GetAwaiter().GetResult() == true);
            }
        }
    }
}
