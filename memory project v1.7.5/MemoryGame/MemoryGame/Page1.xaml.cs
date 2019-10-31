using System.Windows;
using System.Windows.Controls;

namespace MemoryGame
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }
         
        private void DootDoot_CLick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Page2());
        }
        private void Click_CLick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new highscore());
        }


    }
}
