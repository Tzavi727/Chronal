using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using TimeSentinel.Interfaces;
using TimeSentinel.Models;

namespace TimeSentinel.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public ObservableCollection<TrackedProcess> SharedProcesses { get; } = new();

    public SettingsViewModel Settings { get; }
    public HomeViewModel Home { get; }

    public MainViewModel(IProcessRepository repository)
    {
        var processes = repository.GetAll();
        foreach (var process in processes)
        {
            SharedProcesses.Add(process);
        }



        Settings = new SettingsViewModel(repository, SharedProcesses);
        Home = new HomeViewModel(SharedProcesses);
    }
}
