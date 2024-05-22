using Quizz.Domain.Core.Entities;
using System.Collections.Generic;

namespace Quizz.Domain.Infrastructure.Data.Entities
{
    public class EFQuestion
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Type { get; set; }
        public bool IsValid { get; set; }

        public int AdminId { get; set; }
        public EFUser Admin { get; set; }

        public int LevelId { get; set; }
        public EFLevel Level { get; set; }

        public int TechnologyId { get; set; }
        public EFTechnology Technology { get; set; }
        public ICollection<EFResponse> Responses { get; set; }

    }
}