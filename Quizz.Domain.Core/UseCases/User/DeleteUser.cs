using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces.IUser;

namespace Quizz.Domain.Core.UseCases.User
{
    public class DeleteUser : IDeleteUser
    {
        private readonly IUserRepository _userRepository;
        private readonly List<ICheckRuleUser<UserRequest>> _rules;

        public DeleteUser(IUserRepository userRepository, List<ICheckRuleUser<UserRequest>> rules)
        {
            _rules = rules;
            _userRepository = userRepository;
        }
        public async Task<UserResponse> Handle(UserRequest userRequest)
        {
            if (CheckIfUserIsUsed(userRequest))
            {
                userRequest.IsActive = false;
                await _userRepository.Update(userRequest);
                return new UserResponse()
                {

                };
            }

            try
            {
                // Attempt to delete the level
                bool success = await _userRepository.Delete(userRequest);

                if (!success)
                {
                    return new UserResponse
                    {
                        Id = -1,
                        FirstName = "User could not be deleted because it does not exist."
                    };
                }

                // Return success response
                return new UserResponse
                {
                    Id = -1,
                    FirstName = "User deleted successfully."
                };
            }
            catch (ArgumentNullException ex)
            {
                // Handle the case where levelRequest is null
                return new UserResponse
                {
                    Id = -1,
                    FirstName = $"ArgumentNullException: {ex.Message}"
                };
            }
            catch (Exception ex)
            {
                // Handle any other exceptions that might occur
                return new UserResponse
                {
                    Id = -1,
                    FirstName = $"An error occurred: {ex.Message}"
                };
            }

            #region local methods

            bool CheckIfUserIsUsed(UserRequest userRequest)
            {
                return _userRepository.UserIsUsed(userRequest).ConfigureAwait(false).GetAwaiter().GetResult();
            }
            #endregion
        }
    }
}
