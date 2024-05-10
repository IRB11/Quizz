using Quizz.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.Entities
{
    public class Admin : IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public Agent Agent { get; set; }
        public Question Question { get; set; }
        public QuizzTest QuizzTest { get; set; }
        public Technologies Technologies { get; set; }
        public Level Level { get; set; }
    }
}
