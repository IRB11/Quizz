using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.Interfaces
{
    public interface IUser
    {
        int Id { get; set; }
        string Name { get; set; }
        string LastName {  get; set; }        
        string EmailAddress { get; set; }

    }
}
