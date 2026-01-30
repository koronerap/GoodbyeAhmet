using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GoodbyeAhmetWPF.Models
{
    public class SettingsFile : INotifyPropertyChanged
    {
        private string _modeset = "";
        public string Modeset
        {
            get => _modeset;
            set { _modeset = value; OnPropertyChanged(); }
        }

        private string _ttl = "";
        public string TTL
        {
            get => _ttl;
            set { _ttl = value; OnPropertyChanged(); }
        }

        private string _v4Address = "";
        public string V4Address
        {
            get => _v4Address;
            set { _v4Address = value; OnPropertyChanged(); }
        }

        private string _v4Port = "";
        public string V4Port
        {
            get => _v4Port;
            set { _v4Port = value; OnPropertyChanged(); }
        }

        private string _v6Address = "";
        public string V6Address
        {
            get => _v6Address;
            set { _v6Address = value; OnPropertyChanged(); }
        }

        private string _v6Port = "";
        public string V6Port
        {
            get => _v6Port;
            set { _v6Port = value; OnPropertyChanged(); }
        }

        private bool _launchOnStart = false;
        public bool LaunchOnStart
        {
            get => _launchOnStart;
            set { _launchOnStart = value; OnPropertyChanged(); }
        }

        private bool _activateOnStart = false;
        public bool ActivateOnStart
        {
            get => _activateOnStart;
            set { _activateOnStart = value; OnPropertyChanged(); }
        }

        private string _language = "en-US";
        public string Language
        {
            get => _language;
            set { _language = value; OnPropertyChanged(); }
        }

        public SettingsFile()
        {
            // Default initialization if needed
        }

        public void UsePreset(Preset preset)
        {
            Modeset = preset.Modeset;
            TTL = preset.TTL;
            V4Address = preset.DNSV4Address;
            V4Port = preset.DNSV4Port;
            V6Address = preset.DNSV6Address;
            V6Port = preset.DNSV6Port;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
