using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Infrastructure.InMemory
{
    public class InMemoryLevelRepository : ILevelRepository
    {
        private List<LevelRequest> levels;
        public InMemoryLevelRepository() 
        {
            levels = GetLevelRequest();
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

        public Task<bool> IdIsNotAvailable(long? id)
        {
            return Task.Run(() => levels.Any(f => f.Id == id));
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
                }
            };
        }
    }
}
