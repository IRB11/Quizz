using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Entities;
using Quizz.Domain.Core.Interfaces.Questions;
using Quizz.Domain.Core.Interfaces.Quizz;
using System;

namespace Quizz.Domain.Core.UseCases.Quizz
{
    public class GenerateQuiz : IGenerateQuiz
    {
        private readonly IQuizzRepository _quizzRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IEnumerable<ICheckQuizzRule<QuizRequest>> _rules;

        public GenerateQuiz(IQuizzRepository quizzRepository, IQuestionRepository questionRepository, IEnumerable<ICheckQuizzRule<QuizRequest>> rules)
        {
            _quizzRepository = quizzRepository;
            _questionRepository = questionRepository;
            _rules = rules;            
        }
        public async Task<QuizResponse> Handle(QuizRequest quizRequest)
        {
            try
            {
                var questions = GetRandomQuestions(quizRequest.LevelId, quizRequest.TechnologyId, quizRequest.NumberOfQuestion).Result;

                quizRequest.URL = GenerateQuizURL();

                var response = await _quizzRepository.Add(quizRequest);

                quizRequest.Id = (int)response.Id;

                var quizzQuestionResponses = questions.Select(q => new Quizz_QuestionResponse
                {
                    QuizId = quizRequest.Id,
                    QuestionId = (int)q.Id,
                }).ToList();

                await _quizzRepository.SaveQuestionToQuizz_Question((int)response.Id, quizzQuestionResponses);


                if (CheckIfRulesAreNotOK()) return null;

                if (response == null)
                {
                    return null;
                }

                return response;
            }
            catch (Exception)
            {

                throw;
            }

            #region Rules
            bool CheckIfRulesAreNotOK()
            {
                if (CheckIfRuleNotRespected(quizRequest))
                {
                    List<string> errorList = new List<string>();
                    _rules.ToList().ForEach(r =>
                    {
                        string currentErrorMessage = r.GetErrorMessage();
                        if (!string.IsNullOrWhiteSpace(currentErrorMessage))
                        {
                            errorList.Add(currentErrorMessage);
                            Console.WriteLine(currentErrorMessage);
                        }
                    });

                    return true;
                }

                return false;
            }

            bool CheckIfRuleNotRespected(QuizRequest quizRequest)
            {
                return _rules.Any(r => (r.CheckRule(quizRequest)).ConfigureAwait(false).GetAwaiter().GetResult() == true);
            }
            #endregion
        }

        private static readonly Random random = new Random();

        public static string GenerateQuizURL()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, 15)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private async Task<List<QuestionResponse>> GetRandomQuestions(int Level, int technologyId, int numberOfQuestions)
        {
            // Define distribution rules
            Dictionary<int, (double juniorPercentage, double confirmedPercentage, double experiencedPercentage)> distributionRules = new Dictionary<int, (double, double, double)>
            {
                { 1, (0.70, 0.20, 0.10) }, // Junior
                { 2, (0.20, 0.70, 0.10) }, // Confirmed
                { 3, (0.10, 0.20, 0.70) }  // Experienced
            };

            if (!distributionRules.ContainsKey(Level))
            {
                throw new ArgumentException("Invalid candidate level");
            }

            var (juniorPercentage, confirmedPercentage, experiencedPercentage) = distributionRules[Level];

            int juniorQuestions = (int)(numberOfQuestions * juniorPercentage);
            int confirmedQuestions = (int)(numberOfQuestions * confirmedPercentage);
            int experiencedQuestions = (int)(numberOfQuestions * experiencedPercentage);

            // Fetch questions
            var juniorQuestionsList = await GetQuestionsByLevelAndTechnology(1, 1, juniorQuestions);
            var confirmedQuestionsList = await GetQuestionsByLevelAndTechnology(2, 1, confirmedQuestions);
            var experiencedQuestionsList = await GetQuestionsByLevelAndTechnology(3, 1, experiencedQuestions);

            // Combine all questions and ensure no duplicates
            var allQuestions = new List<QuestionResponse>();
            allQuestions.AddRange(juniorQuestionsList);
            allQuestions.AddRange(confirmedQuestionsList);
            allQuestions.AddRange(experiencedQuestionsList);

            var uniqueQuestions = allQuestions
                .GroupBy(q => q.Id)
                .Select(g => g.First())
                .ToList();

            // Shuffle questions
            var random = new Random();
            return uniqueQuestions.OrderBy(q => random.Next()).Take(numberOfQuestions).ToList();
        }

        private async Task<List<QuestionResponse>> GetQuestionsByLevelAndTechnology(int levelId, int technologyId, int count)
        {
           return await _questionRepository.GetQuestionsByLevelAndTechnology(levelId, technologyId,count);
        }
    }
}
