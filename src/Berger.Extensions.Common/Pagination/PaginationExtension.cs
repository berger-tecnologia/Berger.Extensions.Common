using System;
using System.Linq;
using Berger.Extensions.Common.Auxiliar;

namespace Berger.Extensions.Common.Pagination
{
    public static class PaginationExtension
    {
        public static Pagination<T> Paginate<T>(this IQueryable<T> query, int page, int limit) where T : class
        {
            var pagination = new Pagination<T>();
            var records = query.Count();
            var pages = (double)records / limit;
            var round = (int)Math.Ceiling(pages);
            var skip = (page - 1) * limit;
            var results = query.Count() <= limit ? query : query.Skip(skip).Take(limit);

            pagination.Page = page;
            pagination.Limit = limit;
            pagination.Records = records;
            pagination.Previous = (page - 1 == 0) ? 1 : page - 1;
            pagination.Next = (page + 1 == round + 1) ? round : page + 1;
            pagination.Pages = round;
            pagination.Results = results.ToList();

            return pagination;
        }
    }
}