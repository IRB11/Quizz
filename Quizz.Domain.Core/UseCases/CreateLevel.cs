using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.UseCases
{
    public class CreateLevel : ICreateLevel
    {
        private readonly IEnumerable<ICheckRule<LevelRequest>> rules;
        private readonly ILevelRepository levelRepository;

        public CreateLevel(ILevelRepository levelRepository, IEnumerable<ICheckRule<LevelRequest>> rules)
        {
            this.rules = rules;
            this.levelRepository = levelRepository;

        }

        public async Task<LevelResponse> Handle(LevelRequest levelRequest)
        {
            if (CheckIfRulesAreNotOK()) return null;

            return await levelRepository.Add(levelRequest);



            bool CheckIfRulesAreNotOK()
            {
                if (CheckIfRuleNotRespected(levelRequest))
                {
                    List<string> errorList = new List<string>();
                    rules.ToList().ForEach(r =>
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

            bool CheckIfRuleNotRespected(LevelRequest levelRequest)
            {
                return rules.Any(r => (r.CheckRule(levelRequest)).ConfigureAwait(false).GetAwaiter().GetResult() == true);
            }
        }
    }
}
