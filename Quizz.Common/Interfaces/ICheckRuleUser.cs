using System.Threading.Tasks;

namespace Quizz.Common.Interfaces
{
    public interface ICheckRuleUser<in TUseCaseRequest>
    {
        string GetErrorMessage();
        Task<bool> CheckRule(TUseCaseRequest UserRequest);
    }
}
