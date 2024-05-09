using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.Entities
{
    public class Status
    {
        public int Id { get; set; }
        public string StatusQuizz { get; set; }
        public Quizz Quizz { get; set; }
    }
}
