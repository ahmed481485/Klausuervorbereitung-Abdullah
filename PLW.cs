using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Klausuervorbereitung
{
    class PLW
    {
        public double PosY { get; private set; }
        public double PosX { get; private set; }
        
        public double GesX { get; private set; }
        public static Random rnd = new Random();
        Rectangle e;

        public PLW(Canvas Zeichnefläche)
        {
            PosX = rnd.Next(0, Convert.ToInt32(Zeichnefläche.ActualWidth));
            PosY = 0.8 * Convert.ToInt32(Zeichnefläche.ActualHeight);
            GesX = 280 + 40 * rnd.NextDouble() + 800 ;
            e = new Rectangle();
            e.Width = 10;
            e.Height = 10;
            e.Fill = Brushes.Gray;
        }


        public void Zeichne (bool isAlted ,Canvas Zeichnefläche)
        {
            if (isAlted)
            {
                e.Fill = Brushes.Blue;
            }
            else
            {
                e.Fill = Brushes.Gray;
            }
            Canvas.SetLeft(e, PosX);
            Canvas.SetTop(e, PosY);
            Zeichnefläche.Children.Add(e);
            
        }



        public void Bewegung(TimeSpan intrval)
        {
            PosX += GesX * intrval.TotalSeconds;
            

            if (PosX >= 800)
            {
                PosX = 0;

            }
           
            else if(PosX <= 0)
            {
                PosX = 800;

            }
           
        }

        public void Alt()
        {
            GesX = -GesX;
        }
    }
}
