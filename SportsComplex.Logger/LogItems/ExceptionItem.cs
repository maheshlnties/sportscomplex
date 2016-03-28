using System;
using System.Collections;
using System.Text;
using SportsComplex.Logger.Interfaces;

namespace SportsComplex.Logger.LogItems
{
    public class ExceptionItem : ILogItem
    {
        private readonly Exception _exception;

        public ExceptionItem(Exception ex)
        {
            _exception = ex;
            DateTime = DateTime.UtcNow;
        }

        private void GetExceptionDetails(Exception exception, StringBuilder stringBuilder, int indentLevel = 0)
        {
            while (true)
            {
                var indent = new string(' ', indentLevel);
                stringBuilder.AppendLine(indentLevel > 0 ?
                    string.Format("{0}============INNER EXCEPTION============", indent)
                    : "===============EXCEPTION================");

                var exceptionTemp = exception;
                Action<string> append = prop =>
                {
                    var propInfo = exceptionTemp.GetType().GetProperty(prop);
                    if (propInfo != null)
                    {
                        var propValue = propInfo.GetValue(exceptionTemp, null);
                        if (propValue != null)
                        {
                            stringBuilder.AppendLine(string.Format("{0}: {1}{2}:{3}",
                                DateTime.ToString("MMM dd, yyyy HH:mm:ss tt \"UTC\""), indent, prop, propValue.ToString()));
                        }
                    }
                };

                append("Message");
                append("HResult");
                append("HelpLink");
                append("Source");
                append("StackTrace");
                append("TargetSite");

                foreach (DictionaryEntry exceptionData in exception.Data)
                {
                    stringBuilder.AppendLine(string.Format("{0}{1} : {2}", indent, exceptionData.Key,
                        exceptionData.Value));
                }

                if (exception.InnerException != null)
                {
                    exception = exception.InnerException;
                    indentLevel = ++indentLevel;
                    continue;
                }
                break;
            }
        }

        public string LogItem
        {
            get
            {
                var stringBuilder = new StringBuilder();
                if (_exception == null)
                {
                    stringBuilder.AppendLine("===============EXCEPTION================");
                    stringBuilder.AppendLine(string.Format("{0}: null",
                        DateTime.ToString("MMM dd, yyyy HH:mm:ss tt \"UTC\"")));
                    return stringBuilder.ToString();
                }
                GetExceptionDetails(_exception, stringBuilder);
                return stringBuilder.ToString();
            }
        }

        public DateTime DateTime { get; private set; }
        public LogItemType ItemType
        {
            get { return LogItemType.Error; }
        }
    }
}
