using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Lab4._2._8_9_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            Console.WriteLine("Лабораторная работа №4. Сложность 2\n\nЗадание 8\n Матрица размера 6 на 6 по строкам");
            double[,] n8 = new double[6, 6];
            Console.WriteLine("Форматированный вывод:");
            for (int i = 0; i < n8.GetLength(0); i++)
            {
                for (int j = 0; j < n8.GetLength(1); j++)
                {
                    n8[i, j] = rand.Next(-1000, 1000) * 0.1;
                    Console.Write($"{n8[i, j],8}");
                }
                Console.Write("\n");
            }

            int max0=0,max1;
            double c;
            for (int i = 0; i < n8.GetLength(0); i++) {
                if (i % 2 == 0) {
                    max0 = 0;
                    for (int j = 0; j < n8.GetLength(1); j++)
                        if (n8[i, max0] < n8[i, j])
                            max0 = j;
                }
                else
                {
                    max1 = 0;
                    for (int j = 0; j< n8.GetLength(1); j++)
                        if (n8[i, max1] < n8[i, j])
                            max1 = j;
                    c = n8[i - 1, max0];
                    n8[i-1, max0] = n8[i, max1];
                    n8[i, max1]=c;
                }

            }
            Console.WriteLine("Полученная матрица:");
            for (int i = 0; i < n8.GetLength(0); i++)
            {
                for (int j = 0; j < n8.GetLength(1); j++)
                    Console.Write($"{n8[i, j],8}");
                Console.Write("\n");
            }

            Console.WriteLine("\nЗадание 9\n Матрица размера 6 на 7 по строкам");
            double[,] n9 = new double[6, 7];
            Console.WriteLine("Форматированный вывод:");
            for (int i = 0; i < n9.GetLength(0); i++)
            {
                for (int j = 0; j < n9.GetLength(1); j++)
                {
                    n9[i, j] = rand.Next(-1000, 1000) * 0.1;
                    Console.Write($"{n9[i, j],8}");
                }
                Console.Write("\n");
            }
            for (int i = 0; i < n9.GetLength(0); i++)
                for (int j = 0; j < (int)(n9.GetLength(1)/2); j++)
                {
                    c = n9[i, j];
                    n9[i, j] = n9[i, n9.GetLength(1) - 1 - j];
                    n9[i, n9.GetLength(1) - 1 - j]= c;
                }
            Console.WriteLine("Полученная матрица:");
            for (int i = 0; i < n9.GetLength(0); i++)
            {
                for (int j = 0; j < n9.GetLength(1); j++)
                    Console.Write($"{n9[i, j],8}");
                Console.Write("\n");
            }


            Console.WriteLine("\nЗадание 1\n Матрица размера 5 на 7 по строкам:");
            double[,] n1 = new double[5, 7];
            Console.WriteLine("Форматированный вывод:");
            for (int i = 0; i < n1.GetLength(0); i++)
            {
                for (int j = 0; j < n1.GetLength(1); j++)
                {
                    n1[i, j] = rand.Next(-1000, 1000) * 0.1;
                    Console.Write($"{n1[i, j],8}");
                }
                Console.Write("\n");
            }

            for (int i=0; i < n1.GetLength(0); i++)
            {
                max0 = 0;
                for(int j=1;j< n1.GetLength(1); j++)
                    if (n1[i, j] > n1[i,max0])
                        max0 = j;
                if ((max0 > 0) && (max0 < n1.GetLength(1)-1))
                {
                    if (n1[i, max0 - 1] < n1[i, max0 + 1])
                        n1[i, max0 - 1] *= 2;
                    else
                        n1[i, max0 + 1] *= 2;
                }
                else {
                    if (max0 == 0)
                        n1[i, max0 + 1] *= 2;
                    else
                        n1[i, max0 -1] *= 2;
                }
            }
            Console.WriteLine("Полученная матрица:");
            for (int i = 0; i < n1.GetLength(0); i++)
            {
                for (int j = 0; j < n1.GetLength(1); j++)
                    Console.Write($"{n1[i, j],8}");
                Console.Write("\n");
            }
        }
    }
}

