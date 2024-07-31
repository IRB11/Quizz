using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces;

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