using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Lab2Som
{
    class Learning
    {
        public double[,,] VectorW;
        public int sizeX = 0;
        public int sizeY = 0;
        public int sizeZ = 0;
        //скорость обучения
        private double constStartLearningRate = 0.1;
        //количество итераций обучения
        private int m_iNumIterations = 7000;
        private double R = 0;
        private string[] allfolders;
        List<string[]> files = new List<string[]>();

        public Learning(int x, int y, double R, double constStartLearningRate, int m_iNumIterations, string[] allfolders, List<string[]> files)
        {
            sizeX = x;
            sizeY = y;
            sizeZ = 3;
            this.R = R;
            this.constStartLearningRate = constStartLearningRate;
            this.m_iNumIterations = m_iNumIterations;
            VectorW = new double[sizeY, sizeX, sizeZ];
            step1(ref sizeY, ref sizeX, ref sizeZ);

            this.allfolders = allfolders;
            this.files.AddRange(files.ToArray());

            int countIter = 0;
            do
            {
                int k = 0;
                do
                {

                    string[] mas = files[k];
                    //iTxt - номер txt в папке
                    for (int iTxt = 0; iTxt < mas.Length; iTxt++)
                    {
                        //считываю данные
                        List<string> listData = readDatas(k, iTxt);

                        //отправляю на обучение по одной строке
                        for (int iStr = 0; iStr < listData.Count; iStr++)
                        {
                            string setVector = listData[iStr];

                            int dx, dy;

                            dx = 0; dy = 0;
                            double dist = Double.MaxValue;
                            for (int j = 0; j < sizeY; j++)
                                for (int i = 0; i < sizeX; i++)
                                {
                                    double a = step3(ref j, ref i, ref setVector);
                                    if (a < dist)
                                    {
                                        dist = a;
                                        dx = i;
                                        dy = j;
                                    }
                                }

                            step4(ref dy, ref dx, ref setVector, ref k, ref dist);
                            /*изменение весов соседей*/
                            int ves = (int)funcDMapRadius(k);
                            for (int j = dy - ves; j < dy + ves; j++)
                            {
                                if (j < 0) j = 0;
                                if (j == sizeY) break;
                                for (int i = dx - ves; i < dx + ves; i++)
                                {
                                    if (i < 0) i = 0;
                                    if (i == sizeX) break;
                                    if ((i != dx) || (j != dy))
                                    {
                                        dist = step3(ref j, ref i, ref setVector);
                                        step4(ref j, ref i, ref setVector, ref k, ref dist);
                                    }
                                }
                            }
                        }
                    }
                    k++;
                } while (k < files.Count);
                countIter++;
            } while (countIter < /*m_iNumIterations*/1);

        }

        //Инициализация вектора весов (для каждого из узлов сети) случайными значениями
        private void step1(ref int y, ref int x, ref int z)
        {
            List<double[]> list = new List<double[]>();

            /*list.Add(new double[] { 255, 0, 0 });
            list.Add(new double[] { 0, 128, 0 });
            list.Add(new double[] { 0, 0, 255 });
            list.Add(new double[] { 0, 100, 0 });
            list.Add(new double[] { 0, 0, 139 });
            list.Add(new double[] { 255, 255, 0 });
            list.Add(new double[] { 255, 165, 0 });
            list.Add(new double[] { 128, 0, 128 });*/
            list.Add(new double[] { 0, 15, 30 });
            list.Add(new double[] { 5, 20, 35 });
            list.Add(new double[] { 10, 25, 40 });
            list.Add(new double[] {15, 30, 45 });
            list.Add(new double[] { 20, 35, 0 });
            list.Add(new double[] { 25, 40, 5 });
            list.Add(new double[] { 30, 45, 10 });
            list.Add(new double[] { 35, 0, 15 });


            Random rnd = new Random();
            for (int j = 0; j < y; j++)
                for (int i = 0; i < x; i++)
                {
                    double[] a = list[rnd.Next(0, 8)];
                    for (int k = 0; k < z; k++)
                        VectorW[j, i, k] = a[k];
                }
        }

        // количество итераций, которые будет выполнять алгоритм обучения
        private double Eps(string vector, int dx, int dy)
        {
            List<int> list = masToList(ref vector);

            double eps = 0.0;
            for (int i = 0; i < list.Count; i++)
                eps += Math.Abs(list[i] - VectorW[dy, dx, i]);

            return eps * (1 / list.Count);
        }

        //Из обучающего множества случайным образом выбирается вектор.
        /*private string step2(ref List<string> listData)
        {
            if (listData.Count == 0) return "stop";
            Random rnd = new Random();
            int k = rnd.Next(0, listData.Count);
            string setVector = listData[k];
            listData.RemoveAt(k);
            return setVector;
        }*/

        //поиск близких значений
        private double step3(ref int y, ref int x, ref string vector)
        {
            List<int> list = masToList(ref vector);

            double distance = 0;
            for (int i = 0; i < list.Count; i++)
                distance += (list[i] - VectorW[y, x, i]) * (list[i] - VectorW[y, x, i]);

            return Math.Sqrt(distance);
        }

        //регулировка веса
        private void step4(ref int dy, ref int dx, ref string vector, ref int k, ref double dist)
        {
            List<int> list = masToList(ref vector);

            for (int i = 0; i < sizeZ; i++)
                VectorW[dy, dx, i] += funcT(k, dist) * funcSpeedL(k) * (list[i] - VectorW[dy, dx, i]);
        }

        // степень влияния расстояния узла от BMU на его обучение
        private double funcT(int k, double dist)
        {
            return Math.Exp(-(dist / (2 * Math.Pow(funcDMapRadius(k), 2))));
        }

        //скорость обучения
        private double funcSpeedL(int k)
        {
            return constStartLearningRate * Math.Exp(-(double)k / m_iNumIterations);
        }

        //радиус соседства, изменеяется со временем
        private double funcDMapRadius(int k)
        {
            double m_dTimeConstant = m_iNumIterations / R;
            return R * Math.Exp(-(double)k / m_dTimeConstant);
        }

        //переобразовать входную строку в список целых значений
        private List<int> masToList(ref string vector)
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

            return list;
        }
        
        //читать из файла
        private List<string> readDatas(int iter, int iText)
        {
            List<string> spisok = new List<string>();
            string path = files[iter][iText];

            try
            {
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        spisok.Add(line);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");                
            }
            return spisok;
        }
    }
}
