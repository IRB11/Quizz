using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces;
using Quizz.Domain.Core.UseCases.Techno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Infrastructure.InMemory
{
    public class InMemoryTechnoRepository : ITechnoRepository
    {
        private List<TechnologiesRequest> technos;
        public InMemoryTechnoRepository() 
        {
          technos = new List<TechnologiesRequest>() 
          {
              new TechnologiesRequest()
              {
                  Id = 1,
                  Name = "Test1",
              },
              new TechnologiesRequest()
              {
                  Id = 2,
                  Name = "Test2",
              },
              new TechnologiesRequest()
              {
                  Id = 3,
                  Name = "Test3"
              },
              new TechnologiesRequest()
              {
                  Id = 4,
                  Name = "Test4",
              },
          };
        }

        public async Task<TechnologiesResponse> Add(TechnologiesRequest request)
        {
            if (request.Name != null)
            {
                await Task.Run(() =>  technos.Add(request));
            }
            return new TechnologiesResponse()
            {
                Name = request.Name,
                Id = (long)request.Id,
            };
        }

        public Task DeleteAsync(object techno)
        {
            throw new NotImplementedException();
        }

        public Task<TechnologiesResponse> DeleteAsync(TechnologiesRequest techno)
        {
            throw new NotImplementedException();
        }

        public Task<TechnologiesResponse> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TechnologiesResponse> GetTechnoById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> TechnoIsUsed(int technoId)
        {
            throw new NotImplementedException();
        }

        public Task<TechnologiesResponse> Update(TechnologiesRequest technoRequest)
        {
            throw new NotImplementedException();
        }

        Task<List<TechnologiesResponse>> GetAll()
        {
            throw new NotImplementedException();
        }

        Task<List<TechnologiesResponse>> ITechnoRepository.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
