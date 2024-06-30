using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.UseCases.Techno
{
    public class CreateTechno : ICreateTechno
    {
        private readonly ITechnoRepository technoRepository;
        public CreateTechno(ITechnoRepository technoRepository)
        {
            this.technoRepository = technoRepository;
        }
        public async Task<TechnologiesResponse> Handle(TechnologiesRequest technologiesRequest)
        {

            TechnologiesResponse response = await technoRepository.Add(technologiesRequest);

            return response;
        }
    }
}
