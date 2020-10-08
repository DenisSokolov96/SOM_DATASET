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
        //просто подсчитываю средние значения
        public List<int[]> listZn = new List<int[]>();

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
                    listZn.Add(new int[] { 0, 0, 0 });
                    int count = 0;
                    //iTxt - номер txt в папке
                    for (int iTxt = 0; iTxt < mas.Length; iTxt++)
                    {
                        //считываю данные
                        List<string> listData = readDatas(k, iTxt);
                        count += listData.Count;
                        //отправляю на обучение по одной строке
                        for (int iStr = 0; iStr < listData.Count; iStr++)
                        {
                            int[] intVector = masToList(listData[iStr]);
                            listZn[k][0] += intVector[0];
                            listZn[k][1] += intVector[1];
                            listZn[k][2] += intVector[2];
                            int dx, dy;

                            dx = 0; dy = 0;
                            double dist = Double.MaxValue;
                            for (int j = 0; j < sizeY; j++)
                                for (int i = 0; i < sizeX; i++)
                                {
                                    double a = step3(ref j, ref i, ref intVector);
                                    if (a < dist)
                                    {
                                        dist = a;
                                        dx = i;
                                        dy = j;
                                    }
                                }

                            step4(ref dy, ref dx, ref intVector, ref k, ref dist);
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
                                        dist = step3(ref j, ref i, ref intVector);
                                        step4(ref j, ref i, ref intVector, ref k, ref dist);
                                    }
                                }
                            }
                        }                        
                    }
                    listZn[k][0] /= count;
                    listZn[k][1] /= count;
                    listZn[k][2] /= count;
                    count = 0;                    
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
            list.Add(new double[] { 22, 49, 35 });
            list.Add(new double[] { 20, 50, 35 });
            list.Add(new double[] { 22, 50, 34 });
            list.Add(new double[] { 18, 49, 34, });
            list.Add(new double[] { 26, 49, 40 });
            list.Add(new double[] { 25, 49, 41 });
            list.Add(new double[] { 21, 48, 43 });


            Random rnd = new Random();
            for (int j = 0; j < y; j++)
                for (int i = 0; i < x; i++)
                {
                    double[] a = list[rnd.Next(0, 7)];
                    for (int k = 0; k < z; k++)
                        VectorW[j, i, k] = a[k];
                }
        }

        // количество итераций, которые будет выполнять алгоритм обучения
        private double Eps(int[] vector, int dx, int dy)
        {
            double eps = 0.0;
            for (int i = 0; i < vector.Length; i++)
                eps += Math.Abs(vector[i] - VectorW[dy, dx, i]);

            return eps * (1 / vector.Length);
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
        private double step3(ref int y, ref int x, ref int[] vector)
        {
            double distance = 0;
            for (int i = 0; i < vector.Length; i++)
                distance += (vector[i] - VectorW[y, x, i]) * (vector[i] - VectorW[y, x, i]);

            return Math.Sqrt(distance);
        }

        //регулировка веса
        private void step4(ref int dy, ref int dx, ref int[] vector, ref int k, ref double dist)
        {
            for (int i = 0; i < sizeZ; i++)
                VectorW[dy, dx, i] += funcT(k, dist) * funcSpeedL(k) * (vector[i] - VectorW[dy, dx, i]);
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
        
        //читать из файла
        private List<string> readDatas(int iter, int iText)
        {
            List<string> spisok = new List<string>();
            string path = files[iter][iText];

            try
            {
                using (StreamReader sr = new StreamReader(path, Encoding.Default))
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
