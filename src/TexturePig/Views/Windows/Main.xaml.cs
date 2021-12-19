using System.Collections.ObjectModel;
using System.Windows;
using WPFUI.Common;

namespace TexturePig.Views.Windows
{
    /// <summary>
    /// Interaction logic for Bubble.xaml
    /// </summary>
    public partial class Main : Window
    {
        // WPFUI.Theme.Manager.Switch(WPFUI.Theme.Style.Light);
        public ObservableCollection<NavItem> NavigationItems { get; set; }

        public ObservableCollection<NavItem> NavigationFooter { get; set; }

        public Main()
        {
            if (WPFUI.Background.Mica.IsSupported() && WPFUI.Background.Mica.IsSystemThemeCompatible())
                WPFUI.Background.Mica.Apply(this);

            InitializeComponent();

            NavigationItems = new ObservableCollection<NavItem>
            {
                new() { Icon = WPFUI.Common.Icon.Home20, Name = "Home", Tag = "dashboard", Type = typeof(Pages.DashboardStore)},
                new() { Icon = WPFUI.Common.Icon.Apps28, Name = "Forms", Tag = "forms", Type = typeof(Pages.Help)},
                new() { Icon = WPFUI.Common.Icon.ResizeLarge24, Name = "Controls", Tag = "controls", Type = typeof(Pages.Help)},
                new() { Icon = WPFUI.Common.Icon.Games28, Name = "Actions", Tag = "actions", Type = typeof(Pages.Help)},
                new() { Icon = WPFUI.Common.Icon.Color24, Name = "Colors", Tag = "colors", Type = typeof(Pages.Help)}
            };

            NavigationFooter = new ObservableCollection<NavItem>
            {
                new() { Icon = WPFUI.Common.Icon.Library20, Name = "Library", Tag = "library", Type = typeof(Pages.Help)},
                new() { Icon = WPFUI.Common.Icon.QuestionCircle28, Name = "Help", Tag = "help", Type = typeof(Pages.Help)}
            };

            DataContext = this;
        }

        private void RootNavigation_OnLoaded(object sender, RoutedEventArgs e)
        {
            RootNavigation.Navigate("dashboard");
        }
    }
}
