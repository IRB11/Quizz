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
    public class UpdateLevel : IUpdateLevel
    {
        private readonly IEnumerable<ICheckRuleLevel<LevelRequest>> _rules;
        private readonly ILevelRepository _levelRepository;

        public UpdateLevel(ILevelRepository levelRepository, IEnumerable<ICheckRuleLevel<LevelRequest>> rules)
        {
            _levelRepository = levelRepository;
            _rules = rules;
        }

        public async Task<LevelResponse> Handle(LevelRequest levelRequest)
        {
            if (CheckIfRulesAreNotOK()) return null;

            return await _levelRepository.Update(levelRequest);



            bool CheckIfRulesAreNotOK()
            {
                if (CheckIfRuleNotRespected(levelRequest))
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

            bool CheckIfRuleNotRespected(LevelRequest levelRequest)
            {
                return _rules.Any(r => (r.CheckRule(levelRequest)).ConfigureAwait(false).GetAwaiter().GetResult() == true);
            }
        }
    }
}
