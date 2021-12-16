namespace Berger.Extensions.Common.Globalization
{
    public static class CurrencyExtension
    {
        public static string Format(this double value)
        {
            return string.Format(value.ToString("N2"));
        }
    }
}