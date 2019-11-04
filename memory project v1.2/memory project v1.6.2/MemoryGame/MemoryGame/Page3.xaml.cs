<<<<<<< HEAD:memory project v1.7/MemoryGame/MemoryGame/Page3.xaml.cs
﻿using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
=======
﻿using System;
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
>>>>>>> e65a46c9b5e5a034d03da5d689d24318ce7ec219:memory project v1.2/memory project v1.6.2/MemoryGame/MemoryGame/Page3.xaml.cs

namespace MemoryGame
{
    /// <summary>
    /// Interaction logic for Page3.xaml
    /// </summary>
    public partial class Page3 : Window
    {
        private const int NR_OF_COLS = 4;
        private const int NR_OF_ROWS = 4;
        private MemoryGrid grid;


        public Page3()
        {
            InitializeComponent();
            grid = new MemoryGrid(MemoryGrid, NR_OF_COLS, NR_OF_ROWS);
            //InitializeGameGrid();
        }
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

        private void Reset(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

    }
}