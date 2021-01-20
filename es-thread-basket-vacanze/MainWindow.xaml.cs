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
    /// oooooooooo
    /// 666
    /// yjjy7i
    /// njjjjj
    /// jjjjj
    /// hhhh
    /// 999
    public partial class MainWindow : Window
    {
        private double inizio;
        private double fine;
        private double altezza;

        Thread t1;
        Thread t2;
        Thread t3;
        Thread t4;
        private Stopwatch Cronometro1;
        private Stopwatch Cronometro2;
        private Stopwatch Cronometro3;
        private List<Tuple<string, double>> tempo;
        public MainWindow()
        {
            InitializeComponent();
            inizio = 12;
            fine = 580;
            altezza = 10;


            BitmapImage bitmap1 = new BitmapImage();
            bitmap1.BeginInit();
            bitmap1.UriSource = new Uri("LebronJames.png", UriKind.RelativeOrAbsolute);
            bitmap1.EndInit();
            LebronJames_img.Source = bitmap1;
            LebronJames_img.Margin = new Thickness(0, 30, 0, 0);


            BitmapImage bitmap2 = new BitmapImage();
            bitmap2.BeginInit();
            bitmap2.UriSource = new Uri("Kobe.png", UriKind.RelativeOrAbsolute);
            bitmap2.EndInit();
            Kobe_img.Source = bitmap2;
            Kobe_img.Margin = new Thickness(0, 146, 0, 0);

            BitmapImage bitmap3 = new BitmapImage();
            bitmap3.BeginInit();
            bitmap3.UriSource = new Uri("MichaelJordan.png", UriKind.RelativeOrAbsolute);
            bitmap3.EndInit();
            MichaelJordan_img.Source = bitmap3;
            MichaelJordan_img.Margin = new Thickness(0, 280, 0, 0);

            tempo = new List<Tuple<string, double>>();
            tempo.Add(new Tuple<string, double>("thread 1", 0));
            tempo.Add(new Tuple<string, double>("thread 2", 0));
            tempo.Add(new Tuple<string, double>("thread 3", 0));

            t1 = new Thread(new ThreadStart(Metodo1));
            t2 = new Thread(new ThreadStart(Metodo2));
            t3 = new Thread(new ThreadStart(Metodo3));
            t4 = new Thread(new ThreadStart(Metodo4));

            Cronometro1 = new Stopwatch();
            Cronometro2 = new Stopwatch();
            Cronometro3 = new Stopwatch();



        }
        private void Metodo4()
        {
            bool bl = true;
            int d= 0, e= 0, f = 0;
            while (bl)
            {


                if (t1.IsAlive == false && d == 0)
                {
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        Cronometro1.Stop();
                        tempo[0] = new Tuple<string, double>(tempo[0].Item1, Cronometro1.Elapsed.TotalSeconds);
                        lbl_classificafinale.Content = lbl_classificafinale.Content + tempo[0].Item1 + ": " + tempo[0].Item2 + "\n";
                    }));
                    d++;
                }

                if (t2.IsAlive == false && e == 0)
                {
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        Cronometro2.Stop();
                        tempo[1] = new Tuple<string, double>(tempo[1].Item1, Cronometro2.Elapsed.TotalSeconds);
                        lbl_classificafinale.Content = lbl_classificafinale.Content + tempo[1].Item1 + ": " + tempo[1].Item2 + "\n";
                    }));
                    e++;
                }

                if (t3.IsAlive == false && f == 0)
                {
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        Cronometro3.Stop();
                        tempo[2] = new Tuple<string, double>(tempo[2].Item1, Cronometro3.Elapsed.TotalSeconds);
                        lbl_classificafinale.Content = lbl_classificafinale.Content + tempo[2].Item1 + ": " + tempo[2].Item2 + "\n";
                    }));
                    f++;
                }

                if (e + d + f == 3)
                    bl = false;
            }
        }






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
            double ml = 11;


            while (ml < fine)
            {
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    ml = LebronJames_img.Margin.Left;
                    int tmp = rnd.Next(11, 50);
                    LebronJames_img.Margin = new Thickness(ml + tmp, LebronJames_img.Margin.Top, 0, 0);

                }));
                Thread.Sleep(rnd.Next(400, 1000));

            }
        }



        private void Sposta2()
        {
            Random rnd = new Random();
            double ml = 11;

            while (ml < fine)
            {
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    ml = Kobe_img.Margin.Left;
                    int tmp = rnd.Next(11, 50);
                    Kobe_img.Margin = new Thickness(ml + tmp, Kobe_img.Margin.Top, 0, 0);

                }));
                Thread.Sleep(rnd.Next(400, 1000));

            }
        }
        private void Sposta3()
        {
            Random rnd = new Random();
            double ml = 11;

            while (ml < fine)
            {
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    ml = MichaelJordan_img.Margin.Left;
                    int tmp = rnd.Next(11, 50);
                    MichaelJordan_img.Margin = new Thickness(ml + tmp, MichaelJordan_img.Margin.Top, 0, 0);

                }));
                Thread.Sleep(rnd.Next(400, 1000));

            }
        }

        private void btn_inizio_Click_1(object sender, RoutedEventArgs e)
        {
            Thread t = new Thread(new ThreadStart(Start));
            t.Start();
        }


        private void Start()
        {
            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();

            t1.Join();
            t2.Join();
            t3.Join();
            t4.Join();





        }

       
    }
}




        
       

