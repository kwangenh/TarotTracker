using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface ILoggingManager
    {
        void LogInfo(string message);
        void LogWarning(string message);
        void LogDebug(string message);
        void LogError(string message);
    }
}
