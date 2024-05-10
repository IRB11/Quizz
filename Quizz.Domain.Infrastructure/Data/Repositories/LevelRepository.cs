using AutoMapper;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces;
using Quizz.Domain.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Infrastructure.Data.Repositories
{
    public class LevelRepository : ILevelRepository
    {
        private readonly Context context;
        private readonly IMapper mapper;

        public LevelRepository(Context context, IMapper mapper) : base ()
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<LevelResponse> Add(LevelRequest levelRequest)
        {
            EFLevel eFLevel = mapper.Map<EFLevel>(levelRequest);
            this.context.Add(eFLevel);
            await this.context.SaveChangesAsync();
            LevelResponse levelResponse = mapper.Map<LevelResponse>(eFLevel);
            return levelResponse;
        }

        public Task<bool> ContentIsNotAvailable(string Content)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IdIsNotAvailable(long? id)
        {
            throw new NotImplementedException();
        }
    }
}
