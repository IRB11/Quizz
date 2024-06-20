using Quizz.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.Interfaces
{
    public interface IHashingPassword
    {
        public Task<string> CreateUser(User create);
        public Task<string> UserVerify(User verify);
    }
}
