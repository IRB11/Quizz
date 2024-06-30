/*using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.UseCases.Techno
{
    public class GetTechnoById : IGetTechnoById
    {
        private readonly IEnumerable<ICheckRuleTechno<TechnoRequest>> -rule;
        private readonly ITechnoRepository _technoRepository;
        

        public GetTechnoById(ITechnoRepository technoRepository)
        {
            _technoRepository = technoRepository;
            -Rules = Rules;
        }

        public async Task<TechnologiesResponse> Handle(int id)
        {
            return await _technoRepository.GetTechnoById(id);
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
*/
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.UseCases.Techno
{
    public class GetTechnoById : IGetTechnoById
    {
        private readonly ITechnoRepository _technoRepository;

        public GetTechnoById(ITechnoRepository technoRepository)
        {
            _technoRepository = technoRepository;

        }

        public async Task<TechnologiesResponse> Handle(int id)
        {
            if (CheckIfRulesAreNotOK()) return null;

            return await _technoRepository.GetTechnoById(id);

            bool CheckIfRulesAreNotOK()
            {
                   if(id == -1) return true;
                   else return false;
            }


        }
    }
}
