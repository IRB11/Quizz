using System.Threading.Tasks;

namespace Quizz.Common.Interfaces
{
    public interface ICheckRuleUser<in TUseCaseRequest>
    {
        string GetErrorMessage();
        Task<bool> CheckRule(TUseCaseRequest UserRequest);
        Task<bool> CheckRule(int id);
    }
}
