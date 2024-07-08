using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.UseCases.Techno
{
    public class UpdateTechno : IUpdateTechno
    {
        //private readonly IEnumerable<ICheckRuleTechno<TechnologiesRequest>> _rules;
        private readonly ITechnoRepository _technoRepository;

        public UpdateTechno(ITechnoRepository technoRepository)
        {
            _technoRepository = technoRepository;
          //  _rules = rules;
        }

        public async Task<TechnologiesResponse> Handle(TechnologiesRequest technoRequest)
        {
            if (await CheckIfRulesAreNotOKAsync()) return null;

            return await _technoRepository.Update(technoRequest);

            async Task<bool> CheckIfRulesAreNotOKAsync()
            {
                await _technoRepository.TechnoAlreadyExist(technoRequest);
                return false;
            }

            //bool CheckIfRuleNotRespected(TechnologiesRequest technoRequest)
            //{
            //   // return _rules.Any(r => r.CheckRule(technoRequest).ConfigureAwait(false).GetAwaiter().GetResult());
            //}
        }
    }
}