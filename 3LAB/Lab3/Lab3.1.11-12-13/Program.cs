using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3._1._11_12_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] n = new double[10];
            int mi = -1;
            Console.WriteLine("Лабораторная работа№3.Сложность 1\nЗадание 11\n Введите 10 положительных элементов массива");
            for (int i = 0; i < n.Length; i++)
            {
                Console.Write($" n[{i + 1}]=");
                while (!double.TryParse(Console.ReadLine().Replace('.', ','), out n[i]) || (n[i] < 0))
                    Console.Write($" Упс!Введено некорректное значение. Попробуйте ещё раз n[{i + 1}]=");

            }
            Console.Write("Конечный массив:");
            foreach (var x in n)
                Console.Write($" {x}");


            Console.WriteLine("\nЗадание 12\n Введите 8 элементов массива");
            for (int i = 0; i < 8; i++)
            {
                Console.Write($" n[{i+1}]=");
                while (!double.TryParse(Console.ReadLine().Replace('.', ','), out n[i]))
                    Console.Write($" Упс!Введено некорректное значение. Попробуйте ещё раз n[{i + 1}]=");
                if ((n[i] < 0) && (i > mi))
                    mi = i;
            }
            Console.Write("Конечный массив:");
            for (int i = 0; i < 8; i++)
                Console.Write($" {n[i]}");
            if (mi==-1)
                Console.WriteLine(" Данный массив не содержит отрицательных элементов");
            else
                 Console.WriteLine($" Последнего отрицательный элемент n[{mi}]={n[mi]}");

            Console.WriteLine("Задание 13\n Введите 10 элементов массива:");
            double[] n1 = new double[5], n2 = new double[5];
            for (int i = 0; i < 10; i++)
            {
                Console.Write($" n[{i+1}]=");
                while (!double.TryParse(Console.ReadLine().Replace('.', ','), out n[i])) 
                    Console.Write($" Упс!Введено некорректное значение. Попробуйте ещё раз n[{i + 1}]=");
                if (i % 2 == 0)
                    n1[(int)i / 2] = n[i];
                else
                    n2[(int)(i-1) / 2] = n[i];
            }
            Console.Write("Конечный массив:");
            foreach (var x in n)
                Console.Write($" {x}");
            Console.Write("\n");
            Console.WriteLine(String.Format("{0,-8}", "Массив 1:") + "Массив 2:");
            for (int i = 0; i < 5; i++)
                Console.WriteLine(String.Format("{0,-8}", n1[i]) + $"{n2[i]}");

        }
    }
}
