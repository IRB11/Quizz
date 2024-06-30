using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.Interfaces
{ 

    public interface IGetTechnoById : IUseCaseRequestHandler<int, TechnologiesResponse>
    {
        
    }
}
