using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double r, s;
            Console.Write("Лабораторная работа№2. Сложность 1-го уровня\n Задание 6\n Введите площадь круга r: ");

            while ((!double.TryParse(Console.ReadLine().Replace('.', ','), out r) || (r <= 0)))
            {
                Console.Write(" Упс!ВВеденно некорректное значение.Попробуйте ещё раз: ");
            }
            Console.Write(" Введите площадь квадрата s: ");
            while ((!double.TryParse(Console.ReadLine().Replace('.', ','), out s) || (s <= 0)))
            {
                Console.Write(" Упс!ВВеденно некорректное значение.Попробуйте ещё раз: ");
            }
            Console.Write(" !ВВеденные значения r={0} и s={1}\n Ответ: ",r,s);

            if (Math.Sqrt(s) / 2 >= Math.Sqrt(r) / 3.14)
                Console.WriteLine("круг поместиться в квдрате.");
            else Console.WriteLine("круг НЕ поместиться в квдрате.");
        }
    }
}
