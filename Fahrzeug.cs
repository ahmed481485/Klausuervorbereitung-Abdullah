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
    class PKW
    {
        public double PositionY { get; private set; }
        public double PositionX { get; private set; }
        public double GeschwindigkeitX { get; private set; }
        public static Random rnd = new Random();
        Ellipse e;
        private int sign;
        public PKW(Canvas Zeichnefläche)
            
        {
            PositionX = rnd.Next(0, Convert.ToInt32(Zeichnefläche.ActualWidth));
            PositionY = 0.4*Convert.ToInt32(Zeichnefläche.ActualHeight);
            GeschwindigkeitX = (240 + 40 * rnd.NextDouble() + 200);
            e = new Ellipse();
            e.Width = 10;
            e.Height = 10;
            e.Fill = Brushes.Blue;
            
        } 

        public void Zeichne (bool isAlted,Canvas Zeichnefläche)
        {
            if (isAlted)
            {
                e.Fill = Brushes.Gray;
            }
            else
            {
                e.Fill = Brushes.Blue;
            }
            Canvas.SetLeft(e, PositionX);
            Canvas.SetTop(e, PositionY);
            Zeichnefläche.Children.Add(e);
            
        }
       

        public void Bewegung(TimeSpan interval, Canvas zeichenfläche)
        {
            PositionX += GeschwindigkeitX * interval.TotalSeconds;
            
            if(PositionX >= zeichenfläche.ActualWidth)
            {
                PositionX = 0;
            }
            
            else if(PositionX <= 0)
            {
                PositionX = zeichenfläche.ActualWidth;
            }
            
        }
        public void Alt()
        {
            GeschwindigkeitX = -GeschwindigkeitX;
        }

    }
}
