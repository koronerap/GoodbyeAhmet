using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using GoodbyeAhmetWPF.Models;

namespace GoodbyeAhmetWPF.Services
{
    public class GoodbyeDpiService
    {
        private Process? _process;

        // Path logic needs to be robust. 
        // Assuming the essentials folder is copied to the output directory, same as the WinForms app.
        private static string APP_PATH_64 => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"essentials\goodbyedpi\x86_64\goodbyedpi.exe");
        private static string APP_PATH_32 => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"essentials\goodbyedpi\x86\goodbyedpi.exe");

        private static string APP_PATH => Environment.Is64BitProcess ? APP_PATH_64 : APP_PATH_32;

        public bool IsRunning => _process != null && !_process.HasExited;

        public void Start(SettingsFile settings)
        {
            if (IsRunning) return;

            if (!File.Exists(APP_PATH))
            {
                throw new FileNotFoundException($"Goodbye DPI not found at: {APP_PATH}");
            }

            ProcessStartInfo startInfo = new ProcessStartInfo(APP_PATH)
            {
                CreateNoWindow = true,
                UseShellExecute = false, // Required for CreateNoWindow to verify, typically false for services
                WindowStyle = ProcessWindowStyle.Hidden
            };

            StringBuilder arguments = new StringBuilder();

            if (!string.IsNullOrEmpty(settings.Modeset))
                arguments.Append($"{settings.Modeset} ");

            if (!string.IsNullOrEmpty(settings.TTL))
                arguments.Append($"--set-ttl {settings.TTL} ");

            if (!string.IsNullOrEmpty(settings.V4Address))
                arguments.Append($"--dns-addr {settings.V4Address} ");

            if (!string.IsNullOrEmpty(settings.V4Port))
                arguments.Append($"--dns-port {settings.V4Port} ");

            if (!string.IsNullOrEmpty(settings.V6Address))
                arguments.Append($"--dnsv6-addr {settings.V6Address} ");

            if (!string.IsNullOrEmpty(settings.V6Port))
                arguments.Append($"--dnsv6-port {settings.V6Port}");

            string args = arguments.ToString().Trim();
            startInfo.Arguments = args;

            try
            {
                _process = Process.Start(startInfo);
                Trace.WriteLine($"App started with arguments: {startInfo.Arguments}");
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Failed to start process: {ex.Message}");
                throw;
            }
        }

        public void Stop()
        {
            KillProcesses();
        }

        private void KillProcesses()
        {
            try
            {
                // Kill all instances of goodbyedpi to be safe, similar to original KillProcesses
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
                    finally
                    {
                        p.Dispose();
                    }
                }

                if (_process != null)
                {
                    if (!_process.HasExited)
                    {
                        try
                        {
                            _process.Kill();
                        }
                        catch (Exception ex)
                        {
                            Trace.WriteLine($"Main process kill error: {ex.Message}");
                        }
                    }
                    _process.Dispose();
                    _process = null;
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"KillProcesses general error: {ex.Message}");
            }
        }
    }
}
