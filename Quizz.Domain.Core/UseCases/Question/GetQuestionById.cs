using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.UseCases.Question
{
    public class GetQuestionById : IGetQuestionById
    {
        private readonly IQuestionRepository _questionRepository;
        public GetQuestionById(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<QuestionResponse> Handle(int id)
        {
            return await _questionRepository.GetById(id);
        }
    }
}
