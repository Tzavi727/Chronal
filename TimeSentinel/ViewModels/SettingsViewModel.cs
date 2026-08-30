using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using TimeSentinel.Interfaces;
using TimeSentinel.Models;

namespace TimeSentinel.ViewModels;

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
    public bool HasProcessNameToRemove => !string.IsNullOrWhiteSpace(ProcessNameToAdd);
    private bool CanAdd => !string.IsNullOrWhiteSpace(ProcessNameToAdd);
    private bool CanRemove => SelectedProcess != null || !string.IsNullOrWhiteSpace(ProcessNameToRemove);

    [RelayCommand(CanExecute = nameof(CanAdd))]
    private void AddProcess()
    {
        var newProcess = new TrackedProcess
        {
            ProcessName = ProcessNameToAdd
        };
        RegisteredProcesses.Add(newProcess);
        _processRepository.AddProcess(newProcess);
        LoadProcesses();
        ClearAddText();
    }
    [RelayCommand(CanExecute = nameof(CanRemove))]
    private void RemoveProcess()
    {
        if (SelectedProcess != null)
        {
            _processRepository.RemoveProcess(SelectedProcess.ProcessId);
            RegisteredProcesses.Remove(SelectedProcess);
            SelectedProcess = null;
        }
        else if (!string.IsNullOrWhiteSpace(ProcessNameToRemove))
        {
            var target = RegisteredProcesses.FirstOrDefault(p =>
                p.ProcessName.Equals(ProcessNameToRemove));

            if (target != null)
            {
                _processRepository.RemoveProcess(target.ProcessId);
                RegisteredProcesses.Remove(target);
            }
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

