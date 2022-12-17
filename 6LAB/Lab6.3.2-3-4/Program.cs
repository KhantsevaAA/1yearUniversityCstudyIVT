using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab6._3._2_3_4
{
    internal class Program
    {
        struct team
        {
            public string name;
            public int win;
        }
        static void order(team[] x)
        {
            for (int i = 0; i < x.Length; i++)
                for (int j = 0; j < x.Length; j++)
                    if (x[i].win > x[j].win)
                    {
                        int c = x[i].win;
                        x[i].win = x[j].win;
                        x[j].win = c;
                        string s = x[i].name;
                        x[i].name = x[j].name;
                        x[j].name = s;
                    }
        }
        struct competitor
        {
            public string name;
            public int place;
            public int team;
        }
        static void points(competitor[] c, ref int x, ref int y, ref int z)
        {
            for (int i = 0; i < c.Length; i++)
                switch (c[i].team)
                {
                    case 1:
                        if (c[i].place < 6)
                            x += 6 - c[i].place;
                        break;
                    case 2:
                        if (c[i].place < 6)
                            y += 6 - c[i].place;
                        break;
                    case 3:
                        if (c[i].place < 6)
                            z += 6 - c[i].place;
                        break;
                }
        }
        struct skis
        {
            public string name;
            public double time;
            // public int place;
        }
        static void skiorder(skis[] x)
        {
            for (int i = 0; i < x.Length; i++)
                for (int j = i + 1; j < x.Length; j++)
                    if (x[i].time > x[j].time)
                    {
                        double c = x[i].time;
                        x[i].time = x[j].time;
                        x[j].time = c;
                        string s = x[i].name;
                        x[i].name = x[j].name;
                        x[j].name = s;
                    }
        }
        static void allorder(skis[] x, int[] y)
        {
            for (int i = 0; i < x.Length; i++)
                for (int j = i + 1; j < x.Length; j++)
                    if (x[i].time > x[j].time)
                    {
                        double c = x[i].time;
                        x[i].time = x[j].time;
                        x[j].time = c;
                        string s = x[i].name;
                        x[i].name = x[j].name;
                        x[j].name = s;
                        int n = y[i];
                        y[i] = y[j];
                        y[j] = n;
                    }
        }
        static void outr(skis[] x)
        {
            for (int i = 0; i < x.Length; i++)
                Console.WriteLine($"{x[i].name,15}" + $"{x[i].time,12}");
        }
        static void Main(string[] args)
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            Console.WriteLine("Лабораторная работа №6. Сложность 3\n Задание 2\n Команды и кол-во из победы на 1-м этапе:");
            team[] teams = new team[12];
            Console.WriteLine($"{"Команда",12}" + $"{" Кол-во побед",6}");
            for (int i = 0; i < teams.Length; i++)
            {
                teams[i].name = $"Команда{i + 1}";
                teams[i].win = rand.Next(1, 7);
                Console.WriteLine($"{teams[i].name,12}" + $"{teams[i].win,6}");
            }
            order(teams);
            Console.WriteLine("\n Участники второго этапа:\n" + $"{"Команда",12}" + $"{" Кол-во побед",6}");
            for (int i = 0; i < 6; i++)
                Console.WriteLine($"{teams[i].name,12}" + $"{teams[i].win,6}");

            Console.WriteLine("\nЗадание 3");
            competitor[] com = new competitor[18];
            int place1 = 0;
            Console.WriteLine($"{"Игрок",12}" + $"{"Место",6}" + $"{"Ком.",6}");
            for (int i = 0; i < com.Length; i++)
            {
                com[i].name = $"Участник{i + 1}";
                bool f;
                do
                {
                    f = true;
                    com[i].place = rand.Next(1, 18 + 1);
                    for (int j = 0; j < i; j++)
                        if (com[i].place == com[j].place)
                            f = false;
                } while (f == false);
                if (com[i].place == 1)
                    place1 = com[i].team;
                com[i].team = i % 3 + 1;
                Console.WriteLine($"{com[i].name,12}" + $"{com[i].place,6}" + $"{com[i].team,6}");
            }
            int r1 = 0, r2 = 0, r3 = 0;
            points(com, ref r1, ref r2, ref r3);
            Console.WriteLine($"Баллы команды№1: {r1}, команды№2: {r2}, команды№3: {r3}");
            if ((r1 == r2) && (r2 == r3))
                Console.Write("Ничья => победителя нет");
            else
            {
                int[] n = { r1, r2, r3 };
                Console.WriteLine($"Победителем является команда№");
                if (((r1 == r2) && (r1 > r3)) || ((r2 == r3) && (r2 > r1)) || ((r1 == r3) && (r1 > r2)))
                    Console.Write(place1);
                else
                {
                    if (n.Max() == r1)
                        Console.Write(1);
                    if (n.Max() == r2)
                        Console.Write(2);
                    if (n.Max() == r3)
                        Console.Write(3);

                }
                Console.WriteLine($", набравшая {n.Max()} баллов");
            }
            Console.WriteLine("\nЗадание 4");
            skis[] team1 = new skis[15];
            skis[] team2 = new skis[15];
            Console.WriteLine($"{"Группа1",15}" + $"{"Результаты",12}" + $"{"Группа2",15}" + $"{"Результаты",12}");
            for (int i = 0; i < team1.Length; i++)
            {
                team1[i].time = rand.Next(10000, 20000) * 0.001;
                team2[i].time = rand.Next(10000, 20000) * 0.001;
                team1[i].name = $"Участник-1.{i + 1}";
                team2[i].name = $"Участник-2.{i + 1}";
                Console.WriteLine($"{team1[i].name,15}" + $"{team1[i].time,12}" + $"{team2[i].name,15}" + $"{team2[i].time,12}");
            }
            Console.WriteLine("\n Первая группа в порядке увеличения времени:");
            skiorder(team1);
            outr(team1);
            Console.WriteLine("\n Вторая группа в порядке увеличения времени:");
            skiorder(team2);
            outr(team2);
            Console.WriteLine($" Сводная таблица в порядке занятых мест:\n" + $"{"Участник",15}" + $"{"Результаты",12}" + $"{"Группа",7}");
            skis[] result = new skis[team1.Length + team2.Length];
            int[] group = new int[team1.Length + team2.Length];
            for (int i = 0; i < 15; i++)
            {
                result[i].name = team1[i].name;
                result[i].time = team1[i].time;
                result[i + team1.Length].name = team2[i].name;
                result[i + team1.Length].time = team2[i].time;
                group[i] = 1;
                group[i + team1.Length] = 2;
                //Console.WriteLine($"{result[i].name,15}"+$"{result[i].time,12}"+"\n" +$"{result[i + team1.Length].name,15}"+$" {result[i + team1.Length].time,12}");
            }
            allorder(result, group);
            for (int i = 0; i < result.Length; i++)
                Console.WriteLine($"{result[i].name,15}" + $"{result[i].time,12}" + $"{group[i],4}");
        }
    }
}
