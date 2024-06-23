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
            builder.RegisterType<GetLevelById>().As<IGetLevelById>().InstancePerLifetimeScope();
            builder.RegisterType<GetAllLevels>().As<IGetAllLevels>().InstancePerLifetimeScope();
            builder.RegisterType<UpdateLevel>().As<IUpdateLevel>().InstancePerLifetimeScope();
            builder.RegisterType<DeleteLevel>().As<IDeleteLevel>().InstancePerLifetimeScope();
            builder.RegisterInstance(new JWTService(_jwtSecret)).AsSelf().SingleInstance();
            builder.Register(c => new LoginUser(
                c.Resolve<IUserRepository>(),
                c.Resolve<JWTService>())).As<ILoginUser>().InstancePerLifetimeScope();
            builder.Register(c => new CreateUser(
                c.Resolve<IUserRepository>(),
                c.Resolve<JWTService>())).As<ICreateUser>().InstancePerLifetimeScope();
            builder.RegisterType<CheckAvailabilityOfLevelContent>().As<ICheckRuleLevel<LevelRequest>>().InstancePerLifetimeScope();
            builder.Register(ctx =>
            {
                var context = ctx.Resolve<IComponentContext>();
                var rules = context.Resolve<IEnumerable<ICheckRuleLevel<LevelRequest>>>().ToList();
                return rules;
            }).As<List<ICheckRuleLevel<LevelRequest>>>();

        }
    }
}
