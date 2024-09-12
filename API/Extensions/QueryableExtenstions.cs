using System.Linq.Expressions;

namespace API.Extensions
{
    public static class QueryableExtenstions
    {
        /// <summary>
        /// Custom extension method to filter IQueryable based on condition
        /// If condition is true, apply the predicate
        /// If condition is false, return the queryable as is
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="condition"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> queryable, bool condition, Expression<Func<T, bool>> predicate)
        {
            if (condition)
            {
                return queryable.Where(predicate);
            }

            return queryable;
        }
    }
}
