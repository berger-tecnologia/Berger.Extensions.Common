using System.Collections.Generic;

namespace Berger.Global.Extensions.Auxiliar
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