using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using WPFUI.Common;

namespace TexturePig.Views.Windows
{
    public static class MainValue
    {
        public static NavigationStore Store;
    }
    /// <summary>
    /// Interaction logic for Bubble.xaml
    /// </summary>
    public partial class Main : Window
    {
        public ObservableCollection<NavItem> NavigationItems { get; set; }

        public ObservableCollection<NavItem> NavigationFooter { get; set; }

        public Main()
        {
            if (WPFUI.Background.Mica.IsSupported() && WPFUI.Background.Mica.IsSystemThemeCompatible())
                WPFUI.Background.Mica.Apply(this);
            
            RenderOptions.ProcessRenderMode = System.Windows.Interop.RenderMode.Default;
            MainValue.Store = RootNavigation;
            InitializeComponent();
            Debug.WriteLine("(ENVT) Triggerd InitializeComponent");
            
            NavigationItems = new ObservableCollection<NavItem>
            {
                new() { Icon = WPFUI.Common.Icon.Home20, Name = "Home", Tag = "dashboard", Type = typeof(Pages.DashboardStore)},
                new() { Icon = WPFUI.Common.Icon.AppsList24, Name = "Featured", Tag = "featured", Type = typeof(Pages.NotSupported)}
            };

            NavigationFooter = new ObservableCollection<NavItem>
            {
                new() { Icon = WPFUI.Common.Icon.PersonAccounts24, Name = "Account", Tag = "account", Type = typeof(Pages.NotSupported)},
                new() { Icon = WPFUI.Common.Icon.Library20, Name = "Library", Tag = "library", Type = typeof(Pages.Library)},
                new() { Icon = WPFUI.Common.Icon.Settings24, Name = "Settings", Tag = "settings", Type = typeof(Pages.Settings)}
            };

            DataContext = this;
        }

        private void RootNavigation_OnLoaded(object sender, RoutedEventArgs e)
        {
            RootNavigation.Navigate("dashboard");
            Debug.WriteLine("(SRCLEVNT) Loaded nav-sys and auto-prefixed to 'dashboard'");
        }

        private int IndexPos = 0;

        private void ChangeIndex(int Index) 
        {
            switch (Index) 
            {
                default:
                    RootNavigation.Navigate("dashboard");
                    break;
                case 0:
                    RootNavigation.Navigate("dashboard");
                    break;
                case 1:
                    RootNavigation.Navigate("featured");
                    break;
                case 2:
                    RootNavigation.Navigate("account");
                    break;
                case 3:
                    RootNavigation.Navigate("library");
                    break;
                case 4:
                    RootNavigation.Navigate("settings");
                    break;
            }
            Debug.WriteLine("(SRCLEVNT) Switched page index to: " + Index);
        }

        private void RootNavigation_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
                IndexPos--;
            else if (e.Delta < 0)
                IndexPos++;

            if(IndexPos == -1)
                IndexPos = 4;
            if (IndexPos == 5)
                IndexPos = 0;
            ChangeIndex(IndexPos);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.D1 when (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control:
                    RootNavigation.Navigate("dashboard");
                    Debug.WriteLine("(KEYEVNT) Switched page index to 'dashboard'");
                    break;
                case Key.D2 when (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control:
                    RootNavigation.Navigate("featured");
                    Debug.WriteLine("(KEYEVNT) Switched page index to 'featured'");
                    break;
                case Key.D3 when (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control:
                    RootNavigation.Navigate("account");
                    Debug.WriteLine("(KEYEVNT) Switched page index to 'account'");
                    break;
                case Key.D4 when (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control:
                    RootNavigation.Navigate("library");
                    Debug.WriteLine("(KEYEVNT) Switched page index to 'library'");
                    break;
                case Key.D5 when (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control:
                    RootNavigation.Navigate("settings");
                    Debug.WriteLine("(KEYEVNT) Switched page index to 'settings'");
                    break;
            }
        }
    }
}
