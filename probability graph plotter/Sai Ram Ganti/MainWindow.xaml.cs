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

namespace Sai_Ram_Ganti
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        static long factorial(Double n)
        {
            int c;
            long result = 1;
            for (c = 1; c <= n; c++)
                result = result * c;
            return (result);
        }




        //normal......................................................................................
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           Graph plot = new Graph();
           int count = 2;
           double y, x, var, mean;

           ///get information from user and make sure its valid
           if (!(double.TryParse(meanIn.Text, out mean)))
               MessageBox.Show("Invalid mean");
           else
               count--;

           ///get information from user and make sure its valid & within range
           if (!(double.TryParse(varIn.Text, out var)))
               MessageBox.Show("Invalid standard deviation");
           else if (var <= 0)
               MessageBox.Show("Number must be greater than 0");
           else
               count--;

           if (count == 0)
           {
               for (int i = 0; i < 301; i++)
               {
                   x = (i - 150.0) / 60;

                   if (i > 0 && i < 150 && (i % 30) == 0)
                   {
                       count++;
                       plot.setText(count, x.ToString());
                   }
                   else if (i > 160 && i < 300 && ((i - 1) % 30) == 0)
                   {
                       count++;
                       plot.setText(count, x.ToString());
                   }

                   ///Use Normal distribution formula to calculate y-point
                   y = 1.0 / (Math.Sqrt(var) * Math.Sqrt(Math.PI * 2));
                   y = y * Math.Exp(Math.Pow((x - mean), 2) / (-2.0 * var));

                   ///shrink height of graph to fit window
                   y *= 10.0;
                   if (var >= 1)
                       y *= 20.0;
                   else if (var < 1)
                       y *= 10;

                   y = 150 - y;

                   plot.norm.Points.Add(new Point(i, y));
               }

               ///label y-axis tick marks
               if (var < 1)
               {
                   y = .3;
                   x = -.3;
                   for (int i = 0; i < 4; i++)
                   {
                       count++;
                       plot.setText(count, y.ToString());
                       count++;
                       plot.setText(count, x.ToString());
                       y += .3;
                       x -= .3;
                   }
               }
               else
               {
                   y = 0.150786;
                   x = -0.150786;
                   for (int i = 0; i < 4; i++)
                   {
                       count++;
                       plot.setText(count, y.ToString());
                       count++;
                       plot.setText(count, x.ToString());
                       y += 0.150786;
                       x -= 0.150786;
                   }
               }

               plot.ShowDialog();
           }
        }









        //exponential...................................................................................................
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Graph plot = new Graph();
            int count = 2;
            double y, x, lam, var;

            ///get information from user and make sure its valid
            if (!(double.TryParse(lamIn.Text, out lam)))
                MessageBox.Show("Invalid lambda");
            else
                count--;
            double.TryParse(varIn.Text, out var);
            if (count == 1)
            {
                for (int i = 0; i < 301; i++)
                {
                    x = (i - 150.0) / 60;

                    if (i > 0 && i < 150 && (i % 30) == 0)
                    {
                        count++;
                        plot.setText(count, x.ToString());
                    }
                    else if (i > 160 && i < 300 && ((i - 1) % 30) == 0)
                    {
                        count++;
                        plot.setText(count, x.ToString());
                    }

                    ///Use exponential distribution formula to calculate y-position
                    y = lam * Math.Exp(-lam * x);
                    ///shrink height of graph to fit window
                    y *= 10.0;
                    if (var >= 1)
                        y *= 20.0;
                    else if (var < 1)
                        y *= 10;

                    y = 150 - y;

                    plot.norm.Points.Add(new Point(i, y));
                }

                ///label y-axis tick marks
                if (var < 1)
                {
                    y = .3;
                    x = -.3;
                    for (int i = 0; i < 4; i++)
                    {
                        count++;
                        plot.setText(count, y.ToString());
                        count++;
                        plot.setText(count, x.ToString());
                        y += .3;
                        x -= .3;
                    }
                }
                else
                {
                    y = 0.150786;
                    x = -0.150786;
                    for (int i = 0; i < 4; i++)
                    {
                        count++;
                        plot.setText(count, y.ToString());
                        count++;
                        plot.setText(count, x.ToString());
                        y += 0.150786;
                        x -= 0.150786;
                    }
                }

                plot.ShowDialog();
            }
        }







        //binomial......................................................................................................
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Graph plot = new Graph();
            int count = 1;
            double y, x, var,p,n;

            ///get information from user and make sure its valid & within range
            if (!(double.TryParse(varIn.Text, out var)))
                MessageBox.Show("Invalid standard deviation");
            else
                count--;
            double.TryParse(pIn.Text, out p);
            double.TryParse(nIn.Text, out n);
            if (count == 0)
            {
                for (int i = 0; i < 301; i++)
                {
                    x = (i - 150.0) / 60;

                    if (i > 0 && i < 150 && (i % 30) == 0)
                    {
                        count++;
                        plot.setText(count, x.ToString());
                    }
                    else if (i > 160 && i < 300 && ((i - 1) % 30) == 0)
                    {
                        count++;
                        plot.setText(count, x.ToString());
                    }

                    ///Use Binomial distribution formula to calculate y-point
                   y = (factorial(n) / (factorial(x) * factorial(n-x)) * Math.Pow(p,x) * Math.Pow((1-p) , (n-x)));

                    ///shrink height of graph to fit window
                    y *= 10.0;
                    if (var >= 1)
                        y *= 20.0;
                    else if (var < 1)
                        y *= 10;

                    y = 150 - y;

                    plot.norm.Points.Add(new Point(i, y));
                }

                ///label y-axis tick marks
                if (var < 1)
                {
                    y = .3;
                    x = -.3;
                    for (int i = 0; i < 4; i++)
                    {
                        count++;
                        plot.setText(count, y.ToString());
                        count++;
                        plot.setText(count, x.ToString());
                        y += .3;
                        x -= .3;
                    }
                }
                else
                {
                    y = 0.150786;
                    x = -0.150786;
                    for (int i = 0; i < 4; i++)
                    {
                        count++;
                        plot.setText(count, y.ToString());
                        count++;
                        plot.setText(count, x.ToString());
                        y += 0.150786;
                        x -= 0.150786;
                    }
                }

                plot.ShowDialog();
            }
        }







        //rayleigh......................................................................................................
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Graph plot = new Graph();
            int count = 2;
            double y, x, var;
            ///get information from user and make sure its valid & within range
            if (!(double.TryParse(varIn.Text, out var)))
                MessageBox.Show("Invalid standard deviation");
            else
                count--;

            if (count == 1)
            {
                for (int i = 0; i < 301; i++)
                {
                    x = (i - 150.0) / 60;

                    if (i > 0 && i < 150 && (i % 30) == 0)
                    {
                        count++;
                        plot.setText(count, x.ToString());
                    }
                    else if (i > 160 && i < 300 && ((i - 1) % 30) == 0)
                    {
                        count++;
                        plot.setText(count, x.ToString());
                    }

                    ///Use rayleigh distribution formula to calculate y-point
                    y = x / (var * var);
                    y = y * Math.Exp((x * x) / (-2.0 * var * var));
              
                    ///shrink height of graph to fit window
                    y *= 10.0;
                    if (var >= 1)
                        y *= 20.0;
                    else if (var < 1)
                        y *= 10;

                    y = 150 - y;

                    plot.norm.Points.Add(new Point(i, y));
                }

                ///label y-axis tick marks
                if (var < 1)
                {
                    y = .3;
                    x = -.3;
                    for (int i = 0; i < 4; i++)
                    {
                        count++;
                        plot.setText(count, y.ToString());
                        count++;
                        plot.setText(count, x.ToString());
                        y += .3;
                        x -= .3;
                    }
                }
                else
                {
                    y = 0.150786;
                    x = -0.150786;
                    for (int i = 0; i < 4; i++)
                    {
                        count++;
                        plot.setText(count, y.ToString());
                        count++;
                        plot.setText(count, x.ToString());
                        y += 0.150786;
                        x -= 0.150786;
                    }
                }

                plot.ShowDialog();
            }
        }








        //poison...................................................................................................
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Graph plot = new Graph();
            int count = 2;
            double y, x, var, lam, c, fact=1;

            ///get information from user and make sure its valid
            if (!(double.TryParse(lamIn.Text, out lam)))
                MessageBox.Show("Invalid lambda");
            else
                count--;
            double.TryParse(varIn.Text, out var);
               
            if (count == 1)
            {
                for (int i = 0; i < 301; i++)
                {
                    x = (i - 150.0) / 60;

                    if (i > 0 && i < 150 && (i % 30) == 0)
                    {
                        count++;
                        plot.setText(count, x.ToString());

                    }
                    else if (i > 160 && i < 300 && ((i - 1) % 30) == 0)
                    {
                        count++;
                        plot.setText(count, x.ToString());
                    }

                    ///Use poison distribution formula to calculate y-point
                    for (c = 1; c <= x; c++)
                    {
                        fact = fact * c;
                    }
                    y = (Math.Pow(lam, x) * Math.Exp(-lam)) / fact;

                    ///shrink height of graph to fit window
                    y *= 10.0;
                    if (var >= 1)
                        y *= 20.0;
                    else if (var < 1)
                        y *= 10;

                    y = 150 - y;

                    plot.norm.Points.Add(new Point(i, y));
                }

                ///label y-axis tick marks
                if (var < 1)
                {
                    y = .3;
                    x = -.3;
                    for (int i = 0; i < 4; i++)
                    {
                        count++;
                        plot.setText(count, y.ToString());
                        count++;
                        plot.setText(count, x.ToString());
                        y += .3;
                        x -= .3;
                    }
                }
                else
                {
                    y = 0.150786;
                    x = -0.150786;
                    for (int i = 0; i < 4; i++)
                    {
                        count++;
                        plot.setText(count, y.ToString());
                        count++;
                        plot.setText(count, x.ToString());
                        y += 0.150786;
                        x -= 0.150786;
                    }
                }

                plot.ShowDialog();
            }
        }
    }
}
