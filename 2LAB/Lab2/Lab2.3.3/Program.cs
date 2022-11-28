using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2._2._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n, s = 0;
            double x=0;
            string str;
            bool f = true;
            Console.WriteLine("Введите через Enter вес учеников 1-го класса. Для окончания ввода введите цифру слово 'end':");
            while(f==true)
            {
                str = Console.ReadLine();
                if (str == "end") f = false;
                else
                {
                    while ((!double.TryParse(str.Replace('.', ','), out x) || (x <= 0)))
                    {
                        Console.WriteLine("Упс! Введенно некорректное значение.Попробуйте ещё раз ('end' уже не принимает): : ");
                        str = Console.ReadLine();
                    }
                        if (x < 30)
                        s = s + 1;
                }
            }
            if (x == 0)
                Console.WriteLine("Вы сразу ввели 'end'");
            else
                Console.WriteLine("Ответ: для 1-го класса нужно {0} мл молока в стаканах по 200мл для {1} учеников", s * 200, s);
        }
    }
}
