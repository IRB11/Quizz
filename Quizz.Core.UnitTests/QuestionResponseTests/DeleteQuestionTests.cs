using NUnit.Framework;
using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces;
using Quizz.Domain.Core.Interfaces.Questions;
using Quizz.Domain.Core.UseCases.Question;
using Quizz.Domain.Core.UseCases.Rules.QuestionRules;
using Quizz.Domain.Infrastructure.InMemory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quizz.Core.UnitTests.QuestionResponseTests
{
    [TestFixture]
    public class DeleteQuestionTests
    {
        private IDeleteQuestion _deleteQuestion;
        private IQuestionRepository _questionRepository;
        private QuestionRequest _question;
        private List<ICheckQuestionRule<QuestionRequest>> _rules;
        private ILevelRepository _levelRepository;

        [SetUp]
        public void SetUp()
        {
            _questionRepository = new InMemoryQuestionRepository();
            _levelRepository = new InMemoryLevelRepository();
            InitRules();
            _deleteQuestion = new DeleteQuestion(_questionRepository,_levelRepository, _rules);
            _question = GetQuestionRequest();
        }

        #region Init
        private void InitRules()
        {
            _rules = new List<ICheckQuestionRule<QuestionRequest>>();
            _rules.Add(new CheckIfQuestionIsUsedInQuiz(_questionRepository));
            _rules.Add(new CheckIfQuestionExists(_questionRepository));
        }

        private QuestionRequest GetQuestionRequest()
        {
            return new QuestionRequest
            {
                Id = 4,
                Content = "What is the capital of Germany?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 1,
                AdminId = 1,
                Response = new List<Response_Request>
                {
                    new Response_Request { Id = 1, Content = "Paris", isCorrect = false },
                    new Response_Request { Id = 2, Content = "Berlin", isCorrect = true }
                },
                LevelId = 1,
                TechnologyId = 1
            };
        }

        private QuestionRequest GetQuestionToDeleteRequest()
        {
            return new QuestionRequest
            {
                Id = 9,
                Content = "What is the capital of Poland?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 1,
                AdminId = 1,
                Response = new List<Response_Request>
                {
                    new Response_Request { Id = 1, Content = "Paris", isCorrect = false },
                    new Response_Request { Id = 1, Content = "Munich", isCorrect = false },
                    new Response_Request { Id = 1, Content = "Osle", isCorrect = false },
                    new Response_Request { Id = 2, Content = "Varsovie", isCorrect = true }
                },
                LevelId = 1,
                TechnologyId = 1
            };
        }
        #endregion

        [Test]
        public async Task ShouldSetIsValidToFalse_IfQuestionIsUsedInQuiz()
        {
            // Arrange
            _question.Id = 1;

            await _questionRepository.Add(_question);
            await _questionRepository.CheckIfQuestionIsUsedInQuizz((int)_question.Id);
            // Act
            await _deleteQuestion.Handle(_question);

            var result = await _questionRepository.GetById((int)_question.Id);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.IsValid, Is.False);
        }

        [Test]
        public async Task ShouldReturnNull_IfQuestionIsNotUsedInQuiz()
        {
            // Arrange
            _question = GetQuestionToDeleteRequest();         
            await _questionRepository.Add(_question);

            // Act
            var result = await _deleteQuestion.Handle(_question);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task ShouldReturnNull_IfQuestionDoesNotExist()
        {
            // Arrange
            _question.Id = 99;
            // Act
            var result = await _deleteQuestion.Handle(_question);
            // Assert
            Assert.That(result, Is.Null);
        }
    }
}
