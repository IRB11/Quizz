using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces;
using Quizz.Domain.Core.Interfaces.Quizz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.UseCases.Quizz
{
    public class GetQuizzById : IGetQuizzById
    {
       private readonly IQuizzRepository _quizzRepository;

        public GetQuizzById(IQuizzRepository quizzRepository)
        {
            _quizzRepository = quizzRepository;
        }
        public async Task<QuizResponse> Handle(int id)
        {
           return await  _quizzRepository.GetById(id);
        }
    }
}
