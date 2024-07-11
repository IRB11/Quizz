using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Common.Interfaces
{
    public interface ICheckQuizzRule<in TUseCaseRequest>
    {
        string GetErrorMessage();
        Task<bool> CheckRule(TUseCaseRequest request);
    }
}
