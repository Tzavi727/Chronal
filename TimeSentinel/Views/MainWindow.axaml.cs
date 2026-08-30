using Avalonia.Controls;
using TimeSentinel.ViewModels;

namespace TimeSentinel.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        this.PropertyChanged += (sender, e) =>
        {
            if (e.Property == WindowStateProperty && WindowState == WindowState.Minimized)
            {
                this.Hide();
            }
        };
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