using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace MemoryGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        private const int NR_OF_COLS = 4;
        private const int NR_OF_ROWS = 4;
        private MemoryGrid grid;


        public Page3(List<string> playernames)
        {
            InitializeComponent();
            grid = new MemoryGrid(MemoryGrid, NR_OF_COLS, NR_OF_ROWS);
            label1.Content = playernames[0];
            label2.Content = playernames[1];
        }

        public Page3()
        { }

        private void Reset(object sender, RoutedEventArgs e) //update in nieuwe versie
        {
            this.NavigationService.Navigate(new Page3());
        }
        private void ResetHM(object sender, RoutedEventArgs e) //update in nieuwe versie
        {
            this.NavigationService.Navigate(new Page1());
        }

        private void Save(object sender, RoutedEventArgs e)
        {

        }
    }
}

