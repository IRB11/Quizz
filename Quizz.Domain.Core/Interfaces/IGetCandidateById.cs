using Quizz.Domain.Core.Dto;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.Interfaces
{
    public interface IGetCandidateById
    {
        Task<CandidateResponse> Handle(int id);
    }
}