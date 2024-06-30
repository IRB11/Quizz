using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.Entities
{
    public class Response
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Explanation { get; set; }
        public bool isCorrect { get; set; }
        public Question question { get; set; }

    }
}
