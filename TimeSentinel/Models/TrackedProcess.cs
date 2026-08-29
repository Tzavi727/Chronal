using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSentinel.Models;

public partial class TrackedProcess : ObservableObject
{
    public int ProcessId { get; set; } = 0;
    public required string ProcessName { get; set; }

    [ObservableProperty]
    private bool _isActive; 

    [ObservableProperty]
    private int _processTotalTime;
}
