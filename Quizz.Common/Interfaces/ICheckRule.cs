using System.Threading.Tasks;

namespace Quizz.Common.Interfaces
{
    public interface ICheckRule<in TUseCaseRequest>
    {
        string GetErrorMessage();
        Task<bool> CheckRule(TUseCaseRequest levelRequest);
    }
}
