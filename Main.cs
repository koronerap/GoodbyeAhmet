using System.Diagnostics;
using System.Text;

namespace GoodbyeAhmet
{
    public partial class Main : Form
    {
        private Process? process;

        private static string APP_PATH_64 = Application.StartupPath + @"essentials\goodbyedpi\x86_64\goodbyedpi.exe";
        private static string APP_PATH_32 = Application.StartupPath + @"essentials\goodbyedpi\x86\goodbyedpi.exe";
        private static string SAVE_FILE_PATH = "preferences";

        private static string APP_PATH => Environment.Is64BitProcess ? APP_PATH_64 : APP_PATH_32;

        public Main()
        {
            InitializeComponent();

            presetsComboBox.Items.Clear();

            presetsComboBox.SelectedIndexChanged += PresetsComboBox_SelectedIndexChanged;

            foreach(var preset in Presets.presets)
                presetsComboBox.Items.Add(preset.Name);

            Load();
        }

        private void PresetsComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (presetsComboBox.SelectedIndex < 0) return;
            ApplyPreset(Presets.presets[presetsComboBox.SelectedIndex]);
            Save();
        }

        private void Load()
        {
            if (File.Exists(SAVE_FILE_PATH))
            {
                string text = File.ReadAllText(SAVE_FILE_PATH);

                if(int.TryParse(text, out int preset))
                    presetsComboBox.SelectedIndex = preset;
            }
            else
            {
                presetsComboBox.SelectedIndex = 0;
            }
        }

        private void Save()
        {
            File.WriteAllText(SAVE_FILE_PATH,presetsComboBox.SelectedIndex.ToString());
        }

        private void ApplyPreset(Preset preset)
        {
            modesetTextBox.Text = preset.Modeset;
            ttlTextBox.Text = preset.TTL;
            dnsV4AddressTextBox.Text = preset.DNSV4Address;
            dnsV4PortTextBox.Text = preset.DNSV4Port;
            dnsV6AddressTextBox.Text = preset.DNSV6Address;
            dnsV6PortTextBox.Text = preset.DNSV6Port;
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

            StringBuilder arguments = new StringBuilder();

            if (modesetTextBox.Text.Length > 0)
                arguments.Append($"{modesetTextBox.Text} ");

            if(ttlTextBox.Text.Length > 0)
                arguments.Append($"--set-ttl {ttlTextBox.Text} ");

            if (dnsV4AddressTextBox.Text.Length > 0)
                arguments.Append($"--dns-addr {dnsV4AddressTextBox.Text} ");

            if (dnsV4PortTextBox.Text.Length > 0)
                arguments.Append($"--dns-port {dnsV4PortTextBox.Text} ");

            if (dnsV6AddressTextBox.Text.Length > 0)
                arguments.Append($"--dnsv6-addr {dnsV6AddressTextBox.Text} ");

            if (dnsV6PortTextBox.Text.Length > 0)
                arguments.Append($"--dnsv6-port {dnsV6PortTextBox.Text}");

            string args = arguments.ToString().Trim();

            startInfo.Arguments = args;

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
