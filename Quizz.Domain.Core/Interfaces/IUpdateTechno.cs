using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.UseCases.Techno;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.Interfaces
{
    public interface IUpdateTechno : IUseCaseRequestHandler<TechnologiesRequest, TechnologiesResponse>
    {
        //Task<TechnoResponse> Handle(TechnoRequest technoRequest);
    }
}