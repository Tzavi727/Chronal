using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using System;
using Chronal.Data;
using Chronal.Repositories;
using Chronal.Services;
using Chronal.ViewModels;
using Chronal.Views;

namespace Chronal;

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
    private void TrayIcon_OnClicked(object? sender, EventArgs e)
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var window = desktop.MainWindow;
            if (window != null)
            {
                window.Show();
                window.WindowState = WindowState.Normal;
                window.Activate();
            }
        }
    }
}