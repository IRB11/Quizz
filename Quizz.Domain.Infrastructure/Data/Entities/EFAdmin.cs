using Quizz.Domain.Core.Entities;
using System.Collections;
using System.Collections.Generic;

namespace Quizz.Domain.Infrastructure.Data.Entities
{
    public class EFAdmin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<EFAgent> Agents { get; set; }
        public ICollection<EFQuestion> Questions { get; set; }
        public ICollection<EFQuizzTest> QuizzTests { get; set; }
        public ICollection<EFTechnologies> Technologies { get; set; }
        public ICollection<EFLevel> Levels { get; set; }
    }
}