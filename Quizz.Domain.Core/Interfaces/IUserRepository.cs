using Quizz.Domain.Core.Dto;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> EmailIsNotAvailable(string? email);
        Task<UserResponse> CreateUser(UserRequest createUserRequest);
        Task<UserResponse> GetByEmailAndPassword(LoginRequest authenticateRequest);
        void UpdateToken(int? id, string token);
    }
}