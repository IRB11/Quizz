using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.UseCases.Question
{
    public class GetListQuestionsByQuizzId : IGetListQuestionByQuizzId
    {
        private IQuestionRepository questionRepository;

        public GetListQuestionsByQuizzId(IQuestionRepository questionRepository)
        {
            this.questionRepository = questionRepository;
        }
        public async Task<List<QuestionResponse>> Handle(int QuizzId)
        {
            var response = await questionRepository.GetListQuestionsByQuizzId(QuizzId);
            return response;
        }
    }
}
