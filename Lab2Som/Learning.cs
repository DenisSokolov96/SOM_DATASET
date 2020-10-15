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
        //Считываю все данные в список
        List<List<List<int[]>>> ListDataSet = new List<List<List<int[]>>>();

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

            readDatas();
            int dx = 0, dy = 0;
            double dist = Double.MaxValue;
            int countIter = 0;
            do
            {
                //номер директории
                int k = 0;
                do
                {                    
                    //iTxt - номер txt в директории
                    for (int iTxt = 0; iTxt < ListDataSet[k].Count; iTxt++)
                    {
                        //отправляю на обучение по одной строке
                        for (int iStr = 0; iStr < ListDataSet[k][iTxt].Count; iStr++)
                        {
                            dx = 0; dy = 0;
                            dist = Double.MaxValue;
                            for (int j = 0; j < sizeY; j++)
                                for (int i = 0; i < sizeX; i++)
                                {
                                    double a = step3(ref j, ref i, ListDataSet[k][iTxt][iStr]);
                                    if (a < dist)
                                    {
                                        dist = a;
                                        dx = i;
                                        dy = j;
                                    }
                                }

                            step4(ref dy, ref dx, ListDataSet[k][iTxt][iStr], ref k, ref dist);
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
                                        dist = step3(ref j, ref i, ListDataSet[k][iTxt][iStr]);
                                        step4(ref j, ref i, ListDataSet[k][iTxt][iStr], ref k, ref dist);
                                    }
                                }
                            }
                        }                        
                    }
                    k++;                   
                } while (k < files.Count);
                countIter++;
            } while (countIter < m_iNumIterations);
        }

        //Инициализация вектора весов (для каждого из узлов сети) случайными значениями
        private void step1(ref int y, ref int x, ref int z)
        {           
            Random rnd = new Random();
            for (int j = 0; j < y; j++)
                for (int i = 0; i < x; i++)                
                    for (int k = 0; k < z; k++)
                        VectorW[j, i, k] = rnd.NextDouble();
                
        }

        //поиск близких значений
        private double step3(ref int y, ref int x, int[] vector)
        {
            double distance = 0;
            for (int i = 0; i < vector.Length; i++)
                distance += (vector[i] - VectorW[y, x, i]) * (vector[i] - VectorW[y, x, i]);

            return Math.Sqrt(distance);
        }

        //регулировка веса
        private void step4(ref int dy, ref int dx, int[] vector, ref int k, ref double dist)
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
        private void readDatas()
        {
            for (int iFold = 0; iFold < allfolders.Length; iFold++)
            {
                List<List<int[]>> listList = new List<List<int[]>>();
                //не беру последний, оставляю для проверки
                for (int iFile = 0; iFile < files[iFold].Length - 1; iFile++)
                {
                    List<int[]> listMas = new List<int[]>();
                    using (StreamReader sr = new StreamReader(files[iFold][iFile], Encoding.Default))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)                        
                            listMas.Add(masToList(line));
                    }
                    listList.Add(listMas);
                }
                ListDataSet.Add(listList);
            }
        }
    }
}
