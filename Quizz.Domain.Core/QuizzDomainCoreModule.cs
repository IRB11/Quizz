using Autofac;
using Quizz.Common.Interfaces;
using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Interfaces;
using Quizz.Domain.Core.Interfaces.Questions;
using Quizz.Domain.Core.Services;
using Quizz.Domain.Core.UseCases;
using Quizz.Domain.Core.UseCases.Question;
using Quizz.Domain.Core.UseCases.Rules;
using Quizz.Domain.Core.UseCases.Rules.QuestionRules;

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

            builder.RegisterType<CreateUser>().As<ICreateUser>().InstancePerLifetimeScope();
            builder.RegisterType<GetUserById>().As<IGetUserById>().InstancePerLifetimeScope();
            builder.RegisterType<GetAllUsers>().As<IGetAllUsers>().InstancePerLifetimeScope();
            builder.RegisterType<UpdateUser>().As<IUpdateUser>().InstancePerLifetimeScope();
            builder.RegisterType<DeleteUser>().As<IDeleteUser>().InstancePerLifetimeScope();

            builder.RegisterType<CreateQuestion>().As<ICreateQuestion>().InstancePerLifetimeScope();
            builder.RegisterType<GetQuestionById>().As<IGetQuestionById>().InstancePerLifetimeScope();
            builder.RegisterType<GetAllQuestion>().As<IGetAllQuestion>().InstancePerLifetimeScope();
            builder.RegisterType<UpdateQuestion>().As<IUpdateQuestion>().InstancePerLifetimeScope();
            builder.RegisterType<DeleteQuestion>().As<IDeleteQuestion>().InstancePerLifetimeScope();


            builder.RegisterInstance(new JWTService(_jwtSecret)).AsSelf().SingleInstance();

            builder.Register(c => new LoginUser(
                c.Resolve<IUserRepository>(),
                c.Resolve<JWTService>())).As<ILoginUser>().InstancePerLifetimeScope();

            //builder.RegisterType(c => new CreateUser().As<ICreateUser>().InstancePerLifetimeScope();

            builder.RegisterType<CheckAvailabilityOfLevelContent>().As<ICheckRuleLevel<LevelRequest>>().InstancePerLifetimeScope();
            builder.RegisterType<CheckAvailabilityOfLevelContent>().As<ICheckRuleLevel<LevelRequest>>().InstancePerLifetimeScope();


            builder.RegisterType<CheckIfAtLeastOneResponseIsCorrect>().As<ICheckQuestionRule<QuestionRequest>>().InstancePerLifetimeScope();
            builder.RegisterType<CheckIfMultipleOrSingleChoiceQuestionHasTwoOrFourResponses>().As<ICheckQuestionRule<QuestionRequest>>().InstancePerLifetimeScope();
            builder.RegisterType<CheckIfOpenQuestionHasNoResponse>().As<ICheckQuestionRule<QuestionRequest>>().InstancePerLifetimeScope();
            builder.RegisterType<CheckIfQuestionExists>().As<ICheckQuestionRule<QuestionRequest>>().InstancePerLifetimeScope();
            builder.RegisterType<CheckIfQuestionIsActive>().As<ICheckQuestionRule<QuestionRequest>>().InstancePerLifetimeScope();
            builder.RegisterType<ValidQuestionTypeRule>().As<ICheckQuestionRule<QuestionRequest>>().InstancePerLifetimeScope();

            // Enregistrer toutes les implémentations de ICheckQuestionRule<QuestionRequest>
            builder.Register(ctx =>
            {
                var context = ctx.Resolve<IComponentContext>();
                var rules = context.Resolve<IEnumerable<ICheckQuestionRule<QuestionRequest>>>().ToList();
                return rules;
            }).As<List<ICheckQuestionRule<QuestionRequest>>>();

            // Enregistrer CreateQuestion
            builder.RegisterType<CreateQuestion>().AsSelf().InstancePerLifetimeScope();

            builder.Register(ctx =>
            {
                var context = ctx.Resolve<IComponentContext>();
                var rules = context.Resolve<IEnumerable<ICheckRuleLevel<LevelRequest>>>().ToList();
                return rules;
            }).As<List<ICheckRuleLevel<LevelRequest>>>();

            builder.RegisterType<CheckAvailabilityOfUserEmail>().As<ICheckRuleUser<UserRequest>>().InstancePerLifetimeScope();
            builder.Register(ctx =>
            {
                var context = ctx.Resolve<IComponentContext>();
                var rules = context.Resolve<IEnumerable<ICheckRuleUser<UserRequest>>>().ToList();
                return rules;
            }).As<List<ICheckRuleUser<UserRequest>>>();

        }
    }
}
