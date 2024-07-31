using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces.IUser;
using Quizz.Domain.Core.Services;

namespace Quizz.Domain.Core.UseCases.User
{
    public class LoginUser : ILoginUser
    {
        private readonly IEnumerable<ICheckRule<UserRequest>> rules;
        private readonly IUserRepository userRepository;
        private readonly JWTService jWTService;

        public LoginUser(IUserRepository userRepository, JWTService jWTService)
        {
            this.userRepository = userRepository;
            this.jWTService = jWTService;
        }

        public async Task<UserResponse> Handle(LoginRequest authenticateRequest)
        {
            var user = await userRepository.GetByEmailAndPassword(authenticateRequest);

            if (user == null) return null;


            user.Token = jWTService.GetToken(user);
            try
            {
                userRepository.UpdateToken(user.Id, user.Token);
            }
            catch (Exception e)
            {

                throw e;
            }

            return user;
        }
    }
}
