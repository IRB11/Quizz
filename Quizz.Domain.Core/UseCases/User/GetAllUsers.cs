using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces.IUser;

namespace Quizz.Domain.Core.UseCases.User
{
    public class GetAllUsers : IGetAllUsers
    {
        private readonly IUserRepository _userRepository;
        private readonly IEnumerable<ICheckRuleUser<UserRequest>> _rules;

        public GetAllUsers(IUserRepository userRepository, IEnumerable<ICheckRuleUser<UserRequest>> ruleUsers)
        {
            _userRepository = userRepository;
            _rules = ruleUsers;

        }
        public Task<List<UserResponse>> Handle()
        {
            return _userRepository.getAll();
        }
    }
}
