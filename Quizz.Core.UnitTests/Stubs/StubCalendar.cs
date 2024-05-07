using Quizz.Domain.Core.Interfaces.Date;

namespace Quizz.Core.UnitTests.Stubs
{
    public class StubCalendar : ICalendarService
    {
        public int GetCurrentWeek()
        {
            return 4;
        }

        public int GetCurrentYear()
        {
            return 2021;
        }
    }
}
