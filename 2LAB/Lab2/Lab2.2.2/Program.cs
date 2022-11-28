using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2._2._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n,s=0;
            double r,a,b;
            Console.Write("Лабораторная работа№2. Сложность 2-го уровня\nЗадание 2\nВведите коодинаты центра окружности (a,b). Введите a: ");
            
            while (!double.TryParse(Console.ReadLine().Replace('.', ','), out a))
                Console.Write(" Упс!Введенно некорректное значение a.Попробуйте ещё раз: ");
            Console.Write("Введите b: ");
            while (!double.TryParse(Console.ReadLine().Replace('.', ','), out b))
                Console.Write(" Упс!Введенно некорректное значение b.Попробуйте ещё раз: ");
            Console.Write("Введите радиус окружности r положительный и отличный от нуля: ");
            while ((!double.TryParse(Console.ReadLine().Replace('.', ','), out r)) || r<=0)
                Console.Write(" Упс!Введенно некорректное значение r.Попробуйте ещё раз: ");
            Console.Write("Введите кол-во точек n: ");
            while (!int.TryParse(Console.ReadLine().Replace('.', ','), out n) || (n < 0))
                Console.Write(" Упс!Введенно некорректное значение n.Попробуйте ещё раз: ");
            double[] x = new double[n], y = new double[n];
            double vx,vy;
            if (n == 0)
                Console.WriteLine("Ответ: Вы указали ноль точек. => Ни одной точки нет внутри указанной окружности");
            else
            {
                Console.WriteLine("Введите координаты точек через. Сначало x потом y через Enter: ");
                for (int i = 0; i < n; i++)
                {
                    Console.Write("x{0}=", i);
                    while (!double.TryParse(Console.ReadLine().Replace('.', ','), out vx))
                        Console.Write(" Упс!Введенно некорректное значение x.Попробуйте ещё раз: ");
                    Console.Write("y{0}=", i);
                    while (!double.TryParse(Console.ReadLine().Replace('.', ','), out vy))
                        Console.Write(" Упс!Введенно некорректное значение y.Попробуйте ещё раз: ");
                    if (Math.Pow(vx - a, 2) + Math.Pow(vy - b, 2) <= Math.Pow(r, 2)) {
                        x[s] = vx;
                        y[s] = vy;
                        s = s + 1;
                    }
                }
                Console.WriteLine("Ответ: {0} точек из {1} попадают в круг окружности с координатами:", s,n);
                for (int i = 0; i < s; i++)
                    Console.WriteLine(" ({0};{1})", x[i], y[i]);
            }
        }
    }
}
