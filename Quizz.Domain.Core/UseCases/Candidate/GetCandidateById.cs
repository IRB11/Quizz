/*using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.UseCases.Candidate
{
     
    public class GetCandidateById : IGetCandidateById
    {
        public Task<CandidateResponse> Handle(int id)
        {
            throw new NotImplementedException();
        }
    }
}*/

using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.UseCases.Candidate
{
    public class GetCandidateById : IGetCandidateById
    {
        private readonly ICandidateRepository _candidateRepository;

        public GetCandidateById(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public async Task<CandidateResponse> Handle(int id)
        {
            if (CheckIfRulesAreNotOK()) return null;

            return await _candidateRepository.GetById(id);

            bool CheckIfRulesAreNotOK()
            {
                if (id <= 0) return true;
                else return false;
            }
        }
    }
}