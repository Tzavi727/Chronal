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
    [NotifyPropertyChangedFor(nameof(FormattedTime))]
    private int _processTotalTime;
    [ObservableProperty]
    private int _sessionTime = 0;
    [ObservableProperty]
    private bool _isCurrentlyRunning;
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(LastRunDisplay))]
    private DateTime? _lastRunTime;

    public string LastRunDisplay => LastRunTime?.ToString("dd/MM/yyyy HH:mm") ?? "NEVER";
    public string FormattedTime => TimeSpan.FromSeconds(ProcessTotalTime).ToString(@"hh\:mm\:ss");
}
