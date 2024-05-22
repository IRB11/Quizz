using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.Dto
{
    public class RoleRequest
    {
        public long? Id { get; set; }
        public string Name { get; set; }
    }
}
