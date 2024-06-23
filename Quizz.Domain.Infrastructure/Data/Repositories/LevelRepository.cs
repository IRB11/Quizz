using AutoMapper;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces;
using Quizz.Domain.Infrastructure.Data.Entities;

namespace Quizz.Domain.Infrastructure.Data.Repositories
{
    public class LevelRepository : ILevelRepository
    {
        private readonly Context context;
        private readonly IMapper mapper;

        public LevelRepository(Context context, IMapper mapper) : base()
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<LevelResponse> Add(LevelRequest levelRequest)
        {
            EFLevel eFLevel = mapper.Map<EFLevel>(levelRequest);
            this.context.Levels.Add(eFLevel);
            await this.context.SaveChangesAsync();
            LevelResponse levelResponse = mapper.Map<LevelResponse>(eFLevel);
            return levelResponse;
        }

        public Task<bool> ContentIsNotAvailable(string Content)
        {
            return Task.Run(() => context.Levels.Any(f => f.Content.ToLower().Equals(Content.ToLower())));
        }

        public async Task<bool> DeleteLevel(LevelRequest levelRequest)
        {
            if (context.Levels.Any(l => l.Id == levelRequest.Id))
            {
                EFLevel eFLevel = mapper.Map<EFLevel>(levelRequest);
                context.Levels.Remove(eFLevel);
                context.SaveChanges();
                return true;
            }
            else return false;
        }

        public async Task<List<LevelResponse>> getAllLevels()
        {
            var efLevels = context.Levels.ToList();
            var levels = mapper.Map<List<LevelResponse>>(efLevels);

            return levels;
        }

        public async Task<LevelResponse> GetLevel(int id)
        {
            EFLevel eFLevel = context.Levels.FirstOrDefault(l => l.Id == id);
            LevelResponse levelResponse = mapper.Map<LevelResponse>(eFLevel);
            return levelResponse;
        }

        public Task<bool> IdIsNotAvailable(long? id)
        {
            return Task.Run(() => context.Levels.Any(f => f.Id == id));
        }

        public Task<bool> levelIsUsed(LevelRequest levelRequest)
        {
            return Task.Run(() => context.Questions.Any(f => f.Level.Id == levelRequest.Id));
        }

        public async Task<LevelResponse> Update(LevelRequest levelRequest)
        {
            EFLevel efLevel = mapper.Map<EFLevel>(levelRequest);
            LevelResponse levelResponse = null;
            try
            {
                await Task.Run(() =>
                {
                    lock (context.Levels)
                    {
                        context.Levels.Update(efLevel);
                        context.SaveChangesAsync();

                    }
                });
            }
            catch (Exception ex)
            {
                levelResponse.Id = -1;
                levelResponse.Content = $"An error occurred: {ex.Message}";
            }
            levelResponse = mapper.Map<LevelResponse>(efLevel);

            return levelResponse;
        }
    }
}
