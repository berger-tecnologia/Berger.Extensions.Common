namespace Berger.Global.Extensions.Globalization
{
    public static class CurrencyExtension
    {
        public static string Format(this double value)
        {
            return string.Format(value.ToString("N2"));
        }
    }
}