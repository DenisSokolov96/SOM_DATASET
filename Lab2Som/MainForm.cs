using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Lab2Som
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public double[,,] VectorW;
        private int sizeX = 4;
        private int sizeY = 4;
        private string[] allfolders;
        List<string[]> files = new List<string[]>();
        //parameters
        private double R = 0;
        private double speed = 0;
        private int iterat = 0;        

        private void обучитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int countFiles = 0;
            allfolders = Directory.GetDirectories("D:\\Универ\\2й курс магистратура\\НС\\Лаб2\\HMP_Dataset");            
            for (int i = 0; i < allfolders.Length; i++)
            {
                files.Add(Directory.GetFiles(allfolders[i]));
                countFiles += files[i].Length;
            }
            richTextBox1.Text += "Прочитано: " + allfolders.Length + " директ.\n";
            richTextBox1.Text += "Файлов txt: " + countFiles.ToString() + ".\n";

            learningFunc();            

        }

        private void learningFunc()
        {
            try
            {
                sizeY = Convert.ToInt32(textY.Text);
                sizeX = Convert.ToInt32(textX.Text);

                R = Convert.ToDouble(textBox3.Text); ;
                speed = (double)trackBar1.Value / 10;
                iterat = Convert.ToInt32(textBox2.Text);
            }
            catch
            {
                textY.Text = "30";
                textX.Text = "30";
                sizeY = 30;
                sizeX = 30;
                R = 15;
                speed = 0.1;
                iterat = 7000;
            }

            Learning learning = new Learning(sizeX, sizeY, R, speed, iterat, allfolders, files);
            VectorW = learning.VectorW;

            Draw();
        }

        private void Draw()
        {

            Graphics g = pictureBox1.CreateGraphics();
            int y = pictureBox1.Width / sizeY;
            int x = pictureBox1.Height / sizeX;
            for (int i = 0; i < sizeX; i++)
                for (int j = 0; j < sizeY; j++)
                {
                    long a1 = (long)VectorW[j, i, 0];
                    long a2 = (long)VectorW[j, i, 1];
                    long a3 = (long)VectorW[j, i, 2];

                    /* double b = 0.5 / VectorW[j, i, 0];
                     long a1 = (long)(255.0 / b);

                     b = 0.5 / VectorW[j, i, 1];
                     long a2 = (long)(255.0 / b);

                     b = 0.5 / VectorW[j, i, 2];
                     long a3 = (long)(255.0 / b);*/



                    if (a1 > 255) a1 = 255;
                    if (a2 > 255) a2 = 255;
                    if (a3 > 255) a3 = 255;
                    if (a1 < 0) a1 = 0;
                    if (a2 < 0) a2 = 0;
                    if (a3 < 0) a3 = 0;

                    if ((i != 0) && (j != 0))
                    {
                        g.FillRectangle(new SolidBrush(Color.FromArgb((int)a1, (int)a2, (int)a3)),
                                                              j * pictureBox1.Width / sizeY - 1, i * pictureBox1.Height / sizeX - 1,
                                                    y + 1, x + 1);
                    }
                    if ((i == 0) && (j == 0))
                    {
                        g.FillRectangle(new SolidBrush(Color.FromArgb((int)a1, (int)a2, (int)a3)),
                                                             j * pictureBox1.Width / sizeY, i * pictureBox1.Height / sizeX,
                                                     y + 1, x + 1);
                    }
                    if ((i == 0) && (j != 0))
                    {
                        g.FillRectangle(new SolidBrush(Color.FromArgb((int)a1, (int)a2, (int)a3)),
                                                             j * pictureBox1.Width / sizeY - 1, i * pictureBox1.Height / sizeX,
                                                  y + 1, x + 1);
                    }
                    if ((i != 0) && (j == 0))
                    {
                        g.FillRectangle(new SolidBrush(Color.FromArgb((int)a1, (int)a2, (int)a3)),
                                                             j * pictureBox1.Width / sizeY, i * pictureBox1.Height / sizeX - 1,
                                                     y + 1, x + 1);
                    }
                }

            g.Dispose();
        }

        private void распознатьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label3.Text = ((double)trackBar1.Value / 10).ToString();
        }
    }
}
