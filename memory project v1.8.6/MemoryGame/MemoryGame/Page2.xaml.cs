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

namespace MemoryGame
{
    /// <summary>
    /// Interaction logic for highscore.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();

        }

        public List<string> playernames = new List<string>();
        private void SpelenBtn_Click(object sender, RoutedEventArgs e)
        {
            playernames.Add(naam1.Text);
            playernames.Add(naam2.Text);

            this.NavigationService.Navigate(new Page3(playernames));
        }




        private void back_CLick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Page1());
        }

        private void naam2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}