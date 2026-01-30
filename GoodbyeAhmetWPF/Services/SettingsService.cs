using GoodbyeAhmetWPF.Models;
using System.IO;
using System.Text.Json;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

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

                // Auto-detect system language
                try
                {
                    var culture = CultureInfo.CurrentCulture;
                    var available = LocalizationService.Instance.AvailableLanguages;

                    // 1. Try exact match (e.g. "tr-TR")
                    var exact = available.FirstOrDefault(x => x.Code.Equals(culture.Name, StringComparison.OrdinalIgnoreCase));
                    if (exact != null)
                    {
                        Data.Language = exact.Code;
                    }
                    // 2. Try 2-letter code match (e.g. "tr" matches "tr-TR")
                    else
                    {
                        var twoLetter = culture.TwoLetterISOLanguageName;
                        var match = available.FirstOrDefault(l => l.Code.StartsWith(twoLetter, StringComparison.OrdinalIgnoreCase));
                        if (match != null)
                        {
                            Data.Language = match.Code;
                        }
                    }
                }
                catch
                {
                    // Fallback to default
                }

                // Apply first preset as default
                var presets = PresetService.GetPresets();
                if (presets.Count > 0)
                {
                    Data.UsePreset(presets[0]);
                }

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
