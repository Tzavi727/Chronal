using System.Diagnostics;
using System.Linq;
using TimeSentinel.Interfaces;

namespace TimeSentinel.Services
{
    internal class ProcessService : IProcessService
    {
        public bool IsRunning(string processName)
        {
            return Process.GetProcessesByName(processName).Any();
        }
    }
}
