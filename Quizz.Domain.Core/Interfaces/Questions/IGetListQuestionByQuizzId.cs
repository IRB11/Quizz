using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;

namespace Quizz.Domain.Core.Interfaces.Questions
{
    public interface IGetListQuestionByQuizzId : IUseCaseRequestHandler<int, List<QuestionResponse>>
    {

    }
}
