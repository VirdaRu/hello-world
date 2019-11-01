using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Input;
using System.Diagnostics;
using System.Windows;

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
              
                
                card.Source = null;
               

                if (ClickCards == 2)
                {
                    card.Source = null;
                    if (Jaah[Vorigekaart].Show() == Jaah[index].Show())
                    {
                        Jaah[Vorigekaart].Onzichtbaar();
                        
                        Jaah[index].Onzichtbaar();


                    }
                    else
                    {
                        ShowCards();
                        grid.InvalidateVisual();
                        Stopwatch sp = new Stopwatch();
                        sp.Start();
                        while (sp.ElapsedMilliseconds < 2000) { }
                        Jaah[Vorigekaart].Terugdraaien();
                        Jaah[index].Terugdraaien();
                        //ShowCards();

                    }
                    ClickCards = 0;
                }
                else
                    Vorigekaart = index;

                ShowCards();
            }
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
                    image.MouseDown += new MouseButtonEventHandler(CardClick);
                    image.Source = Jaah[j * cols + i].Show();
                    image.Tag = j * cols + i;
                    Grid.SetColumn(image, j);
                    Grid.SetRow(image, i);
                    grid.Children.Add(image);
                  
                }

            }
            grid.InvalidateVisual();
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


