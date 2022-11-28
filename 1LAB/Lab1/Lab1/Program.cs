using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)  
        {
            Console.WriteLine("Лабораторная работа№1\n\nСложность 1-го уровня\n Задание№8");
            int s=0,x;
            for (int i = 1; i < 7; i++)
            {
                x = 1;
                for (int j = 1; j < i + 1; j++)
                    x = x * j;
                s = s + x;
            }
            Console.WriteLine("  Ответ: s={0}\n Задание№9", s);
            double sf = 0;
            for(int i = 1; i < 7; i++)
            {
                x = 1;
                for (int j = 1; j < i + 1; j++)
                    x = x * j;
                sf = sf + Math.Pow((-5),i)/x;
            }
            Console.WriteLine("  Ответ: s={0:f5}\n Задание№10 ",sf);
            s = 1;
            for (int i = 0; i < 7; i++)
                s = s * 3;
            Console.WriteLine("  Ответ: s={0:d}\n\nСложность 2-го уровня", s);
            x = 10; s = 0;
            while (x < 100000)
            {
                s = s + 3;
                x = x * 2;
            }
            Console.WriteLine(" Задание№6\n  Ответ: за {0} часа",s);
            sf = 0; double xf = 10;
            for (int i = 0; i < 7; i++)
            {
                sf = sf + xf;
                xf=xf*1.1;
            }
            Console.Write(" Задание№7\n  Ответ: a){0:f5} км;", sf);
            sf = 0; x = 0; 
            while(sf<=100)
            {
                x = x + 1;
                sf = sf +10*Math.Pow(1.1,x);
            }
            Console.Write(" б)через {0:d} дн ({1:f5} км);", x,sf);
            s = 0; xf = 10;
            while (xf<=20)
            {
                s = s + 1;
                xf = xf * 1.1;
            }
            Console.WriteLine(" в)через {0:d} дн ({1:f5} км);", s,xf);
            sf = 100000; x = 0;
            s = (int)sf * 2;
            while (sf <= s)
            {
                x = x + 1;
                sf = sf * 1.08;
            }
            Console.WriteLine(" Задание№8\n  Ответ: через {0:d} мес ({1:f5} руб);\n\nСложность 3-го уровня\n Задание№8", x,sf);
            for (double i = 0.1; i <=1.05; i = i + 0.05)
            {
                xf = 1;sf = 1;x = 1;
                while (!(xf < 0.0001))
                {
                    xf=xf*2*i/x;
                    sf = sf + xf;
                    x++;
                }
                xf = Math.Exp(2 * i);
                Console.WriteLine("   при x={0} y={1:f6}, s={2:f6};", i,xf,sf);
            }
            Console.WriteLine(" Задание№9");
            for (double i = 0.1; i <= 0.5; i = i + 0.05)
            {
                sf = 0; x = 0;
                while (!(xf < 0.0001))
                {
                    xf = Math.Pow(i,2*x+1)/(2*x+1);
                    sf = sf + xf * Math.Pow((-1), x);
                    x++;
                }
                xf = Math.Atan(i);
                Console.WriteLine("   при x={0} y={1:f7}, s={2:f7};", i, xf, sf);
            }
            Console.WriteLine(" Задание№1");
            for (double i = 0.1; i <= 1; i = i + 0.1)
            {
                sf = 1; x = 1;xf = 1;
                while (!(xf < 0.0001))
                {
                    xf =i*i/( (x*2 - 1) * x*2);
                    sf = sf + Math.Pow((-1), x) *xf;
                    x++;
                }
                xf = Math.Cos(i);
                Console.WriteLine("   при x={0} y={1:f4}, s={2:f4};", i, xf, sf);
            }
        }
    }
}
