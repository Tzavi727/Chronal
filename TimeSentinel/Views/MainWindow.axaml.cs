using Avalonia.Controls;
using TimeSentinel.ViewModels;

namespace TimeSentinel.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    protected override void OnClosing(WindowClosingEventArgs e)
    {
        if (DataContext is MainViewModel vm)
        {
            vm.SaveAllProcesses();
        }
        base.OnClosing(e);
    }
}