using GoodbyeAhmetWPF.ViewModels;
using System.Windows;
using System.ComponentModel;

namespace GoodbyeAhmetWPF;

public partial class MainWindow : Window
{
    private System.Windows.Forms.NotifyIcon _notifyIcon;

    public MainWindow()
    {
        InitializeComponent();

        _notifyIcon = new System.Windows.Forms.NotifyIcon();
        try
        {
            var assembly = System.Reflection.Assembly.GetEntryAssembly();
            if (assembly != null)
            {
                // Try to get icon, but don't crash if fails
                // _notifyIcon.Icon = System.Drawing.Icon.ExtractAssociatedIcon(assembly.Location);
                // ExtractAssociatedIcon might fail for DLLs. Let's just use a default or try-catch.
                // Better: Load from resource if available.
                // For now, let's try a safer approach or just skip if it fails.
                if (System.IO.File.Exists(assembly.Location))
                    _notifyIcon.Icon = System.Drawing.Icon.ExtractAssociatedIcon(assembly.Location);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Trace.WriteLine($"Icon error: {ex.Message}");
            // Fallback to a system icon or null (might not show)
            _notifyIcon.Icon = System.Drawing.SystemIcons.Application;
        }

        if (_notifyIcon.Icon == null)
            _notifyIcon.Icon = System.Drawing.SystemIcons.Application;

        _notifyIcon.Visible = true;
        _notifyIcon.Text = "Goodbye Ahmet";
        _notifyIcon.DoubleClick += (s, args) => ShowWindow();

        var contextMenu = new System.Windows.Forms.ContextMenuStrip();
        contextMenu.Items.Add("Show", null, (s, e) => ShowWindow());
        contextMenu.Items.Add("Exit", null, (s, e) => CloseApp());
        _notifyIcon.ContextMenuStrip = contextMenu;

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
                    _notifyIcon.ShowBalloonTip(3000, "Goodbye Ahmet", "Running in background", System.Windows.Forms.ToolTipIcon.Info);
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
        _notifyIcon.Dispose();
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