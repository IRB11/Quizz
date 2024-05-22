using NUnit.Framework;
using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using System.Collections.Generic;
using Quizz.Core.UnitTests.InMemory;
using Quizz.Domain.Core.Interfaces;
using Quizz.Domain.Core.UseCases;
using System;
using System.Threading.Tasks;
using Quizz.Domain.Core.UseCases.Rules;
using Quizz.Domain.Infrastructure.InMemory;

namespace Quizz.Core.UnitTests
{
    public class CreateLevelTest
    {
        private ICreateLevel createLevel;
        private ILevelRepository levelRepository;
        private LevelRequest level;
        List<ICheckRule<LevelRequest>> rules;

        [SetUp]
        public void SetUp()
        {
            levelRepository = new InMemoryLevelRepository();
            InitRules();
            createLevel = new CreateLevel(levelRepository, rules);
            level = GetLevelRequest();
        }

        private void InitRules()
        {
            rules = new List<ICheckRule<LevelRequest>>();
            rules.Add(new CheckAvailabilityOfLevelContent(levelRepository));
        }

        [Test]
        public async Task CreateLevel_WhenCalled_ReturnNull_IfLevelExist()
        {            
            LevelResponse result = await createLevel.Handle(level);

            Assert.That(result, Is.Null);
        }
        [Test]
        public async Task CreateLevel_WhenCalled_AddLevel_ReturnLevel()
        {
            level.Content = "Advanced";

            LevelResponse result = await createLevel.Handle(level);

            Assert.That(result.Content.Equals(level.Content));
        }

        private LevelRequest GetLevelRequest()
        {
            return new LevelRequest()
            {
                Id = 1,
                Content = "Junior"
            };
        }



    }
}
