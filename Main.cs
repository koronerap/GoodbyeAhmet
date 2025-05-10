using System.Diagnostics;
using System.Text;

namespace GoodbyeAhmet
{
    public partial class Main : Form
    {
        private Process? process;

        private static string APP_PATH_64 = Application.StartupPath + @"essentials\goodbyedpi\x86_64\goodbyedpi.exe";
        private static string APP_PATH_32 = Application.StartupPath + @"essentials\goodbyedpi\x86\goodbyedpi.exe";

        private static string APP_PATH => Environment.Is64BitProcess ? APP_PATH_64 : APP_PATH_32;

        private bool firstLaunch = true;

        public Main()
        {
            InitializeComponent();

            Settings.Load();
            Application.ApplicationExit += Application_ApplicationExit;
        }

        private void Application_ApplicationExit(object? sender, EventArgs e)
        {
            KillProcesses();
            Trace.WriteLine("app exit");
        }

        private void Launch()
        {
            if (!File.Exists(APP_PATH))
            {
                MessageBox.Show($"Goodbye DPI not found at:\n{APP_PATH}!");
                return;
            }

            if (Settings.Data == null)
            {
                MessageBox.Show($"Settings couldn't be loaded!");
                return;
            }

            launchButton.Enabled = false;

            ProcessStartInfo startInfo = new ProcessStartInfo(APP_PATH)
            {
                CreateNoWindow = true,
            };

            StringBuilder arguments = new StringBuilder();

            if (Settings.Data.Modeset.Length > 0)
                arguments.Append($"{Settings.Data.Modeset} ");

            if (Settings.Data.TTL.Length > 0)
                arguments.Append($"--set-ttl {Settings.Data.TTL} ");

            if (Settings.Data.V4Address.Length > 0)
                arguments.Append($"--dns-addr {Settings.Data.V4Address} ");

            if (Settings.Data.V4Port.Length > 0)
                arguments.Append($"--dns-port {Settings.Data.V4Port} ");

            if (Settings.Data.V6Address.Length > 0)
                arguments.Append($"--dnsv6-addr {Settings.Data.V6Address} ");

            if (Settings.Data.V6Port.Length > 0)
                arguments.Append($"--dnsv6-port {Settings.Data.V6Port}");

            string args = arguments.ToString().Trim();

            startInfo.Arguments = args;

            try
            {
                process = Process.Start(startInfo);

                Trace.WriteLine($"App started with arguments: {arguments}");

                Hide();
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(3000, "Information", "Goodbye Ahmet is now active.", ToolTipIcon.Info);
            }
            catch (System.ComponentModel.Win32Exception)
            {
                MessageBox.Show("Failed to start the application as an administrator.");
                launchButton.Enabled = true;
            }
        }

        private void launchButton_Click(object sender, EventArgs e)
        {
            Launch();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            KillProcesses();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void KillProcesses()
        {
            try
            {
                var processes = Process.GetProcessesByName("goodbyedpi");

                foreach (var p in processes)
                {
                    try
                    {
                        if (!p.HasExited)
                            p.Kill();
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine($"Process {p.Id} kill error: {ex.Message}");
                    }

                    try
                    {
                        p.Close();
                        p.Dispose();
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine($"Process {p.Id} cleanup error: {ex.Message}");
                    }
                }

                if (process != null && !process.HasExited)
                {
                    try
                    {
                        process.Kill();
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine($"Main process kill error: {ex.Message}");
                    }

                    try
                    {
                        process.Close();
                        process.Dispose();
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine($"Main process cleanup error: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"KillProcesses genel hata: {ex.Message}");
            }
        }


        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KillProcesses();

            WindowState = FormWindowState.Maximized;
            ShowInTaskbar = true;

            Show();
            launchButton.Enabled = true;
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            new ConnectionSettings().ShowDialog();
        }


        private void Main_Load(object sender, EventArgs e)
        {
            if (!firstLaunch) return;
            firstLaunch = false;

            if (Settings.Data == null) return;
            if (Settings.Data.LaunchOnStart)
            {
                WindowState = FormWindowState.Minimized;
                ShowInTaskbar = false;

                BeginInvoke(new MethodInvoker(delegate
                {
                    Hide();
                }));

                Launch();
            }
        }
    }
}
