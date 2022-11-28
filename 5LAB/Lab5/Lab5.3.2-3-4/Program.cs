using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5._3._2_3_4
{
    internal class Program
    {
        static void inputint(out int x)
        {
            while ((!int.TryParse(Console.ReadLine().Replace('.', ','), out x) || (x <= 0)))
                Console.Write(" Упс!Некорретное значение.\n Попробуйте ещё раз: ");
        }
        static void inputdouble( double x)
        {
            while (!double.TryParse(Console.ReadLine().Replace('.', ','), out x))
                Console.Write(" Упс!Некорретное значение.\n Попробуйте ещё раз: ");

        }
        static void assignment(double[,] x)
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            for (int i = 0; i < x.GetLength(0); i++)
                for (int j = 0; j < x.GetLength(1); j++)
                {
                    Console.Write($"x[{i}, {j}] = ");
                    inputdouble(x[i, j]);
                }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа №5. Сложность 3\n Задание 2");
            Console.Write("введите кол-во строк матрицы: ");
            inputint(out int n);
            Console.Write("введите кол-во стролбцов матрицы: ");
            inputint(out int m);
            double[,] mat = new double[n, m];
            assignment(mat);

        }
        
    }
}
