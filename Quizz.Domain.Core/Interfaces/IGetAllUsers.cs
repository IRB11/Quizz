using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;

namespace Quizz.Domain.Core.Interfaces
{
    public interface IGetAllUsers : IUseCaseRequestHandler<List<UserResponse>>
    {
    }
}
