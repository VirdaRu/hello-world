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

