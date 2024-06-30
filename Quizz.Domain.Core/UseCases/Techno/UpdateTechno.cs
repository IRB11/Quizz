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
            if (CheckIfRulesAreNotOK()) return null;

            return await _technoRepository.Update(technoRequest);

            bool CheckIfRulesAreNotOK()
            {
                //if (CheckIfRuleNotRespected(technoRequest))
                //{
                //    List<string> errorList = new List<string>();
                //    _rules.ToList().ForEach(r =>
                //    {
                //        string currentErrorMessage = r.GetErrorMessage();
                //        if (!string.IsNullOrWhiteSpace(currentErrorMessage))
                //        {
                //            errorList.Add(currentErrorMessage);
                //        }
                //    });

                //    return true;
                //}

                return false;
            }

            //bool CheckIfRuleNotRespected(TechnologiesRequest technoRequest)
            //{
            //   // return _rules.Any(r => r.CheckRule(technoRequest).ConfigureAwait(false).GetAwaiter().GetResult());
            //}
        }
    }
}