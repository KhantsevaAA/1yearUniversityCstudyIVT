using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_7_._1._2_3
{

    internal class Program
    {
        static void check(string y, out double x)
        {
            if ((!double.TryParse(y, out x)) || (x<0))
            {
                Console.Write("  Упс! Некорректные данные. Попобуйте ещё раз: ");
                while (!double.TryParse(Console.ReadLine().Replace(".", ","), out x) || (x < 0))
                    Console.Write("  Упс! Некорректные данные. Попобуйте ещё раз: ");
            }
        }
        static void sort1(jump[] x, int y){
            for (int i = 0; i < y; i++)
                for (int j=i+1; j < y; j++)
                    if (x[i].result+ x[i].result2<= x[j].result + x[j].result2)
                    {
                        jump c = x[i];
                        x[i] = x[j];
                        x[j] = c;
                    }
        }
        static void sort2(cross[] x, int y)
        {
            for (int i = 0; i < y; i++)
                for (int j = i + 1; j < y; j++)
                    if (x[i].result  >= x[j].result )
                    {
                        cross c = x[i];
                        x[i] = x[j];
                        x[j] = c;
                    }
        }
        static string nl( string s)
        {
            string x=s;
            while (x.Length == 0)
            {
                Console.Write("Вы велли пустое значение! Повторите: ");
                x = Console.ReadLine();
            }
            return x;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа №7. Сложность 1\n Ограничение: не более 30 участников. Введите данные через Enter, для окончания ввода введите 'end'.\n" +
                "Если ввод данных участника не завершён и введёте 'end', то программа потребует продолжить ввод.\n"+ "\n\nЗадание 2. Соревнований по прыжкам в длину (попытки в метрах)");
            jump[] play1 = new jump[30];

            int sum = 0;
            string x;
            bool f = true;
            do
            {
                switch (sum%4)
                {
                    case 0:
                        Console.Write($"{sum/4+1})Введите фамилию участника: ");
                        break;
                    case 1:
                        Console.Write(" Введите общество: ");
                        break;
                    case 2:
                        Console.Write(" Введите 1-ю попытку: ");
                        break;
                    case 3:
                        Console.Write(" Введите 2-ю попытку: ");
                        break;

                }
                x = Console.ReadLine();
                if ((sum % 4 == 0) && (x=="end"))
                    f = false;
                else
                {
                    if (x == "end")
                    {
                        Console.Write("  Вы ввели не все данные участника! Продолжите ввод! Ещё раз: ");
                        x = Console.ReadLine();
                    }
                    if (sum % 4 == 0)
                        play1[sum / 4] = new jump();
                    switch (sum % 4)
                    {
                        case 0:
                            
                            play1[sum / 4].lastname = nl(x);
                            break;
                        case 1:
                            
                            play1[sum / 4].company = nl(x);
                            break;
                        case 2:
                            check(x, out play1[sum / 4].result);
                            break;
                        case 3:
                            check(x, out play1[sum / 4].result2);
                            break;

                    }
                }
                sum = sum + 1;

            }
            while ((f == true) && (sum/4<30));
            sum = sum / 4;

            Console.WriteLine("\nИзначальная таблица:\n"+$"{"Участник",12}" + $"{"Общество",12}" + $"{"Попытка№1",12}" + $"{"Попытка№2",12}");
            for (int i = 0; i < sum; i++)
                Console.WriteLine($"{play1[i].lastname,12}" + $"{play1[i].company,12}" + $"{play1[i].result,12}" + $"{play1[i].result2,12}");// + $"{(x[i].result2 + x[i].result1) / 2,12}");
            sort1(play1, sum);
            Console.WriteLine("\nОтсортированная таблица:\n" + $"{"Участник",12}" + $"{"Общество",12}" + $"{"Попытка№1",12}" + $"{"Попытка№2",12}");
            for (int i = 0; i < sum; i++)
                Console.WriteLine($"{play1[i].lastname,12}" + $"{play1[i].company,12}" + $"{play1[i].result,12}" + $"{play1[i].result2,12}");// + $"{(play1[i].result + play1[i].result2) / 2,12}");

            Console.WriteLine("\n\nЗадание 3. Соревнования кросса 500м для женщин (результат в мин)");
            sum = 0;
            f = true;
            cross[] play2 = new cross[30];
            do
            {
                switch (sum % 4)
                {
                    case 0:
                        Console.Write($"{sum/4+1})Введите фамилию участницы: ");
                        break;
                    case 1:
                        Console.Write(" Введите группу: ");
                        break;
                    case 2:
                        Console.Write(" Введите фамилию учителя: ");
                        break;
                    case 3:
                        Console.Write(" Введите результат: ");
                        break;

                }
                x = Console.ReadLine();
                if ((sum % 4 == 0) && (x == "end"))
                    f = false;
                else
                {
                    if (x == "end")
                    {
                        Console.Write("  Вы ввели не все данные участника! Продолжите ввод! Ещё раз: ");
                        x = Console.ReadLine();
                    }
                    if (sum % 4 == 0)
                        play2[sum / 4] = new cross();
                    switch (sum % 4)
                    {
                        case 0:
                            play2[sum / 4].lastname = nl(x);
                            break;
                        case 1:
                            play2[sum / 4].group = nl(x); 
                            break;
                        case 2:
                            play2[sum / 4].teacher = nl(x);
                            break;
                        case 3:
                            check(x, out play2[sum / 4].result);
                            break;

                    }
                }
                sum = sum + 1;

            }
            while ((f == true) && (sum / 4 < 30));
            sum = sum / 4;
            sort2(play2, sum);
            Console.WriteLine("\nИзначальная таблица:\n" + $"{"Участник",12}" + $"{"Группа",12}" + $"{"Учителя",12}" + $"{"Результат",12}");
            for (int i = 0; i < sum; i++)
                Console.WriteLine($"{play2[i].lastname,12}" + $"{play2[i].group,12}" + $"{play2[i].teacher,12}" + $"{play2[i].result,12}");// + $"{(x[i].result2 + x[i].result1) / 2,12}");
            sort1(play1, sum);
            Console.WriteLine("\nОтсортированная таблица (зачёт при выполнении норматива меньше чем за 2 минуты):\n" + $"{"Участник",12}" + $"{"Группа",12}" + $"{"Учителя",12}" + $"{"Результат",12}" + $"{"Сдал",12}");
            for (int i = 0; i < sum; i++)
            {
                string r;
                if (play2[i].result <= 2)
                    r = "зачёт";
                else
                    r = "незачёт";
                Console.WriteLine($"{play2[i].lastname,12}" + $"{play2[i].group,12}" + $"{play2[i].teacher,12}" + $"{play2[i].result,12}"+ $"{r,12}");

            }
        }
    }
    

    class competitor
    {
        public string lastname;
    }
    class jump : competitor
    {
        public string company;
        public double result;
        public double result2;
    }
    class cross : competitor
    {
        public string group;
        public double result;
        public string teacher;
    }
}
