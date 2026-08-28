using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSentinel.Interfaces
{
    internal interface IProcessService
    {
        bool IsRunning(string processName);
    }
}
