using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces;
using Quizz.Domain.Core.Interfaces.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.UseCases.Question
{
    public class UpdateQuestion : IUpdateQuestion
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IEnumerable<ICheckQuestionRule<QuestionRequest>> _rules;

        public UpdateQuestion(IQuestionRepository questionRepository, IEnumerable<ICheckQuestionRule<QuestionRequest>> rules)
        {
            _questionRepository = questionRepository;
            _rules = rules;
        }
        public async Task<QuestionResponse> Handle(QuestionRequest request)
        {
            if (CheckIfRulesAreNotOK()) return null;
            
            return await _questionRepository.Update(request);

            bool CheckIfRulesAreNotOK()
            {
                if (CheckIfRuleNotRespected(request))
                {
                    List<string> errorList = new List<string>();
                    _rules.ToList().ForEach(r =>
                    {
                        string currentErrorMessage = r.GetErrorMessage();
                        if (!string.IsNullOrWhiteSpace(currentErrorMessage))
                        {
                            errorList.Add(currentErrorMessage);
                        }
                    });

                    return true;
                }

                return false;
            }

            bool CheckIfRuleNotRespected(QuestionRequest request)
            {
                return _rules.Any(r => (r.CheckRule(request)).ConfigureAwait(false).GetAwaiter().GetResult() == true);
            }
        }
    }
}
