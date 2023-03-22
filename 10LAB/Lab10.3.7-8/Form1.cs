using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Lab10._3._7_8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Игра 'Набери сумму'";


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.Text = "Игра 'Набкри сумму'";
            label1.Text = "Лабораторная работа №10. Сложность 3. Задание 7\n";

            // MessageBox.Show(
            //groupBox1.AutoSize = true;
            groupBox1.Text = "Правила:\n";


            label2.Text = "Нужно набрать Заданную сумму. За ход игрок может получить случайное число из диапозона," +
                " что суммируется с имеющимися числами, пропустить ход - ничего не получить. " +
                "Если у игрока больше числа, сумму которого надо набрать, он автоматически проигрывает. При завершении игры досрочно выигрывает игрок, " +
                "у которого меньше и ближе к нужному числу или совпадает с нужным числом";
            groupBox1.Size = new Size(this.Width - 50, (int)(label2.Text.Length * 100 / (this.Width - 50)) + 10);
            label2.MaximumSize = new Size(groupBox1.Width - 5, groupBox1.Height);
            groupBox1.Controls.Add(label2);

            //groupBox1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            groupBox2.Location = new Point(groupBox1.Left, groupBox1.Top + groupBox1.Height);
            groupBox2.Text = "Инструкция:\n";
            label3.Text = "Задайте диапозон и сумму, которуб нужно набрать. После нажатия кнопки 'Начать игру' бедитесь, что ввод принят Все три числа должны быть целыми. Одна кнопка для обоих игроков.";
            groupBox2.Size = new Size(this.Width - 50, (int)(label3.Text.Length * 150 / (this.Width - 50)) + 10);
            label3.MaximumSize = new Size(groupBox2.Width - 7, groupBox2.Height);
            groupBox2.Controls.Add(label3);

            groupBox3.Text = "Диапозон";
            groupBox3.Size = new Size(this.Width / 2 - 30, 50);
            groupBox3.Location = new Point(groupBox1.Left, groupBox2.Top + groupBox2.Height);

            groupBox4.Text = "Сумма";
            groupBox4.Size = new Size(groupBox3.Width, groupBox3.Height);
            groupBox4.Location = new Point(groupBox1.Right - groupBox3.Width, groupBox3.Top);


            label4.Text = "от";
            textBox1.Location = new Point(groupBox1.Left + label4.Width, label4.Top);
            label5.Text = "до";
            label5.Location = new Point(textBox1.Left + textBox1.Width, label4.Top);
            textBox2.Location = new Point(textBox1.Left + textBox1.Width + label5.Width, label4.Top);

            groupBox3.Controls.Add(textBox1);
            groupBox3.Controls.Add(textBox2);
            groupBox4.Controls.Add(textBox3);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(label5);
            button1.Text = "Начать игру";
            label6.Text = "";
            button1.Location = new Point(groupBox1.Left, groupBox3.Top + groupBox3.Height + 5);
            label6.Location = new Point(groupBox4.Left, button1.Top+5);
            groupBox5.Text = "Счёт:";
            groupBox5.Size = new Size(this.Width - 50, 80);
            groupBox5.Location = new Point(groupBox1.Left, button1.Top + button1.Height + 5);
            label7.Text = "Игрок 1";
            //label7.Location = new Point(groupBox1.Left, groupBox5. + 100);
            label8.Text = "Игрок 2";
            label8.Location = new Point(label7.Left, label7.Top + 30);
            label9.Text = "0";
            label9.Location = new Point(this.Width - 90, label7.Top);
            label10.Text = "0";
            label10.Location = new Point(label9.Left, label8.Top);
            groupBox5.Controls.Add(label7);
            groupBox5.Controls.Add(label8);
            groupBox5.Controls.Add(label9);
            groupBox5.Controls.Add(label10);
            button2.Text = "Сделать ход";
            button2.Size = button1.Size;
            button2.Location = new Point(groupBox1.Left, groupBox5.Top + groupBox5.Height + 5);
            button3.Text = "Пропустить ход";
            button3.Size= button2.Size;
            button3.Location = new Point(this.Width / 2 - button3.Width/2-3, button2.Top);
            button4.Text = "Завершить игру";
            button4.Size = new Size(button3.Width,(int)(button3.Height*1.5));
            button4.Location = new Point(this.Width - button3.Width-33, button2.Top);

        }
        public static int n1, n2 , n3, ord = 0,s1,s2;

        private void button4_Click(object sender, EventArgs e)
        {
            if (s1 == s2)
                MessageBox.Show("Ничья", "Итог");
            if (s1>s2)
                MessageBox.Show("Игрок 1 выиграл!", "Итог");
            else
                MessageBox.Show("Игрок 2 выиграл!", "Итог");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ord++;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text.Replace(".", ","), out n1) || !int.TryParse(textBox2.Text.Replace(".", ","), out n2) ||
                !int.TryParse(textBox3.Text.Replace(".", ","), out n3) || n3 <= 0 || n2 - n1 <= 0)
                label6.Text = "!Ошибка в вводе!";
            else
                label6.Text = "Ввод принят";
            s1 = 0; s2 = 0;
            label9.Text = s1.ToString();
            label10.Text = s2.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            if (ord % 2 == 0)
                s1 += rand.Next(n1, n2 + 1);
            else
                s2 += rand.Next(n1, n2 + 1);
            label9.Text = s1.ToString();
            label10.Text = s2.ToString();
            ord++;
            if (s1 > n3 || s2 > n3)
            {
                if (s1>n3)
                    MessageBox.Show("Игрок 1 проиграл!", "Итог");
                else
                    MessageBox.Show("Игрок 2 проиграл!", "Итог");
            }
            else
            {
                if(n3==s1)
                    MessageBox.Show("Игрок 1 выиграл!", "Итог");
                else if(n3==s2)
                    MessageBox.Show("Игрок 2 выиграл!", "Итог");

            }
        }
    }
}
