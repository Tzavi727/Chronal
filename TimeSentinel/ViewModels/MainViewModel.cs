using Avalonia.Controls.ApplicationLifetimes;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using TimeSentinel.Interfaces;
using TimeSentinel.Models;
using TimeSentinel.Repositories;
using TimeSentinel.Services;

namespace TimeSentinel.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private readonly IProcessRepository _processRepository;
    public ObservableCollection<TrackedProcess> SharedProcesses { get; } = new();

    public SettingsViewModel Settings { get; }
    public HomeViewModel Home { get; }

    public MainViewModel(IProcessRepository repository, CounterService counterService)
    {
        _processRepository = repository;
        var processes = repository.GetAll();
        foreach (var process in processes)
        {
            SharedProcesses.Add(process);
        }
        Settings = new SettingsViewModel(repository, SharedProcesses);
        Home = new HomeViewModel(SharedProcesses, counterService);
    }

    public void SaveAllProcesses()
    {
        foreach (var p in SharedProcesses)
        {
            if (p.ProcessTotalTime > 0)
            {
                _processRepository.UpdateProcessTime(p.ProcessName, p.ProcessTotalTime, p.IsCounterActive);
            }
        }
    }
}
