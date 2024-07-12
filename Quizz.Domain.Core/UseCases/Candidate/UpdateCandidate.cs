using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.UseCases.Candidate
{
    public class UpdateCandidate : IUpdateCandidate
    {
        //private readonly IEnumerable<ICandidateRepository<CandidateRequest>> _rules;
        private readonly ICandidateRepository _candidateRepository;
        //private ICandidateRepository _candidateRepository;

        public UpdateCandidate(ICandidateRepository CandidateRepository)
        {
            _candidateRepository = CandidateRepository;
        }

        public async Task<CandidateResponse> Handle(CandidateRequest candidateRequest)
        {
            if (await CheckIfRulesAreNotOKAsync(candidateRequest)) return null;
            return await _candidateRepository.Update(candidateRequest);
            
            async Task<bool> CheckIfRulesAreNotOKAsync(CandidateRequest candidateRequest)
            {
               bool IsExist = await _candidateRepository.CandidateAlreadyExist(candidateRequest);
                return IsExist;
            }
        }

    }

}

   

         
        


            
 
