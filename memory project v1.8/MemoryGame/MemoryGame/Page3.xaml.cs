﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

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
        private void InitializeGameGrid()
        {
            for (int i = 0; i < NR_OF_ROWS; i++)
            {
                GameGrid.RowDefinitions.Add(new RowDefinition());
            }
            for (int i = 0; i < NR_OF_COLS; i++)
            {
                GameGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }

       
        private void ResetHM(object sender, RoutedEventArgs e) //update in nieuwe versie
        {
            this.NavigationService.Navigate(new Page1());
        }

        private void save(object sender, RoutedEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += dtTicker;
            dt.Start();

        }
        private int min = 0;
        private int sec = 0;
       private void dtTicker(object sender, EventArgs e)
        {
            sec++;

            seconden.Content = sec.ToString();

            if(sec >59)
            {
                min++;
                minuut.Content = min.ToString();
                sec = 0;
            }




        }
    }
}
