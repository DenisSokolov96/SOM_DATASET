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
        //parameters
        private double R = 0;
        private double speed = 0;
        private int iterat = 0;

        private void обучитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int countFiles = 0;
            string[] allfolders = Directory.GetDirectories("D:\\Универ\\2й курс магистратура\\НС\\Лаб2\\HMP_Dataset");
            List<string[]> files = new List<string[]>();
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
            
            List<string> listData = new List<string>();
           /* for (int i = 0; i < richTextBox1.Lines.Length; i++)
                listData.Add( данные );*/

            Learning learning = new Learning(sizeX, sizeY, listData, R, speed, iterat);
        }


        private void распознатьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
