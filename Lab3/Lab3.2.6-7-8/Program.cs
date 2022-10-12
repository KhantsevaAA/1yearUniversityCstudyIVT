using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3._2._6_7_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lmax = 100, n=0;
            double[] mas = new double[lmax];
            bool f = true;
            string str;
            Console.WriteLine("Лабораторная работа №3. Сложность 2\n" +
                $"Введите элементы массива через Enter не более {lmax}, для окончания введите 'end' (после некорректного ввода, 'end' программа не примет:)");
            double sred = 0;
            do
            {
                Console.Write($"Элемент {n+1}: ");
                str=Console.ReadLine();
                if (str == "end")
                    f = false;
                else
                {
                    while (!double.TryParse(str.Replace('.', ','), out mas[n]))
                    {
                        Console.Write($" Упс! Некорректное значение. Попробуйте ещё раз. Элемент {n}: ");
                        str = Console.ReadLine();
                    }
                    sred = sred + mas[n];
                    n = n + 1;
                }

            }
            while (f == true);

            sred = sred / n;
            double s = double.MaxValue, p;
            int x = 0;
            Console.Write("Задача 6. Введите P: ");
            while (!double.TryParse(Console.ReadLine().Replace('.', ','),out p))
            {
                Console.Write($" Упс! Некорректное значение. Попробуйте ещё раз. Элемент {n}: ");
            }
            for (int i=0; i < n; i++)
            {
                if (Math.Abs(mas[i] - sred) < s){
                    s = Math.Abs(mas[i] - sred);
                    x = i;
                }
            }
            
            for (int i = n; i > x; --i)
                mas[i] = mas[i - 1];

            mas[x + 1] = p;
            for (int i = 0; i <= n; i++)
                Console.Write($"{mas[i]} ");

            x=0;
            Console.WriteLine("\nЗадание 7");
            for (int i=1; i<=n; i++)
                if (mas[i] > mas[x])
                    x=i;
            if (x < n)
                mas[x + 1] = mas[x + 1] * 2;
            else
                Console.WriteLine("Максимальный элемент массива в конце=>Не изменился");
            for (int i = 0; i <= n; i++)
                Console.Write($"{mas[i]} ");
            int m=x;
            for (int i = x; i < n; i++)
                if (mas[i] < mas[m])
                    m = i;
            s = mas[x];
            mas[x] = mas[m];
            mas[m] = s;


        }

    }
}
