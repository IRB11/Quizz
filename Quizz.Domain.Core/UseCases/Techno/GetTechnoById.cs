using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces;

namespace Quizz.Domain.Core.UseCases.Techno
{
    public class GetTechnoById : IGetTechnoById
    {
        private readonly ITechnoRepository _technoRepository;

        public GetTechnoById(ITechnoRepository technoRepository)
        {
            _technoRepository = technoRepository;

        }

        public async Task<TechnologiesResponse> Handle(int id)
        {
            if (CheckIfRulesAreNotOK()) return null;

            return await _technoRepository.GetTechnoById(id);

            bool CheckIfRulesAreNotOK()
            {
                if (id == -1) return true;
                else return false;
            }
        }
    }
}
