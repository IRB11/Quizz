using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces;

namespace Quizz.Domain.Core.UseCases.Candidate
{
    public class UpdateCandidate : IUpdateCandidate
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IEnumerable<ICheckRuleCandidate<CandidateRequest>> _rules;

        public UpdateCandidate(ICandidateRepository CandidateRepository, IEnumerable<ICheckRuleCandidate<CandidateRequest>> rules)
        {
            _candidateRepository = CandidateRepository;
            _rules = rules;
        }

        public async Task<CandidateResponse> Handle(CandidateRequest candidateRequest)
        {
            if (CheckIfRulesAreNotOK()) return null;
            return await _candidateRepository.Update(candidateRequest);


            bool CheckIfRulesAreNotOK()
            {
                if (CheckIfRuleNotRespected(candidateRequest))
                {
                    List<string> errorList = new List<string>();
                    _rules.ToList().ForEach(r =>
                    {
                        string currentErrorMessage = r.GetErrorMessage();
                        if (!string.IsNullOrWhiteSpace(currentErrorMessage))
                        {
                            errorList.Add(currentErrorMessage);
                        }
                    });

                    return true;
                }

                return false;
            }

            bool CheckIfRuleNotRespected(CandidateRequest candidateRequest)
            {
                return _rules.Any(r => (r.CheckRule(candidateRequest)).ConfigureAwait(false).GetAwaiter().GetResult() == true);
            }

        }
    }
}









