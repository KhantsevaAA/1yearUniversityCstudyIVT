using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2._3._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n=-1;
            double x=1, s = 0;
            Console.WriteLine("Лабораторная работа№2. Сложность 3-го уровня\n Задание 1\n  Введите рост учеников через Enter в см. Чтоб закончить ввод, введите ноль");
            while (x!=0)
            {
                while ((!double.TryParse(Console.ReadLine().Replace('.', ','), out x) || (x < 0)))
                    Console.Write(" Упс!Введенно некорректное значение.Попробуйте ещё раз: ");
                s = s + x;
                n = n + 1;
            }
            s = s / n;
            Console.WriteLine("Ответ: средний рост девочек и мальчиков в класса {0}", s);
        }
    }
}
