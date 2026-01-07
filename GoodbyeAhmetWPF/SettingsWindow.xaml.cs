using System.Windows;
using System.Windows.Input;

namespace GoodbyeAhmetWPF
{
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void PresetLabel_Click(object sender, MouseButtonEventArgs e)
        {
            PresetComboBox.IsDropDownOpen = !PresetComboBox.IsDropDownOpen;
        }
    }
}
