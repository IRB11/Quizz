using System.Threading.Tasks;

namespace Quizz.Common.Interfaces
{
    public interface IUseCaseRequestHandler<in TUseCaseRequest, TResponse>
    {
        Task<TResponse> Handle(TUseCaseRequest message);
    }
    public interface IUseCaseRequestHandler<TResponse>
    {
        Task<TResponse> Handle();
    }
}
