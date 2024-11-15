using System.Diagnostics;

namespace GoodbyeAhmet
{
    public partial class Main : Form
    {
        private Process? process;

        private static string APP_PATH_64 = Application.StartupPath + @"essentials\goodbyedpi\x86_64\goodbyedpi.exe";
        private static string APP_PATH_32 = Application.StartupPath + @"essentials\goodbyedpi\x86\goodbyedpi.exe";

        private static string APP_PATH => Environment.Is64BitProcess ? APP_PATH_64 : APP_PATH_32;

        public Main()
        {
            InitializeComponent();
        }

        private void launchButton_Click(object sender, EventArgs e)
        {
            if (!File.Exists(APP_PATH))
            {
                MessageBox.Show($"Goodbye DPI not found at:\n{APP_PATH}!");
                return;
            }

            launchButton.Enabled = false;

            ProcessStartInfo startInfo = new ProcessStartInfo(APP_PATH)
            {
                CreateNoWindow = true,
            };

            string arguments = $"{modesetTextBox.Text} " +
                $"--dns-addr {dnsV4AddressTextBox.Text} " +
                $"--dns-port {dnsV4PortTextBox.Text} " +
                $"--dnsv6-addr {dnsV6AddressTextBox.Text} " +
                $"--dnsv6-port {dnsV6PortTextBox.Text}";

            startInfo.Arguments = arguments;

            try
            {
                process = Process.Start(startInfo);
                
                Hide();
                notifyIcon.Visible = true;
            }
            catch (System.ComponentModel.Win32Exception)
            {
                MessageBox.Show("Failed to start the application as an administrator.");
                launchButton.Enabled = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            process?.Kill();
            process?.Close();
            process?.Dispose();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            process?.Kill();
            process?.Close();
            process?.Dispose();
            Show();
            launchButton.Enabled = true;
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }
    }
}
