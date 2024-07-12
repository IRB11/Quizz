using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.UseCases.Rules.CandidateRules
{
    public class CheckIfCandidateAlreadyExist : ICheckRuleCandidate<CandidateRequest>
    {
        public Task<bool> CheckRule(CandidateRequest request)
        {
            throw new NotImplementedException();
        }

        public string GetErrorMessage()
        {
            throw new NotImplementedException();
        }
    }
}
