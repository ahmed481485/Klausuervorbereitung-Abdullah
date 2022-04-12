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

namespace Klausuervorbereitung
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        List<PKW> pkWs = new List<PKW>();
        List<PLW> pLWs = new List<PLW>();
        bool isAlted;


        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromMilliseconds(17);
            timer.Tick += animiere;
        }

 

        private void animiere(object sender, EventArgs e)
        {
            Zeichefläche.Children.Clear();
            foreach(PLW item in pLWs)
            {
                item.Bewegung(timer.Interval);
                item.Zeichne(isAlted,Zeichefläche);
            }
            foreach(PKW item in pkWs)
            {
                item.Bewegung(timer.Interval, Zeichefläche);
                item.Zeichne(isAlted,Zeichefläche);
            }
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
            for (int i = 0; i < 33; i++)
            {
                pkWs.Add(new PKW(Zeichefläche));
                pLWs.Add(new PLW(Zeichefläche));
            }
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                isAlted = !isAlted;
            }
            if(e.Key == Key.Left)
            {
                foreach(PKW item in pkWs)
                {
                    item.Alt();
                }
                foreach(PLW item in pLWs)
                {
                    item.Alt();
                }
            }
            if(e.Key == Key.Right)
            {
                foreach(PKW item in pkWs)
                {
                    item.Alt();
                }
                foreach(PLW item in pLWs)
                {
                    item.Alt();
                }
            }
        }
    }
}
