using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab6._1._1_2_3
{
    internal class Program
    {
        struct Athlete
        {
            public string lastname;
            public string company;
            public double result1, result2;
        }
        static void inputdouble(out double x)
        {
            while ((!double.TryParse(Console.ReadLine().Replace('.', ','), out x) || (x <= 0)))
                Console.Write("Упс! Некорректные данные. Попробуте ещё раз: ");
        }
        static void inputint(out int x)
        {
            while ((!int.TryParse(Console.ReadLine().Replace('.', ','), out x) || (x <= 0)))
                Console.Write("Упс! Некорректные данные. Попробуте ещё раз: ");
        }
        static void outstruct(Athlete[] x)
        {
            Console.WriteLine($"{"№",3} " + $"{"Фамилия",12}" + $"{"Общество",12}" + $"{"Попытка№1",12}" + $"{"Попытка№2",12}");
            for (int i = 0; i < x.Length; i++)
                Console.WriteLine($"{i + 1,3})" + $"{x[i].lastname,12}" + $"{x[i].company,12}" + $"{x[i].result1,12}" + $"{x[i].result2,12}" + $"{(x[i].result2 + x[i].result1) / 2,12}");
        }
        static void order(Athlete[] x)
        {
            for (int i = 0; i < x.Length; i++)
                for (int j = i + 1; j < x.Length; j++)
                    if ((x[i].result1 + x[i].result2) / 2 < (x[j].result1 + x[j].result2) / 2)
                    {
                        string s = x[i].lastname;
                        x[i].lastname = x[j].lastname;
                        x[j].lastname = s;
                        s = x[i].company;
                        x[i].company = x[j].company;
                        x[j].company = s;
                        double c = x[i].result1;
                        x[i].result1 = x[j].result1;
                        x[j].result1 = c;
                        c = x[i].result2;
                        x[i].result2 = x[j].result2;
                        x[j].result2 = c;
                    }
        }
        struct cross
        {
            public string name;
            public string group;
            public string teacher;
            public double time;

        }
        static void outresult(cross[] x)
        {

            Console.WriteLine($"{"№",3} " + $"{"Фамилия",12}" + $"{"Группа",12}" + $"{"Учитель",12}" + $"{"Результат",12}");
            for (int i = 0; i < x.Length; i++)
                Console.WriteLine($"{i + 1,3})" + $"{x[i].name,12}" + $"{x[i].group,12}" + $"{x[i].teacher,12}" + $"{x[i].time,12}");
        }
        static void orderrun(cross[] x)
        {
            for (int i = 0; i < x.Length; i++)
                for (int j = i + 1; j < x.Length; j++)
                    if (x[i].time > x[j].time)
                    {
                        string s = x[i].name;
                        x[i].name = x[j].name;
                        x[j].name = s;
                        s = x[i].group;
                        x[i].group = x[j].group;
                        x[j].group = s;
                        s= x[i].teacher;
                        x[i].teacher = x[j].teacher;
                        x[j].teacher = s;
                        double c = x[i].time;
                        x[i].time = x[j].time;
                        x[j].time = c;
                    }
        }
        static int count(cross[] x)
        {
            int k=0;
            for (int i = 0; i < x.Length; i++)
                if (x[i].time < 2)
                    k =+ 1;
                return k;
        }
        struct comp
        {
            public string name;
            public double count;
        }
        static int makestruct(string[] x, comp[] y, int n)
        {
            int k;
            int l = 0;
            for (int i = 0; i < n; i++)
            {
                k = 1;
                for (int j = i + 1; j < n; j++)
                    if (x[i] == x[j])
                    {
                        k++;
                    } 
                bool f= true;
                for (int j = 0; j < n; j++)
                    if (y[j].name == x[i])
                        f = false;
                if (f==true)
                {
                    y[l].name = x[i];
                    y[l].count = k * 100 / n;
                    l++;
                }
            }
            return l;
        }
        static void orderper(comp[] x, int m)
        {
            {
                for (int i = 0; i < m; i++)
                    for (int j = i + 1; j < m; j++)
                        if (x[i].count < x[j].count)
                        {
                            string s = x[i].name;
                            x[i].name = x[j].name;
                            x[j].name = s;
                            double c = x[i].count;
                            x[i].count = x[j].count;
                            x[j].count = c;
                        }
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Лабораторная работа№6. Сложность 1\nЗадание 1\n Введите кол-во участников: ");
            int n;
            inputint(out n);
            //Athlete[] athlete = new Athlete[n];
            Athlete[] athlete = new Athlete[3];
            athlete[0].lastname = "Потапова";
            athlete[0].company = "группа";
            athlete[0].result1 = 1;
            athlete[0].result2 = 6;
            athlete[1].lastname = "Краснов";
            athlete[1].company = "группа";
            athlete[1].result1 = 6;
            athlete[1].result2 = 9;
            athlete[2].lastname = "Сергеевич";
            athlete[2].company = "класс";
            athlete[2].result1 = 10;
            athlete[2].result2 = 3;
            //for (int i = 0; i < athlete.Length; i++)
            //{
            //    Console.Write($"{i + 1})Введите фамилию спортсмена: ");
            //    athlete[i].lastname = Console.ReadLine();
            //    Console.Write("  Введите общество спортсмена: ");
            //    athlete[i].company = Console.ReadLine();
            //    Console.Write("  Введите длину 1-го прыжка спортсмена в м: ");
            //    inputdouble(out athlete[i].result1);
            //    Console.Write("  Введите длину 2-го прыжка спортсмена в м: ");
            //    inputdouble(out athlete[i].result2);
            //}
            Console.WriteLine(" Введённые данные:");
            outstruct(athlete);
            Console.WriteLine(" Протокол в порядке занятых мест(по среднему результату): ");
            order(athlete);
            outstruct(athlete);

            Console.Write("Задание 2\n Введите кол-во участников: ");
            inputint(out n);
            //cross[] run = new cross[n];
            cross[] run = new cross[3];
            run[0].name = "Маша";
            run[0].group = "Дятель";
            run[0].teacher = "Константин";
            run[0].time = 1.5;
            run[1].name = "Максим";
            run[1].group = "Липрикон";
            run[1].teacher = "Физрук";
            run[1].time = 3;
            run[2].name = "Александр";
            run[2].group = "бывший";
            run[2].teacher = "Лиллипут";
            run[2].time = 2.5;

            //for (int i = 0; i < run.Length; i++)
            //{
            //    Console.Write($"{i + 1})Введите фамилию: ");
            //    run[i].name = Console.ReadLine();
            //    Console.Write("  Введите группу: ");
            //    run[i].group = Console.ReadLine();
            //    Console.Write("  Введите учителя: ");
            //    run[i].teacher = Console.ReadLine();
            //    Console.Write("  Введите результат в мин: ");
            //    inputdouble(out run[i].time);
            //}
            Console.WriteLine(" Введённые результаты:");
            outresult(run);
            Console.WriteLine(" Протокол по результатам: ");
            orderrun(run);
            outresult(run);
            Console.WriteLine(" Сдавшим нормативом считаются те, кто пробежал менее чем за 2.5 мин. Кол-во сдавших {0}",count(run));
            Console.WriteLine("\nЗадание 3\n Введите ответы через Enter на: Кого вы считаете человеком года? для окончания введите 'end'");
            string[] s=new string [100];
            n = 0;
            do
            {
                s[n] = Console.ReadLine();
                n = n + 1;
            }
            while (s[n - 1] != "end");
            comp[] per = new comp[n];
            int m=makestruct(s, per, n);
            Console.WriteLine(" Данные:\n"+$"{"Имя",12}" +$"{ "Процент",12}");
            Console.WriteLine(m);
            for(int i=0; i < m; i++)
            {
                Console.WriteLine($"{per[i].name,12}"+ $"{per[i].count,12}");
            }
            Console.WriteLine(" Пять наиболее часто встречающихся:\n" + $"{"Имя",12}" + $"{"Процент",12}");
            orderper(per,m);
            if (m<=5)
                for (int i = 0; i < m; i++)
                    Console.WriteLine($"{per[i].name,12}" + $"{per[i].count,12}");
            else
                for (int i = 0; i < 5; i++)
                    Console.WriteLine($"{per[i].name,12}" + $"{per[i].count,12}");
        }
    }
}
