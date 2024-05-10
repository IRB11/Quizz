using Quizz.Domain.Core.Entities;
using System.Collections.Generic;

namespace Quizz.Domain.Infrastructure.Data.Entities
{
    public class EFAgent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public EFAdmin Admin { get; set; }
        public ICollection<EFCandidate> Candidates { get; set; }
        public ICollection<EFQuizzTest> QuizzTests { get; set; }
    }
}