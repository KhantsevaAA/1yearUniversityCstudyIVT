
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2._3._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 0, s = 0, max = 100; ;
            double r, a, b;
            bool f = false;
            Console.Write("Лабораторная работа№2. Сложность 2-го уровня\nЗадание 2\nВведите коодинаты центра окружности (a,b). ВВедите a: ");

            while (!double.TryParse(Console.ReadLine().Replace('.', ','), out a))
                Console.Write(" Упс!Введенно некорректное значение a.Попробуйте ещё раз: ");
            Console.Write("Введите b: ");
            while (!double.TryParse(Console.ReadLine().Replace('.', ','), out b))
                Console.Write(" Упс!Введенно некорректное значение b.Попробуйте ещё раз: ");
            Console.Write("Введите радиус окружности r положительный и отличный от нуля: ");
            while ((!double.TryParse(Console.ReadLine().Replace('.', ','), out r)) || r <=0)
                Console.Write(" Упс!Введенно некорректное значение r.Попробуйте ещё раз: ");
            Console.WriteLine("Введите не более {0} координат точек. Сначала x потом y через Enter. Для окончания введите слово end. При некорректом " +
                "вводе точек прекратить ввод словом 'end' нельзя: ",max);
            string str = null;
            double[] x = new double[max], y = new double[max];
            do
            {
                if (n % 2 == 0)
                    Console.WriteLine("ВВедите x{0}:", (int)n / 2);
                else
                    Console.WriteLine("ВВедите y{0}:", (int)((n - 1) / 2));
                str = Console.ReadLine();
                if (str == "end")
                    if (n % 2 != 0)
                    {
                       while (!double.TryParse(str.Replace('.', ','), out x[(int)n / 2]))
                       {
                            Console.Write("Надо ввести координату y{0} и ввод координат точек прекратится:", (int)(n - 1) / 2);
                            str = Console.ReadLine();
                       }
                        f = true;
                    }
                    else
                        f = true;
                else
                {
                    if (n % 2 == 0)
                    {
                        while (!double.TryParse(str.Replace('.', ','), out x[(int)n / 2]))
                        {
                            Console.Write(" Упс!Введенно некорректное значение x{0}.Попробуйте ещё раз ('end' уже не принимает): ", (int)n / 2);
                            str = Console.ReadLine();
                        }
                    }
                    else
                    {
                        while (!double.TryParse(str.Replace('.', ','), out y[(int)(n - 1) / 2]))
                            Console.Write(" Упс!Введенно некорректное значение y{0}.Попробуйте ещё раз ('end' уже не принимает): ", (int)(n - 1) / 2);
                    }
                }
                n = n + 1;
            } while (f == false);
            n = (int)n / 2;
            
            if (n == 0)
                Console.WriteLine("Ответ: Вы указали ноль точек. => Ни одной точки нет внутри указанной окружности");
            else
            {
                for (int i = 0; i < n; i++)
                    if (Math.Pow(x[i] - a, 2) + Math.Pow(y[i] - b, 2) <= Math.Pow(r, 2))
                    {
                        x[s] = x[i];
                        y[s] = y[i];
                        s = s + 1;
                    }
                if (s==0)
                    Console.WriteLine("Ответ: ни одна из точек не входит в окружность");
                else
                {
                    Console.WriteLine("Ответ: {0} точек из {1} попадают в круг окружности с координатами:", s, n);
                    for (int i = 0; i < s; i++)
                        Console.WriteLine(" ({0},{1})", x[i], y[i]);
                }
            }
        }
    }
}
