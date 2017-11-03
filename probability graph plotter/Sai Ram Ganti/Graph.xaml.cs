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
using System.Windows.Shapes;

namespace Sai_Ram_Ganti
{
    /// <summary>
    /// Interaction logic for Graph.xaml
    /// </summary>
    public partial class Graph : Window
    {
        public Graph()
        {
            InitializeComponent();
        }
        public void setText(int num, string value)
        {
            switch (num)
            {
                case 1:
                    a.Content = value; break;
                case 2:
                    b.Content = value; break;
                case 3:
                    c.Content = value; break;
                case 4:
                    d.Content = value; break;
                case 5:
                    e.Content = value; break;
                case 6:
                    f.Content = value; break;
                case 7:
                    g.Content = value; break;
                case 8:
                    h.Content = value; break;
                case 9:
                    l.Content = value; break;
                case 10:
                    m.Content = value; break;
                case 11:
                    k.Content = value; break;
                case 12:
                    n.Content = value; break;
                case 13:
                    j.Content = value; break;
                case 14:
                    o.Content = value; break;
                case 15:
                    i.Content = value; break;
                case 16:
                    p.Content = value; break;
            }
        }
    }
}
