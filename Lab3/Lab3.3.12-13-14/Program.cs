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
                $"Введите элементы массива через Enter не более {lmax}, для окончания введите 'end' (после некорректного ввода, 'end' программа не примет):");
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

            f = false;
            int n1 = n;
            Console.WriteLine("Задание 12");
            for (int i=0; i<n; i++)
                if (mas[i] < 0)
                {
                    f = true;
                    n1 =i;
                    while ((mas[n1] < 0) && (mas[n1 + 1] < 0))
                            n1 += 1;


                    n1 = n1 - i+1;
                    n -= n1;
                    for (int j = i; j <= n; j++)
                        mas[j] = mas[j + n1];
                        
                }
            if (f==false)
                Console.Write(" В массиве нет отрицательных элементов => Массив не изменён");
            else
            {
                if (n==0)
                    Console.Write(" Данный массив полность из отрицательных элементов => массив пуст");
                else
                Console.Write(" Новый массив: ");
                for (int i = 0; i < n; i++)
                    Console.Write($" {mas[i]}");
            }

            
            Console.WriteLine("\nЗадание 13");
            f = false;
            for (int i = 0; i < n; i++)
                for (int j=i+1;j<n;j++)
                    if (mas[i] == mas[j])
                    {
                        n1 =j;
                        f= true;
                        while ((mas[j] == mas[n1]) && (mas[n1 + 1] == mas[j]))
                                n1 += 1;
                        n1 = n1 - j + 1;
                        n -= n1;
                        for (int k = j; k < n; k++)
                            mas[k] = mas[k + n1];
                    }
            if (f == false)
                Console.Write(" В массиве нет повторяющихся элементов => Массив не изменён");
            else
            {
                if (n == 0)
                    Console.Write(" Данный массив полностью из повторяющихся элементов => массив пуст");
                else
                {
                    Console.Write(" Новый массив: ");
                    for (int i = 0; i < n; i++)
                        Console.Write($" {mas[i]}");
                }
            }
            Console.WriteLine("\nЗадание 14");
            double [] kof = new double[n];
            f = false;
            for(int i = 0; i < n; i++)
                if ((mas[i] < -1) || (mas[i]>1))
                {
                    f = true;
                    kof[i] = 10;
                    while (Math.Abs(mas[i] / kof[i]) > 1)
                        kof[i] *= 10;

                }
            if (f==false)
                Console.Write(" В массиве все элементы находятся в диапозоне [-1;1]=> Массив не изменён");
            else
            {
                Console.Write(" Новый массив: ");
                for (int i = 0; i < n; i++)
                    Console.Write($"{mas[i] / kof[i]} ");
            }
        }
    }
}
