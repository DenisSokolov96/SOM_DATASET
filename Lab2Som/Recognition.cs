using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Lab2Som
{
    class Recognition
    {
        private double[,,] VectorW;        
        private string FilesName = null;
        private List<int[]> ListIntVectors;
        public List<int[]> ListLovedOnes = new List<int[]>();

        public Recognition(int sizeX, int sizeY, double[,,] Matr, string FilesName)
        {
            VectorW = Matr;
            this.FilesName = FilesName;
            ListIntVectors = ReadData();

            for (int KIndex = 0; KIndex < ListIntVectors.Count(); KIndex++)
            {
                int znI = -1;
                int znJ = -1;
                double dist = Double.MaxValue;
                for (int j = 0; j < sizeY; j++)
                    for (int i = 0; i < sizeX; i++)
                    {
                        double a = step1(ref j, ref i,ListIntVectors[KIndex]);
                        if (a < dist)
                        {
                            dist = a;
                            znI = i;
                            znJ = j;
                        }
                    }
                ListLovedOnes.Add(new int[] { znI, znJ});
            }

        }

        //чтение значение значений с файлика
        private List<int[]> ReadData()
        {
            List<int[]> ListVector = new List<int[]>();
            
            try
            {
                using (StreamReader sr = new StreamReader(FilesName, Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)                    
                        ListVector.Add(masToList(line));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }

            return ListVector;
        }

        //переобразовать входную строку в список целых значений
        private int[] masToList(string vector)
        {
            List<int> list = new List<int>();
            list.Add(0);
            int ki = 0;
            for (int i = 0; i < vector.Length; i++)
            {
                if (!vector[i].Equals(' '))
                    list[ki] = list[ki] * 10 + Convert.ToInt32(vector[i].ToString());
                else
                {
                    ki++;
                    list.Add(0);
                }
            }

            return list.ToArray();
        }

        //поиск близких значений
        private double step1(ref int y, ref int x, int[] vector)
        {            
            double distance = 0;
            for (int i = 0; i < vector.Length; i++)
                distance += (vector[i] - VectorW[y, x, i]) * (vector[i] - VectorW[y, x, i]);

            return Math.Sqrt(distance);
        }
        
    }
}
