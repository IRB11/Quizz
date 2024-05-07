using Quizz.Domain.Core.Interfaces.Date;
using System;


namespace Quizz.Domain.Infrastructure.Date
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}
