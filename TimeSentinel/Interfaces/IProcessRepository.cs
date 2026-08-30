using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSentinel.Models;

namespace TimeSentinel.Interfaces
{
    public interface IProcessRepository
    {
        void AddProcess(TrackedProcess process);
        void RemoveProcess(int processId);
        IEnumerable<TrackedProcess> GetAll();
        void UpdateProcessTime(string processName, int newTotalTime, bool isActive);
        void UpdateLastRunTime(string processName, DateTime? lastRunTime);
        TrackedProcess GetProcessByName(string name);
    }
}
