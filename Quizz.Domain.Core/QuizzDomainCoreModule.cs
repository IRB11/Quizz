using Autofac;
using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces;
using Quizz.Domain.Core.Services;
using Quizz.Domain.Core.UseCases;
using Quizz.Domain.Core.UseCases.Rules;

namespace Quizz.Domain.Core
{
    public class QuizzDomainCoreModule : Module
    {
        private readonly string _jwtSecret;

        public QuizzDomainCoreModule(string jwtSecret)
        {
            _jwtSecret = jwtSecret;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CreateLevel>().As<ICreateLevel>().InstancePerLifetimeScope();
            builder.RegisterInstance(new JWTService(_jwtSecret)).AsSelf().SingleInstance();
            builder.Register(c => new LoginUser(
                c.Resolve<IUserRepository>(),
                c.Resolve<JWTService>())).As<ILoginUser>().InstancePerLifetimeScope();
            builder.Register(c => new CreateUser(
                c.Resolve<IUserRepository>(),
                c.Resolve<JWTService>())).As<ICreateUser>().InstancePerLifetimeScope();
            builder.RegisterType<CheckAvailabilityOfLevelContent>().As<ICheckRule<LevelRequest>>().InstancePerLifetimeScope();
        }
    }
}
