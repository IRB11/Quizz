using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.UseCases.Candidate
{
    public class GetAllCandidate : IGetAllCandidates
    {
        private readonly ICandidateRepository _candidateRepository;

        public GetAllCandidate()
        {
        }

        public GetAllCandidate(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }
        public async Task<List<CandidateResponse>> Handle()
        {
            return await _candidateRepository.getAll();
        }

    }
}
