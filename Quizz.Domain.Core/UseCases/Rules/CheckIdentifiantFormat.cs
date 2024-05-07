using Quizz.Domain.Core.Interfaces.Date;
using System.Threading.Tasks;

namespace Quizz.Domain.Core.UseCases.Rules
{
    public class CheckIdentifiantFormat 
    {
        private readonly ICalendarService calendarService;

        private string errorMessage = string.Empty;
        private bool isError => string.IsNullOrWhiteSpace(errorMessage) ? false : true;

        public CheckIdentifiantFormat(ICalendarService calendar)
        {
            calendarService = calendar;
        }



        public string GetErrorMessage()
        {
            return errorMessage;
        }
    }
}
