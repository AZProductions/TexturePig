global using WPFUI;
global using WPFUI.Common;
global using WPFUI.Controls;
global using WPFUI.Theme;
global using System.Windows;

namespace TexturePig
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            WPFUI.Theme.Manager.SetSystemTheme();
            //WPFUI.Theme.Manager.SetSystemAccent();
        }
    }
}
