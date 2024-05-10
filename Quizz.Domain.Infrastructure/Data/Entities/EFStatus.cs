using Microsoft.EntityFrameworkCore.Diagnostics;
using Quizz.Domain.Core.Entities;
using System.Collections.Generic;

namespace Quizz.Domain.Infrastructure.Data.Entities
{
    public class EFStatus
    {
        public int Id { get; set; }
        public string StatusQuizz { get; set; }
        public ICollection<EFQuizzTest> QuizzTests { get; set; }
    }
}