using System;

namespace Berger.Extensions.Common.Globalization
{
    public static class DateTimeExtension
    {
        public static string ConvertUtc(this DateTime date, string zone = "Pacific Standard Time")
        {
            return date.ConvertUtc(TimeZoneInfo.FindSystemTimeZoneById(zone));
        }
        public static string ConvertUtc(this DateTime ? date, string zone = "Pacific Standard Time")
        {
            var format = Format(date);

            return format.ConvertUtc(TimeZoneInfo.FindSystemTimeZoneById(zone));
        }
        private static string ConvertUtc(this DateTime date, TimeZoneInfo zone)
        {
            if (date == DateTime.MinValue)
                return "Not informed";
            else
                return TimeZoneInfo.ConvertTimeFromUtc(date, zone).ToString();
        }
        private static DateTime Format(DateTime? date)
        {
            var format = DateTime.MinValue;

            if (date != null)
                format = (DateTime)date;

            return format;
        }
    }
}