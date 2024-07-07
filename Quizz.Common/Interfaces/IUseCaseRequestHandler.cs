using System.Threading.Tasks;

namespace Quizz.Common.Interfaces
{
    public interface IUseCaseRequestHandler<in TUseCaseRequest, TResponse>
    {
        Task<TResponse> Handle(TUseCaseRequest request);
    }
    public interface IUseCaseRequestHandler<TResponse>
    {
        Task<TResponse> Handle();
    }
}
