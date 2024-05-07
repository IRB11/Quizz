using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Quizz.Domain.Infrastructure.Utils
{
    public static class EnumerableExtensions
    {
        public static IQueryable<T> MatchesWildcard<T>(this IQueryable<T> sequence, Func<T, string> expression, string pattern)
        {
            var regEx = WildcardToRegex(pattern);

            return sequence.Where(item => Regex.IsMatch(expression(item), regEx));
        }

        public static string WildcardToRegex(string pattern)
        {
            return "^" + Regex.Escape(pattern).
            Replace("\\*", ".*").
            Replace("\\?", ".") + "$";
        }


    }
}
