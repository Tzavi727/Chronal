using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
