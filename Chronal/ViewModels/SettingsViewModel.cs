using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Chronal.Interfaces;
using Chronal.Models;

namespace Chronal.ViewModels;

public partial class SettingsViewModel : ViewModelBase
{
    private readonly IProcessRepository _processRepository;

    public SettingsViewModel(IProcessRepository repository, ObservableCollection<TrackedProcess> sharedList)
    {
        _processRepository = repository;
        RegisteredProcesses = sharedList;
        LoadProcesses();
    }

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(AddProcessCommand))]
    [NotifyPropertyChangedFor(nameof(HasProcessNameToAdd))]
    private string? _processNameToAdd;
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(RemoveProcessCommand))]
    [NotifyPropertyChangedFor(nameof(HasProcessNameToRemove))]
    private string? _processNameToRemove;
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(RemoveProcessCommand))]
    private TrackedProcess? _selectedProcess;
    [ObservableProperty]
    ObservableCollection<TrackedProcess> _registeredProcesses = new();
    public bool HasProcessNameToAdd => !string.IsNullOrWhiteSpace(ProcessNameToAdd);
    public bool HasProcessNameToRemove => !string.IsNullOrWhiteSpace(ProcessNameToRemove);
    private bool CanAdd => !string.IsNullOrWhiteSpace(ProcessNameToAdd);
    private bool CanRemove => SelectedProcess != null || !string.IsNullOrWhiteSpace(ProcessNameToRemove);

    [RelayCommand(CanExecute = nameof(CanAdd))]
    private void AddProcess()
    {
        var newProcess = new TrackedProcess
        {
            ProcessName = ProcessNameToAdd!
        };
        _processRepository.AddProcess(newProcess);
        var processWithId = _processRepository.GetProcessByName(newProcess.ProcessName);

        if (processWithId != null)
        {
            RegisteredProcesses.Add(processWithId);
        }

        ClearAddText();
    }

    [RelayCommand(CanExecute = nameof(CanRemove))]
    private void RemoveProcess()
    {
        TrackedProcess? target = null;

        if (SelectedProcess != null)
        {
            target = SelectedProcess;
        }
        else if (!string.IsNullOrWhiteSpace(ProcessNameToRemove))
        {
            target = RegisteredProcesses.FirstOrDefault(p =>
                p.ProcessName.Equals(ProcessNameToRemove, StringComparison.OrdinalIgnoreCase));
        }

        if (target != null)
        {
            _processRepository.RemoveProcess(target.ProcessId);
            RegisteredProcesses.Remove(target);
            SelectedProcess = null;
        }
        ClearRemoveText();
    }
    private void LoadProcesses()
    {
        var processes = _processRepository.GetAll();
        RegisteredProcesses.Clear();
        foreach (var process in processes)
        {
            RegisteredProcesses.Add(process);
        }
    }
    private void ClearAddText()
    {
        ProcessNameToAdd = null;
    }
    private void ClearRemoveText()
    {
        ProcessNameToRemove = null;
    }
}

