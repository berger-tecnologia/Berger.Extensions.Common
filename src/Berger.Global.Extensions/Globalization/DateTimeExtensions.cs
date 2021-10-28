using System;

namespace Berger.Global.Extensions.Globalization
{
    public static class DateTimeExtensions
    {
        public static string ConvertUtc(this DateTime data, string zone = "Pacific Standard Time")
        {
            var timeZone = ReturnTimeZone(zone);

            return data.ConvertUtc(timeZone);
        }

        public static string ConvertUtc(this DateTime ? data, string zona = "Pacific Standard Time")
        {
            var formatacao = Formatar(data);
            var timeZone = ReturnTimeZone(zona);

            return formatacao.ConvertUtc(timeZone);
        }

        private static string ConvertUtc(this DateTime data, TimeZoneInfo zona)
        {
            if (data == DateTime.MinValue)
                return "Not informed";
            else
                return TimeZoneInfo.ConvertTimeFromUtc(data, zona).ToString();
        }

        private static DateTime Formatar(DateTime? data)
        {
            var formatacao = DateTime.MinValue;

            if (data != null)
                formatacao = (DateTime)data;

            return formatacao;
        }
        private static TimeZoneInfo ReturnTimeZone(string zona)
        {
            return TimeZoneInfo.FindSystemTimeZoneById(zona);
        }
    }
}