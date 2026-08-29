using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSentinel.Models;
using TimeSentinel.Services;

namespace TimeSentinel.ViewModels;

public partial class HomeViewModel : ViewModelBase
{
    private readonly CounterService _counterService;
    public HomeViewModel(ObservableCollection<TrackedProcess> sharedList, CounterService counterService)
    {
        _processList = sharedList;
        _counterService = counterService;
        _counterService.Tick += () =>
        {
            OnPropertyChanged(nameof(DisplayLifeTime));
            OnPropertyChanged(nameof(DisplaySession));
            OnPropertyChanged(nameof(DisplayStatus));
        };
    }
    [ObservableProperty]
    private ObservableCollection<TrackedProcess> _processList;
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(DisplayLifeTime))]
    [NotifyPropertyChangedFor(nameof(DisplaySession))]
    [NotifyPropertyChangedFor(nameof(DisplayStatus))]
    private TrackedProcess? _selectedProcess;

    public string DisplayLifeTime => SelectedProcess == null ? "00:00:00" : _counterService.FormatTime(SelectedProcess.ProcessTotalTime);
    public string DisplaySession => SelectedProcess == null ? "00:00:00" : _counterService.FormatTime(SelectedProcess.SessionTime);
    public string DisplayStatus => SelectedProcess == null ? "NOT SELECTED" : SelectedProcess.IsCurrentlyRunning ? "[ ACTIVE ]" : "[ INACTIVE ]";


}



