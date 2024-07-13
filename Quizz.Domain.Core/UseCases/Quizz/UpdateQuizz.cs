using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces.Quizz;

namespace Quizz.Domain.Core.UseCases.Quizz
{
    public class UpdateQuizz : IUpdateQuizz
    {
        private readonly IQuizzRepository _quizzRepository;
        public UpdateQuizz(IQuizzRepository quizzRepository)
        {
            _quizzRepository = quizzRepository;
        }
        public Task<QuizResponse> Handle(QuizRequest request)
        {
            return _quizzRepository.Update(request);
        }
    }
}
