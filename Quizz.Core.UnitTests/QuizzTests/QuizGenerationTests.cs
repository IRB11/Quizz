using NUnit.Framework;
using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Entities;
using Quizz.Domain.Core.Interfaces.Questions;
using Quizz.Domain.Core.Interfaces.Quizz;
using Quizz.Domain.Core.UseCases.Quizz;
using Quizz.Domain.Core.UseCases.Rules.QuizzRules;
using Quizz.Domain.Infrastructure.InMemory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quizz.Core.UnitTests.QuizGenerationTests
{
    [TestFixture]
    public class GenerateQuizTests
    {
        private IGenerateQuiz _generateQuiz;
        private IQuestionRepository _questionRepository;
        private IQuizzRepository _quizRepository;
        private QuizRequest _quizRequest;
        private List<ICheckQuizzRule<QuizRequest>> _rules;

        [SetUp]
        public void SetUp()
        {
            _questionRepository = new InMemoryQuestionRepository();
            _quizRepository = new InMemoryQuizzRepository();

            _rules = new List<ICheckQuizzRule<QuizRequest>>();
            _rules.Add(new CheckIfQuizzAsValidNumberOfQuestions(_quizRepository));

            _generateQuiz = new GenerateQuiz(_quizRepository, _questionRepository, _rules);
            _quizRequest =  GetQuizz();

        }

        private QuizRequest GetQuizz()
        {
            return new()
            {
                AdminId = 1,
                AgentId = 1,
                CandidateId = 1,
                Comment = "",
                Completion = 0,
                IsValid = true,
                NumberOfQuestion = 20,
                Id = 1,
                Result = 0,
                TechnologyId = 1,
                StatusId = 1,
                URL = null,
                LevelId = 1,
                
            };
        }

        [Test]
        public async Task ShouldGenerateQuizWithSpecifiedParameters()
        {
            // Act
            var quiz = await _generateQuiz.Handle(_quizRequest);

            // Assert
            Assert.That(quiz, Is.Not.Null);
            Assert.That(quiz.NumberOfQuestion, Is.EqualTo(_quizRequest.NumberOfQuestion));
            Assert.That(quiz.Level.Id, Is.EqualTo(_quizRequest.LevelId));
            Assert.That(quiz.Admin.Id, Is.EqualTo(_quizRequest.AdminId));
            Assert.That(quiz.Agent.Id, Is.EqualTo(_quizRequest.AgentId));
            Assert.That(quiz.Candidate.Id, Is.EqualTo(_quizRequest.CandidateId));
            Assert.That(quiz.Technologies.Id, Is.EqualTo(_quizRequest.TechnologyId));
        }

        [Test]
        public async Task ShouldGenerateQuizWithExpectedNumberOfQuestions()
        {
            // Arrange
            var quizRequest = new QuizRequest
            {
                Id = 2,
                LevelId = 1, // Junior level
                TechnologyId = 1, // .NET technology
                NumberOfQuestion = 20
            };

            // Act
            var result = await _generateQuiz.Handle(quizRequest);
            var quizzQuestionsIdsByQuizzId = MockData.quizz_QuestionResponses.FindAll(q => q.QuizId == 2);
            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(quizzQuestionsIdsByQuizzId.Count, Is.EqualTo(20));
        }

        [Test]
        public async Task ShouldGenerateQuizWithNoDuplicateQuestions()
        {
            // Arrange
            var quizRequest = new QuizRequest
            {
                Id = 3,
                LevelId = 1,
                TechnologyId = 1,
                NumberOfQuestion = 20
            };

            // Act
            var result = await _generateQuiz.Handle(quizRequest);
            var quizzQuestionsIdsByQuizzId = MockData.quizz_QuestionResponses.FindAll(q => q.QuizId == 2);

            // Assert
            var questionIds = new HashSet<int>();
            foreach (var quizQuestion in quizzQuestionsIdsByQuizzId)
            {
                Assert.That(questionIds.Contains(quizQuestion.QuestionId), Is.False);
                questionIds.Add(quizQuestion.QuestionId);
            }
        }

        [Test]
        public async Task ShouldGenerateQuizWithExpectedQuestionDistributionForJunior()
        {
            // Arrange
            var quizRequest = new QuizRequest
            {
                Id = 4,
                LevelId = 1,
                TechnologyId = 1,
                NumberOfQuestion = 20
            };

            // Act
            var result = await _generateQuiz.Handle(quizRequest);

            var quizzQuestionsIdsByQuizzId = MockData.quizz_QuestionResponses.FindAll(q => q.QuizId == 2);

            var quizzQuestionsByQuizzId = _questionRepository.GetByListIds(quizzQuestionsIdsByQuizzId);

            // Assert
            var juniorQuestions = quizzQuestionsByQuizzId.Result.FindAll(q => q.Level.Id == 1).Count;
            var confirmedquestions = quizzQuestionsByQuizzId.Result.FindAll(q => q.Level.Id == 2).Count;
            var experiencedquestions = quizzQuestionsByQuizzId.Result.FindAll(q => q.Level.Id == 3).Count;

            Assert.That(juniorQuestions, Is.EqualTo(14)); // 70%
            Assert.That(confirmedquestions, Is.EqualTo(4)); // 20%
            Assert.That(experiencedquestions, Is.EqualTo(2)); // 10%
        }
    }
}
