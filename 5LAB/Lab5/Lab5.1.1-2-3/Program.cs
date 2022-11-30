using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5._1._1_2_3
{
    internal class Program
    {
        static int factorial(int m)
        {
            if (m == 1)
                return 1;
            else
                return m * factorial(m - 1);
        }
        static double C(int k, int n)
        {
            Console.Write($" Способа отобора команды в составе {k} человек из {n} кандидатов: ");
            return factorial(n)/(factorial(k)*factorial(n-k));
        }
        static void input(out double x)
        {
            while((!double.TryParse(Console.ReadLine().Replace('.',','), out x)) || (x<=0))
                Console.Write(" Упс!Некорретное значение.\n Попробуйте ещё раз: ");

        }
        static double geron(double a, double b, double c)
        {
            double s,p;
            p = (a + b + c) / 2;
            s = Math.Sqrt(p * Math.Abs(p - a) * Math.Abs(p - b) * Math.Abs(p - c));
            return s;
        }
        static double s(double v, double a, int t)
        {
            return v * t + a * Math.Pow(t,2) / 2;
        }
        static double? time(double v1, double a1, double v2, double a2)
        {
            double a = a1 - a2; 
            double v = v1 - v2;
            double d,t1,t2;
            d = 4 * (Math.Pow(v,2) - a);
            if (d != 0)
            {
                t1 = (-2) * v - Math.Sqrt(d);
                t2 = (-2) * v + Math.Sqrt(d);
                switch ((t1, t2))
                {
                    case (>0,> 0):
                        return Math.Min(t1, t2);
                        break;
                    case (>0,<0):
                        return t1;
                        break;
                    case ( < 0, > 0):
                        return t2;
                        break;
                    default:
                        return null;
                }
            }
            else
                return null;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа №5. Сложность 1\nЗадание 1");
            int team=5, candidate = 8;
            Console.WriteLine(C(team, candidate));
            candidate = 10;
            Console.WriteLine(C(team, candidate));
            candidate = 11;
            Console.WriteLine(C(team, candidate));
            
            Console.Write("Задание 2\n Введите параметры треугольника№1.\n a = ");
            double a1, b1, c1, a2, b2, c2;
            input(out a1);
            Console.Write(" b = ");
            input(out b1);
            Console.Write(" c = ");
            input(out c1);
            Console.Write(" Введите параметры треугольника№2.\n a = ");
            input(out a2);
            Console.Write(" b = ");
            input(out b2);
            Console.Write(" c = ");
            input(out c2);
            if (geron(a1, b1, c1) > geron(a2, b2, c2))
                Console.WriteLine($" Большая полощадь у треугольника№1 s1={geron(a1, b1, c1)}");
            else
                Console.WriteLine($" Большая полощадь у треугольника№2 s2={geron(a2, b2, c2)}");
            a1 = 1; a2 = 1.6; b1 = 10; b2 = 9;
            Console.Write($"\nЗадание2.\n Дано: v1={b1}, a1={a1}, v2={b2}, a2={a2}.\n a)Большее расстояние за 1 ч преодолеет");
            if (s(b1, a1, 1) > s(b2, a2, 1))
                Console.WriteLine($"первый велосипедист s1={s(b1, a1, 1) }");
            else
                Console.WriteLine($"второй велосипедист s1={s(b2, a2, 1) }");
            Console.Write("   Большее расстояние за 4 ч преодолеет ");
            if (s(b1, a1, 4 )> s(b2, a2, 4))
                Console.WriteLine($"первый велосипедист s1={s(b1, a1, 4) }");
            else
                Console.WriteLine($"второй велосипедист s1={s(b2, a2, 4) }");
            double? x;
            x = time(b1, a1, b2, a2);
            if (x == null)
                Console.WriteLine(" Второй спортсмен не догонит первого");
            else
                Console.WriteLine($" Второй спортсмен догонит первого через {x:f5} часа");
        }
    }
}
