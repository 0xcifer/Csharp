using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace cs469a1
{
    public partial class MainWindow : Form
    {
        private Bitmap origImage;
        private Bitmap image;
        private bool imageFit = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    origImage = new Bitmap(openFileDialog.FileName);

                    // Convert pixel format
                    origImage = origImage.Clone(new Rectangle(0, 0, origImage.Width, origImage.Height), PixelFormat.Format32bppArgb);
                    image = new Bitmap(origImage);

                    pictureBox.Image = origImage;
                    pictureBox.Size = origImage.Size;

                    // Resize window
                    int newWidth = Math.Max(this.PreferredSize.Width, 305);
                    int newHeight = this.PreferredSize.Height;
                    newWidth = Math.Min(newWidth, Screen.PrimaryScreen.Bounds.Width * 2 / 3);
                    newHeight = Math.Min(newHeight, Screen.PrimaryScreen.Bounds.Height * 2 / 3);
                    this.Size = new Size(newWidth, newHeight);

                    // Enable buttons
                    foreach (Control c in this.Controls)
                    {
                        if (c is Button)
                            c.Enabled = true;
                    }

                    imageFit = false;
                }
                catch
                {
                    MessageBox.Show("Can't open file.");
                }
            }
        }

        public static Bitmap ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            double ratioX = (double)maxWidth / image.Width;
            double ratioY = (double)maxHeight / image.Height;
            double ratio = Math.Min(ratioX, ratioY);

            int newWidth = (int)(image.Width * ratio);
            int newHeight = (int)(image.Height * ratio);

            Bitmap newImage = new Bitmap(newWidth, newHeight);
            Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
            return newImage;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            Button senderBtn = (Button)sender;
            string title = "";

            double minColor = 255;
            double maxColor = -255;
            double newColor;
            byte color;

            Bitmap newImage = new Bitmap(image);
            Rectangle rect = new Rectangle(0, 0, newImage.Width, newImage.Height);
            BitmapData bmpData = newImage.LockBits(rect, ImageLockMode.ReadWrite, newImage.PixelFormat);

            IntPtr ptr = bmpData.Scan0;

            int bytes = bmpData.Stride * bmpData.Height;
            byte[] rgbaValues = new byte[bytes];

            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbaValues, 0, bytes);

            if (senderBtn.Name == "rButton")
            {
                for (int i = 2; i < rgbaValues.Length - 1; i += 4)
                {
                    rgbaValues[i - 1] = rgbaValues[i - 2] = rgbaValues[i];
                }
                title = "Red";
            }
            else if (senderBtn.Name == "gButton")
            {
                for (int i = 1; i < rgbaValues.Length - 2; i += 4)
                {
                    rgbaValues[i + 1] = rgbaValues[i - 1] = rgbaValues[i];
                }
                title = "Green";
            }
            else if (senderBtn.Name == "bButton")
            {
                for (int i = 0; i < rgbaValues.Length - 3; i += 4)
                {
                    rgbaValues[i + 2] = rgbaValues[i + 1] = rgbaValues[i];
                }
                title = "Blue";
            }
            else if (senderBtn.Name == "cButton")
            {
                for (int i = 2; i < rgbaValues.Length - 1; i += 4)
                {
                    rgbaValues[i] = rgbaValues[i - 1] = rgbaValues[i - 2] = (byte)(255 - rgbaValues[i]);
                }
                title = "Cyan";
            }
            else if (senderBtn.Name == "mButton")
            {
                for (int i = 1; i < rgbaValues.Length - 2; i += 4)
                {
                    rgbaValues[i] = rgbaValues[i + 1] = rgbaValues[i - 1] = (byte)(255 - rgbaValues[i]);
                }
                title = "Magenta";
            }
            else if (senderBtn.Name == "ylwButton")
            {
                for (int i = 0; i < rgbaValues.Length - 3; i += 4)
                {
                    rgbaValues[i] = rgbaValues[i + 2] = rgbaValues[i + 1] = (byte)(255 - rgbaValues[i]);
                }
                title = "Yellow";
            }
            else if (senderBtn.Name == "yButton")
            {
                for (int i = 0; i < rgbaValues.Length - 3; i += 4)
                {
                    rgbaValues[i] = rgbaValues[i + 1] = rgbaValues[i + 2] =
                        (byte)(rgbaValues[i + 2] * 0.299 + rgbaValues[i + 1] * 0.587 + rgbaValues[i] * 0.114);
                }
                title = "Y (luma)";
            }
            else if (senderBtn.Name == "iButton")
            {
                for (int i = 0; i < rgbaValues.Length - 3; i += 4)
                {
                    newColor = rgbaValues[i + 2] * 0.596 + rgbaValues[i + 1] * -0.275 + rgbaValues[i] * -0.321;
                    maxColor = Math.Max(maxColor, newColor);
                    minColor = Math.Min(minColor, newColor);
                }
                for (int i = 0; i < rgbaValues.Length - 3; i += 4)
                {
                    if (maxColor - minColor < 255)
                        color = (byte)(rgbaValues[i + 2] * 0.596 + rgbaValues[i + 1] * -0.275 + rgbaValues[i] * -0.321 - minColor);
                    else
                        color = (byte)((rgbaValues[i + 2] * 0.596 + rgbaValues[i + 1] * -0.275 + rgbaValues[i] * -0.321 - minColor) * 255 / (maxColor - minColor));
                    rgbaValues[i] = rgbaValues[i + 1] = rgbaValues[i + 2] = color;
                }
                title = "I (chroma)";
            }
            else if (senderBtn.Name == "qButton")
            {
                for (int i = 0; i < rgbaValues.Length - 3; i += 4)
                {
                    newColor = rgbaValues[i + 2] * 0.212 + rgbaValues[i + 1] * -0.523 + rgbaValues[i] * 0.311;
                    maxColor = Math.Max(maxColor, newColor);
                    minColor = Math.Min(minColor, newColor);
                }
                for (int i = 0; i < rgbaValues.Length - 3; i += 4)
                {
                    if (maxColor - minColor < 255)
                        color = (byte)(rgbaValues[i + 2] * 0.212 + rgbaValues[i + 1] * -0.523 + rgbaValues[i] * 0.311 - minColor);
                    else
                        color = (byte)((rgbaValues[i + 2] * 0.212 + rgbaValues[i + 1] * -0.523 + rgbaValues[i] * 0.311 - minColor) * 255 / (maxColor - minColor));
                    rgbaValues[i] = rgbaValues[i + 1] = rgbaValues[i + 2] = color;
                }
                title = "Q (chroma)";
            }
            else if (senderBtn.Name == "uButton")
            {
                for (int i = 0; i < rgbaValues.Length - 3; i += 4)
                {
                    newColor = 0.493 * (rgbaValues[i] - (rgbaValues[i + 2] * 0.299 + rgbaValues[i + 1] * 0.587 + rgbaValues[i] * 0.114));
                    maxColor = Math.Max(maxColor, newColor);
                    minColor = Math.Min(minColor, newColor);
                }
                for (int i = 0; i < rgbaValues.Length - 3; i += 4)
                {
                    if (maxColor - minColor < 255)
                        color = (byte)(0.493 * (rgbaValues[i] - (rgbaValues[i + 2] * 0.299 + rgbaValues[i + 1] * 0.587 + rgbaValues[i] * 0.114)) - minColor);
                    else
                        color = (byte)((0.493 * (rgbaValues[i] - (rgbaValues[i + 2] * 0.299 + rgbaValues[i + 1] * 0.587 + rgbaValues[i] * 0.114)) - minColor) * 255 / (maxColor - minColor));
                    rgbaValues[i] = rgbaValues[i + 1] = rgbaValues[i + 2] = color;
                }
                title = "U (chroma)";
            }
            else if (senderBtn.Name == "vButton")
            {
                for (int i = 0; i < rgbaValues.Length - 3; i += 4)
                {
                    newColor = 0.877 * (rgbaValues[i + 2] - (rgbaValues[i + 2] * 0.299 + rgbaValues[i + 1] * 0.587 + rgbaValues[i] * 0.114));
                    maxColor = Math.Max(maxColor, newColor);
                    minColor = Math.Min(minColor, newColor);
                }
                for (int i = 0; i < rgbaValues.Length - 3; i += 4)
                {
                    if (maxColor - minColor < 255)
                        color = (byte)(0.877 * (rgbaValues[i + 2] - (rgbaValues[i + 2] * 0.299 + rgbaValues[i + 1] * 0.587 + rgbaValues[i] * 0.114)) - minColor);
                    else
                        color = (byte)((0.877 * (rgbaValues[i + 2] - (rgbaValues[i + 2] * 0.299 + rgbaValues[i + 1] * 0.587 + rgbaValues[i] * 0.114)) - minColor) * 255 / (maxColor - minColor));
                    rgbaValues[i] = rgbaValues[i + 1] = rgbaValues[i + 2] = color;
                }
                title = "V (chroma)";
            }
            else if (senderBtn.Name == "crButton")
            {
                for (int i = 0; i < rgbaValues.Length - 3; i += 4)
                {
                    newColor = 0.713 * (rgbaValues[i + 2] - (rgbaValues[i + 2] * 0.299 + rgbaValues[i + 1] * 0.587 + rgbaValues[i] * 0.114));
                    maxColor = Math.Max(maxColor, newColor);
                    minColor = Math.Min(minColor, newColor);
                }
                for (int i = 0; i < rgbaValues.Length - 3; i += 4)
                {
                    if (maxColor - minColor < 255)
                        color = (byte)(0.713 * (rgbaValues[i + 2] - (rgbaValues[i + 2] * 0.299 + rgbaValues[i + 1] * 0.587 + rgbaValues[i] * 0.114)) - minColor);
                    else
                        color = (byte)((0.713 * (rgbaValues[i + 2] - (rgbaValues[i + 2] * 0.299 + rgbaValues[i + 1] * 0.587 + rgbaValues[i] * 0.114)) - minColor) * 255 / (maxColor - minColor));
                    rgbaValues[i] = rgbaValues[i + 1] = rgbaValues[i + 2] = color;
                }
                title = "Cr (chroma)";
            }
            else if (senderBtn.Name == "cbButton")
            {
                for (int i = 0; i < rgbaValues.Length - 3; i += 4)
                {
                    newColor = 0.564 * (rgbaValues[i] - (rgbaValues[i + 2] * 0.299 + rgbaValues[i + 1] * 0.587 + rgbaValues[i] * 0.114));
                    maxColor = Math.Max(maxColor, newColor);
                    minColor = Math.Min(minColor, newColor);
                }
                for (int i = 0; i < rgbaValues.Length - 3; i += 4)
                {
                    if (maxColor - minColor < 255)
                        color = (byte)(0.564 * (rgbaValues[i] - (rgbaValues[i + 2] * 0.299 + rgbaValues[i + 1] * 0.587 + rgbaValues[i] * 0.114)) - minColor);
                    else
                        color = (byte)((0.564 * (rgbaValues[i] - (rgbaValues[i + 2] * 0.299 + rgbaValues[i + 1] * 0.587 + rgbaValues[i] * 0.114)) - minColor) * 255 / (maxColor - minColor));
                    rgbaValues[i] = rgbaValues[i + 1] = rgbaValues[i + 2] = color;
                }
                title = "Cb (chroma)";
            }

            System.Runtime.InteropServices.Marshal.Copy(rgbaValues, 0, ptr, bytes);

            newImage.UnlockBits(bmpData);

            ImageWindow newWindow = new ImageWindow(newImage, imageFit);
            newWindow.Text = title;
            newWindow.Show();
        }

        private void fitButton_Click(object sender, EventArgs e)
        {
            image = ScaleImage(origImage, this.ClientRectangle.Width - pictureBox.Left - 3, this.ClientRectangle.Height - pictureBox.Top - 3);
            pictureBox.Image = image;
            pictureBox.Size = image.Size;
            imageFit = true;
            this.Size = this.PreferredSize;
        }
    }
}
