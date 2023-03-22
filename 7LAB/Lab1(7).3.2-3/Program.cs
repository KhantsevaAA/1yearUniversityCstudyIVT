using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Versioning;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab1_7_._3._2_3
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа №6. Сложность 3\n Задание 2\n" +
                " Команды и кол-во из победы на 1-м этапе:");
            footbal[] play = new footbal[12];
            Console.WriteLine($"{"Команда",12}" + $"{" Кол-во побед",6}");
            for (int i = 0; i < play.Length; i++)
            {
                play[i] = new footbal();
                Thread.Sleep(1);
                play[i].results(i);
                Console.WriteLine($"{play[i].team,12}" + $"{play[i].win,6}");
            }
            play = play.OrderByDescending(p => p.win).ToArray();
            Console.WriteLine($"Участники второго этапы:\n" + $"{"Команда",12}" + $"{" Кол-во побед",6}");
            for (int i = 0; i < 6; i++)
                Console.WriteLine($"{play[i].team,12}" + $"{play[i].win,6}");

            Console.WriteLine("\nЗадание 3\n" + $"{"Игрок",12}" + $"{"Место",6}" + $"{"Ком.",6}");
            competition[] pl = new competition[18];
            Random rand = new Random((int)DateTime.Now.Ticks);
            for (int i = 0; i < pl.Length; i++)
            {
                pl[i] = new competition();
                pl[i].name = $"Учас{i}тник";
                bool f;
                do
                {
                    f = true;
                    pl[i].place = rand.Next(1, 18 + 1);
                    for (int j = 0; j < i; j++)
                        if (pl[i].place == pl[j].place)
                            f = false;
                } while (f == false);
                do
                {
                    f = true;
                    int n = 0;
                    pl[i].team = rand.Next(1, 4);
                    for (int j = 0; j < i; j++)
                        if (pl[i].team == pl[j].team)
                            n++;
                    if (n > 6)
                        f = false;
                } while (f == false);
                Console.WriteLine($"{pl[i].name,12}" + $"{pl[i].place,6}" + $"{pl[i].team,6}");
            }

            int r1 = 0, r2 = 0, r3 = 0;
            for (int i = 0; i < pl.Length; i++)
                if (pl[i].place <= 5)
                    switch (pl[i].team)
                    {
                        case 1:
                            r1 += (6 - pl[i].place);
                            break;
                        case 2:
                            r2 += (6 - pl[i].place);
                            break;
                        case 3:
                            r3 += (6 - pl[i].place);
                            break;
                    }
            int place1 = 0;
            Console.WriteLine($"Баллы команды№1: {r1}, команды№2: {r2}, команды№3: {r3}");
            for (int i = 0; i < pl.Length; i++)
                if (pl[i].place == 1)
                    place1 = pl[i].team;

            if ((r1 == r2) && (r1 == r3))
                Console.WriteLine($"Равные баллы у всех трёх команд => Команда-победитель с первым местом{place1}");
            else
            {
                int[] n = { r1, r2, r3 };
                Console.Write($"Победителем является команда№");
                if (((r1 == r2) && (r1 > r3)) || ((r2 == r3) && (r2 > r1)) || ((r1 == r3) && (r1 > r2)))
                    Console.Write(place1);
                else
                {
                    if (n.Max() == r1)
                        Console.Write(1);
                    else
                    {
                        if (n.Max() == r2)
                            Console.Write(2);
                        else
                        {
                            if (n.Max() == r3)
                                Console.Write(3);
                        }
                    }
                }
                Console.WriteLine($", набравшая {n.Max()} баллов");
            }
        }
        class footbal
        {
            public string team;
            public int win;
            public void results(int n)
            {
                Random rand = new Random((int)DateTime.Now.Ticks);
                team = $"Ком{n}анда";
                win = rand.Next(1, 7);
            }
        }
        class competition
        {
            public string name;
            public int place;
            public int team;
        }
    }
}
