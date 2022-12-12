using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6._2._8_9_1
{
    internal class Program
    {
        struct hockey
        {
            public string name;
            public int r1;
            public int r2;
            public int r3;
        }
        static int candidate(hockey[] x)
        {
            int n = 0;
            for (int i = 0; i < x.Length; i++)
                if (x[i].r1 == 10 || x[i].r2 == 10 || x[i].r3 == 10)
                {
                    x[i].r1 = 10;
                    x[i].r2 = 10;
                    x[i].r3 = 10;

                }

            for (int i = 0; i < x.Length; i++)
            {
                for (int j = i + 1; j < x.Length; j++)
                    if (x[i].r1 + x[i].r2 + x[i].r3 > x[j].r1 + x[j].r2 + x[j].r3)
                    {
                        string s = x[i].name;
                        x[i].name = x[j].name;
                        x[j].name = s;

                        int c;
                        c = x[i].r1;
                        x[i].r1 = x[j].r1;
                        x[j].r1 = c;

                        c = x[i].r2;
                        x[i].r2 = x[j].r2;
                        x[j].r2 = c;

                        c = x[i].r3;
                        x[i].r3 = x[j].r3;
                        x[j].r3 = c;
                    }
            }
            while ((n < x.Length) && (x[n].r1 != 10) && (x[n].r3 != 10) && (x[n].r3 != 10))
                n++;
            return n;
        }
        struct grades
        {
            public double r1;
            public double r2;
            public double r3;
            public double r4;
            public double r5;
            public double r6;
            public double r7;
            public string name;
        }

        static void sort(double[,] z, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                    if (z[i, 1] < z[j, 1])
                    {
                        double c;
                        c = z[i, 0];
                        z[i, 0] = z[j, 0];
                        z[j, 0] = c;

                        c = z[i, 1];
                        z[i, 1] = z[j, 1];
                        z[j, 1] = c;
                    }
            }
        }
        static void place(grades[] x, int[] y)
        {
            double[,] z = new double[y.Length, 2];
            for (int i = 0; i < y.Length; i++)
            {
                z[i, 0] = i;
                z[i, 1] = x[i].r1;
                y[i] = 0;
            }
            sort(z, y.Length);
            for (int i = 0; i < y.Length; i++)
                y[(int)z[i, 0]] += (i + 1);

            for (int i = 0; i < y.Length; i++)
            {
                z[i, 0] = i;
                z[i, 1] = x[i].r2;
            }
            sort(z, y.Length);
            for (int i = 0; i < y.Length; i++)
                y[(int)z[i, 0]] += (i + 1);

            for (int i = 0; i < y.Length; i++)
            {
                z[i, 0] = i;
                z[i, 1] = x[i].r3;
            }
            sort(z, y.Length);
            for (int i = 0; i < y.Length; i++)
                y[(int)z[i, 0]] += (i + 1);

            for (int i = 0; i < y.Length; i++)
            {
                z[i, 0] = i;
                z[i, 1] = x[i].r4;
            }
            sort(z, y.Length);
            for (int i = 0; i < y.Length; i++)
                y[(int)z[i, 0]] += (i + 1);

            for (int i = 0; i < y.Length; i++)
            {
                z[i, 0] = i;
                z[i, 1] = x[i].r5;
            }
            sort(z, y.Length);
            for (int i = 0; i < y.Length; i++)
                y[(int)z[i, 0]] += (i + 1);

            for (int i = 0; i < y.Length; i++)
            {
                z[i, 0] = i;
                z[i, 1] = x[i].r6;
            }
            sort(z, y.Length);
            for (int i = 0; i < y.Length; i++)
                y[(int)z[i, 0]] += (i + 1);

            for (int i = 0; i < y.Length; i++)
            {
                z[i, 0] = i;
                z[i, 1] = x[i].r7;
            }
            sort(z, y.Length);
            for (int i = 0; i < y.Length; i++)
                y[(int)z[i, 0]] += (i + 1);

        }
        struct student
        {
            public string name;
            public int g1;
            public int g2;
            public int g3;
            public int g4;
        }
        static int success(student[] x)
        {
            int n = 0;
            for (int i = 0; i < x.Length; i++)
                for (int j = 0; j < x.Length; j++)
                    if (x[i].g1 + x[i].g2 + x[i].g3 + x[i].g4 > x[j].g1 + x[j].g2 + x[j].g3 + x[j].g4)
                    {
                        int c;
                        c = x[i].g1;
                        x[i].g1 = x[j].g1;
                        x[j].g1 = c;

                        c = x[i].g2;
                        x[i].g2 = x[j].g2;
                        x[j].g2 = c;

                        c = x[i].g3;
                        x[i].g3 = x[j].g3;
                        x[j].g3 = c;

                        c = x[i].g4;
                        x[i].g4 = x[j].g4;
                        x[j].g4 = c;

                        string s = x[i].name;
                        x[i].name = x[j].name;
                        x[j].name = s;
                    }
            while (((x[n].g1 + x[n].g2 + x[n].g3 + x[n].g4) / 4 >= 4) && (n < x.Length))
                n++;
            return n;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа№6. Сложность 2\nЗадание 8");
            Console.WriteLine(" Полный список кандидатов:");
            hockey[] team = new hockey[30];
            int[] time = new int[] { 0, 2, 5, 10 };
            Random rand = new Random((int)DateTime.Now.Ticks);
            //Random rand = new Random();
            Console.WriteLine($"{"Фамилия",12}" + $"{"#1",3}" + $"{"#2",3}" + $"{"#3",3}");
            for (int i = 0; i < team.Length; i++)
            {
                team[i].name = $"Хок{i}кеист";
                team[i].r1 = time[rand.Next(3)];
                team[i].r2 = time[rand.Next(time.Length)];
                team[i].r3 = time[rand.Next(time.Length)];
                Console.WriteLine($"{team[i].name,12}" + $"{team[i].r1,3}" + $"{team[i].r2,3}" + $"{team[i].r3,3}");
            }
            Console.WriteLine("\n Урезанный список кандидатов:");
            Console.WriteLine($"{"№",3}" + $"{"Фамилия",12}" + $"{"#1",3}" + $"{"#2",3}" + $"{"#3",3}");
            int n = candidate(team);
            for (int i = 0; i < n; i++)
                Console.WriteLine($"{i + 1,3}" + $"{team[i].name,12}" + $"{team[i].r1,3}" + $"{team[i].r2,3}" + $"{team[i].r3,3}");

            Console.WriteLine("\nЗадание 9\n Обычный список участников:");
            Console.WriteLine($"{"Фамилия",12}" + $"{"#1",6}" + $"{"#2",6}" + $"{"#3",6}" + $"{"#4",6}" +
                    $"{"#5",6}" + $"{"#6",6}" + $"{"#7",6}");
            grades[] skate = new grades[15];

            int[] sum = new int[skate.Length];
            for (int i = 0; i < skate.Length; i++)
            {
                skate[i].name = $"Фигу{i}рист";
                skate[i].r1 = rand.Next(0, 60 + 1) * 0.1;
                skate[i].r2 = rand.Next(0, 60 + 1) * 0.1;
                skate[i].r3 = rand.Next(0, 60 + 1) * 0.1;
                skate[i].r4 = rand.Next(0, 60 + 1) * 0.1;
                skate[i].r5 = rand.Next(0, 60 + 1) * 0.1;
                skate[i].r6 = rand.Next(0, 60 + 1) * 0.1;
                skate[i].r7 = rand.Next(0, 60 + 1) * 0.1;
            }
            place(skate, sum);

            for (int i = 0; i < skate.Length; i++)
            {
                Console.WriteLine($"{skate[i].name,12}" + $"{skate[i].r1,6}" + $"{skate[i].r2,6}" + $"{skate[i].r3,6}" +
                    $"{skate[i].r4,6}" + $"{skate[i].r5,6}" + $"{skate[i].r6,6}" + $"{skate[i].r7,6}" + $"{sum[i],6}");
            }

            for (int i = 0; i < skate.Length; i++)
                for (int j = i + 1; j < skate.Length; j++)
                    if (sum[i] > sum[j])
                    {
                        int z = sum[i];
                        sum[i] = sum[j];
                        sum[j] = z;

                        string s = skate[i].name;
                        skate[i].name = skate[j].name;
                        skate[j].name = s;

                        double c;
                        c = skate[i].r1;
                        skate[i].r1 = skate[j].r1;
                        skate[j].r1 = c;

                        c = skate[i].r2;
                        skate[i].r2 = skate[j].r2;
                        skate[j].r2 = c;

                        c = skate[i].r3;
                        skate[i].r3 = skate[j].r3;
                        skate[j].r3 = c;

                        c = skate[i].r4;
                        skate[i].r4 = skate[j].r4;
                        skate[j].r4 = c;

                        c = skate[i].r5;
                        skate[i].r5 = skate[j].r5;
                        skate[j].r5 = c;

                        c = skate[i].r6;
                        skate[i].r6 = skate[j].r6;
                        skate[j].r6 = c;

                        c = skate[i].r7;
                        skate[i].r7 = skate[j].r7;
                        skate[j].r7 = c;

                    }
            Console.WriteLine("\n Сортированный список участников:");
            Console.WriteLine($"{"Место",5}" + $"{"Фамилия",12}" + $"{"#1",6}" + $"{"#2",6}" + $"{"#3",6}" + $"{"#4",6}" +
                    $"{"#5",6}" + $"{"#6",6}" + $"{"#7",6}" + $"Cумма мест участников");
            for (int i = 0; i < skate.Length; i++)
            {
                Console.WriteLine($"{i + 1,5}" + $"{skate[i].name,12}" + $"{skate[i].r1,6}" + $"{skate[i].r2,6}" + $"{skate[i].r3,6}" +
                    $"{skate[i].r4,6}" + $"{skate[i].r5,6}" + $"{skate[i].r6,6}" + $"{skate[i].r7,6}" + $"{sum[i],6}");
            }

            Console.WriteLine("\nЗадание 1\n Список студентов:");
            student[] per = new student[30];
            for (int i = 0; i < per.Length; i++)
            {
                per[i].name = $"Cтуд{i}ент";
                per[i].g1 = rand.Next(3, 5 + 1);
                per[i].g2 = rand.Next(4, 5 + 1);
                per[i].g3 = rand.Next(2, 5 + 1);
                per[i].g4 = rand.Next(1, 5 + 1);
                Console.WriteLine($"{per[i].name,12}" + $"{per[i].g1,4}" + $"{per[i].g2,4}" + $"{per[i].g3,4}" + $"{per[i].g4,4}");
            }
            Console.WriteLine("\n Список в порядке убывания среднего балла:");
            n = success(per);
            for (int i = 0; i < n; i++)
                Console.WriteLine($"{i+1,3}" + $"{per[i].name,12}" + $"{per[i].g1,4}" + $"{per[i].g2,4}" + $"{per[i].g3,4}" + $"{per[i].g4,4}");

        }
    }
}
