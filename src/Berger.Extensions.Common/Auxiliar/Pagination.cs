using System.Collections.Generic;
using System.Linq;
using System;

namespace Berger.Extensions.Common.Auxiliar
{
    public class Pagination<T> : PaginationBase where T : class
    {
        public IList<T> Items { get; set; }

        public Pagination(IList<T> query, int page, int limit)
        {
            Paginate(query, page, limit);
        }

        public Pagination(IQueryable<T> query, int page, int limit)
        {
            Paginate(query.ToList(), page, limit);
        }

        private void Paginate(IList<T> query, int page, int limit)
        {
            var records = query.Count();
            var pages = (double)records / limit;
            var round = (int)Math.Ceiling(pages);
            var skip = (page - 1) * limit;

            var results = query.Count() <= limit ? query : query.Skip(skip).Take(limit);

            var pageInfo = new PageInfo()
            {
                Current = page,
                Previous = (page - 1 == 0) ? 1 : page - 1,
                Next = (page + 1 == round + 1) ? round : page + 1,
                HasNextPage = round >= page + 1,
                HasPreviousPage = page > 1
            };

            TotalCount = records;
            Limit = limit;
            Pages = round;
            Items = results.ToList();

            PageInfo = pageInfo;
        }
    }
}