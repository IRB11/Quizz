using Quizz.Domain.Core.Entities;

namespace Quizz.Domain.Infrastructure.Data.Entities
{
    public class EFCandidate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public EFAgent Agent { get; set; }
        public EFQuizzTest QuizzTest { get; set; }
    }
}