using Autofac;
using Quizz.Domain.Core.Interfaces.Date;
using Quizz.Domain.Infrastructure.Date;

namespace Quizz.Domain.Infrastructure
{
    public class FolderDomainInfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DateTimeService>().As<IDateTimeService>();
            builder.RegisterType<CalendarService>().As<ICalendarService>();
        }
    }
}
