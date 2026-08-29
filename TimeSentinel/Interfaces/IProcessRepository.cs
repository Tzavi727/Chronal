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
        void UpdateProcessTime(string name, int newTotalTime);
        TrackedProcess GetProcessByName(string name);
    }
}
