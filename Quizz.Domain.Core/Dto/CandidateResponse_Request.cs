using Quizz.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.Dto
{
    public class CandidateResponse_Request
    {
        public long? Id { get; set; }
        public string Content { get; set; }
        public bool Is_Skipped { get; set; }
        public string Open_Response_Text { get; set; }
        public string Comment { get; set; }
        public Candidate Candidate { get; set; }
        public Response Response { get; set; }
        public Quiz_Question Quiz_Question { get; set; }
    }
}
