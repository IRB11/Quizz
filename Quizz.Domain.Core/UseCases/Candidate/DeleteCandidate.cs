using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces;
using Quizz.Domain.Core.UseCases.Candidate;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.UseCases.Candidate
{
    public class DeleteCandidate : IDeleteCandidate
    {
        private readonly ICandidateRepository candidateRepository;
        private readonly List<ICheckRuleCandidate<CandidateRequest>> rules;

        public DeleteCandidate(ICandidateRepository candidateRepository, List<ICheckRuleCandidate<CandidateRequest>> rules)
        {
            this.candidateRepository = candidateRepository;
            this.rules = rules;
        }

        public async Task<CandidateResponse> Handle(CandidateRequest candidateRequest)
        {
            if (CheckIfCandidateIsUsed(candidateRequest))
            {

                await candidateRepository.Update(candidateRequest);
                return new CandidateResponse()
                {
                    Id = (long)candidateRequest.Id,
                    EmailAdress = candidateRequest.EmailAddress,
                    FirstName = candidateRequest.FirstName,
                    Lastname =candidateRequest.Lastname,
                    PhoneNumber = candidateRequest.PhoneNumber,
                };
            }

            try
            {
                // Attempt to delete the candidate
                bool success = await candidateRepository.Delete(candidateRequest);

                if (!success)
                {
                    return new CandidateResponse
                    {
                        Id = -1,
                        FirstName = "Candidate could not be deleted because it does not exist."
                    };
                }

                // Return success response
                return new CandidateResponse
                {
                    Id = (long)candidateRequest.Id,
                    FirstName = "Candidate deleted successfully."
                };
            }
            catch (ArgumentNullException ex)
            {
                // Handle the case where candidateRequest is null
                return new CandidateResponse
                {
                    Id = -1,
                    FirstName = $"ArgumentNullException: {ex.Message}"
                };
            }
            catch (Exception ex)
            {
                // Handle any other exceptions that might occur
                return new CandidateResponse
                {
                    Id = -1,
                    FirstName = $"An error occurred: {ex.Message}"
                };
            }

            #region local methods

            bool CheckIfCandidateIsUsed(CandidateRequest candidateRequest)
            {
                return candidateRepository.CandidateIsUsed(candidateRequest).ConfigureAwait(false).GetAwaiter().GetResult();
            }

            #endregion
        }
    }
}