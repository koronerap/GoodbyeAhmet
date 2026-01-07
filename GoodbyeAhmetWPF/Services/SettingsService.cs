using GoodbyeAhmetWPF.Models;
using System.IO;
using System.Text.Json;
using System.Diagnostics;

namespace GoodbyeAhmetWPF.Services
{
    public class SettingsService
    {
        private const string FILE_PATH = "settings.json";

        public SettingsFile Data { get; private set; }

        public SettingsService()
        {
            Data = new SettingsFile();
        }

        public void Load()
        {
            if (!File.Exists(FILE_PATH))
            {
                // Initialize default logic here if needed, for now just use defaults from class
                Data = new SettingsFile();
                // Apply first preset as default
                var presets = PresetService.GetPresets();
                if (presets.Count > 0)
                {
                    Data.UsePreset(presets[0]);
                }
                Save();
                return;
            }

            try
            {
                string content = File.ReadAllText(FILE_PATH);
                Data = JsonSerializer.Deserialize<SettingsFile>(content) ?? new SettingsFile();
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Error loading settings: {ex.Message}");
                Data = new SettingsFile();
            }
        }

        public void Save()
        {
            if (Data == null)
            {
                Data = new SettingsFile();
            }

            try
            {
                string content = JsonSerializer.Serialize(Data, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(FILE_PATH, content);
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Error saving settings: {ex.Message}");
            }
        }
    }
}
