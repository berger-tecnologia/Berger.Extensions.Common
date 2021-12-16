using System;

namespace Berger.Extensions.Common.Globalization
{
    public static class DateTimeExtension
    {
        public static string ConvertUtc(this DateTime date, string zone = "Pacific Standard Time")
        {
            var timeZone = GetTimeZone(zone);

            return date.ConvertUtc(timeZone);
        }
        public static string ConvertUtc(this DateTime ? date, string zone = "Pacific Standard Time")
        {
            var format = Format(date);
            var timeZone = GetTimeZone(zone);

            return format.ConvertUtc(timeZone);
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
        private static TimeZoneInfo GetTimeZone(string zone)
        {
            return TimeZoneInfo.FindSystemTimeZoneById(zone);
        }
    }
}