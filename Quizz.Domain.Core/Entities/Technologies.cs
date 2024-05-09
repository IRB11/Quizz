using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.Entities
{
    public class Technologies
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Admin Admin { get; set; }
        public Question Question { get; set; }
    }
}
