/*using Quizz.Domain.Core.Dto;

namespace Quizz.Domain.Core.UseCases.Candidate
{
    public interface ICandidateRepository
    {
        Task<bool> CandidateAlreadyExit(CandidateRequest candidateRequest);
        Task<CandidateResponse> Update(CandidateRequest candidateRequest);
    }
}*/

using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.Interfaces
{
    public interface ICandidateRepository : ICRUDRepository<CandidateRequest, CandidateResponse>
    {
        //Task<CandidateResponse> AddAsync(CandidateRequest candidate);
        //Task<IEnumerable<CandidateResponse>> GetAllAsync();
        //Task<CandidateResponse> GetByIdAsync(int id);
        //Task<bool> UpdateAsync(Candidate candidate);
        //Task<bool> DeleteAsync(int id);
        Task<bool> CandidateIsUsed(CandidateRequest candidateRequest);
        //Task<bool> DeleteAsync(long? id);
        //Task UpdateAsync(CandidateRequest candidateRequest);
        Task<bool> CandidateAlreadyExist(CandidateRequest candidateRequest);
        //Task<List<CandidateResponse>> GetAll();
    }
}