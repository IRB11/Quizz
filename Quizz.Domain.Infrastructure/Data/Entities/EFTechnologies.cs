using Quizz.Domain.Core.Entities;
using System.Collections.Generic;

namespace Quizz.Domain.Infrastructure.Data.Entities
{
    public class EFTechnologies
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EFAdmin Admin { get; set; }
        public ICollection<EFQuestion> Questions { get; set; }
    }
}