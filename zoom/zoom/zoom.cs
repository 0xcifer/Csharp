using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zoom
{
    public partial class zoom : Form
    {
        private Bitmap origImage;
        int w, h, r, g, b, f, u, rx,gx,bx,ry,gy,by,rn1,gn1,bn1,rn2,gn2,bn2,k=1;
        public zoom()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
         ////////////main picture box 846 x 603 
        }

        private void button1_Click(object sender, EventArgs e)
        {
         //upload button

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
                //pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
                pictureBox1.Image = origImage;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
         //Double(x) (420x 300) is best suited resolution of stock image
            Bitmap doublex = new Bitmap(w*2, h);
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                        Color originalColor = origImage.GetPixel(i, j);
                        r = originalColor.R;
                        g = originalColor.G;
                        b = originalColor.B;
                        //create the color object
                        Color newColor = Color.FromArgb(r, g, b);
                        doublex.SetPixel(i * 2, j, newColor);
                        doublex.SetPixel((i*2)+1, j, newColor);
                }
            }
            //pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
            pictureBox1.Image = doublex;
        }

        private void button3_Click(object sender, EventArgs e)
        {
         //Double(y)
            Bitmap doubley = new Bitmap(w, h*2);
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    Color originalColor = origImage.GetPixel(i, j);
                    r = originalColor.R;
                    g = originalColor.G;
                    b = originalColor.B;
                    //create the color object
                    Color newColor = Color.FromArgb(r, g, b);
                    doubley.SetPixel(i, j*2, newColor);
                    doubley.SetPixel(i, (j*2)+1, newColor);
                }
            }
            //pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
            pictureBox1.Image = doubley;
        }

        private void button4_Click(object sender, EventArgs e)
        {
        //Double(x,y)
            Bitmap doublexp = new Bitmap(w*2, h);
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    Color originalColor = origImage.GetPixel(i, j);
                    r = originalColor.R;
                    g = originalColor.G;
                    b = originalColor.B;
                    //create the color object
                    Color newColor = Color.FromArgb(r, g, b);
                    doublexp.SetPixel(i * 2, j, newColor);
                    doublexp.SetPixel((i * 2) + 1, j, newColor);
                }
            }
            u = doublexp.Width;
            Bitmap doublexy = new Bitmap(w*2, h*2);
            for (int i = 0; i < u; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    Color originalColor = doublexp.GetPixel(i, j);
                    r = originalColor.R;
                    g = originalColor.G;
                    b = originalColor.B;
                    //create the color object
                    Color newColor = Color.FromArgb(r, g, b);
                    doublexy.SetPixel(i, j * 2, newColor);
                    doublexy.SetPixel(i, (j * 2) + 1, newColor);
                    //pictureBox1.Refresh();
                }
            }
            //pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
            pictureBox1.Image = doublexy;
        }

        private void button5_Click(object sender, EventArgs e)
        {
         //Interpolate
            Bitmap doubleinter = new Bitmap(w * 3, h * 3);
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    Color originalColor = origImage.GetPixel(i, j);
                    Color originalColora = origImage.GetPixel(i+1, j);
                    rx = originalColor.R;
                    gx = originalColor.G;
                    bx = originalColor.B;
                    ry = originalColora.R;
                    gy = originalColora.G;
                    by = originalColora.B;
                    rn1 = (1 / 3) * (ry) + (2 / 3) * (rx);
                    gn1 = (1 / 3) * (gy) + (2 / 3) * (gx);
                    bn1 = (1 / 3) * (by) + (2 / 3) * (bx);
                    rn2 = (2 / 3) * (ry) + (1 / 3) * (rx);
                    gn2 = (2 / 3) * (gy) + (1 / 3) * (gx);
                    bn2 = (2 / 3) * (by) + (1 / 3) * (bx);
                    Color colorx = Color.FromArgb(rx, gx, bx);
                    Color colory = Color.FromArgb(ry, gy, by);
                    Color colorn1 = Color.FromArgb(rn1, gn1, bn1);
                    Color colorn2 = Color.FromArgb(rn2, gn2, bn2);
                    doubleinter.SetPixel(i, j, colorx);
                    doubleinter.SetPixel(i+k, j, colorn1);
                    k++;
                    doubleinter.SetPixel(i+k, j, colorn2);
                    k++;
                    doubleinter.SetPixel(i+k, j, colory);
                    k++;
                }
                k = 1;
            }
            pictureBox1.Image = doubleinter;
        }

        private void button6_Click(object sender, EventArgs e)
        {
        //Exit
            Application.Exit();
        }
    }
}
