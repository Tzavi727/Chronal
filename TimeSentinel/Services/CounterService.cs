using Avalonia.Threading;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSentinel.Interfaces;
using TimeSentinel.Models;

namespace TimeSentinel.Services
{
    public class CounterService
    {
        private readonly IProcessRepository _processRepository;
        private readonly IProcessService _processService;
        private DispatcherTimer _timer;
        public event Action? Tick;
        public CounterService(IProcessRepository repository, IProcessService processService)
        {
            _processRepository = repository;
            _processService = processService;
        }
        public void SetupTimer(ObservableCollection<TrackedProcess> processes)
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += (sender, e) =>
            {
                Timer_Tick(processes);
            };
            _timer.Start();
        }

        private void Timer_Tick(ObservableCollection<TrackedProcess> processes)
        {
            foreach (var process in processes)
            {
                bool wasRunning = process.IsCurrentlyRunning;
                bool runningNow = _processService.IsRunning(process.ProcessName);
                if (wasRunning && !runningNow)
                {
                    process.LastRunTime = DateTime.Now;
                }
                if (!wasRunning && runningNow)
                {
                    process.SessionTime = 0;
                }
                process.IsCurrentlyRunning = runningNow;
                if (process.IsCounterActive && runningNow)
                {
                    process.ProcessTotalTime++;
                    process.SessionTime++;
                }
            }
            Tick?.Invoke();
        }
        public string FormatTime(int seconds)
        {
            return TimeSpan.FromSeconds(seconds).ToString(@"hh\:mm\:ss");
        }
    }
}
