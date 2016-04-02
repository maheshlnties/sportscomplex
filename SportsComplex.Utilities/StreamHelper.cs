using System;
using System.IO;

namespace SportsComplex.Utilities
{
    public class StreamHelper
    {
        public static string ToBase64String(Stream stream)
        {
            if (stream == null) return string.Empty;

            var data = new byte[(int) stream.Length];
            stream.Read(data, 0, data.Length);
            return Convert.ToBase64String(data);
        }
    }
}
