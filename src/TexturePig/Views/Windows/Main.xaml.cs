using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
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
            //DisableWpfTabletSupport();
            MainValue.Store = RootNavigation;
            InitializeComponent();
            
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
        }

        public static void DisableWpfTabletSupport()
        {
            // Get a collection of the tablet devices for this window.    
            TabletDeviceCollection devices = System.Windows.Input.Tablet.TabletDevices;


            if (devices.Count > 0)
            {
                // Get the Type of InputManager.  
                Type inputManagerType = typeof(System.Windows.Input.InputManager);


                // Call the StylusLogic method on the InputManager.Current instance.  
                object stylusLogic = inputManagerType.InvokeMember("StylusLogic",
                            BindingFlags.GetProperty | BindingFlags.Instance |
                            BindingFlags.NonPublic,
                            null, InputManager.Current, null);


                if (stylusLogic != null)
                {
                    // Get the type of the stylusLogic returned 
                    // from the call to StylusLogic.  
                    Type stylusLogicType = stylusLogic.GetType();


                    // Loop until there are no more devices to remove.  
                    while (devices.Count > 0)
                    {
                        // Remove the first tablet device in the devices collection.  
                        stylusLogicType.InvokeMember("OnTabletRemoved",
                                BindingFlags.InvokeMethod |
                                BindingFlags.Instance | BindingFlags.NonPublic,
                                null, stylusLogic, new object[] { (uint)0 });
                    }
                }
            }
        }

        private int IndexPos = 0;
        // 0=Home
        // 1=Featured
        // 2=Account
        // 3=Library
        // 4=Settings

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
    }
}
