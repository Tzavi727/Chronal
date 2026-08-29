using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using System;
using TimeSentinel.Data;
using TimeSentinel.Repositories;
using TimeSentinel.Services;
using TimeSentinel.ViewModels;
using TimeSentinel.Views;

namespace TimeSentinel;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            string dbPath = "Data Source=TimerData.db";
            DataBaseBootstrap dataBase = new();
            dataBase.Setup();
            ProcessService processService = new();
            ProcessRepository repository = new(dbPath);
            CounterService counterService = new(repository,processService);
            var mainVM = new MainViewModel(repository, counterService);
            desktop.MainWindow = new MainWindow
            {
                DataContext = mainVM,
            };
            counterService.SetupTimer(mainVM.SharedProcesses);
        }
        base.OnFrameworkInitializationCompleted();
    }
}