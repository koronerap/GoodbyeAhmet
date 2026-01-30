using System.Configuration;
using System.Data;
using System.Threading;
using System.Windows;

namespace GoodbyeAhmetWPF;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : System.Windows.Application
{
    private static Mutex? _mutex = null;

    protected override void OnStartup(StartupEventArgs e)
    {
        const string appName = "GoodbyeAhmetWPF_Unique_Mutex_Name";
        bool createdNew;

        _mutex = new Mutex(true, appName, out createdNew);

        if (!createdNew)
        {
            // App is already running!
            // Load localized message if possible, or fallback to English
            // Since we haven't loaded localization fully yet, we might check file manually or just hardcode for safety
            System.Windows.MessageBox.Show("Goodbye Ahmet is already running!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            Shutdown();
            return;
        }

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

