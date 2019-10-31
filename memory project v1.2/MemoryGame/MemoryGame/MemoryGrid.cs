using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Input;

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
            //heb hier aanpassingen aan gemaakt gr lars
        {
            List<ImageSource> images = GetImagesList();
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < cols; column++)
                {
                    Image backgroundImage = new Image();
                    backgroundImage.Source = new BitmapImage(new Uri("img/sesame.jpg", UriKind.Relative));
                    backgroundImage.Tag = images.First();
                    images.RemoveAt(0);
                    backgroundImage.MouseDown += new MouseButtonEventHandler(CardClick);
                    Grid.SetColumn(backgroundImage, column);
                    Grid.SetRow(backgroundImage, row);
                    grid.Children.Add(backgroundImage);
                }
            }
        }
        //dit is voor zodat de plaatjes omdraaien gr lars
        private void CardClick(object sender, MouseButtonEventArgs e)
        {
            Image card = (Image)sender;
            ImageSource front = (ImageSource)card.Tag;
            card.Source = front;
        }
        //hier ergens moet de randoizer komen te staan
        private List<ImageSource> GetImagesList()
        {
            Random random = new Random();

            List<ImageSource> images = new List<ImageSource>();
            for (int i = 0; i < 16; i++)
            {
                int imageNr = i % 8 + 1;
                ImageSource source = new BitmapImage(new Uri("img/" + imageNr + ".png", UriKind.Relative));
                images.Add(source);
            }
            return images;
        }
        //tot aan hier

        //weet niet zeker waar dit voor is maar stond in de presentatie dus heb het er voor de zekerheid ingezet waarschijnlijk voor lateree doeleinden
        private void AddLabel()
        {
            Label title = new Label();
            title.Content = "Memory";
            title.FontFamily = new FontFamily("Distant Galaxy");
            title.FontSize = 40;
            title.HorizontalAlignment = HorizontalAlignment.Center;

            Grid.SetColumn(title, 1);
            grid.Children.Add(title);
        }

    }

}
