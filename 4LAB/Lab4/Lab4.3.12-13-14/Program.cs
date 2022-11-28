using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4._3._12_13_14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Лабораторная работа №4. Сложность 3\n Введите " +
                "элементы матрицы размера n на n по строкам каждый элемент " +
                "через Enter. Сначала введите n:");
            int n;
            while (!int.TryParse(Console.ReadLine().Replace('.', ','), out n))
                Console.Write($"Упс! Некорректное значение. Попробуйте ещё раз n=");
            double[,] a = new double[n, n];
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write($"a[{i + 1},{j + 1}]=");
                    while (!double.TryParse(Console.ReadLine().Replace('.', ','), out a[i, j]))
                        Console.Write($"Упс! Некорректное значение. Попробуйте ещё раз a[{i + 1},{j + 1}]=");
                }
            Console.WriteLine("Форматированный вывод:");
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                    Console.Write($"{a[i, j],5}");
                Console.Write("\n");
            }

            Console.WriteLine($"\nЗадание 12");
            double[,] b = new double[n, n] ;
            b = (double[,])a.Clone();
            for (int i = 0; i < b.GetLength(0); i++)
                for (int j = 0; j < i; j++)
                    b[i, j] = 0;

            Console.WriteLine("Полученная матрица:");
            for (int i = 0; i < b.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                    Console.Write($"{b[i, j],5}");
                Console.Write("\n");
            }
            
            Console.WriteLine($"\nЗадание 13");
            b = (double[,])a.Clone();

            for (int i = 0; i < b.GetLength(0); i++)
                for (int j = i+1; j < b.GetLength(0); j++)
                    b[i, j] = 0;

            Console.WriteLine("Полученная матрица:");
            for (int i = 0; i < b.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                    Console.Write($"{b[i, j],5}");
                Console.Write("\n");
            }

            Console.WriteLine($"\nЗадание 14");
            b = (double[,])a.Clone();

            for (int i = 0; i < b.GetLength(0); i++)
                for (int j = 0; j < b.GetLength(0); j++)
                    if (i!=j)
                    b[i, j] = 0;

            Console.WriteLine("Полученная матрица:");
            for (int i = 0; i < b.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                    Console.Write($"{b[i, j],5}");
                Console.Write("\n");
            }
        }
    }
}
