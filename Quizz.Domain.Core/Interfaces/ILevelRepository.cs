using Quizz.Domain.Core.Dto;

namespace Quizz.Domain.Core.Interfaces
{
    public interface ILevelRepository
    {
        Task<LevelResponse> Add(LevelRequest levelRequest);
        Task<bool> ContentIsNotAvailable(string Content);
        Task<bool> DeleteLevel(LevelRequest levelRequest);
        Task<List<LevelResponse>> getAllLevels();
        Task<LevelResponse> GetLevelById(int id);
        Task<bool> IdIsNotAvailable(long? id);
        Task<bool> levelIsUsed(LevelRequest levelRequest);
        Task<LevelResponse> Update(LevelRequest levelRequest);
    }
}