using Berger.Extensions.Common.Auxiliar;
using System.Collections.Generic;
using System.Linq;

namespace Berger.Extensions.Common.Pagination
{
    public static class PaginationExtension
    {
        public static Pagination<T> Paginate<T>(this IQueryable<T> query, int page, int limit) where T : class
        {
            var pagination = new Pagination<T>(query, page, limit);
            
            return pagination;
        }

        public static Pagination<T> Paginate<T>(this IList<T> query, int page, int limit) where T : class
        {
            var pagination = new Pagination<T>(query, page, limit);

            return pagination;
        }
    }
}