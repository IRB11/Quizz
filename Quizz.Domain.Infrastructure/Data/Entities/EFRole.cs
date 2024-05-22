using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Infrastructure.Data.Entities
{
    public class EFRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<EFUser> Users { get; set; }
    }
}
