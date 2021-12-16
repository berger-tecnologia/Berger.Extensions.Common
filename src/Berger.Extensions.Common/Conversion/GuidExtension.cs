using System;

namespace Berger.Extensions.Common.Conversion
{
    public static class GuidExtension
    {
        public static Guid ToGuid(this Guid? source)
        {
            return source ?? Guid.Empty;
        }

        public static Guid ToGuid(this string source)
        {
            return Guid.Parse(source);
        }
    }
}