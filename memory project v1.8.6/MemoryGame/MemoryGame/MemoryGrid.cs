using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Input;
using System.Diagnostics;
using System.Windows;
using System.Timers;

namespace MemoryGame
{
    //er moest iets veranderd worden dus heb dit even snel getypt gr. lars
    class MemoryGrid
    {
        private Grid grid;
        private int cols;
        private int rows;
        private int ClickCards = 0;
        private List<Kaart> Jaah = new List<Kaart>();
        private int Vorigekaart;
        private Timer timer = new Timer();

        public MemoryGrid(Grid grid, int cols, int rows)
        {
            this.grid = grid;
            this.cols = cols;
            this.rows = rows;
            Initialize();
            AddImages();
            ShowCards();
        }
        public void Initialize()
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


        //plaatjes draaien (lars)
        private void CardClick(object sender, MouseButtonEventArgs e)
        {
            Image terug = new Image();
            Image card = (Image)sender;
            int index = (int)card.Tag;
            Jaah[index].clicked();


            

            if (ClickCards < 2)
            {
                ClickCards++;
                
                
                
               

                if (ClickCards == 2)
                {
                    ShowCards();
                    
                    card.Source = null;
                    ImageSource kaart1 = Jaah[Vorigekaart].Show();
                    ImageSource kaart2 = Jaah[index].Show();
                    if (kaart1.ToString() == kaart2.ToString())
                    {
                        MessageBox.Show("2 gelijken!");
                        Jaah[Vorigekaart].Onzichtbaar();

                        Jaah[index].Onzichtbaar();

                    }
                    else
                    {
                        MessageBox.Show("Niet gelijk");
                        Jaah[Vorigekaart].Terugdraaien();
                        Jaah[index].Terugdraaien();

                    }
                    ClickCards = 0;
                }
                else
                    Vorigekaart = index;
                    
            }
            ShowCards();
        }
        public void T()
        {
            Stopwatch sp = new Stopwatch();
            sp.Start();
            while (sp.ElapsedMilliseconds < 2000) ;

        }
        public void AddImages()
        //Dit is de voorkant van de kaartjes (Lars)
        {
            List<ImageSource> images = GetImagesList();
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < cols; column++)
                {
                    Jaah.Add(new Kaart(images.First()));
                    images.RemoveAt(0);
                }
            }
        }
        private void ShowCards()
        {
            grid.Children.Clear();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Image image = new Image();
                    image.Source = Jaah[j * cols + i].Show();
                    if (image.Source != null)
                    {
                        if (image.Source.ToString().Contains("sesame"))
                        {
                            image.MouseDown += new MouseButtonEventHandler(CardClick);
                        }
                    }
                    image.Tag = j * cols + i;
                    Grid.SetColumn(image, j);
                    Grid.SetRow(image, i);
                    grid.Children.Add(image);
                }

            }
        }



        //Dit zijn de plaatjes van de memory (Lars, Max)
        private List<ImageSource> GetImagesList()
        {
            List<ImageSource> images = new List<ImageSource>();
            for (int i = 0; i < 16; i++)
            {
                int imageNr = i % 8 + 1;
                ImageSource source = new BitmapImage(new Uri("img/" + imageNr + ".png", UriKind.Relative));
                images.Add(source);
            }

            //dit is de randomizer  (Rianne, Max)
            Random random = new Random();
            for (int i = 0; i < (rows * cols); i++)
            {
                int r = random.Next(0, (rows * cols));
                ImageSource randomnaam = images[r];
                images[r] = images[i];
                images[i] = randomnaam;
            }
            return images;
        }


        class Kaart
        {
            private bool Clicked, visible;
            private ImageSource front, back;
   
        
            public void clicked()
            {
                Clicked = true;
            }
            public void Terugdraaien()
            {
                Clicked = false;
            }
            public Kaart(ImageSource Voorkant)
            {
                back = new BitmapImage(new Uri("img/sesame.png", UriKind.Relative));
                Clicked = false;
                visible = true;
                front = Voorkant;

            }
            public ImageSource Show()
            {
                if (visible)
                {
                    if (Clicked)
                    {
                        return front;
                    }
                    else
                        return back;
                }
                else
                    return null;
            }
            public void Onzichtbaar()
            {
                visible = false;

            }

        }

    
    }
    }


