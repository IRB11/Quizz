using Quizz.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.Dto
{
    public class TechnologiesRequest
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int AdminId { get; set; }
    }
}
