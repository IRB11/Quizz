using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.UseCases.Question
{
    public class GetAllQuestion : IGetAllQuestion
    {
        IQuestionRepository _questionRepository;
        IEnumerable<ICheckQuestionRule<QuestionRequest>> _rules;
        public GetAllQuestion(IQuestionRepository questionRepository, IEnumerable<ICheckQuestionRule<QuestionRequest>>  rules)
        {
            _questionRepository = questionRepository;
            _rules = rules;
        }
        public async Task<List<QuestionResponse>> Handle()
        {
           return await _questionRepository.getAll();
        }
    }
}
