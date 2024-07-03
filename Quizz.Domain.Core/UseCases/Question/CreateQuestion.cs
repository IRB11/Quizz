using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces;
using Quizz.Domain.Core.Interfaces.Questions;
using Quizz.Domain.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.UseCases.Question
{
    public class CreateQuestion : ICreateQuestion
    {
        private IQuestionRepository questionRepository;
        private readonly IEnumerable<ICheckQuestionRule<QuestionRequest>> rules;

        public CreateQuestion(IQuestionRepository questionRepository, IEnumerable<ICheckQuestionRule<QuestionRequest>> rules)
        {
            this.questionRepository = questionRepository;
            this.rules = rules;
        }

        public async  Task<QuestionResponse> Handle(QuestionRequest request)
        {
            if (CheckIfRulesAreNotOK()) return null;

            var response = await questionRepository.Add(request);

            if (response == null)
            {
                return null;
            }

            return response;

            #region Rules
            bool CheckIfRulesAreNotOK()
            {
                if (CheckIfRuleNotRespected(request))
                {
                    List<string> errorList = new List<string>();
                    rules.ToList().ForEach(r =>
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

            bool CheckIfRuleNotRespected(QuestionRequest questionRequest)
            {
                return rules.Any(r => (r.CheckRule(questionRequest)).ConfigureAwait(false).GetAwaiter().GetResult() == true);
            }
            #endregion
        }
    }
}
