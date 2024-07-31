using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.UseCases.Rules.CandidateRules
{
    public class CheckIfCandidateAlreadyExist : ICheckRuleCandidate<CandidateRequest>
    {
        private readonly ICandidateRepository _candidateRepository;
        private string errorMessage = string.Empty;

        private bool isError => string.IsNullOrWhiteSpace(errorMessage) ? false : true;
        public CheckIfCandidateAlreadyExist(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }
        public async Task<bool> CheckRule(CandidateRequest request)
        {
            var OldUserInfo = await _candidateRepository.GetById((int)request.Id);

            if (OldUserInfo != null && OldUserInfo.EmailAddress != request.EmailAddress)
            {
                if (request == null) { }
                bool EmailAlreadyExist = await _candidateRepository.CandidateAlreadyExist(request);

                if (EmailAlreadyExist)
                {
                    errorMessage += $"Email {request.EmailAddress} is not available";
                }
                return isError;
            }
            return false;
        }

        public string GetErrorMessage()
        {
            throw new NotImplementedException();
        }
    }
}
