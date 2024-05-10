using Autofac;
using Quizz.Domain.Core.Interfaces;
using Quizz.Domain.Core.Interfaces.Date;
using Quizz.Domain.Infrastructure.Date;
using Quizz.Domain.Infrastructure.Data.Repositories;

namespace Quizz.Domain.Infrastructure
{
    public class QuizzDomainInfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LevelRepository>().As<ILevelRepository>().InstancePerLifetimeScope();
            builder.RegisterType<DateTimeService>().As<IDateTimeService>();
            builder.RegisterType<CalendarService>().As<ICalendarService>();
        }
    }
}
