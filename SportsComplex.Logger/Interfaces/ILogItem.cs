using System;

namespace SportsComplex.Logger.Interfaces
{
    public interface ILogItem
    {
        string LogItem { get; }
        DateTime DateTime { get; }
        LogItemType ItemType { get; }
    }
}
