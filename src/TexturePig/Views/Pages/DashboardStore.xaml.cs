using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TexturePig.Views.Pages
{
    /// <summary>
    /// Interaction logic for DashboardStore.xaml
    /// </summary>
    public partial class DashboardStore : Page
    {
        public DashboardStore()
        {
            InitializeComponent();
        }
        bool trigger = false;
        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            trigger = false;
            border.Background = Application.Current.Resources["ControlElevationBorderBrush"] as SolidColorBrush;
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!trigger)
            {
                trigger = true;
                border.Background = Application.Current.Resources["ControlFillColorDefaultBrush"] as SolidColorBrush;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
