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
    public partial class highscore : Page
    {
        public highscore()
        {
            InitializeComponent();

        }

        private void SpelenBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Page3());
        }
<<<<<<< HEAD:memory project v1.7.2/MemoryGame/MemoryGame/Page2.xaml.cs


=======
        private void back_CLick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Page1());
        }
>>>>>>> d46410de4ba7e70a3f427cbaf479c7df9bbd5910:memory project v1.7.1/MemoryGame/MemoryGame/highscore.xaml.cs
    }
}
