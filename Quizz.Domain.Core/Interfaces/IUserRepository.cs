using Quizz.Domain.Core.Dto;

namespace Quizz.Domain.Core.Interfaces
{
    public interface IUserRepository : ICRUDRepository<UserRequest, UserResponse>
    {
        Task<bool> EmailAlreadyExist(string? email);
        Task<UserResponse> GetByEmailAndPassword(LoginRequest authenticateRequest);
        Task<bool> IdIsNotAvailable(int id);
        void UpdateToken(int? id, string token);
        Task<bool> UserIsUsed(UserRequest userRequest);
    }
}