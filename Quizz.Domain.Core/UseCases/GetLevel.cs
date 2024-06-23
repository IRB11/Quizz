using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces;

namespace Quizz.Domain.Core.UseCases
{
    public class GetLevel : IGetlevel
    {
        private readonly IEnumerable<ICheckRuleLevel<LevelRequest>> _rules;
        private readonly ILevelRepository _levelRepository;

        public GetLevel(ILevelRepository levelRepository, IEnumerable<ICheckRuleLevel<LevelRequest>> rules)
        {
            _levelRepository = levelRepository;
            _rules = rules;
        }

        public async Task<LevelResponse> Handle(int id)
        {
            if (CheckIfRulesAreNotOK()) return null;

            return await _levelRepository.GetLevel(id);



            bool CheckIfRulesAreNotOK()
            {
                if (CheckIfRuleNotRespected(id))
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

            bool CheckIfRuleNotRespected(int id)
            {
                return _rules.Any(r => (r.CheckRule(id)).ConfigureAwait(false).GetAwaiter().GetResult() == true);
            }
        }
    }
}
