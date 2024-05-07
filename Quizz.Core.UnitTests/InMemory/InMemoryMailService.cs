using Quizz.Domain.Core.Interfaces;
using System.Threading.Tasks;


namespace Quizz.Core.UnitTests.InMemory
{
    public class InMemoryMailService 
    {
        public Task SendMail(string subject, string dest, string body)
        {
            return null;
        }
    }
}
