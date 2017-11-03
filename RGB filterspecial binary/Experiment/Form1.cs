using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Experiment
{
    public partial class Form1 : Form
    {
        private Bitmap origImage;
        int w, h, r, g, b, x = 0, y = 0, count = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            Bitmap newBitmap = new Bitmap(w, h);
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    //get the pixel from the original image
                    Color originalColor = origImage.GetPixel(i, j);

                    //create the grayscale version of the pixel
                    r = originalColor.R;
                    g = originalColor.G;
                    b = originalColor.B;
                    if (r > 100 && g < 50 && b < 20)
                    {
                        Color newColor = Color.FromArgb(0, 0, 0);
                        newBitmap.SetPixel(i, j, newColor);
                    }
                    else
                    {
                        Color newColora = Color.FromArgb(255, 255, 255);
                        newBitmap.SetPixel(i, j, newColora);
                    }
                } if (i % 40 == 0)
                {
                    pictureBox2.Image = newBitmap;
                    pictureBox2.Refresh();
                }
            }
            pictureBox2.Image = newBitmap;
            //red button
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //green button
            Bitmap newBitmap = new Bitmap(w, h);
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    //get the pixel from the original image
                    Color originalColor = origImage.GetPixel(i, j);

                    //create the grayscale version of the pixel
                    r = originalColor.R;
                    g = originalColor.G;
                    b = originalColor.B;
                    if (g > 100 && r < 50 && b < 20)
                    {
                        Color newColor = Color.FromArgb(0, 0, 0);
                        newBitmap.SetPixel(i, j, newColor);
                    }
                    else
                    {
                        Color newColora = Color.FromArgb(255, 255, 255);
                        newBitmap.SetPixel(i, j, newColora);
                    }
                }
            }
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = newBitmap;
            //red button
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //blue button
            Bitmap newBitmap = new Bitmap(w, h);
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    //get the pixel from the original image
                    Color originalColor = origImage.GetPixel(i, j);

                    //create the grayscale version of the pixel
                    r = originalColor.R;
                    g = originalColor.G;
                    b = originalColor.B;
                    if (b > 100 && g < 50 && r < 20)
                    {
                        Color newColor = Color.FromArgb(0, 0, 0);
                        newBitmap.SetPixel(i, j, newColor);
                    }
                    else
                    {
                        Color newColora = Color.FromArgb(255, 255, 255);
                        newBitmap.SetPixel(i, j, newColora);
                    }
                }
            }
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = newBitmap;
            //red button
        }

        private void button4_Click(object sender, EventArgs e)
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
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = origImage;

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //small picturebox 281 x 193
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //large picturebox 695 x 473
        }
    }
}
