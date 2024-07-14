using Quizz.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.Dto
{
    public class QuizResponse
    {
        public long Id { get; set; }
        public string Comment { get; set; }
        public decimal CompletionLevel { get; set; }
        public DateTime CompletionTime { get; set; }
        public bool IsValid { get; set; }
        public int NumberOfQuestion { get; set; }
        public string QuizzNumber { get; set; }
        public decimal Result { get; set; }
        public string URL { get; set; }
        
        public UserResponse Agent { get; set; }
        public UserResponse Admin { get; set; }
        public CandidateResponse Candidate { get; set; }
        public int StatusId { get; set; }
        public StatusReponse Status { get; set; }
        public LevelResponse Level { get; set; }
        public TechnologiesResponse Technologies { get; set; }

    }
}
