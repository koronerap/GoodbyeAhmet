using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoodbyeAhmet
{
    public partial class ConnectionSettings : Form
    {
        public ConnectionSettings()
        {
            InitializeComponent();

            Clear();

            foreach (var preset in Presets.presets)
                presetComboBox.Items.Add(preset.Name);

            Fill();

            Trace.WriteLine($"Modeset: {Settings.Data.Modeset}");
            Trace.WriteLine($"TTL: {Settings.Data.TTL}");
            Trace.WriteLine($"V4Address: {Settings.Data.V4Address}");
            Trace.WriteLine($"V4Port: {Settings.Data.V4Port}");
            Trace.WriteLine($"V6Address: {Settings.Data.V6Address}");
            Trace.WriteLine($"V6Port: {Settings.Data.V6Port}");
        }

        private void Fill()
        {
            Settings.Load();

            if (Settings.Data == null) return;

            modesetTextBox.Text = Settings.Data.Modeset;
            ttlTextBox.Text = Settings.Data.TTL;
            v4aTextBox.Text = Settings.Data.V4Address;
            v4pTextBox.Text = Settings.Data.V4Port;
            v6aTextBox.Text = Settings.Data.V6Address;
            v6pTextBox.Text = Settings.Data.V6Port;
            launchOnStart.Text = Settings.Data.LaunchOnStart ? "Enabled" : "Disabled";
        }

        private void ApplyPreset(Preset preset)
        {
            modesetTextBox.Text = preset.Modeset;
            ttlTextBox.Text = preset.TTL;
            v4aTextBox.Text = preset.DNSV4Address;
            v4pTextBox.Text = preset.DNSV4Port;
            v6aTextBox.Text = preset.DNSV6Address;
            v6pTextBox.Text = preset.DNSV6Port;
        }

        private void Clear()
        {
            presetComboBox.Items.Clear();
            modesetTextBox.Text = "";
            ttlTextBox.Text = "";
            v4aTextBox.Text = "";
            v4pTextBox.Text = "";
            v6aTextBox.Text = "";
            v6pTextBox.Text = "";
        }


        private void presetComboBoxPanel_Click(object sender, EventArgs e)
        {
            presetComboBox.DroppedDown = true;
        }

        private void presetComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            presetComboBoxLabel.Text = presetComboBox.SelectedItem?.ToString();

            ApplyPreset(Presets.presets[presetComboBox.SelectedIndex]);
        }

        private void presetComboBoxLabel_Click(object sender, EventArgs e)
        {
            presetComboBox_SelectedIndexChanged(sender, e);
        }

        private void saveAndExitButton_Click(object sender, EventArgs e)
        {
            if (Settings.Data == null) return;

            Settings.Data.Modeset = modesetTextBox.Text;
            Settings.Data.TTL = ttlTextBox.Text;
            Settings.Data.V4Address = v4aTextBox.Text;
            Settings.Data.V4Port = v4pTextBox.Text;
            Settings.Data.V6Address = v6aTextBox.Text;
            Settings.Data.V6Port = v6pTextBox.Text;

            Settings.Save();

            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void launchOnStart_Click(object sender, EventArgs e)
        {
            Settings.Data.LaunchOnStart = !Settings.Data.LaunchOnStart;

            launchOnStart.Text = Settings.Data.LaunchOnStart ? "Enabled" : "Disabled";
        }
    }
}
