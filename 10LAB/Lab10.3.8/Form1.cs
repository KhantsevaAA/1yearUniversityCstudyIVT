using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using System.Reflection.Emit;
using System.Text.RegularExpressions;

namespace Lab10._3._8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Игра 'Карусель-лото'";
            this.SizeChanged += new EventHandler(Form1_SizeChanged);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Лабораторная работа №10. Сложность 3. Задание 8\n";
            label1.Location = new Point(10, 10);

            groupBox1.Text = "Правила:";
            groupBox1.Location = new Point(10, label1.Top + 15);
            groupBox1.Width = (this.Width - 40);

            label2.Text = "За один ход компьютер генерирует случайное целое число в интервале [0; 36]. Перед этим участники " +
                "заказывают одну комбинацию из следующих возможных (стараясь угадать число или интервал, в который число попадает):\r\n" +
                "a)\tвыпадает четное или нечетное число;\r\n" +
                "b)\tчисло попадает в интервал [1, 18] или [19, 36];\r\n" +
                "c)\tчисло попадает в одну из трех дюжин [1, 12], [13, 24], [25, 36];\r\n" +
                "d)\tчисло попадает в одну из четырех девяток: [1, 9], [10, 18], [19, 27], [28, 36];\r\n" +
                "e)\tчисло попадает в одну из шестерок: [1, 6], [7, 12], [13, 18], [19, 24], [25, 30], [31, 36];\r\n" +
                "f)\tчисло попадает в одну из троек: [1, 3], [4, 6], ..., [34, 36];\r\n" +
                "g)\tчисло попадает в одну из пар: [1, 2], [3, 4], ..., [35, 36];\r\n" +
                "h)\tвыпадет число K от 1 до 36.\r\n";
            label2.Location = new Point(groupBox1.Left, groupBox1.Top);
            label2.MaximumSize = new Size(groupBox1.Width - 10, this.Height);
            groupBox1.Controls.Add(label2);
            groupBox1.AutoSize = true;
            groupBox1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);


            groupBox2.Text = "Инструкция:";
            groupBox2.Location = new Point(10, groupBox1.Bottom + 5);
            groupBox2.Width = (this.Width - 40);

            label6.Text = "Введите целое число в строку кол-во игроков. Убедитесь, что ваш ввод принят. Выберете в списке вариант хода " +
                "(все они расписаны в правилах), затем нажмите 'сделать ход'. Высветятся кнопки, нужно догадаться какому условию, написанному на кнопке, удовлетворяет сгенерированное компьютером число." +
                "Если ваша догадка верна, то в начале нового раунда (круга ходов) счёт обновится, вам присвоятся соответствующие очки и покажется загаданное число прошлого раунда. Выигрывает игрок набравший 50 баллов.";
            label6.Location = new Point(groupBox2.Left, groupBox1.Top);
            label6.MaximumSize = new Size(groupBox2.Width - 10, this.Height);
            //while ()
            groupBox2.Controls.Add(label6);

            groupBox2.AutoSize = true;
            groupBox2.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);




            label3.Text = "Введите кол-во игроков:";
            label3.Location = new Point(groupBox2.Left, groupBox2.Bottom + 10);

            textBox1.Location = new Point(label3.Left + label3.Width + 5, groupBox2.Bottom + 10);

            button1.Text = "Начать";
            button1.Location = new Point(textBox1.Left + textBox1.Width + 5, groupBox2.Bottom + 10);

            label4.Text = "";
            label4.Location = new Point(button1.Left + button1.Width + 5, groupBox2.Bottom + 10);

            label5.Text = "";
            label5.Location = new Point(groupBox2.Left, label3.Bottom + 10);

            button2.Text = "Сделай ход игрок1";
            button2.AutoSize = true;
            button2.Location = new Point(button1.Left, groupBox2.Bottom + 50);

            string[] s = { "a", "b", "c", "d", "e", "f", "g", "h" };
            listBox1.Items.AddRange(s);
            listBox1.Location = new Point(button2.Left + button2.Width, groupBox2.Bottom + 50);
        }
        public int k = -1, n, x, z = 0;
        bool y = true;
        public int[] b;


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (k == -1)
            {
                if (!(int.TryParse(textBox1.Text, out k) || (k < 0) || (k > 10))) //кол-во игроков
                    label4.Text = "Некорректное\nзначение!";
                else
                {
                    label4.Text = "Принято!";
                    int[] bb = new int[k];
                    b = bb;
                    for (int i = 0; i < k; i++)
                        label5.Text += $"Игрок{i + 1}" + $"{b[i],10}\n";
                }
            }
            x = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (k != -1 && y && listBox1.SelectedIndex!=-1)
            {

                y = false;
                int j;// dвыбор игрока
                if (x == 0)
                {
                    z++;
                    if (z>1)
                        label4.Text = $"Раунд {z}. " + "Предыдущее число "+n.ToString();
                    else
                        label4.Text = $"Раунд {z}";
                    Random r = new Random();
                    n = r.Next(0, 36 + 1);
                }
                j = listBox1.SelectedIndex;
                switch (j)
                {
                    case 0:
                        var1();
                        break;
                    case 1:
                        var2();
                        break;
                    default:
                        var3(j);
                        break;
                }
            }
        }

        void rr()
        {
            if (x == k - 1)
            {
                x = 0;
                outresults();
            }
            else
            {
                if (b[x] >= 50)
                {
                    k = -1;
                    x = 0;
                    label5.Text = "";
                    label4.Text = "";
                    textBox1.Text = "";
                    Array.Clear(b, 0, b.Length);
                    MessageBox.Show($"!ВЫИГРАЛ ИГРОК{x}!\nиграперезапущена", "Игра закончена");
                }
                else
                x++;
            }
            y = true;
            button2.Text = $"Сделай ход игрок{x + 1}";
        }
        void outresults()
        {
            label5.Text = "";
            for (int i = 0; i < k; i++)
                label5.Text += $"Игрок{i + 1}" + $"{b[i],10}\n";
        }
        private void Form1_SizeChanged(object sender, System.EventArgs e)
        {
            label2.MaximumSize = new Size(groupBox1.Width - 10, this.Height);
        }
        void var1()
        {
            System.Windows.Forms.Button bt1 = new System.Windows.Forms.Button();
            System.Windows.Forms.Button bt2 = new System.Windows.Forms.Button();
            bt1.Text = "Чётное";
            bt2.Text = "Нечётное";

            bt1.Location = new Point(button2.Left, listBox1.Bottom);
            bt1.Size = new Size((listBox1.Width + button2.Width) / 2, 30);

            bt2.Location = new Point(button2.Left + bt1.Width, listBox1.Bottom);
            bt2.Size = new Size((listBox1.Width + button2.Width) / 2, 30);

            Controls.Add(bt1);
            Controls.Add(bt2);
            bt1.Click += new System.EventHandler(bt1_Click);
            bt2.Click += new System.EventHandler(bt2_Click);

            void bt1_Click(object sender, EventArgs e)
            {
                if (n % 2 == 0)
                    b[x] += 1;
                rr();
                delete();
            }
            void bt2_Click(object sender, EventArgs e)
            {
                if (n % 2 != 0)
                    b[x] += 1;
                delete();
                rr();
            }
            void delete()
            {
                bt1.Click -= new System.EventHandler(bt1_Click);
                Controls.Remove(bt1);
                bt1.Dispose();

                bt2.Click -= new System.EventHandler(bt2_Click);
                Controls.Remove(bt2);
                bt2.Dispose();



            }

        }
        void var2()
        {
            System.Windows.Forms.Button bt1 = new System.Windows.Forms.Button();
            System.Windows.Forms.Button bt2 = new System.Windows.Forms.Button();
            bt1.Text = "[1, 18]";
            bt2.Text = "[19, 36]";

            bt1.Location = new Point(button2.Left, listBox1.Bottom);
            bt1.Size = new Size((listBox1.Width + button2.Width) / 2, 30);

            bt2.Location = new Point(button2.Left + bt1.Width, listBox1.Bottom);
            bt2.Size = new Size((listBox1.Width + button2.Width) / 2, 30);

            Controls.Add(bt1);
            Controls.Add(bt2);
            bt1.Click += new System.EventHandler(bt1_Click);
            bt2.Click += new System.EventHandler(bt2_Click);

            void bt1_Click(object sender, EventArgs e)
            {
                if (n >= 1 && n <= 18)
                    b[x] += 1;
                rr();
                delete();
            }
            void bt2_Click(object sender, EventArgs e)
            {
                if (n >= 19 && n <= 36)
                    b[x] += 1;
                delete();
                rr();
            }
            void delete()
            {
                bt1.Click -= new System.EventHandler(bt1_Click);
                Controls.Remove(bt1);
                bt1.Dispose();

                bt2.Click -= new System.EventHandler(bt2_Click);
                Controls.Remove(bt2);
                bt2.Dispose();
            }

        }
        void var3(int j)
        {

            switch (j)
            {
                case 2:
                    j = 12;
                    break;
                case 3:
                    j = 9;
                    break;
                case 4:
                    j = 6;
                    break;
                case 5:
                    j = 3;
                    break;
                case 6:
                    j = 2;
                    break;
                case 7:
                    j = 1;
                    break;
            }
            System.Windows.Forms.Button[] bt = new System.Windows.Forms.Button[36 / j];

            bt[0] = new System.Windows.Forms.Button();
            int s = Math.Max(label5.Bottom, listBox1.Bottom);
            bt[0].Location = new Point(0, s);
            if (36 / j < 6)
                s = (this.Width - 10) / (36 / j);
            else
                s = (this.Width - 10) / 6;
            bt[0].Size = new Size(s, 25);


            for (int i = 0; i < bt.Length; i++)
            {
                if (i != 0)
                {
                    bt[i] = new System.Windows.Forms.Button();
                    bt[i].Size = bt[0].Size;
                    if (i % 6 == 0 && (36 / j >= 6))
                        bt[i].Location = new Point(0, bt[i - 1].Bottom);
                    else
                        bt[i].Location = new Point(bt[i - 1].Left + s, bt[i - 1].Top);
                }
                if (j != 1)
                    bt[i].Text = $"[{j * i + 1},{j * (1 + i)}]";
                else
                    bt[i].Text = (i + 1).ToString();
                Controls.Add(bt[i]);
                bt[i].Click += new System.EventHandler(bt_Click);
            }

            void bt_Click(object sender, EventArgs e)
            {
                string msg = ((System.Windows.Forms.Button)sender).Text;
                int t;
                int.TryParse(string.Join("", msg.Where(c => char.IsDigit(c))), out t);
                if (msg.Length != 1 && msg.Length != 2)
                {
                    if (msg.Length == 5)
                        t = t / 10;
                    else
                        t = t / 100;
                }
                if (((n >= t) && (n <= (t + j - 1)) && (j != 1)) || ((j == 1) && (t == n)))
                {
                    int i = 0;
                    switch (j)
                    {
                        case 12:
                            i = 2;
                            break;
                        case 9:
                            i = 3;
                            break;
                        case 6:
                            i = 5;
                            break;
                        case 3:
                            i = 11;
                            break;
                        case 2:
                            i = 17;
                            break;
                        case 1:
                            i = 35;
                            break;
                    }
                    b[x] += i;
                }
                for (int i = 0; i < bt.Length; i++)
                {
                    bt[i].Click -= new System.EventHandler(bt_Click);
                    Controls.Remove(bt[i]);
                    bt[i].Dispose();
                }
                rr();
            }
        }

    }
}
