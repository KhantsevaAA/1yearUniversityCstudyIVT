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
            int n, s=0;
            double x;
            Console.WriteLine("Введите кол-во учеников в 1-м классе:");
            while (!int.TryParse(Console.ReadLine(), out n) || (n <= 0))
                Console.WriteLine("Упс! Введенно некорректное значение n.Попробуйте ещё раз: ");
            Console.WriteLine("Введите через Enter вес учеников:");
            for (int i = 0; i < n; i++)
            {
                while(!double.TryParse(Console.ReadLine().Replace('.', ','), out x) || (x<=10))
                    Console.WriteLine("Упс! Введенно некорректное значение.Попробуйте ещё раз: ");
                if (x < 30)
                    s = s + 1;
            }
            Console.WriteLine("Ответ: для 1-го класса нужно {0} мл молока в стаканах по 200мл для {1} учеников", s * 200, s);
        }
    }
}
