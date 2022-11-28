using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Lab._5._2._26_27_28
{
    internal class Program
    {
        static void inputint(out int x)
        {
            while ((!int.TryParse(Console.ReadLine().Replace('.', ','), out x) && (x<=0)))
                Console.Write(" Упс!Некорретное значение.\n Попробуйте ещё раз: ");

        }static void inputdouble(out double x)
        {
            while (!double.TryParse(Console.ReadLine().Replace('.', ','), out x ))
                Console.Write(" Упс!Некорретное значение.\n Попробуйте ещё раз: ");

        }
        static void assignment(double[,] x)
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            for (int i = 0; i < x.GetLength(0); i++)
                for (int j = 0; j < x.GetLength(1); j++)
                    x[i, j] = rand.Next(-1000, 1000) * 0.1;
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

        static void exchangestrings(double[,] x, double[,] y, int maxx, int maxy)
        {
            double c;
            for (int j = 0; j < x.GetLength(1); j++)
            {
                c = x[maxx, j];
                x[maxx, j] = y[maxy, j];
                y[maxy, j]=c;

            }
        }
        static int countnegative(double[,] x)
        {
            int imax=-1, max = 0,k;
            for (int i=0; i < x.GetLength(0);i++)
            {
                k = 0;
                for (int j=0; j < x.GetLength(1); j++)
                {
                    if (x[i, j] < 0)
                        k++;
                }
                if (k > max)
                {
                    max = k;
                    imax = i;
                }
            }
            return imax;
        }
        static void changestrings(double[,] x)
        {
            int max;
            for (int i = 0; i < x.GetLength(0); i++)
            {
                max = 0;
                for (int j = 1; j < x.GetLength(1); j++)
                    if (x[i, j] > x[i, max])
                        max = j;
                if ((i + 1) % 2 == 0)
                    x[i, max] = 0;
                else
                    x[i, max] *= (max + 1);

            }
        }

        static void generate(double[,] x, double a, double b)
        {
            Random r = new Random((int)DateTime.Now.Ticks);
            for (int j = 0; j < x.GetLength(1); j++)
            {
                x[0, j] = r.Next((int)Math.Min(a, b) * 10, (int)Math.Max(a, b) * 10) * 0.1;
                x[0, j] = j;
            }
            for (int i = 1; i < x.GetLength(0); i++)
                for (int j = 0; j < x.GetLength(1); j++)
                {
                    x[i, j] = r.Next(-1000, 1000) * 0.1;
                    x[1, j] = x.GetLength(1)-j;
                    x[2, j] = 1;
                }
        }

        static void outtab(double[,] x)
        {
            Console.Write("\n");
            for (int i = 0; i < x.GetLength(0); i++)
            {
                for (int j = 0; j < x.GetLength(1); j++)
                {
                    if ((i == 0) && (j == 0))
                        Console.Write($"y/x" + $"{x[i, j],8}");
                    else
                        if (i == 0)
                        Console.Write($"{x[i, j],8}");
                    else
                            if (j == 0)
                        Console.Write($"y{i} " + $"{x[i, j],8}");
                    else
                        Console.Write($"{x[i, j],8}");
                }
                Console.Write("\n");
            }

        }
        static void order(double[,] x)
        {
            for (int i = 0; i < x.GetLength(1); i++)
            {
                for (int j = i+1; j < x.GetLength(1); j++)
                    if (x[0, i] > x[0, j])
                        for (int k = 0; k < x.GetLength(0); k++)
                        {
                            double c = x[k, i];
                            x[k, i] = x[k,j];
                            x[k,j]=c;
                        }
            }
        }

        static string monall(double[,] x)
        {
            string str1 = "не монотона", str2="не монотона";
            bool f = true,fi=true;
            int n ;
            for (int i = 1; i < x.GetLength(0); i++)
            {
                n = 0;
                if (x[i, n] == x[i, n + 1])
                    while(x[i, n] == x[i, n + 1] && n < x.GetLength(1) - 2)
                        n = n + 1;
                //Console.WriteLine($"{n} {x.GetLength(1)}");
                if (n+1 == x.GetLength(1) - 1)
                {
                    if (i == 1)
                        str1 = $"это y={x[i, n]}";
                    else
                        str2 = $"это y={x[i, n]}";
                }
                else
                {
                    if (x[i, n] > x[i, n + 1])
                        while (f && n < x.GetLength(1) - 2)
                        {
                            if (x[i, n] < x[i, n + 1])
                                f = false;
                            n = n + 1;
                        }
                    else if (x[i, n] < x[i, n + 1])
                    {
                        while (f && n < x.GetLength(1) - 1)
                        {
                            if (x[i, n] > x[i, n + 1])
                                f = false;
                            n = n + 1;
                        }
                        fi = false;
                    }
                    Console.WriteLine($"{n}");
                    if (n+1 == x.GetLength(1) - 1)
                    {
                        if (fi)
                        {
                            if (i == 1)
                                str1 = "монотоно возрастает";
                            else
                                str2 = "монотоно возрастает";
                            
                        }
                        else
                        {
                            if (i == 1)
                                str1 = "монотоно убывает";
                            else
                                str2 = "монотоно убывает";
                        }
                    }
                }
            }
            return str1 +" и "+ str2;
        }
        static void mon(double[,] x, string str )
        {
            int n;
            string[] s =str.Split(' ');
            Console.WriteLine(s.GetLength(0));
            for(int i=1; i < x.GetLength(0); i++)
            {

            }
        }
        static void Main(string[] args)
        {
            int n, m;
            Console.Write("Лабораторная работа №5. Сложность 2.\nЗадание 26\n Введите размер двух матриц, которые будут составлены автоматически: \nкол-во строк n = ");
            inputint(out n);
            Console.Write("кол-во столбцов m = ");
            inputint(out m);
            double[,] a = new double[n, m];
            assignment(a);
            
            double[,] b = new double[n, m];
            assignment(b);
            Console.WriteLine("Форматированный вывод 1 матрицы:");
            matrixout(a);
            Console.WriteLine("Форматированный вывод 2 матрицы:");
            matrixout(b);
            int maxa = countnegative(a);
            int maxb = countnegative(b);
            switch ((maxa, maxb))
            {
                case (-1,-1):
                    Console.WriteLine("Обе матрицы не имеют отрицательных чисел -> нельзя поменять строчки");
                    break;
                case (-1,>-1):
                    Console.WriteLine("Первая матрица не имеет отрицательных чисел -> нельзя поменять строчки");
                    break;
                case (> -1,-1):
                    Console.WriteLine("Вторая матрица не имеет отрицательных чисел -> нельзя поменять строчки");
                    break;
                default:
                    exchangestrings(a, b, maxa, maxb);
                    Console.WriteLine("\nПолученная 1 матрица:");
                    matrixout(a);
                    Console.WriteLine("Полученная 2 матрица:");
                    matrixout(b);
                    break;
            }
            Console.WriteLine("\n Задание 27\n Используются полученные матрицы с предыдущего задания (нумерация начинается с 1)");
            changestrings(a);
            changestrings(b);
            Console.WriteLine("Измененная 1 матрица:");
            matrixout(a);
            Console.WriteLine("Измененная 2 матрица:");
            matrixout(b);

            double A, B;
            Console.Write(" \n Задание 28\n Введите область определения для функций y=f1(x) и y=f2(x) [A,B]\n A = ");
            inputdouble(out A);
            Console.Write(" B = ");
            inputdouble(out B);
            Console.Write("Сгененерированная таблица:");
            //double[,] tab = new double[3, (int)(Math.Abs(A - B) + 1)];
            double[,] tab = { { 1, 2, 3, 4, 5 }, { 1, 1, 3, 3, 9 }, { 9, 9, 7, 7, -1, } };
            //generate(tab, A, B);
            
            outtab(tab);
            order(tab);
            Console.WriteLine("\nУпорядочим значения аргумета по возрастанию:");
            Console.Write("  ");
            for (int j = 0; j < tab.GetLength(1); j++)
            {
                Console.Write(String.Format("{0,8}", $"x{j}"));
            }
            outtab(tab);
            string str = monall(tab);
            Console.WriteLine("а) Функция y1 и y2 " + str+ " на отрезке [A, B] соотвественно");
            mon(tab, str);

        }
    }
}
