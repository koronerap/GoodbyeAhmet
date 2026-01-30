using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Globalization;
using GoodbyeAhmetWPF.Models;

namespace GoodbyeAhmetWPF.Services
{
    public class LocalizationService : INotifyPropertyChanged
    {
        private static LocalizationService? _instance;
        public static LocalizationService Instance => _instance ??= new LocalizationService();

        private Dictionary<string, string> _strings = new Dictionary<string, string>();

        private string LocalFolder => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "local");

        public string this[string key]
        {
            get
            {
                if (_strings.TryGetValue(key, out var value))
                {
                    return value;
                }
                return key;
            }
        }

        private string _currentLanguage = "en-US";
        public string CurrentLanguage
        {
            get => _currentLanguage;
            set
            {
                if (_currentLanguage != value)
                {
                    _currentLanguage = value;
                    LoadLanguage(_currentLanguage);
                    OnPropertyChanged();
                    // Notify all properties changed so indexer bindings update
                    OnPropertyChanged(string.Empty);
                }
            }
        }

        public List<LanguageInfo> AvailableLanguages
        {
            get
            {
                if (Directory.Exists(LocalFolder))
                {
                    return Directory.GetFiles(LocalFolder, "*.json")
                        .Select(path =>
                        {
                            var code = Path.GetFileNameWithoutExtension(path);
                            string name = code;
                            try
                            {
                                var culture = CultureInfo.GetCultureInfo(code);
                                name = culture.NativeName;
                                // Capitalize first letter
                                if (name.Length > 0)
                                    name = char.ToUpper(name[0]) + name.Substring(1);
                            }
                            catch { }

                            return new LanguageInfo { Code = code, Name = name };
                        })
                        .OrderBy(x => x.Name)
                        .ToList();
                }
                return new List<LanguageInfo> { new LanguageInfo { Code = "en-US", Name = "English (United States)" } };
            }
        }

        private LocalizationService()
        {
            // Initial load
            LoadLanguage(_currentLanguage);
        }

        public void LoadLanguage(string languageCode)
        {
            string path = Path.Combine(LocalFolder, $"{languageCode}.json");
            if (File.Exists(path))
            {
                try
                {
                    string json = File.ReadAllText(path);
                    var dict = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
                    if (dict != null)
                    {
                        _strings = dict;
                    }
                }
                catch
                {
                    // Fallback or log
                }
            }
            else
            {
                // Try finding any json if default not found? Or just keep empty
            }

            // Notify that everything changed
            OnPropertyChanged(string.Empty);
        }

        // Helper to refresh when languages are added
        public void RefreshAvailableLanguages()
        {
            OnPropertyChanged(nameof(AvailableLanguages));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
