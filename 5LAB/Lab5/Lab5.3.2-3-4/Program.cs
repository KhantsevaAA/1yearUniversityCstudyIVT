using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        static void inputdouble(out double x)
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
                    //Console.Write($"x[{i}, {j}] = ");
                    //inputdouble(out x[i, j]);
                    x[i, j] = rand.Next(-100,100)*0.1 ;
                }
        }
        static void matrixout(double[,] x)
        {
            for (int i = 0; i < x.GetLength(0); i++)
            {
                for (int j = 0; j < x.GetLength(1); j++)
                    Console.Write($"{x[i, j],8}");
                Console.Write("\n");
            }
        }
        delegate void stri(int x, double[,] y);
        static void str0(int x, double[,] y)
        {
            for (int j = 0; j < y.GetLength(1); j++)
                for (int k = j + 1; k < y.GetLength(1); k++)
                    if (y[x, j] > y[x, k])
                    {
                        double c = y[x, j];
                        y[x, j] = y[x, k];
                        y[x, k] = c;
                    }
        }
        static void str1(int x, double[,] y)
        {
            for (int j = 0; j < y.GetLength(1); j++)
                for (int k = j + 1; k < y.GetLength(1); k++)
                    if (y[x, j] < y[x, k])
                    {
                        double c = y[x, j];
                        y[x, j] = y[x, k];
                        y[x, k] = c;
                    }
        }
        static void order(double[,] x)
        {
            for (int i = 0; i < x.GetLength(0); i++)
            {
                if ((i + 1) % 2 == 0)
                    str0(i, x);
                else
                    str1(i, x);
            }
        }
        static void massiv(double[] x)
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            for (int i = 0; i < x.GetLength(0); i++)
                x[i] = rand.Next(-100, 100) * 0.1;
        }
        static void outmas(double[] x)
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            for (int i = 0; i < x.GetLength(0); i++)
                Console.Write($"{x[i]} ");
        }

        delegate void exchangei(double[] x);
        static void exchange0(double[] x) { 
            for (int i = 0; i < x.GetLength(0)-1; i=i+2)
            {
                double c = x[i];
                x[i] = x[i + 1];
                x[i + 1] = c;
            }

        }
        static void exchange1(double[] x) {
            for (int i = x.GetLength(0)-1; i > 0; i = i-2)
            {
                double c = x[i];
                x[i] = x[i - 1];
                x[i - 1] = c;
            }
        }
        static void change(double[] x)
        {
            double s = 0;
            for (int i = 0; i < x.GetLength(0); i++)
                s += x[i];
            s=s/x.GetLength(0);
            if (x[0] > s)
                exchange0(x);
            else
                exchange1(x);
        }

        static double sum(double[] x)
        {
            double s = 0;
            return s;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа №5. Сложность 3\n Задание 2");
            Console.Write(" введите кол-во строк матрицы: ");
            inputint(out int n);
            Console.Write(" введите кол-во стролбцов матрицы: ");
            inputint(out int m);
            double[,] mat = new double[n, m];
            assignment(mat);
            Console.WriteLine(" Изначальная матрица:");
            matrixout(mat);
            order(mat);
            Console.WriteLine(" Полученная матрица (нумерация начиная с 1):");
            matrixout(mat);
            Console.WriteLine("Задание 3\n Введите длину массива:");
            inputint(out int l);
            double[] mas = new double[l];
            massiv(mas);
            Console.WriteLine("Сгенерированный массив");
            outmas(mas);
            change(mas);
            Console.WriteLine("\nМассив после изменения:");
            outmas(mas);

        }
        
    }
}
