using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
using MessageBox = WPFUI.Controls.MessageBox;
using TexturePig.API;

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

        bool active = false;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!active)
            {
                WPFUI.Controls.Button btn = (WPFUI.Controls.Button)sender;
                btn.Content = new ProgressBar()
                {
                    Foreground = Brushes.White,
                    Value = 10,
                    Height = 10,
                    MinWidth = 100,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };
                active = true;
            }
            else 
            {
                WPFUI.Controls.Button btn = (WPFUI.Controls.Button)sender;
                ProgressBar progressBar = btn.Content as ProgressBar;
                if (progressBar.Value == 100)
                    progressBar.Value = 0;
                else
                    progressBar.Value = progressBar.Value + 10;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        { /*
            string html = string.Empty;
            string url = @"http://193.123.61.148/v1/pack/2/";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }
            var getPack = GetPack.FromJson(html);*/
        }
    }
}
