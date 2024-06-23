using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Entities;
using Quizz.Domain.Core.Interfaces;

namespace Quizz.Domain.Infrastructure.InMemory
{
    public class InMemoryLevelRepository : ILevelRepository
    {
        private List<LevelRequest> levels;
        private List<Question> questions;
        public InMemoryLevelRepository()
        {
            levels = GetLevelRequest();
            questions = GetQuizzes();
        }

        public async Task<LevelResponse> Add(LevelRequest levelRequest)
        {
            await Task.Run(() => levels.Add(levelRequest));

            return new LevelResponse()
            {
                Id = (long)levelRequest.Id,
                Content = levelRequest.Content,
            };
        }

        public Task<bool> ContentIsNotAvailable(string content)
        {
            return Task.Run(() => levels.Any(f => f.Content == content));
        }

        public Task<bool> DeleteLevel(LevelRequest levelRequest)
        {
            return Task.Run(() => levels.Remove(levelRequest));
        }

        public async Task<List<LevelResponse>> getAllLevels()
        {
            var levelResponses = levels.Select(level => new LevelResponse
            {
                Id = (long)level.Id,
                Content = level.Content
            }).ToList();

            return await Task.FromResult(levelResponses);
        }

        public async Task<LevelResponse> GetLevelById(int id)
        {
            var level = await Task.Run(() => levels.FirstOrDefault(l => l.Id == id));

            if (level == null)
            {
                return null;
            }
            else return new LevelResponse()
            {
                Id = (long)level.Id,
                Content = level.Content,
            };
        }

        public Task<bool> IdIsNotAvailable(long? id)
        {
            return Task.Run(() => levels.Any(f => f.Id == id));
        }

        public Task<bool> levelIsUsed(LevelRequest levelRequest)
        {
            return Task.Run(() => questions.Any(f => f.Level.Id == levelRequest.Id));
        }

        public async Task<LevelResponse> Update(LevelRequest levelRequest)
        {
            var response = new LevelResponse();

            try
            {
                await Task.Run(() =>
                {
                    lock (levels)
                    {
                        int index = levels.FindIndex(l => l.Id == levelRequest.Id);

                        if (index >= 0)
                        {
                            levels.RemoveAt(index);
                            var updatedLevel = new LevelRequest
                            {
                                Id = levelRequest.Id,
                                Content = levelRequest.Content
                                // Map other properties if needed
                            };
                            levels.Add(updatedLevel);
                            response.Id = (long)updatedLevel.Id;
                            response.Content = updatedLevel.Content;
                        }
                        else
                        {
                            response.Id = -1;
                            response.Content = "Level not found.";
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                response.Id = -1;
                response.Content = $"An error occurred: {ex.Message}";
            }

            return response;
        }

        private List<LevelRequest> GetLevelRequest()
        {
            return new List<LevelRequest>
            {
                new LevelRequest
                {
                    Id = 0,
                    Content ="Junior"
                },
                new LevelRequest
                {
                    Id = 1,
                    Content = "Senior"
                },
                new LevelRequest
                {
                    Id = 2,
                    Content = "To Delete"
                }
            };
        }

        private List<Question> GetQuizzes()
        {
            return new List<Question>
            {
                new Question
                {
                   Level = new Level()
                   {
                       Id = 0,
                       Content = "Junior"
                   }
                },
                new Question
                {
                   Level = new Level()
                   {
                       Id = 1,
                       Content = "Senior"
                   }
                },
                new Question
                {
                   Level = new Level()
                   {
                       Id = 0,
                       Content = "Junior"
                   }
                }
            };
        }
    }
}
