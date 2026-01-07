using System;

namespace GoodbyeAhmetWPF.Models
{
    public class Preset
    {
        public string Name { get; set; } = string.Empty;
        public string Modeset { get; set; } = string.Empty;
        public string TTL { get; set; } = string.Empty;
        public string DNSV4Address { get; set; } = string.Empty;
        public string DNSV4Port { get; set; } = string.Empty;
        public string DNSV6Address { get; set; } = string.Empty;
        public string DNSV6Port { get; set; } = string.Empty;
        public string Blacklist { get; set; } = string.Empty;
    }
}
