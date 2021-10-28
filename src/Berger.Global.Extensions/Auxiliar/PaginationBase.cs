namespace Berger.Global.Extensions.Auxiliar
{
    public class PaginationBase
    {
        public int Page { get; set; }
        public int Pages { get; set; }
        public int Limit { get; set; }
        public int Previous { get; set; }
        public int Next { get; set; }
        public int Records { get; set; }
    }
}