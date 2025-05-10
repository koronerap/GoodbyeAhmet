using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodbyeAhmet
{
    public static class Presets
    {
        public static List<Preset> presets = new List<Preset>()
        {
            new Preset()
            {
                Name = "Any Country",
                Modeset = "-5",
                TTL = "",
                DNSV4Address = "",
                DNSV4Port = "",
                DNSV6Address = "",
                DNSV6Port = "",
                Blacklist = "",
            },
            new Preset()
            {
                Name = "Any Country (DNS Redir)",
                Modeset = "-5",
                TTL = "",
                DNSV4Address = "77.88.8.8",
                DNSV4Port = "1253",
                DNSV6Address = "2a02:6b8::feed:0ff",
                DNSV6Port = "1253",
                Blacklist = "",
            },
            new Preset()
            {
                Name = "Turkey (DNS Redir)",
                Modeset = "-5",
                TTL = "5",
                DNSV4Address = "77.88.8.8",
                DNSV4Port = "1253",
                DNSV6Address = "2a02:6b8::feed:0ff",
                DNSV6Port = "1253",
                Blacklist = "",
            },
            new Preset()
            {
                Name = "Turkey Superonline",
                Modeset = "",
                TTL = "3",
                DNSV4Address = "",
                DNSV4Port = "",
                DNSV6Address = "",
                DNSV6Port = "",
                Blacklist = "",
            },
            new Preset()
            {
                Name = "Turkey Superonline Alternative",
                Modeset = "-5",
                TTL = "",
                DNSV4Address = "",
                DNSV4Port = "",
                DNSV6Address = "",
                DNSV6Port = "",
                Blacklist = "",
            },
            new Preset()
            {
                Name = "Russia",
                Modeset = "-5",
                TTL = "",
                DNSV4Address = "",
                DNSV4Port = "",
                DNSV6Address = "",
                DNSV6Port = "",
                Blacklist = "",
            },
        };

        public static List<Blacklist> blacklists = new List<Blacklist> {
            new Blacklist()
            {
                Name = "Russia",
                URL = "https://antizapret.prostovpn.org/domains-export.txt",
            }
        };
    }

    public class Preset
    {
        public string Name { get; set; }
        public string Modeset { get; set; }
        public string TTL { get; set; }
        public string DNSV4Address { get; set; }
        public string DNSV4Port { get; set; }
        public string DNSV6Address { get; set; }
        public string DNSV6Port { get; set; }
        public string Blacklist { get; set; }

    }

    public class Blacklist
    {
        public string Name { get; set; }
        public string URL { get; set; }
    }
}
