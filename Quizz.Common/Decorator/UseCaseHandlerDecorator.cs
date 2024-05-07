using AspectInjector.Broker;
using Serilog;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Quizz.Common.Decorator
{
    [Aspect(Scope.Global)]
    [Injection(typeof(UseCaseHandlerDecorator))]
    public class UseCaseHandlerDecorator : Attribute
    {
        private static readonly ILogger _logger = Serilog.Log.Logger;

        private static readonly MethodInfo _asyncHandler = typeof(UseCaseHandlerDecorator).GetMethod(nameof(WrapAsync), BindingFlags.NonPublic | BindingFlags.Static);
        private static readonly MethodInfo _syncHandler = typeof(UseCaseHandlerDecorator).GetMethod(nameof(WrapSync), BindingFlags.NonPublic | BindingFlags.Static);
        private static readonly Type _voidTaskResult = Type.GetType("System.Threading.Tasks.VoidTaskResult");

        [Advice(Kind.Around, Targets = Target.Method)]
        public object Around([Argument(Source.Target)] Func<object[], object> target,
            [Argument(Source.Arguments)] object[] args,
            [Argument(Source.ReturnType)] Type retType,
            [Argument(Source.Type)] Type calledType)
        {
            _logger.Information($"UseCase lance:  {calledType.Name}");

            if (typeof(Task).IsAssignableFrom(retType)) //check if method is async, you can also check by statemachine attribute
            {
                var syncResultType = retType.IsConstructedGenericType ? retType.GenericTypeArguments[0] : _voidTaskResult;
                return _asyncHandler.MakeGenericMethod(syncResultType).Invoke(this, new object[] { target, args, calledType.Name });
            }
            else
            {
                retType = retType == typeof(void) ? typeof(object) : retType;
                return _syncHandler.MakeGenericMethod(retType).Invoke(this, new object[] { target, args, calledType.Name });
            }
        }

        private static T WrapSync<T>(Func<object[], object> target, object[] args, string name)
        {
            T result = default;
            try
            {
                result = (T)target(args);
                _logger.Information($"UseCase fini : {name}");

            }
            catch (Exception e)
            {
                Log(e, name);
            }

            return result;
        }

        private static async Task<T> WrapAsync<T>(Func<object[], object> target, object[] args, string name)
        {
            T result = default;
            try
            {
                result = await ((Task<T>)target(args)).ConfigureAwait(false);
                _logger.Information($"UseCase fini : {name}");

            }
            catch (Exception e)
            {
                Log(e, name);
            }

            return result;
        }


        private static void Log(Exception e, string name) { _logger.Error(e, $"Exception pour {name}, message {e.Message} {Environment.NewLine} {e.StackTrace}"); }


    }
}