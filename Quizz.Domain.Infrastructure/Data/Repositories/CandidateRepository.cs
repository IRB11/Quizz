/*using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Entities;
using Quizz.Domain.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Quizz.Domain.Core.Interfaces;
using AutoMapper;
using Quizz.Domain.Infrastructure.Data.Entities;

namespace Quizz.Domain.Infrastructure.Data.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly Context context;
        private readonly IMapper mapper;

        public CandidateRepository(Context context, IMapper mapper) : base()
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<CandidateRequest> Add(CandidateRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var Efcandidate = mapper.Map<CandidateRequest>(request);

            context.Add(Efcandidate);
            context.SaveChanges();

            TechnologiesResponse technologiesResponse = mapper.Map<TechnologiesResponse>(request);
            return CandidateResponse;
        }
        public async Task<TechnologiesResponse> GetCandidatById(int id)
        {
            var efCandidate = context.Technologies.FirstOrDefault(t => t.Id == id);
            var candidate = mapper.Map<TechnologiesResponse>(efCandidate);
            return candidate;

        }

        public Task<bool> CandidateAlreadyExist(TechnologiesRequest technologiesRequest)
        {
            return Task.Run(() => context.Technologies.Any(q => q.Name.Trim().ToLower() == technologiesRequest.Name.Trim().ToLower()));
        }

        public Task<bool> CandidateISUser(int candidateId)
        {
            return Task.Run(() => context.Questions.Any(q => q.Id == candidateId)) || context.Quizzes.Any(qz => qz.Id == candidateId);
        }

        public async Task<TechnologiesResponse> Update(TechnologiesRequest candidateRequest);
        
        {
         EFTechnology eFTechnology = mapper.Map<EFTechnology>(candidateRequest);
        TechnologiesResponse technologiesResponse = null;
        try
        { await Task.Run(() =>
                                                            
         {
            _context.Technologies.Update(eFTechnology);
            _context.SaveChangesAsync();

            catch (Exception ex)
            {
                technologiesResponse.Id = -1;
                technologiesResponse.Name = $"An error occurred: {ex.Message}";
            }
            technologiesResponse = mapper.Map<TechnologiesResponse>(eFTechnology);

            return technologiesResponse;

        }
        }




        }

    }

}*/



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
            if (request == null) throw new ArgumentNullException(nameof(request));

            var candidateEntity = _mapper.Map<EFCandidate>(request);
            _context.Candidates.Update(candidateEntity);
            await _context.SaveChangesAsync();
            return _mapper.Map<CandidateResponse>(candidateEntity);
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
            // Implémentez la logique pour vérifier si le candidat est utilisé
            return await Task.FromResult(false);
        }

        public async Task<bool> CandidateAlreadyExist(CandidateRequest request)
        {
            return await _context.Candidates.AnyAsync(c => c.EmailAddress.Trim().ToLower() == request.EmailAddress.Trim().ToLower());
        }
    }
}
