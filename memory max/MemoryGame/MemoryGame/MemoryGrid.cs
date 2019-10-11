using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MemoryGame
{
    class MemoryGrid
    {
        private Grid grid;
        private int cols;
        private int rows;

        public MemoryGrid(Grid grid, int cols, int rows)
        {
            this.grid = grid;
            this.cols = cols;
            this.rows = rows;
            InitializeGameGrid(cols, rows);
            AddImages();
        }

        private void InitializeGameGrid(int cols, int rows)
        {
            for (int i = 0; i < rows; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }
            for (int i = 0; i < cols; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }
        private void AddImages()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < cols; column++)
                {
                    Image backgroundImage = new Image();
                    backgroundImage.Source = new BitmapImage(new Uri("oscar.png", UriKind.Relative));
                    Grid.SetColumn(backgroundImage, column);
                    Grid.SetRow(backgroundImage, row);
                    grid.Children.Add(backgroundImage);
                }
            }
        }
    } 

    

}
