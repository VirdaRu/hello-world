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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += dtTicker;
            dt.Start();

            DispatcherTimer tt = new DispatcherTimer();
            tt.Interval = TimeSpan.FromMinutes(1);
            tt.Tick += Tt_Tick;
            tt.Start();
                                 
        }

        

        private int increment = 0;
        private int minute = 0;

       
        private void dtTicker(object sender, EventArgs e)
        {
            increment++;

            Timerlabel.Content = increment.ToString();

            if (increment > 59)
            {
                minute++;
                Minutelabel.Content = minute.ToString();
                increment = 0;
            }                
        }

        private void Tt_Tick (object sender, EventArgs e)
        {
            
        }

    }
}

