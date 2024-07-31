using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;

namespace Quizz.Domain.Core.Interfaces.IUser
{
    public interface ICreateUser : IUseCaseRequestHandler<UserRequest, UserResponse>
    {
    }
}