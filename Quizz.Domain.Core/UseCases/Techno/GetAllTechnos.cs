using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.UseCases.Techno
{
    public class GetAllTechnos : IGetAllTechnos
    {
        private ITechnoRepository _technoRepository;

        public GetAllTechnos(ITechnoRepository technoRepository)
        {
            _technoRepository = technoRepository;
        }
        public async Task<List<TechnologiesResponse>> Handle()
        {
            return await _technoRepository.GetAll();
        }
    }
}
