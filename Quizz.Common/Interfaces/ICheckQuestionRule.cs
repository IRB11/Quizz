using System.Threading.Tasks;

namespace Quizz.Common.Interfaces
{
    public interface ICheckQuestionRule<in TUseCaseRequest>
    {
        string GetErrorMessage();
        Task<bool> CheckRule(TUseCaseRequest request);
    }
}
