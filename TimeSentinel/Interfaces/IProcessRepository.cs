using System;
using System.Collections.Generic;
using Chronal.Models;

namespace Chronal.Interfaces
{
    public interface IProcessRepository
    {
        void AddProcess(TrackedProcess process);
        void RemoveProcess(int processId);
        IEnumerable<TrackedProcess> GetAll();
        void UpdateProcessTime(string processName, int newTotalTime, bool isActive);
        void UpdateLastRunTime(string processName, DateTime? lastRunTime);
        TrackedProcess? GetProcessByName(string name);
    }
}
