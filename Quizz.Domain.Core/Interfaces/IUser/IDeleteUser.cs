using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;

namespace Quizz.Domain.Core.Interfaces.IUser
{
    public interface IDeleteUser : IUseCaseRequestHandler<UserRequest, UserResponse>
    {
    }
}
