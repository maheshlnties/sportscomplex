using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using SportsComplex.Logger.Interfaces;

namespace SportsComplex.Logger.LogProviders
{
    [ExcludeFromCodeCoverage]
    public class TraceLogProvider : ILogProvider
    {
        public void WriteError(string errorMessage)
        {
            Trace.WriteLine(errorMessage);
        }

        public void WriteMessage(string message)
        {
            Trace.WriteLine(message);
        }

        public void WriteDebug(string debugMessage)
        {
            Trace.WriteLine(debugMessage);
        }
    }
}
