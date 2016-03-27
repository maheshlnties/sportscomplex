using System;
using System.Linq;
using System.Text;
using SportsComplex.Logger.Interfaces;

namespace SportsComplex.Logger.LogItems
{
    public class DebugItem : ILogItem
    {
        private readonly object[] _objects;
        private readonly string _message;

        public DebugItem(string message, params object[] objects)
        {
            _objects = objects;
            _message = message;
            DateTime = DateTime.UtcNow;
        }
        public string LogItem
        {
            get
            {
                var stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("=============DEBUG MESSAGE=============");
                stringBuilder.AppendLine(string.Format("{0}: {1}", DateTime.ToString("MMM dd, yyyy HH:mm:ss tt \"UTC\""),
                    _message ?? "null"));
                if (_objects == null) return stringBuilder.ToString();
                stringBuilder.AppendLine("=============DEBUG OBJECTS=============");
                foreach (var o in _objects.Where(o => o != null))
                {
                    stringBuilder.AppendLine(string.Format("{0}: {1}",
                        DateTime.ToString("MMM dd, yyyy HH:mm:ss tt \"UTC\""), o));
                }
                return stringBuilder.ToString();
            }
        }

        public DateTime DateTime { get; private set; }

        public LogItemType ItemType
        {
            get { return LogItemType.Debug; }
        }
    }
}
