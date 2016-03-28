using System;
using SportsComplex.Logger.Interfaces;

namespace SportsComplex.Logger
{
    public class Logger : ILogger
    {
        private readonly ILogProvider _logProvider;

        public Logger(ILogProvider logProvider)
        {
            if (logProvider == null)
            {
                throw new ArgumentNullException("Log provider can not be null");
            }
            _logProvider = logProvider;
        }
        
        public void LogMessage(ILogItem messageItem)
        {
            _logProvider.WriteMessage(messageItem.LogItem);
        }

        public void LogException(ILogItem exceptionItem)
        {
            _logProvider.WriteError(exceptionItem.LogItem);
        }

        public void LogDebug(ILogItem debugItem)
        {
            _logProvider.WriteDebug(debugItem.LogItem);
        }
    }
}
