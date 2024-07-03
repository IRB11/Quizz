using Quizz.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.Dto
{
    public class QuestionRequest
    {
        public long? Id { get; set; }
        public string Content { get; set; }
        public string Type { get; set; }
        public bool IsValid { get; set; }
        public int Order {  get; set; }

        public int AdminId { get; set; }
        public IList<Response_Request> Response { get; set; }
        public int LevelId { get; set; }
        public int TechnologyId { get; set;}
    }
}
