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
using Button = WPFUI.Controls.Button;
using MessageBox = WPFUI.Controls.MessageBox;

namespace TexturePig.Views.Pages
{
    /// <summary>
    /// Interaction logic for Library.xaml
    /// </summary>
    public partial class Library : Page
    {
        public Library()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            contentPanel.Children.Clear();
            MineClient.GetResourcePacks client = new();
            foreach(MineClient.ResourcePackItem item in client.PackList)
                contentPanel.Children.Add(CreateCard(item.Name, item.Description + $" [{item.Version}]", item.Location));
        }

        public CardControl controlCard;

        private CardControl CreateCard(string Title, string SubTitle, string file) 
        {
            Button button = new Button()
            {
                Content = "Delete",
                Appearance = Appearance.Danger
            };
            button.Click += Click_evnt;
            CardControl cardControl = new CardControl() { Title = Title, Margin = new Thickness(0, 0, 0, 8), Glyph = WPFUI.Common.Icon.Icons24, Subtitle = SubTitle, Content = button };
            controlCard = cardControl;
            void Click_evnt(object sender, RoutedEventArgs e) 
            {
                new MessageBox() 
                {
                    Title = "Heads up..",
                    Content = $"Do you want to delete {Title + ".zip"}?",
                    RightButtonName = "Cancel",
                    LeftButtonName = "Confirm"
                }.Show();
                this.controlCard.Visibility = Visibility.Collapsed;
                System.IO.File.Delete(file);
            }
            cardControl = controlCard;
            return cardControl;
        }
    }
}
