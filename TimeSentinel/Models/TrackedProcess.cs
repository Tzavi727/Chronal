using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSentinel.Interfaces;

namespace TimeSentinel.Models;

public partial class TrackedProcess : ObservableObject
{
    public int ProcessId { get; set; } = 0;
    public required string ProcessName { get; set; }
    [ObservableProperty]
    private bool _isCounterActive; 
    [ObservableProperty]
    private int _processTotalTime;
    [ObservableProperty]
    private int _sessionTime = 0;
    [ObservableProperty]
    private bool _isCurrentlyRunning;
    public string FormattedTime => TimeSpan.FromSeconds(ProcessTotalTime).ToString(@"hh\:mm\:ss");
}
