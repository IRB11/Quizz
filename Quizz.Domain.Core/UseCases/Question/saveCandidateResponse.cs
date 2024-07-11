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
    public class saveCandidateResponse : ISaveCandidateResponse
    {
        private readonly IQuestionRepository _questionRepository;

        public saveCandidateResponse(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }
        public async Task<bool> Handle(CandidateResponse_Request request)
        {
           var SaveBool =  _questionRepository.SaveCandidateResponseToQuizz(request);
            if (SaveBool.IsCompleted)
            {
                return true;
            }
            else return false;
        }
    }
}
