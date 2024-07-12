using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Entities;



namespace Quizz.Domain.Core.Interfaces
{
    public interface ICreateCandidate : IUseCaseRequestHandler<CandidateRequest, Dto.CandidateResponse>
    {
        Task<Dto.CandidateResponse> Handle(CandidateRequest candidateRequest);
    }
}
