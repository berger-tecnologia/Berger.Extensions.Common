using System;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace Berger.Extensions.Common.Enums
{
    public static class EnumExtension
    {
        public static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        public static string GetName(this Enum enumerator)
        {
            var attribute = GetAttribute(enumerator);

            return attribute != null ? attribute.Name : enumerator.ToString();
        }

        public static string GetDescription(this Enum enumerator)
        {
            var attribute = GetAttribute(enumerator);

            var output = string.Empty;

            if (attribute.Description != null)
                output = attribute.Description;

            else if (attribute.Name != null)
                output = attribute.Name;

            else
                output = enumerator.ToString();

            return output;
        }

        private static DisplayAttribute GetAttribute(object value)
        {
            if (value != null)
            {
                Type type = value.GetType();

                var field = type.GetField(value.ToString());

                return field == null ? null : field.GetCustomAttribute<DisplayAttribute>();
            }
            else
                return new DisplayAttribute { Description = "Not informed" };
        }
    }
}