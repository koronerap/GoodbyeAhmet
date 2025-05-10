using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Diagnostics;

namespace GoodbyeAhmet
{
    internal class Settings
    {
        public const string FILE_PATH = "settings.json";

        public static SettingsFile? Data { get; set; }

        public static void Load()
        {
            if (!File.Exists(FILE_PATH))
                Save();

            string content = File.ReadAllText(FILE_PATH);

            Data = JsonSerializer.Deserialize<SettingsFile>(content);
        }

        public static void Save()
        {
            if(Data == null)
            {
                Data = new SettingsFile();
            }

            string content = JsonSerializer.Serialize(Data);

            Trace.WriteLine(content);

            File.WriteAllText(FILE_PATH, content);
        }
    }

    public class SettingsFile
    {
        public string Modeset { get; set; } = "";
        public string TTL { get; set; } = "";
        public string V4Address { get; set; } = "";
        public string V4Port { get; set; } = "";
        public string V6Address { get; set; } = "";
        public string V6Port { get; set; } = "";
        public bool LaunchOnStart { get; set; } = false;

        public SettingsFile()
        {
            UsePreset(Presets.presets[0]);
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
    }
}
