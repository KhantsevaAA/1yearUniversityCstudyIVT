using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab10._2._1_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Лабораторная работа№10. Сложность 2";
            label2.Text = "Задание 1\ny=2sinx+sin(2x); a=-pi, b=pi, n=50\nМаштаб: 20:1";
            label3.Text = "Задание 2\ny=xsinx; a=0, b=3pi, n=20\nМаштаб: 15:1";
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.TranslateTransform(150, 150); // смешение оси кординат
            g.DrawLine(new Pen(Color.Brown, 1.0f), -130, 0, 130, 0); //ось x
            g.DrawLine(new Pen(Color.Brown, 1.0f), 0, -120, 0, 130); //ось y

            double a = -Math.PI, b = Math.PI, n = 50, j = (b - a) / n, x = a, y;
            double c = a, d = 2 * Math.Sin(c) + Math.Sin(2 * c);//координаты предыдущей точки
            do
            {
                y = 2 * Math.Sin(x) + Math.Sin(2 * x);
                g.DrawEllipse(new Pen(Color.Blue, 2.0f), (int)(x * 40), -(int)(y * 40), 1, 1);
                g.DrawLine(new Pen(Color.Aquamarine, 0.5f), (int)(c * 40), -(int)(d * 40), (int)(x * 40), -(int)(y * 40));
                c = x; d = y;
                x = x + j; //<--это
            } while (x <= b);

            g.TranslateTransform(200, 0); // смешение оси кординат
            g.DrawLine(new Pen(Color.Brown, 1.0f), -40, 0, 190, 0); //ось x
            g.DrawLine(new Pen(Color.Brown, 1.0f), 0, -130, 0, 130); //ось y

            a = 0;
            b = 3 * Math.PI;
            n = 20;
            j = (b - a) / n;
            c = a;d = c * Math.Sin(c);
            for (x = a; x <= b; x += j)
            {
                y = x * Math.Sin(x);
                g.DrawEllipse(new Pen(Color.Blue, 2.0f), (int)(x * 15), -(int)(y * 15), 1, 1);
                g.DrawLine(new Pen(Color.Aquamarine, 0.5f), (int)(c * 15), -(int)(d * 15), (int)(x * 15), -(int)(y * 15));
                c = x; d = y;
            }

        }
    }
}
