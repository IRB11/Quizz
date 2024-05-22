using Microsoft.EntityFrameworkCore.Diagnostics;
using Quizz.Domain.Core.Entities;
using System.Collections.Generic;

namespace Quizz.Domain.Infrastructure.Data.Entities
{
    public class EFStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public ICollection<EFQuiz> Quizzes { get; set; }
    }
}