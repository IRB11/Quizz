using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.UseCases.Techno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.Interfaces
{
    public interface ITechnoRepository
    {
        Task<List<TechnologiesResponse>> GetAll();
        Task<TechnologiesResponse> Add(TechnologiesRequest request);
        Task<TechnologiesResponse> GetTechnoById(int id);
        Task<TechnologiesResponse> GetByIdAsync(int id);
        Task<TechnologiesResponse> DeleteAsync(TechnologiesRequest techno);
        Task<bool> TechnoIsUsed(int technoId);
        Task<TechnologiesResponse> Update(TechnologiesRequest technoRequest);
    }
}
