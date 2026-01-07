using System.Configuration;
using System.Data;
using System.Windows;

namespace GoodbyeAhmetWPF;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : System.Windows.Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        AppDomain.CurrentDomain.UnhandledException += (s, args) =>
        {
            System.Windows.MessageBox.Show($"CurrentDomain Error: {args.ExceptionObject}", "Crash");
        };

        this.DispatcherUnhandledException += (s, args) =>
        {
            System.Windows.MessageBox.Show($"Dispatcher Error: {args.Exception.Message}", "Crash");
            args.Handled = true;
        };
    }
}

