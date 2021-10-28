namespace Berger.Global.Extensions.Globalization
{
    public static class CurrencyExtensions
    {
        public static string Format(this double value)
        {
            return string.Format(value.ToString("N2"));
        }
    }
}