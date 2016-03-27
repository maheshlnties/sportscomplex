using System;
using System.Text;
using SportsComplex.Logger.Interfaces;

namespace SportsComplex.Logger.LogItems
{
    public class MessageItem : ILogItem
    {
        private readonly string _message;

        public MessageItem(string message)
        {
            _message = message ?? "null";
            DateTime = DateTime.UtcNow;
        }

        public string LogItem
        {
            get
            {
                var stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("================MESSAGE================");
                stringBuilder.AppendLine(string.Format("{0}: {1}", DateTime.ToString("MMM dd, yyyy HH:mm:ss tt \"UTC\""),
                    _message));
                return stringBuilder.ToString();
            }
        }

        public DateTime DateTime { get; private set; }
        public LogItemType ItemType
        {
            get { return LogItemType.Message; }
        }
    }
}
