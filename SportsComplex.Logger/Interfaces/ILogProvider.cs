namespace SportsComplex.Logger.Interfaces
{
    public interface ILogProvider
    {
        void WriteError(string errorMessage);
        void WriteMessage(string message);
        void WriteDebug(string debugMessage);
    }
}
