using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.Interfaces
{
    public interface ICandidateRepository : ICRUDRepository<CandidateRequest, CandidateResponse>
    {
        Task<bool> CandidateIsUsed(CandidateRequest candidateRequest);
        Task<bool> CandidateAlreadyExist(CandidateRequest candidateRequest);
    }
}