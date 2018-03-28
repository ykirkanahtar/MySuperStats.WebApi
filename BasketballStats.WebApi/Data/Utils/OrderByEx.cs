using System;
using System.Linq;
using System.Linq.Expressions;

namespace BasketballStats.WebApi.Data.Utils
{
    public static class OrderByEx
    {
        public static IOrderedQueryable<TSource> OrderBy<TSource, TKey>(this IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, bool ascending)
        {
            return @ascending ? source.OrderBy(keySelector) : source.OrderByDescending(keySelector);
        }
    }
}
