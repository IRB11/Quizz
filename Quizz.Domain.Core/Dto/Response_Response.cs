using Quizz.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.Dto
{
    public class Response_Response
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public string Explanation { get; set; }
        public bool isCorrect { get; set; }
    }
}
