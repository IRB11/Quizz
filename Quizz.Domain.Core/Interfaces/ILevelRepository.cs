using Quizz.Domain.Core.Dto;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.Interfaces
{
    public interface ILevelRepository
    {
        Task<LevelResponse> Add(LevelRequest levelRequest);
        Task<bool> ContentIsNotAvailable(string Content);
        Task<bool> IdIsNotAvailable(long? id);
    }
}