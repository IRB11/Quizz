using AutoMapper;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Entities;
using Quizz.Domain.Core.Interfaces;
using Quizz.Domain.Core.UseCases.Techno;
using Quizz.Domain.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Infrastructure.Data.Repositories
{
    public class TechnoRepository : ITechnoRepository
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public TechnoRepository(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<TechnologiesResponse> Add(TechnologiesRequest request)
        {
            // Si Techno est null envoie une exception
            if (request == null) throw new ArgumentNullException(nameof(request));

            //mapping en EfTechno
            var EfTechno = _mapper.Map<EFTechnology>(request);

            // sauvegarde en base de donnée
            _context.Add(EfTechno);
            _context.SaveChanges();

            //mapping inverse pour renvoie au front
            TechnologiesResponse technoResponse = _mapper.Map<TechnologiesResponse>(EfTechno);
            return technoResponse;
        }

        public Task DeleteAsync(object techno)
        {
            throw new NotImplementedException();
        }

        public Task<TechnologiesResponse> DeleteAsync(TechnologiesRequest techno)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TechnologiesResponse>> GetAll()
        {
            var efTechnos = _context.Technologies.ToList();
            var technos = _mapper.Map<List<TechnologiesResponse>>(efTechnos);
            return technos;
        }

        public Task<TechnologiesResponse> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TechnologiesResponse> GetTechnoById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> TechnoIsUsed(int technoId)
        {
            return Task.Run( () => _context.Questions.Any(q => q .TechnologyId == technoId) || _context.Quizzes.Any(qz => qz.TechnologyId == technoId));
        }

        public Task<TechnologiesResponse> Update(TechnologiesRequest technoRequest)
        {
            throw new NotImplementedException();
        }
    }
}
