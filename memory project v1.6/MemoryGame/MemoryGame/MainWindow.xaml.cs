using System.Windows;
using System.Windows.Controls;

namespace MemoryGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int NR_OF_COLS = 4;
        private const int NR_OF_ROWS = 4;
        private MemoryGrid grid;


        public MainWindow()
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
    }
}
