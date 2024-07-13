using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;

namespace Quizz.Domain.Core.Interfaces.Questions
{
    public interface IGetListQuestionIdsByQuizzId : IUseCaseRequestHandler<int, List<int>>
    {

    }
}
