
using Quizz.Domain.Core.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.Interfaces
{
    public interface IGetAllCandidates
    {
        Task<List<CandidateResponse>> Handle();
    }
}