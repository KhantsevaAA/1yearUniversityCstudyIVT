using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3._3._12_13_14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lmax = 100, n = 0;
            double[] mas = new double[lmax];
            bool f = true;
            string str;
            Console.WriteLine("Лабораторная работа №3. Сложность 2\n" +
                $"Введите элементы массива через Enter не более {lmax}, для окончания введите 'end' (после некорректного ввода, 'end' программа не примет:)");
            do
            {
                Console.Write($" Элемент {n + 1}: ");
                str = Console.ReadLine();
                if (str == "end")
                    f = false;
                else
                {
                    while (!double.TryParse(str.Replace('.', ','), out mas[n]))
                    {
                        Console.Write($"  Упс! Некорректное значение. Попробуйте ещё раз. Элемент {n}: ");
                        str = Console.ReadLine();
                    }
                    n = n + 1;
                }

            }
            while (f == true);

            int n1 = n;
            Console.WriteLine("Задание 12");
            for (int i=0; i<n; i++)
                if (mas[i] < 0)
                {
                    Console.WriteLine($"{i} {mas[i]}");
                    n1 -= 1;
                    for (int j = i; j <= n1; j++)
                        mas[j] = mas[j + 1];
                }

            if (n == n1)
                Console.Write(" В массиве нет отрицательных элементов => Массив не изменён");
            else
            {
                Console.Write(" Новый массив: ");
                for (int i = 0; i < n1; i++)
                    Console.Write($" {mas[i]}");
            }

            n = n1;
            Console.WriteLine("\nЗадание 13");
            for (int i = 0; i < n; i++)
                for (int j=i+1;j<n;j++)
                    if (mas[i] == mas[j])
                    {
                        n1 -= 1;
                        for (int k = j; k <= n1; k++)
                            mas[k] = mas[k + 1];
                    }
            if (n == n1)
                Console.Write(" В массиве нет повторяющихся элементов => Массив не изменён");
            else
            {
                Console.Write(" Новый массив: ");
                for (int i = 0; i <= n1; i++)
                    Console.Write($" {mas[i]}");
            }
        }
    }
}
