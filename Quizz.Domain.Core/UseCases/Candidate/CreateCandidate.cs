using System.Threading.Tasks;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Entities;
using Quizz.Domain.Core.Interfaces;


namespace Quizz.Domain.Core.UseCases.Candidate
{
    public class CreateCandidate : ICreateCandidate
    {
        private readonly ICandidateRepository candidateRepository;

        public CreateCandidate(ICandidateRepository candidateRepository)
        {
            this.candidateRepository = candidateRepository;
        }         

        public async Task<CandidateResponse> Handle(CandidateRequest candidateRequest)
        {
            bool CandidateExist = await candidateRepository.CandidateAlreadyExist(candidateRequest);
            if (!CandidateExist)
            {
                var response = await candidateRepository.Add(candidateRequest);

                return response;
            }
            else return null;

        }
    
    }


    
     
    

}