using System.Threading.Tasks;

namespace Quizz.Common.Interfaces
{
    public interface ICheckRuleLevel<in TUseCaseRequest>
    {
        string GetErrorMessage();
        Task<bool> CheckRule(TUseCaseRequest LevelRequest);
        Task<bool> CheckRule(int id);
    }
}
