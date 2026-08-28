using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSentinel.Models;

namespace TimeSentinel.Interfaces
{
    internal interface IProcessRepository
    {
        void AddProcess(ProcessRecord process);
        void RemoveProcess(int itemId);
        void UpdateProcessTime(string name, int newTotalTime);
        ProcessRecord GetProcessByName(string name);
    }
}
