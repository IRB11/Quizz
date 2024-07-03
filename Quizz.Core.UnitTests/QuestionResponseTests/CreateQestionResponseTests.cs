using NUnit.Framework;
using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces.Questions;
using Quizz.Domain.Core.UseCases.Question;
using Quizz.Domain.Core.UseCases.Rules.QuestionRules;
using Quizz.Domain.Infrastructure.InMemory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quizz.Core.UnitTests.QuestionResponseTests
{
    [TestFixture]
    public class CreateQuestionResponseTests
    {
        private ICreateQuestion _CreateQuestion;
        private IQuestionRepository _questionRepository;
        private QuestionRequest _question;
        private List<ICheckQuestionRule<QuestionRequest>> _rules;

        [SetUp]
        public void SetUp()
        {
            _questionRepository = new InMemoryQuestionRepository();
            InitRules();
            _CreateQuestion = new CreateQuestion(_questionRepository, _rules);
            _question = GetQuestionRequest();
        }

        #region Init
        private void InitRules()
        {
            _rules = new List<ICheckQuestionRule<QuestionRequest>>();
            _rules.Add(new CheckIfQuestionExists(_questionRepository));
            _rules.Add(new CheckIfQuestionIsActive());
            _rules.Add(new CheckIfAtLeastOneResponseIsCorrect());
            _rules.Add(new CheckIfOpenQuestionHasNoResponse());
            _rules.Add(new CheckIfMultipleOrSingleChoiceQuestionHasTwoOrFourResponses());
            _rules.Add(new ValidQuestionTypeRule());
        }

        private QuestionRequest GetQuestionRequest()
        {
            return new QuestionRequest
            {
                Id = 1,
                Content = "What is the capital of germany?",
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
        #endregion

        [Test]
        public async Task ShouldReturnNull_IfQuestionAlreadyExists()
        {
            // Arrange
            await _questionRepository.Add(new QuestionRequest
            {
                Id = 1,
                Content = "What is the capital of Germany?",
                IsValid = true,
                Response = new List<Response_Request>
                    {
                        new() { Id = 1, Content = "Paris", isCorrect = false },
                        new() { Id = 2, Content = "Berlin", isCorrect = true }
                    }
            });

            // Acc
            var result = await _CreateQuestion.Handle(_question);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task ShouldReturnNull_IfQuestionIsInactive()
        {
            // Arrange
            await _questionRepository.Add(new QuestionRequest
            {
                Id = 1,
                Content = "What is the capital of Germany?",
                IsValid = false,
                Response = new List<Response_Request>
                    {
                        new Response_Request { Id = 1, Content = "Paris", isCorrect = false },
                        new Response_Request { Id = 2, Content = "Berlin", isCorrect = true }
                    }
             });

            // Act
            var result = await _CreateQuestion.Handle(_question);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task ShouldReturnQuestion_IfNewMultipleChoiceQuestionIsAddedWithTwoResponses()
        {
            // Arrange
            _question.Id = 2;
            _question.Content = "What is the capital of Spain?";
            _question.Response = new List<Response_Request>
                {
                    new Response_Request { Id = 1, Content = "Madrid", isCorrect = true },
                    new Response_Request { Id = 2, Content = "Barcelona", isCorrect = false }
                };

            // Act
            var result = await _CreateQuestion.Handle(_question);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Content, Is.EqualTo(_question.Content));
            Assert.That(result.Response, Has.Count.EqualTo(2));
        }

        [Test]
        public async Task ShouldReturnNull_IfMultipleChoiceQuestionHasOneResponse()
        {
            // Arrange
            _question.Id = 3;
            _question.Content = "What is the capital of Spain?";
            _question.Response = new List<Response_Request>
                {
                    new Response_Request { Id = 1, Content = "Madrid", isCorrect = true }
                };

            // Act
            var result = await _CreateQuestion.Handle(_question);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task ShouldReturnNull_IfMultipleChoiceQuestionHasThreeResponses()
        {
            // Arrange
            _question.Id = 3;
            _question.Content = "What is the capital of Spain?";
            _question.Response = new List<Response_Request>
                {
                    new Response_Request { Id = 1, Content = "Madrid", isCorrect = true },
                    new Response_Request { Id = 2, Content = "Barcelona", isCorrect = false },
                    new Response_Request { Id = 3, Content = "Valencia", isCorrect = false }
                };

            // Act
            var result = await _CreateQuestion.Handle(_question);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task ShouldReturnQuestionResponse_IfNewSingleChoiceQuestionIsAddedWithTwoResponses()
        {
            // Arrange
            _question.Id = 4;
            _question.Type = "SingleChoice";
            _question.Content = "What is the capital of Italy?";
            _question.Response = new List<Response_Request>
                {
                    new Response_Request { Id = 1, Content = "Rome", isCorrect = true },
                    new Response_Request { Id = 2, Content = "Milan", isCorrect = false }
                };

            // Act
            var result = await _CreateQuestion.Handle(_question);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Content, Is.EqualTo(_question.Content));
            Assert.That(result.Response, Has.Count.EqualTo(2));
        }

        [Test]
        public async Task ShouldReturnNull_IfMultipleChoiceQuestionHasNoCorrectResponse()
        {
            // Arrange
            _question.Content = "What is the capital of Spain?";
            _question.Response = new List<Response_Request>
                {
                    new Response_Request { Id = 1, Content = "Madrid", isCorrect = false },
                    new Response_Request { Id = 2, Content = "Barcelona", isCorrect = false }
                };

            // Act
            var result = await _CreateQuestion.Handle(_question);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task Handle_ShouldReturnQuestionResponse_IfNewSingleChoiceQuestionIsAddedWithTwoResponses()
        {
            // Arrange
            _question.Type = "SingleChoice";
            _question.Content = "What is the capital of Italy?";
            _question.Response = new List<Response_Request>
                {
                    new Response_Request { Id = 1, Content = "Rome", isCorrect = true },
                    new Response_Request { Id = 2, Content = "Milan", isCorrect = false }
                };

            // Act
            var result = await _CreateQuestion.Handle(_question);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Content, Is.EqualTo(_question.Content));
            Assert.That(result.Response, Has.Count.EqualTo(2));
        }

        [Test]
        public async Task Handle_ShouldReturnNull_IfSingleChoiceQuestionHasNoCorrectResponse()
        {
            // Arrange
            _question.Type = "SingleChoice";
            _question.Content = "What is the capital of Italy?";
            _question.Response = new List<Response_Request>
                {
                    new Response_Request { Id = 1, Content = "Rome", isCorrect = false },
                    new Response_Request { Id = 2, Content = "Milan", isCorrect = false }
                };

            // Act
            var result = await _CreateQuestion.Handle(_question);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task Handle_ShouldReturnQuestionResponse_ForOpenQuestion()
        {
            // Arrange
            _question.Type = "OpenQuestion";
            _question.Content = "Describe the process of solar system.";
            _question.Response = null; // Open questions typically don't have predefined responses

            // Act
            var result = await _CreateQuestion.Handle(_question);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Content, Is.EqualTo(_question.Content));
        }
        [Test]
        public async Task ShouldReturnNull_IfQuestionType_IsNotCorrect()
        {
            // Arrange
            _question.Type = "otherchoice";
            _question.Content = "What is the capital of Italy?";
            _question.Response = new List<Response_Request>
                {
                    new Response_Request { Id = 1, Content = "Rome", isCorrect = false },
                    new Response_Request { Id = 2, Content = "Milan", isCorrect = false }
                };

            // Act
            var result = await _CreateQuestion.Handle(_question);

            // Assert
            Assert.That(result, Is.Null);
        }
    }
}
