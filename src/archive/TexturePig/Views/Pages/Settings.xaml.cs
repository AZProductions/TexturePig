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
    /// Interaction logic for Help.xaml
    /// </summary>
    public partial class Settings : Page
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void comboTheme_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem comboBoxItem = (ComboBoxItem)comboTheme.SelectedItem;
            string value = comboBoxItem.Content.ToString();
            if (value == "Light") 
                WPFUI.Theme.Manager.Switch(WPFUI.Theme.Style.Light);
            else
                WPFUI.Theme.Manager.Switch(WPFUI.Theme.Style.Dark);
        }
    }
}
