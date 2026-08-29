using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using TimeSentinel.Data;
using TimeSentinel.Repositories;
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
            ProcessRepository repository = new ProcessRepository(dbPath);
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainViewModel(repository),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}