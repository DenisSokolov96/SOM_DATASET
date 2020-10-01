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
        }
    }
}
