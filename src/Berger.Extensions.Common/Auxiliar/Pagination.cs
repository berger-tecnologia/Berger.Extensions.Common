using System.Collections.Generic;

namespace Berger.Extensions.Common.Auxiliar
{
    public class Pagination<T> : PaginationBase where T : class
    {
        public IList<T> Results { get; set; }

        public Pagination()
        {
            Results = new List<T>();
        }
    }
}