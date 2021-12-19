using System;
using System.Windows;
using System.Windows.Controls;

namespace TexturePig.Views.Pages
{
    /// <summary>
    /// Interaction logic for Actions.xaml
    /// </summary>
    public partial class Actions : Page
    {
        public Actions()
        {
            InitializeComponent();
        }

        private void ButtonTaskbar_Click(object sender, RoutedEventArgs e)
        {
            int selectedState = TaskbarStatusCombo.SelectedIndex;

            Int32.TryParse(TaskbarValueText.Text, out int value);

            if (value > 100)
            {
                value = 100;
            }

            if (value < 0)
            {
                value = 0;
            }

            switch (selectedState)
            {
                case 0: // None
                    WPFUI.Taskbar.Progress.SetState(WPFUI.Taskbar.ProgressState.None, false);
                    break;
                case 1: // Indeterminate
                    WPFUI.Taskbar.Progress.SetState(WPFUI.Taskbar.ProgressState.Indeterminate, false);
                    break;
                case 2: // Normal
                    WPFUI.Taskbar.Progress.SetValue(value, 100, false);
                    WPFUI.Taskbar.Progress.SetState(WPFUI.Taskbar.ProgressState.Normal, false);
                    break;
                case 3: // Error
                    WPFUI.Taskbar.Progress.SetValue(value, 100, false);
                    WPFUI.Taskbar.Progress.SetState(WPFUI.Taskbar.ProgressState.Error, false);
                    break;
                case 4: // Paused
                    WPFUI.Taskbar.Progress.SetValue(value, 100, false);
                    WPFUI.Taskbar.Progress.SetState(WPFUI.Taskbar.ProgressState.Paused, false);
                    break;
            }
        }

        private void Button_SwitchLightClick(object sender, RoutedEventArgs e)
        {
            WPFUI.Theme.Manager.Switch(WPFUI.Theme.Style.Light);
        }

        private void Button_SwitchDarkClick(object sender, RoutedEventArgs e)
        {
            WPFUI.Theme.Manager.Switch(WPFUI.Theme.Style.Dark);
        }
    }
}
