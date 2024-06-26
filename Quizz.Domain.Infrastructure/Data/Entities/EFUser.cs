﻿using Quizz.Domain.Core.Entities;
using Quizz.Domain.Core.Interfaces;
using System.Collections.Generic;

namespace Quizz.Domain.Infrastructure.Data.Entities
{
    public class EFUser 
    {
        public int Id { get ; set ; }
        public string FirstName { get; set ; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool IsActive { get; set; }
        public string Token { get; set; }
        public byte[] Salt { get; internal set; }
        public int RoleId { get; set; }
        public EFRole Role { get; set; }
        public ICollection<EFCandidate> Candidates { get; set; }
        public ICollection<EFTechnology> Technologies { get; set; }
        public ICollection<EFQuiz> AdministeredQuizzes { get; set; }
        public ICollection<EFQuiz> AssignedQuizzes { get; set; }
        public ICollection<EFLevel> Levels { get; set; }
        public ICollection<EFQuestion> Questions { get; set; }

    }
}