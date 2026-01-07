using GoodbyeAhmetWPF.Models;
using System.Collections.Generic;

namespace GoodbyeAhmetWPF.Services
{
    public static class PresetService
    {
        public static List<Preset> GetPresets()
        {
            return new List<Preset>()
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
        }

        public static List<Blacklist> GetBlacklists()
        {
            return new List<Blacklist> {
                new Blacklist()
                {
                    Name = "Russia",
                    URL = "https://antizapret.prostovpn.org/domains-export.txt",
                }
            };
        }
    }
}
