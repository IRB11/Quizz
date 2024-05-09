﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.Entities
{
    public class Level
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public Question Question { get; set; }
    }
}