using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSentinel.Services
{
    internal class CounterService
    {
        private readonly Stopwatch _stopWatch = new();

        public void Start() => _stopWatch.Start();
        public void Stop() => _stopWatch.Stop();
        public TimeSpan Elapsed => _stopWatch.Elapsed;
        public string GetFormattedTime()
        {
            return Elapsed.ToString(@"hh\:mm\:ss");
        }
        public string FormattTime(int totalTime)
        {
            return Elapsed.ToString($@"{TimeSpan.FromSeconds(totalTime):hh\:mm\:ss}");
        }
        public int GetTimeRan()
        {
            return (int)Elapsed.TotalSeconds;
        }
    }
}
