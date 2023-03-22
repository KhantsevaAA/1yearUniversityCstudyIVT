using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab10._1._1_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Лабораторная работа №10. Сложность 1\nЗадание 1\nВведиете значения a и b. Через Enter программа не примет значения,\n" +
                "нажмите кнопку 'Загрузить'. Строка состояния отобразит корректность значения\n" +
                "(программа принимает вещественные числа). Для того,чтобы получить\n получить вычисления нажмите 'Вычислить'.\n" +
                "При изменении любых значение надо повторно нажимать кнопки.";
            label2.Text = "Состояние";
            label3.Text = "Введите значение a:";
            label5.Text = "Введите значение b:";
            label4.Text = "???";
            label6.Text = "???";
            button1.Text = "Загрузить";
            button2.Text = "Загрузить";
            label7.Text = "c=a+b";
            button3.Text = "Вычислить";
            
            label8.Text = "Задание 2\nВведите число n:\n(натуральное)";
            button4.Text = "Загрузить";
            label9.Text = "???";
            label10.Text = "Сумма 1-х n чисел:";
            button5.Text = "Вычислить";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            indouble(textBox1, label4);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            indouble(textBox2, label6);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double c,d=0;
            if ((!double.TryParse(textBox1.Text.Replace(".", ","), out c)) || (!double.TryParse(textBox2.Text.Replace(".", ","), out d)))
                textBox3.Text = "Упс!";
            else
                textBox3.Text = (c + d).ToString();
        }
        public void indouble(TextBox x, Label y)
        {
            double z;
            if (!double.TryParse(x.Text.Replace(".", ","), out z))
                y.Text = "Некорректное\nзначение!";
            else
                y.Text = "Принято!";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int n;
            if (!int.TryParse(textBox4.Text.Replace(".", ","), out n)||(n<=0))
                label9.Text = "Некорректное\nзначение!";
            else
                label9.Text = "Принято!";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int n;
            if (!int.TryParse(textBox4.Text.Replace(".", ","), out n) || (n <= 0))
                textBox5.Text = "Упс!";
            else
                textBox5.Text = result(n).ToString();
        }
        public int result(int x) 
        {
            int y = 0;
            if (x == 1)
                y += 1;
            else
                y+=(x+result(x-1));
            return y;
        }
    }
}
