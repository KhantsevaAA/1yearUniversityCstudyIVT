using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4._1._7_8_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            Console.WriteLine("Лабораторная работа №4. Сложность 1\n\nЗадание 26\n Матрицы размера 5 на 7 по строкам.");
            double[,] n = new double[5, 7];
            Console.WriteLine("Форматированный вывод:");
            for (int i = 0; i < n.GetLength(0); i++)
            {
                for (int j = 0; j < n.GetLength(1); j++)
                {
                    n[i, j] = rand.Next(-1000, 1000) * 0.1;
                    Console.Write($"{n[i, j],8}");
                }
                Console.Write("\n");
            }
            int max = 0;
            for (int i=1; i< n.GetLength(0); i++)
                if (n[max, 5] < n[i,5])
                    max = i;
            double[] b = new double[7];
            Console.WriteLine("Введите через Enter массив b размера 7:");
            for (int i = 0; i < n.GetLength(1); i++)
                {
                    Console.Write($"b[{i + 1}]=");
                    while (!double.TryParse(Console.ReadLine().Replace('.', ','), out b[i]))
                        Console.Write($"Упс! Некорректное значение. Попробуйте ещё раз b[{i + 1}]=");
                }
            for (int i = 0; i < n.GetLength(1); i++)
                n[max, i] = b[i];
            Console.WriteLine("Полученная матрица:");
            for (int i = 0; i < n.GetLength(0); i++)
            {
                for (int j = 0; j < n.GetLength(1); j++)
                    Console.Write($"{n[i, j],8}");
                Console.Write("\n");
            }

            Console.Write("\nЗадание 27\n Используем в качестве изначальной матрицы" +
                " полученную из предыдущего задания");
            for (int i = 0; i < n.GetLength(0); i++) 
            {
                max = 0;
                for (int j = 1; j < n.GetLength(1); j++)
                    if (n[i, max] < n[i, j])
                        max = j;
                b[i] = n[i, max];
            }
            Console.Write($"\n");
            for (int i = n.GetLength(0) - 1; i > -1; --i)
                n[n.GetLength(0)-i-1, 3] = b[i];

            Console.WriteLine("Полученная матрица:");
            for (int i = 0; i < n.GetLength(0); i++)
            {
                for (int j = 0; j < n.GetLength(1); j++)
                    Console.Write($"{n[i, j],8}");
                Console.Write("\n");
            }

            Console.Write($"\nЗадание 28\n Так как, по условию, в данном задание заданная" +
                $" матрица имеет столько же строк сколько столбцов предыдущая матрица и столько стобов сколько строк, " +
                $"используем матрицу полученную из предыдущего задания. Изначальная матрица:\n");
            for (int j = 0; j < n.GetLength(1); j++)
            {
                for (int i = 0; i < n.GetLength(0); i++)
                    Console.Write($"{n[i, j],8}");
                Console.Write("\n");
            }
            double mmax = 0,sum;
            for (int i = 0; i < n.GetLength(0); i++)
                if (n[i, 0] > 0)
                    mmax += n[i, 0];
            max = 0;
            for (int j = 1; j < n.GetLength(1); j++)
            {
                sum = 0;
                for (int i = 0; i < n.GetLength(0); i++)
                    if (n[i, j] > 0)
                        sum += n[i, j];
                if (sum> mmax)
                {
                    mmax = sum;
                    max = j;
                }
            }
            
            for (int j = max; j < n.GetLength(1)-1; j++)
                for (int i = 0; i < n.GetLength(0); i++)
                    n[i, j] = n[i, j + 1];
            Console.WriteLine("Полученная матрица:");
            for (int j = 0; j < n.GetLength(1)-1; j++)
            {
                for (int i = 0; i < n.GetLength(0); i++)
                    Console.Write($"{n[i, j],8}");
                Console.Write("\n");
            }
        }
    }
}
