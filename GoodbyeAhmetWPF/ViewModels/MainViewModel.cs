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

            // Try to match current settings to a preset, or default to first
            // This is a simplification; in reality we might want to check values matches
            SelectedPreset = Presets.FirstOrDefault();

            StartCommand = new RelayCommand(Start, CanStart);
            StopCommand = new RelayCommand(Stop, CanStop);
            ToggleCommand = new RelayCommand(Toggle);
            SaveSettingsCommand = new RelayCommand(SaveSettings);
            ResetSettingsCommand = new RelayCommand(ResetSettings);
            ApplyPresetCommand = new RelayCommand(ApplyPreset);

            if (_settings.LaunchOnStart)
            {
                // Logic handled in View for minimizing, but we can start service here if desired
                // Though typically UI events drive this to allow main window to show first if needed
                // or hide immediately.
                Start(null);
            }
        }

        public SettingsFile Settings
        {
            get => _settings;
            set => SetProperty(ref _settings, value);
        }

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

        private bool CanStart(object? parameter) => !IsRunning;

        private void Start(object? parameter)
        {
            try
            {
                _goodbyeDpiService.Start(Settings);
                IsRunning = true;

                // Show notification (handled in view usually, or via a notification service)
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
            MessageBox.Show("Settings reset.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
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
