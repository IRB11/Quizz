using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.Interfaces
{
    public interface ILoginUser : IUseCaseRequestHandler<LoginRequest, UserResponse>
    {
    }
}
