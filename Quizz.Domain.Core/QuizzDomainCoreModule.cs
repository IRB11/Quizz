using Autofac;
using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces;
using Quizz.Domain.Core.UseCases;
using Quizz.Domain.Core.UseCases.Rules;

namespace Quizz.Domain.Core
{
    public class QuizzDomainCoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CreateLevel>().As<ICreateLevel>().InstancePerLifetimeScope();
            builder.RegisterType<CheckAvailabilityOfLevelContent>().As< ICheckRule<LevelRequest>>().InstancePerLifetimeScope();
        }
    }
}
