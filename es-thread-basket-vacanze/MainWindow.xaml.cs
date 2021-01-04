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
using System.Threading;
using System.Diagnostics;

namespace es_thread_basket_vacanze
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int incremento;
        int fine;
        int altezza;
        public MainWindow()
        {
            InitializeComponent();
            incremento = 20;
            fine = 800;
            altezza = 50;
            BitmapImage bitmap1 = new BitmapImage();
            bitmap1.BeginInit();
            bitmap1.UriSource = new Uri("LebronJmaes.png", UriKind.RelativeOrAbsolute);
            bitmap1.EndInit();
            LebronJames_img.Source = bitmap1;
            LebronJames_img.Margin = new Thickness(incremento, altezza, 0, 0);

            BitmapImage bitmap2 = new BitmapImage();
            bitmap1.BeginInit();
            bitmap1.UriSource = new Uri("Kobe.png", UriKind.RelativeOrAbsolute);
            bitmap1.EndInit();
            Kobe_img.Source = bitmap2;
            Kobe_img.Margin = new Thickness(incremento, altezza + 120, 0, 0);

            BitmapImage bitmap3 = new BitmapImage();
            bitmap1.BeginInit();
            bitmap1.UriSource = new Uri("MichaelJordan.png", UriKind.RelativeOrAbsolute);
            bitmap1.EndInit();
            MichaelJordan_img.Source = bitmap3;
            MichaelJordan_img.Margin = new Thickness(incremento, altezza + 240, 0, 0);

            tempo.Add(new Tuple<string, double>("thread 1", 0));
            tempo.Add(new Tuple<string, double>("thread 2", 0));
            tempo.Add(new Tuple<string, double>("thread 3", 0));

            Thread t1 = new Thread(new ThreadStart(Metodo1));
            Thread t2 = new Thread(new ThreadStart(Metodo2));
            Thread t3 = new Thread(new ThreadStart(Metodo3));
            Thread t4 = new Thread(new ThreadStart(Metodo4));
            Cronometro1 = new Stopwatch();
            Cronometro2 = new Stopwatch();
            Cronometro3 = new Stopwatch();




        }



        private Stopwatch Cronometro1;
        private Stopwatch Cronometro2;
        private Stopwatch Cronometro3;
        private List<Tuple<string, double>> tempo;


        private void Metodo1()
        {
            Cronometro1.Start();
            Sposta1();
        }

        private void Metodo2()
        {
            Cronometro2.Start();
            Sposta2();
        }

        private void Metodo3()
        {
            Cronometro3.Start();
            Sposta3();
        }

        private void Sposta1()
        {

            Random rnd = new Random();
            while (LebronJames_img.Margin.Left < fine)
            {
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    int tmp = rnd.Next(10, 41);
                    LebronJames_img.Margin = new Thickness(LebronJames_img.Margin.Left + tmp, LebronJames_img.Margin.Top, LebronJames_img.Margin.Right, LebronJames_img.Margin.Bottom);

                }));
                Thread.Sleep(400);
            }



        }

        private void Sposta2()
        {
            Random rnd = new Random();
            while (Kobe_img.Margin.Left < fine)
            {
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    int tmp = rnd.Next(10, 41);
                    Kobe_img.Margin = new Thickness(Kobe_img.Margin.Left + tmp, Kobe_img.Margin.Top, Kobe_img.Margin.Right, Kobe_img.Margin.Bottom);
                }));
                Thread.Sleep(400);
            }
        }

        private void Sposta3()
        {
            Random rnd = new Random();
            while (MichaelJordan_img.Margin.Left < fine)
            {
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    int tmp = rnd.Next(10, 41);
                    MichaelJordan_img.Margin = new Thickness(MichaelJordan_img.Margin.Left + tmp, MichaelJordan_img.Margin.Top, MichaelJordan_img.Margin.Right, MichaelJordan_img.Margin.Bottom);
                }));
                Thread.Sleep(400);
            }
        }



    }
}

        
       
    }
}
