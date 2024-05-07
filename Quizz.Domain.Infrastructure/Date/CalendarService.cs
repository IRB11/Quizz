using Quizz.Common.Configuration;
using Quizz.Domain.Core.Interfaces.Date;
using System;
using System.Globalization;

namespace Quizz.Domain.Infrastructure.Date
{
    public class CalendarService : ICalendarService
    {
        private readonly IDateTimeService dateTimeService;

        private Calendar myCal;
        private CalendarWeekRule myCWR;
        private DayOfWeek myFirstDOW;

        public CalendarService(IDateTimeService dateTimeService, CultureConfiguration cultureConfiguration)
        {
            this.dateTimeService = dateTimeService;

            CultureInfo myCI = new CultureInfo(cultureConfiguration.Language);
            myCal = myCI.Calendar;
            myCWR = myCI.DateTimeFormat.CalendarWeekRule;
            myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;
        }

        public int GetCurrentWeek()
        {
            return myCal.GetWeekOfYear(dateTimeService.Now(), myCWR, myFirstDOW);
        }

        public int GetCurrentYear()
        {
            return myCal.GetYear(dateTimeService.Now());
        }
    }
}
