using NUnit.Framework;
using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces;
using Quizz.Domain.Core.UseCases.Techno;
using Quizz.Domain.Infrastructure.Data.Repositories;
using Quizz.Domain.Infrastructure.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Core.UnitTests
{
    public class TechnologiesTest
    {
        private ICreateTechno createTechno;
        private ITechnoRepository technoRepository;
        private TechnologiesRequest technologiesRequest;
        List<ICheckRule<LevelRequest>> rules;

        [SetUp]
        public void SetUp()
        {
            technoRepository = new InMemoryTechnoRepository();

            createTechno = new CreateTechno(technoRepository);
            technologiesRequest = new TechnologiesRequest()
            {
                Id = 1,
                Name = "Test5",
            };
        }
        [Test]
        public async Task Should_Return_TechnoResponse_If_TechnoRequest_Is_Added()
        {
      
            TechnologiesResponse response = await createTechno.Handle(technologiesRequest);
            Assert.That(response.Name.Equals(technologiesRequest.Name));
        }

    }
}
