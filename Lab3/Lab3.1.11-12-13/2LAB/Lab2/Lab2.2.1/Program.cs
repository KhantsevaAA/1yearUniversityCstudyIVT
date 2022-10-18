using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2._2._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            double x,s=0;
            Console.Write("Лабораторная работа№2. Сложность 2-го уровня\n Задание 1\n Введите кол-во учеников: ");
            while ((!int.TryParse(Console.ReadLine().Replace('.', ','), out n)) || (n <= 0))
                Console.Write(" Упс!Введенно некорректное значение.Попробуйте ещё раз: ");
            Console.WriteLine(" Введите рост учеников через Enter в см");
            for (int i = 0; i < n; i++)
            {
                while ((!double.TryParse(Console.ReadLine().Replace('.', ','), out x) || (x<=0)))
                    Console.Write(" Упс!Введенно некорректное значение.Попробуйте ещё раз: ");
                s = s + x;
            }
            s= s / n;
            Console.WriteLine("Ответ: средний рост девочек и мальчиков в класса {0}", s);
        }
    }
}
