using System;
using System.Xml.Linq;

namespace Berger.Global.Extensions.Xml
{
    public static class XmlExtensions
    {
        public static DateTime ToDateTime(this XElement e)
        {
            if (e == null)
                return DateTime.MinValue;

            else if (string.IsNullOrEmpty(e.Value))
                return DateTime.MinValue;

            else
                return DateTime.Parse(e.Value);
        }

        public static string FromElementToString(this XElement e)
        {
            if (e == null)
                return string.Empty;

            else if (string.IsNullOrEmpty(e.Value))
                return string.Empty;

            else
                return e.Value;
        }

        public static string FromAttributeToString(this XAttribute e)
        {
            if (e == null)
                return string.Empty;
            else
                return e.Value;
        }

        public static int FromAttributeToInt(this XAttribute e)
        {
            if (e == null)
                throw new InvalidCastException("Invalid cast.");
            else
                return int.Parse(e.Value.ToString());
        }
    }
}