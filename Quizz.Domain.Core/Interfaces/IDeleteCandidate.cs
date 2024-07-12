using Quizz.Domain.Core.Dto;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.Interfaces
{
    public interface IDeleteCandidate
    {
        Task<CandidateResponse> Handle(CandidateRequest candidateRequest);
    }
}