using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.Entities
{
    public class User : IUser
    {
        public int Id { get; set; }
        public string FirstName { get; set ; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public string Token { get; set; }
        public Role Role { get; set; }
    }
}
