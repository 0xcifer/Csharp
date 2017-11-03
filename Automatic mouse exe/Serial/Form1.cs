using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Serial
{
    public partial class Form1 : Form
    {
        int x, y;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen) serialPort1.Close();
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                //horizontal
                if (serialPort1.IsOpen)
                {
                    textBox1.Text = "" + trackBar1.Value;
                    int x = trackBar1.Value + 200;
                    string a = x.ToString();
                    //Console.WriteLine("a"+a);
                    serialPort1.Write("a" + a);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                //vertical
                if (serialPort1.IsOpen)
                {
                    textBox2.Text = "" + trackBar2.Value;
                    int y = trackBar2.Value;
                    string b = y.ToString();
                    //Console.WriteLine("b"+b);
                    serialPort1.Write("b" + b);
                }
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //connect
            serialPort1.PortName = "COM3";
            serialPort1.BaudRate = 9600;
            serialPort1.Open();     
             if (serialPort1.IsOpen)
             {
                 for(int i=0;i<=100;i++)
                 {
                     progressBar1.Value = i;
                     Thread.Sleep(15);
                 }
             }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //disconnect
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                for (int i = 100; i >= 0; i--)
                {
                    progressBar1.Value = i;
                    Thread.Sleep(15);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //exit
            serialPort1.Close();
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //led on
            if (serialPort1.IsOpen)
            {
                serialPort1.Write("H");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //led off
            if (serialPort1.IsOpen)
            {
                serialPort1.Write("L");
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //manual
        }

        public void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            int count = 0;
            //automatic
            while (radioButton2.Checked)
            {
                x = MousePosition.X;
                y = MousePosition.Y;
                int r = 900 / 180;
                int q = 1440 / 180;
                x = x / q;
                y = y / r;
                x = x + 200;
                String d = y.ToString();
                string c = x.ToString();
                Console.Write(x);
                Console.Write("----");
                Console.WriteLine(y);
                serialPort1.Write("d" + d);
                serialPort1.Write("c" + c);
                count++;
                if (count > 5000)
                {
                    break;
                }
            }
        }
    }
}
