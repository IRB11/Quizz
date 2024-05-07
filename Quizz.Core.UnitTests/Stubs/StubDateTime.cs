using System;
using Quizz.Domain.Core.Interfaces.Date;

namespace Quizz.Core.UnitTests.Stubs
{
    public class StubDateTime : IDateTimeService
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}
