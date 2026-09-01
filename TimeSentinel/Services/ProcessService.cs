using System.Diagnostics;
using System.Linq;
using Chronal.Interfaces;

namespace Chronal.Services
{
    internal class ProcessService : IProcessService
    {
        public bool IsRunning(string processName)
        {
            return Process.GetProcessesByName(processName).Any();
        }
    }
}
