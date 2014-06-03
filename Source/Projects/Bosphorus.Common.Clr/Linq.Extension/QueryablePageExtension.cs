using System.Linq;

namespace Bosphorus.Common.Clr.Linq.Extension
{
    public static class QueryablePageExtension
    {
        public static int defaultPageSize = 10;

        public static IQueryable<T> Page<T>(this IQueryable<T> queryable, int pageNumber)
        {
            IQueryable<T> result = Page<T>(queryable, pageNumber, defaultPageSize);
            return result;
        }

        public static IQueryable<T> Page<T>(this IQueryable<T> queryable, int pageNumber, int pageSize)
        {
            int start = (pageNumber - 1) * pageSize;
            IQueryable<T> result = queryable.Skip(start).Take(pageSize);
            return result;
        }

    }
}
