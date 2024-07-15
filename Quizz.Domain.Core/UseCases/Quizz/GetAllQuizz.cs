using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces.Quizz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.UseCases.Quizz
{
    public class GetAllQuizz : IGetAllQuizz
    {
        private readonly IQuizzRepository _quizzRepository;

        public GetAllQuizz(IQuizzRepository quizzRepository)
        {
            _quizzRepository = quizzRepository;
        }
        public async Task<List<QuizResponse>> Handle()
        {
            return await _quizzRepository.getAll();
        }
    }
}
