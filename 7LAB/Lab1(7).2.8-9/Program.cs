using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab1_7_._2._8_9
{
    internal class Program
    {
        static hockey[] candidate(hockey[] x)
        {
            //hockey[] c = (hockey[])x.Clone();
            hockey[] c = new hockey[x.Length];
            Array.Copy(x, c, x.Length);
            int l = c.Length;
            for (int j = 0; j < c.Length; j++)
                if ((c[j].time1 == 10) || (c[j].time2 == 10) || (c[j].time3 == 10))
                {
                    c[j].time1 = 10;
                    c[j].time2 = 10;
                    c[j].time3 = 10;
                    l--;
                }
            for (int i = 0; i < c.Length; i++)
                for (int j = i + 1; j < c.Length; j++)
                {
                    if (c[i].time1 + c[j].time2 + c[j].time3 <= c[i].time1 + c[i].time2 + c[i].time3)
                    {
                        hockey p;
                        p = new hockey();
                        p = c[i];
                        c[i] = c[j];
                        c[j] = p;
                    }
                }
            Array.Resize(ref c, l);
            return c;
        }
        static double[,] places(skate[] x)
        {
            
            skate[] r = new skate[x.Length];
            Array.Copy(x, r, x.Length);
            double[,] l = new double[r.Length, 2];
            Array.Clear(l, 0, l.Length);

            for (int i = 0; i <r.Length; i++)
                l[i, 1] = x[i].r1;
            r = r.OrderByDescending(p => p.r1).ToArray();
            for (int i = 0; i < r.Length; i++)
                for (int j = 0; j < r.Length; j++)
                    if ( l[j,1]== r[i].r1)
                        l[j, 0] = i;    

            for (int i = 0; i < r.Length; i++)
                l[i, 1] = x[i].r2;
            r = r.OrderByDescending(p => p.r2).ToArray();
            for (int i = 0; i < r.Length; i++)
                for (int j = 0; j < r.Length; j++)
                    if (l[j, 1] == r[i].r2)
                        l[j, 0] += i;

            for (int i = 0; i < r.Length; i++)
                l[i, 1] = x[i].r3;
            r = r.OrderByDescending(p => p.r3).ToArray();
            for (int i = 0; i < r.Length; i++)
                for (int j = 0; j < r.Length; j++)
                    if (l[j, 1] == r[i].r3)
                        l[j, 0] += i;

            for (int i = 0; i < r.Length; i++)
                l[i, 1] = x[i].r4;
            r = r.OrderByDescending(p => p.r4).ToArray();
            for (int i = 0; i < r.Length; i++)
                for (int j = 0; j < r.Length; j++)
                    if (l[j, 1] == r[i].r4)
                        l[j, 0] += i;

            for (int i = 0; i < r.Length; i++)
                l[i, 1] = x[i].r5;
            r = r.OrderByDescending(p => p.r5).ToArray();
            for (int i = 0; i < r.Length; i++)
                for (int j = 0; j < r.Length; j++)
                    if (l[j, 1] == r[i].r5)
                        l[j, 0] += i;

            for (int i = 0; i < r.Length; i++)
                l[i, 1] = x[i].r6;
            r = r.OrderByDescending(p => p.r6).ToArray();
            for (int i = 0; i < r.Length; i++)
                for (int j = 0; j < r.Length; j++)
                    if (l[j, 1] == r[i].r6)
                        l[j, 0] += i;

            for (int i = 0; i < r.Length; i++)
                l[i, 1] = x[i].r7;
            r = r.OrderByDescending(p => p.r7).ToArray();
            for (int i = 0; i < r.Length; i++)
                for (int j = 0; j < r.Length; j++)
                    if (l[j, 1] == r[i].r7)
                        l[j, 0] += i;
            //for (int i = 0; i < r.Length; i++) Console.WriteLine($"{l[i, 0],-3}" + $"{l[i, 1],3}" + $"{r[i].r7,5}"); //место у мервого судьи -- обычнй список -- отсортированный
            return l;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа№. Сложность 2\n Задание 8");
            hockey[] play = new hockey[30];
            int[] time = new int[] { 0, 2, 5, 10 };
            Console.WriteLine("\nИсходная таблица:\n" + $"{"Фамилия",12}" + $"{"#1",3}" + $"{"#2",3}" + $"{"#3",3}");
            for (int i = 0; i < play.Length; i++)
            {
                Thread.Sleep(1);
                play[i] = new hockey();
                play[i].results(time, i);
                Console.WriteLine($"{play[i].player,12}" + $"{play[i].time1,3}" + $"{play[i].time2,3}" + $"{play[i].time3,3}");
            }
            hockey[] с = candidate(play);
            Console.WriteLine("\nТаблица кандидатов:\n" + $"{"Фамилия",12}" + $"{"#1",3}" + $"{"#2",3}" + $"{"#3",3}");
            for (int i = 0; i < с.Length; i++)
                Console.WriteLine($"{с[i].player,12}" + $"{с[i].time1,3}" + $"{с[i].time2,3}" + $"{с[i].time3,3}");


            Console.WriteLine("\nЗадание 9\nИсходная таблица:\n"+ $"{"Фамилия",12}" + $"{"#1",6}" + $"{"#2",6}" + $"{"#3",6}" + $"{"#4",6}" +
                    $"{"#5",6}" + $"{"#6",6}" + $"{"#7",6}");
            skate[] pl = new skate[15];
            for (int i = 0; i < pl.Length; i++)
            {
                Thread.Sleep(1);
                pl[i] = new skate();
                pl[i].results(time, i);
                Console.WriteLine($"{pl[i].name,12}" + $"{pl[i].r1,6}" + $"{pl[i].r2,6}" + $"{pl[i].r3,6}" +
                    $"{pl[i].r4,6}" + $"{pl[i].r5,6}" + $"{pl[i].r6,6}" + $"{pl[i].r7,6}");
            }
            Console.WriteLine("\n");
            double[,] s=places(pl);

            for (int i = 0; i < pl.Length; i++)
                for(int j=i+1;j<pl.Length; j++)
                    if (s[i,0] <= s[j,0])
                    {
                        double c=s[i,0];
                        s[i, 0] = s[j, 0];
                        s[j, 0] = c;
                        skate cc=pl[i];
                        pl[i] = pl[j];
                        pl[j] = cc;
                    }
            Console.WriteLine("\n Сортированный список участников:\n"+$"{"Место",5}" + $"{"Фамилия",12}" + $"{"#1",6}" + $"{"#2",6}" + $"{"#3",6}" + $"{"#4",6}" +
                    $"{"#5",6}" + $"{"#6",6}" + $"{"#7",6}" + $"Cумма мест участников");
            for (int i = 0; i < pl.Length; i++)
                Console.WriteLine($"{i+1,5}"+$"{pl[i].name,12}" + $"{pl[i].r1,6}" + $"{pl[i].r2,6}" + $"{pl[i].r3,6}" +
                    $"{pl[i].r4,6}" + $"{pl[i].r5,6}" + $"{pl[i].r6,6}" + $"{pl[i].r7,6}"+ $"{s[i,0],6}");
        }

    }
    class skate
    {
        public string name;
        public double r1;
        public double r2;
        public double r3;
        public double r4;
        public double r5;
        public double r6;
        public double r7;
        public void results(int[] v, int n)
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            name = $"Фигу{n}рист";
            r1 = rand.Next(0, 60 + 1) * 0.1;
            r2 = rand.Next(0, 60 + 1) * 0.1;
            r3 = rand.Next(0, 60 + 1) * 0.1;
            r4 = rand.Next(0, 60 + 1) * 0.1;
            r5 = rand.Next(0, 60 + 1) * 0.1;
            r6 = rand.Next(0, 60 + 1) * 0.1;
            r7 = rand.Next(0, 60 + 1) * 0.1;
        }
    }
    class hockey
    {
        public string player;
        public int time1;
        public int time2;
        public int time3;
        public void results(int[] v, int n)
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            player = $"Игр{n}ок";
            time1 = v[rand.Next(v.Length)];
            time2 = v[rand.Next(v.Length)];
            time3 = v[rand.Next(v.Length)];
        }
    }
}
