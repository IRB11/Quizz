using Quizz.Domain.Core.Entities;
using System.Collections.Generic;

namespace Quizz.Domain.Infrastructure.Data.Entities
{
    public class EFCandidate
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }

        public int AgentId { get; set; }
        public EFUser Agent { get; set; }
        public ICollection<EFQuiz> Quizzes { get; set; }
    }
}