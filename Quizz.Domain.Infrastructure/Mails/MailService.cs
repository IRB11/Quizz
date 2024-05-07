using System.Threading.Tasks;
using Quizz.Common.Configuration;
using Quizz.Domain.Core.Interfaces;

namespace Quizz.Domain.Infrastructure.Mails
{
    public class MailService 
    {
        private readonly MailConfiguration mailConfiguration;

        public MailService(MailConfiguration mailConfiguration)
        {
            this.mailConfiguration = mailConfiguration;
        }

        public Task SendMail(string subject, string dest, string body)
        {
            //tododododododdo
            return null;
        }
    }
}
