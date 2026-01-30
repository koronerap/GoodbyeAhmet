using GoodbyeAhmetWPF.ViewModels;
using GoodbyeAhmetWPF.Services;
using System.Windows;
using System.ComponentModel;

namespace GoodbyeAhmetWPF;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        // Setup Notification Icon via Service
        var notifyService = NotificationService.Instance;
        notifyService.SetDoubleClickAction(ShowWindow);
        notifyService.AddContextMenuItem("Show", ShowWindow);
        notifyService.AddContextMenuItem("Exit", CloseApp);

        Loaded += MainWindow_Loaded;
        Closing += MainWindow_Closing;
    }

    private void OpenSettings(object sender, RoutedEventArgs e)
    {
        var settingsWindow = new SettingsWindow();
        settingsWindow.DataContext = this.DataContext; // Share VM
        settingsWindow.Owner = this;
        settingsWindow.ShowDialog();
    }

    private void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        if (DataContext is MainViewModel vm)
        {
            if (vm.Settings.LaunchOnStart)
            {
                Hide();
                if (vm.StartCommand.CanExecute(null))
                {
                    // Already started in VM constructor if logic placed there, 
                    // but good to ensure or show balloon tip.
                    NotificationService.Instance.ShowNotification("Goodbye Ahmet", LocalizationService.Instance["RunningInBackground"]);
                }
            }
        }
    }

    private void MainWindow_Closing(object? sender, CancelEventArgs e)
    {
        // Minimize to tray instead of closing, unless explicit exit?
        // Original app: "Form1_FormClosing" called "KillProcesses". So it actually exited on close.
        // It only hid when "Launch()" was called and succeeded.
        // But users usually expect "X" to close app effectively or min to tray.
        // Let's implement: X closes app (stops service). Tray icon is for when it's hidden?
        // Wait, original `Launch()` called `Hide()`. And `notifyIcon` became visible.

        // Let's stick to simple behavior: 
        // If running, maybe ask or warn? Or just kill processes as original did.

        if (DataContext is MainViewModel vm)
        {
            vm.Cleanup();
        }
        NotificationService.Instance.Dispose();
    }

    private void ShowWindow()
    {
        Show();
        WindowState = WindowState.Normal;
        Activate();
    }

    private void CloseApp()
    {
        Close();
    }

    // Allow hiding nicely
    protected override void OnStateChanged(EventArgs e)
    {
        if (WindowState == WindowState.Minimized)
        {
            Hide();
        }
        base.OnStateChanged(e);
    }
}