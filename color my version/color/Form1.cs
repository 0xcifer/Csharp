using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace color
{
    public partial class Form1 : Form
    {
        private Bitmap origImage;
        int r, g, b, i, x, y, w, h,l,m;
        public Form1()
        {
            InitializeComponent();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    origImage = new Bitmap(openFileDialog1.FileName);
                    w = origImage.Width;
                    h = origImage.Height;
                }
                catch
                {
                    MessageBox.Show("Can't open file.");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            l = w / 20;
            m = h / 20;
            int k = 0;
            Bitmap myBitmap = new Bitmap(300,500);
                for(i=0;i<=255;i++)
                 {
                     for(x=0;x<=w;x=x+l)
                     {
                         for(y=0;y<=h;y=y+m)
                         {
                             Color pixelColor = origImage.GetPixel(x, y);
                             r = pixelColor.R;
                             if(r==i)
                             {
                                 //Console.WriteLine(r);
                                 myBitmap.SetPixel(i, k, Color.Red);
                                 myBitmap.SetPixel(i+1, k, Color.Red);
                                 k++;
                             }
                         }
                     }
                 }
                for (i = 0; i < 300;i++)
                {
                    myBitmap.SetPixel(i, 0, Color.Black);
                   // myBitmap.SetPixel(i+1, 0, Color.Black);
                }
                for (i = 0; i < 500; i++)
                {
                    myBitmap.SetPixel(0, i, Color.Black);
                   // myBitmap.SetPixel(0, i+1, Color.Black);
                }
                    pictureBox1.Image = myBitmap;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            l = w / 20;
            m = h / 20;
            int k = 0;
            Bitmap myBitmap = new Bitmap(300,500);
                for(i=0;i<=255;i++)
                 {
                     for(x=0;x<=w;x=x+l)
                     {
                         for(y=0;y<=h;y=y+m)
                         {
                             Color pixelColor = origImage.GetPixel(x, y);
                             g = pixelColor.G;
                             if(g==i)
                             {
                                 //Console.WriteLine(r);
                                 myBitmap.SetPixel(i, k, Color.Green);
                                 myBitmap.SetPixel(i+1, k, Color.Green);
                                 k++;
                             }
                         }
                     }
                 }
                for (i = 0; i < 300; i++)
                {
                    myBitmap.SetPixel(i, 0, Color.Black);
                   // myBitmap.SetPixel(i+1, 0, Color.Black);
                }
                for (i = 0; i < 500; i++)
                {
                    myBitmap.SetPixel(0, i, Color.Black);
                   // myBitmap.SetPixel(0, i+1, Color.Black);
                }
                pictureBox1.Image = myBitmap;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            l = w / 20;
            m = h / 20;
            int k = 0;
            Bitmap myBitmap = new Bitmap(300,500);
                for(i=0;i<=255;i++)
                 {
                     for(x=0;x<=w;x=x+l)
                     {
                         for(y=0;y<=h;y=y+m)
                         {
                             Color pixelColor = origImage.GetPixel(x, y);
                             b = pixelColor.B;
                             if(b==i)
                             {
                                 //Console.WriteLine(r);
                                 myBitmap.SetPixel(i, k, Color.Blue);
                                 myBitmap.SetPixel(i+1, k, Color.Blue);
                                 k++;
                             }
                         }
                     }
                 }
                for (i = 0; i < 300; i++)
                {
                    myBitmap.SetPixel(i, 0, Color.Black);
                    //myBitmap.SetPixel(i+1, 0, Color.Black);
                }
                for (i = 0; i < 500; i++)
                {
                    myBitmap.SetPixel(0, i, Color.Black);
                   // myBitmap.SetPixel(0, i+1, Color.Black);
                }
                pictureBox1.Image = myBitmap;
        }

        private void button6_Click(object sender, EventArgs e)
        {
          int  p = w / 20;
            m = h / 20;
            int k = 0, l = 0, q = 0;
            Bitmap myBitmap = new Bitmap(300, 500);
            for (i = 0; i <= 255; i++)
            {
                for (x = 0; x <= w; x=x+p)
                {
                    for (y = 0; y <= h; y=y+m)
                    {
                        Color pixelColor = origImage.GetPixel(x, y);
                        r = pixelColor.R;
                        g = pixelColor.G;
                        b = pixelColor.B;
                        if (r==i)
                        {
                            //Console.WriteLine(r);
                            myBitmap.SetPixel(i, k, Color.Red);
                            myBitmap.SetPixel(i+1, k, Color.Red);
                            k++;
                        }
                        if (g==i)
                        {
                            //Console.WriteLine(r);
                            myBitmap.SetPixel(i, l, Color.Green);
                            myBitmap.SetPixel(i+1, l, Color.Green);
                            l++;
                        }
                        if (b==i)
                        {
                            //Console.WriteLine(r);
                            myBitmap.SetPixel(i, q, Color.Blue);
                            myBitmap.SetPixel(i+1, q, Color.Blue);
                            q++;
                        }
                    }
                }
            }

            for (i = 0; i < 300; i++)
            {
                myBitmap.SetPixel(i, 0, Color.Black);
                //myBitmap.SetPixel(i+1, 0, Color.Black);
            }
            for (i = 0; i < 500; i++)
            {
                myBitmap.SetPixel(0, i, Color.Black);
                //myBitmap.SetPixel(0, i+1, Color.Black);
            } pictureBox1.Image = myBitmap;
        }
        
        
    }
}
