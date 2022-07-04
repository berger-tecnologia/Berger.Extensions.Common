namespace Berger.Extensions.Common.Auxiliar
{
    public class PaginationBase
    {
        public int Limit { get; set; }
        public int Pages { get; set; }
        public int TotalCount { get; set; }
        public PageInfo PageInfo { get; set; }
    }

}