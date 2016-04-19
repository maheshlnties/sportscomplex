using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SportsComplex.Application.Helper
{
    public class CsvActionResult<T> : FileResult
    {
        private readonly IList<T> _list;
        private const char Separator = ',';
        private readonly List<PropertyInfo> _properties; 

        public CsvActionResult(IList<T> list)
            : base("text/csv")
        {
            _list = list;
            if (_list != null)
                _properties = typeof (T).GetProperties().ToList();
        }

        protected override void WriteFile(HttpResponseBase response)
        {
            var outputStream = response.OutputStream;
            using (var memoryStream = new MemoryStream())
            {
                WriteList(memoryStream);
                outputStream.Write(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
            }
        }

        private void WriteList(Stream stream)
        {
            var streamWriter = new StreamWriter(stream, Encoding.Default);

            WriteHeaderLine(streamWriter);
            streamWriter.WriteLine();
            WriteDataLines(streamWriter);

            streamWriter.Flush();
        }

        private void WriteHeaderLine(TextWriter streamWriter)
        {
            foreach (var member in _properties)
            {
                WriteValue(streamWriter, member.Name);
            }
        }

        private void WriteDataLines(TextWriter streamWriter)
        {
            foreach (var line in _list)
            {
                foreach (var member in _properties)
                {
                    WriteValue(streamWriter, GetPropertyValue(line, member.Name));
                }
                streamWriter.WriteLine();
            }
        }

        private static void WriteValue(TextWriter writer, string value)
        {
            writer.Write("\"");
            writer.Write(value.Replace("\"", "\"\""));
            writer.Write("\"" + Separator);
        }

        private string GetPropertyValue(object src, string propName)
        {
            var value = _properties.First(x => x.Name == propName).GetValue(src, null);
            return value != null ? value.ToString() : string.Empty;
        }
    }
}