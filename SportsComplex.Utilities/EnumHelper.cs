using System;

namespace SportsComplex.Utilities
{
    public class EnumHelper
    {
        public static T TryParse<T>(string value, T defaultValue=default(T)) where T : struct
        {
            if (string.IsNullOrWhiteSpace(value))
                return defaultValue;

            T result;
            return Enum.TryParse(value, out result) ? result : defaultValue;
        }
    }
}


