using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces;

namespace Quizz.Domain.Core.UseCases
{
    public class GetAllLevels : IGetAllLevels
    {
        private readonly ILevelRepository _levelRepository;
        private readonly IEnumerable<ICheckRuleLevel<LevelRequest>> _rules;

        public GetAllLevels(ILevelRepository levelRepository, IEnumerable<ICheckRuleLevel<LevelRequest>> rules)
        {
             _levelRepository = levelRepository;
            _rules = rules
;        }
        public Task<List<LevelResponse>> Handle()
        {
             return _levelRepository.getAllLevels();
        }
    }
}
