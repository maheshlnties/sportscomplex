namespace SportsComplex.Logger.Interfaces
{
    public interface ILogger
    {
        void LogMessage(ILogItem messageItem);
        void LogException(ILogItem exceptionItem);
        void LogDebug(ILogItem debugItem);
    }
}
