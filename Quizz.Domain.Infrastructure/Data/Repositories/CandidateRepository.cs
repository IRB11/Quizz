using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Entities;
using Quizz.Domain.Core.Interfaces;
using Quizz.Domain.Infrastructure.Data.Entities;

namespace Quizz.Domain.Infrastructure.Data.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public CandidateRepository(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CandidateResponse> Add(CandidateRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var candidateEntity = _mapper.Map<EFCandidate>(request);
            _context.Candidates.Add(candidateEntity);
            await _context.SaveChangesAsync();

            return _mapper.Map<CandidateResponse>(candidateEntity);
        }

        public async Task<CandidateResponse> GetById(int id)
        {
            var candidateEntity = await _context.Candidates.FindAsync(id);
            return _mapper.Map<CandidateResponse>(candidateEntity);
        }

        public async Task<List<CandidateResponse>> getAll()
        {
            var candidateEntities = await _context.Candidates.ToListAsync();
            return _mapper.Map<List<CandidateResponse>>(candidateEntities);
        }

        public async Task<CandidateResponse> Update(CandidateRequest request)
        {
            EFCandidate eFCandidate = _mapper.Map<EFCandidate>(request);
            CandidateResponse candidateResponse = new CandidateResponse();

            try
            {
                EFCandidate existingCandidate = _context.Candidates.Include(r => r.Agent).SingleOrDefault(u => u.Id == request.Id);

                if (existingCandidate == null)
                {
                    candidateResponse.Id = -1;
                    candidateResponse.FirstName = "User not found.";
                    return candidateResponse;
                }
                existingCandidate.FirstName = request.FirstName;
                existingCandidate.LastName = request.LastName;
                existingCandidate.EmailAddress = request.EmailAddress;
                existingCandidate.PhoneNumber = request.PhoneNumber;

                EFUser newAgent = await _context.Users.FindAsync((int)request.AgentId);
                if (newAgent != null)
                {
                    existingCandidate.Agent = newAgent;
                }

                await _context.SaveChangesAsync();

                candidateResponse = _mapper.Map<CandidateResponse>(existingCandidate);
            }
            catch (Exception ex)
            {
                candidateResponse.Id = -1;
                candidateResponse.FirstName = $"An error occurred: {ex.Message}";
            }

            return candidateResponse;
        }

        public async Task<bool> Delete(CandidateRequest request)
        {
            var candidateEntity = await _context.Candidates.FindAsync(request.Id);
            if (candidateEntity == null) return false;
            _context.Candidates.Remove(candidateEntity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> CandidateIsUsed(CandidateRequest candidateRequest)
        {
            return await Task.FromResult(false);
        }

        public async Task<bool> CandidateAlreadyExist(CandidateRequest request)
        {
            return await _context.Candidates.AnyAsync(c => c.EmailAddress.Trim().ToLower() == request.EmailAddress.Trim().ToLower());
        }
    }
}
