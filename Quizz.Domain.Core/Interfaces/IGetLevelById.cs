using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;

namespace Quizz.Domain.Core.Interfaces
{
    public interface IGetLevelById : IUseCaseRequestHandler<int, LevelResponse>
    {
    }
}