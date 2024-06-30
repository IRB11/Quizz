

 using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

            // Supprimer le techno
            //var techno = await _technoRepository.GetByIdAsync(technoRequest.Id);
            //if (techno == null)
            //{
            //    return new TechnologiesResponse
            //    {
            //        Success = false,
            //        Message = "Techno not found."
            //    };
            //}

            await _technoRepository.DeleteAsync(technoRequest);

            return new TechnologiesResponse
            {
                Id = -1,
                Name = "Techno is currently in use and cannot be deleted."
            };
        }

        private async Task<bool> CheckIfTechnoIsUsedAsync(int technoId)
        {
            // Implémentez la logique pour vérifier si le techno est utilisé.
            // Cela pourrait impliquer de vérifier d'autres entités qui utilisent ce techno.
            // Creer une methode dans techno repository IsTechnoUsed qui renvoi un bool 
            return await _technoRepository.TechnoIsUsed(technoId);
            // return _technoRepository.TechnoIsUsed(technoId).ConfigureAwait(false).GetAwaiter().GetResult; // Modifier cette ligne en fonction de la logique réelle.
        }
    }
}  
 