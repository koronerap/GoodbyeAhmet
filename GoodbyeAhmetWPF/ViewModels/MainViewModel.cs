using GoodbyeAhmetWPF.Models;
using GoodbyeAhmetWPF.Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using MessageBox = System.Windows.MessageBox;

namespace GoodbyeAhmetWPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly SettingsService _settingsService;
        private readonly GoodbyeDpiService _goodbyeDpiService;
        private SettingsFile _settings;
        private bool _isRunning;
        private Preset? _selectedPreset;

        public MainViewModel()
        {
            _settingsService = new SettingsService();
            _settingsService.Load();
            _settings = _settingsService.Data;

            _goodbyeDpiService = new GoodbyeDpiService();

            Presets = new ObservableCollection<Preset>(PresetService.GetPresets());

            // Try to match current settings to a preset
            var matchingPreset = Presets.FirstOrDefault(p =>
                p.Modeset == _settings.Modeset &&
                p.TTL == _settings.TTL &&
                p.DNSV4Address == _settings.V4Address &&
                p.DNSV4Port == _settings.V4Port &&
                p.DNSV6Address == _settings.V6Address &&
                p.DNSV6Port == _settings.V6Port);

            if (matchingPreset != null)
            {
                SelectedPreset = matchingPreset;
            }

            StartCommand = new RelayCommand(Start, CanStart);
            StopCommand = new RelayCommand(Stop, CanStop);
            ToggleCommand = new RelayCommand(Toggle);
            SaveSettingsCommand = new RelayCommand(SaveSettings);
            ResetSettingsCommand = new RelayCommand(ResetSettings);
            ApplyPresetCommand = new RelayCommand(ApplyPreset);
            AboutCommand = new RelayCommand(ShowAbout);

            // Initialize Language
            LocalizationService.Instance.CurrentLanguage = _settings.Language;

            if (_settings.ActivateOnStart)
            {
                Start(null);
            }
        }

        public SettingsFile Settings
        {
            get => _settings;
            set => SetProperty(ref _settings, value);
        }

        public string SelectedLanguage
        {
            get => _settings.Language;
            set
            {
                if (_settings.Language != value)
                {
                    _settings.Language = value;
                    LocalizationService.Instance.CurrentLanguage = value;

                    // Force UI update for Settings since it holds the language value too
                    // though usually the ComboBox updates the source.
                    OnPropertyChanged();

                    // Also save immediately? Or wait for save button.
                    // User usually expects language change to persist or apply immediately.
                    // We'll let Save button handle persistence, but apply immediately.
                }
            }
        }

        public List<LanguageInfo> AvailableLanguages => LocalizationService.Instance.AvailableLanguages;

        public ObservableCollection<Preset> Presets { get; }

        public Preset? SelectedPreset
        {
            get => _selectedPreset;
            set
            {
                if (SetProperty(ref _selectedPreset, value))
                {
                    if (value != null)
                    {
                        ApplyPreset(value);
                    }
                }
            }
        }

        public bool IsRunning
        {
            get => _isRunning;
            set
            {
                if (SetProperty(ref _isRunning, value))
                {
                    // Force re-evaluation of commands
                    CommandManager.InvalidateRequerySuggested();
                }
            }
        }

        public ICommand StartCommand { get; }
        public ICommand StopCommand { get; }
        public ICommand ToggleCommand { get; }
        public ICommand SaveSettingsCommand { get; }
        public ICommand ResetSettingsCommand { get; }
        public ICommand ApplyPresetCommand { get; }
        public ICommand AboutCommand { get; }

        private bool CanStart(object? parameter) => !IsRunning;

        private void Start(object? parameter)
        {
            try
            {
                _goodbyeDpiService.Start(Settings);
                IsRunning = true;

                // Show notification
                NotificationService.Instance.ShowNotification("Goodbye Ahmet", LocalizationService.Instance["Connected"], System.Windows.Forms.ToolTipIcon.Info);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error starting GoodbyeDPI: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                IsRunning = false;
            }
        }

        private void Toggle(object? parameter)
        {
            if (IsRunning)
                Stop(null);
            else
                Start(null);
        }

        private bool CanStop(object? parameter) => IsRunning;

        private void Stop(object? parameter)
        {
            _goodbyeDpiService.Stop();
            IsRunning = false;
            NotificationService.Instance.ShowNotification("Goodbye Ahmet", LocalizationService.Instance["Disconnected"], System.Windows.Forms.ToolTipIcon.Info);
        }

        private void SaveSettings(object? parameter)
        {
            _settingsService.Save();
            MessageBox.Show("Settings saved.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ResetSettings(object? parameter)
        {
            Stop(null);
            _settingsService.Load(); // Re-load or reset
            Settings = _settingsService.Data;
            // In a real app we might want to deep copy or create new instance logic in service
            MessageBox.Show(LocalizationService.Instance["SettingsReset"], "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ShowAbout(object? parameter)
        {
            MessageBox.Show(LocalizationService.Instance["AboutContent"], LocalizationService.Instance["About"], MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ApplyPreset(object? parameter)
        {
            if (parameter is Preset preset)
            {
                Settings.UsePreset(preset);
                // Trigger property change for Settings fields if UI binds to them directly inside Settings object
                // Since Settings is an object, changes inside it might not notify unless SettingsFile implements INotifyPropertyChanged
                // For simplicity, we assume UI binds to MainViewModel.Settings which is the same object, 
                // but deep properties update might not reflect if not notified. 
                // Ideally SettingsFile should implement INotifyPropertyChanged.

                // Let's hack refresh by re-setting settings if needed or assume bindings are direct.
                // Better approach: Make SettingsFile observeable.
                OnPropertyChanged(nameof(Settings));
            }
        }

        public void Cleanup()
        {
            _goodbyeDpiService.Stop();
        }
    }
}
