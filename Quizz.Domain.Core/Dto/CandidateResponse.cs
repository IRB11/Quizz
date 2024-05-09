using Quizz.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.Dto
{
    public class CandidateResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAdress { get; set; }
        public Agent Agent { get; set; }
        public QuizzTest QuizzTest { get; set; }
    }
}
