using Autofac;
using Quizz.Domain.Core.Interfaces;
using Quizz.Domain.Core.Interfaces.Date;
using Quizz.Domain.Infrastructure.Date;
using Quizz.Domain.Infrastructure.Data.Repositories;
using Quizz.Domain.Infrastructure.Utils;

namespace Quizz.Domain.Infrastructure
{
    public class QuizzDomainInfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LevelRepository>().As<ILevelRepository>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<HashingPassword>().As<IHashingPassword>();
            builder.RegisterType<TechnoRepository>().As<ITechnoRepository>();
            builder.RegisterType<DateTimeService>().As<IDateTimeService>();
            builder.RegisterType<CalendarService>().As<ICalendarService>();
        }
    }
}
