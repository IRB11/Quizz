

using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces;

namespace Quizz.Domain.Core.UseCases.Techno
{
    public class DeleteTechno : IDeleteTechno
    {
        private readonly ITechnoRepository _technoRepository;
        public DeleteTechno(ITechnoRepository technoRepository)
        {
            _technoRepository = technoRepository;
        }

        public async Task<TechnologiesResponse> Handle(TechnologiesRequest technoRequest)
        {

            if (technoRequest == null || string.IsNullOrEmpty(technoRequest.Name))
            {
                return null;
            }

            // Vérifier si le techno est utilisé
            if (CheckIfTechnoIsUsedAsync((int)technoRequest.Id).Result)
            {
                return new TechnologiesResponse
                {
                    Id = -1,
                    Name = "Techno is currently in use and cannot be deleted."
                };
            }

            await _technoRepository.Delete(technoRequest);

            return new TechnologiesResponse
            {
                Id = -1,
                Name = "Techno is currently in use and cannot be deleted."
            };
        }

        private async Task<bool> CheckIfTechnoIsUsedAsync(int technoId)
        {
            return await _technoRepository.TechnoIsUsed(technoId);
        }
    }
}
