using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Лабораторная работа №3 во 2 семестре. Крестики-нолики";
            label1.Text = "Игрок 1: O";
            label1.Location = new Point(10, 10);
            label1.Font = new Font("T-FLEX Type A", 11);
            label2.Font = label1.Font;
            //label1.Font = new Font("Malgun Gothic", 11);
            label2.Text = "Игрок 2: X";
            label2.Top = label1.Top;
            label2.Left = this.ClientRectangle.Width - label1.Left - label2.Width;
            label3.Text = "Счёт\n 0:0";
            label3.Top = label1.Top;
            label3.Location = new Point((this.ClientRectangle.Width - label3.Width) / 2, label1.Top);
            label3.Font = label1.Font;
            Array.Clear(p, 0, 9);
            button1.Text = "Сбросить счёт";
            button1.Size = new Size(90, 30);
            button2.Size = button1.Size;
            button2.Text = "Новая игра";
            button1.Font= label1.Font;
            button2.Font= label1.Font;
        }
        private void Form1_Resize(object sender, EventArgs e)
        {

            label2.Top = label1.Top;
            label2.Left = this.Width - label1.Left - label2.Width - 20;
            label3.Left = (this.Width - 10 - label3.Width) / 2;
            l = (label2.Left - label1.Width / 2 - label1.Right) / 2;
            button1.Location = new Point(label1.Left, label3.Bottom + l * 2 + button1.Height);
            button2.Location = new Point(this.ClientRectangle.Width - label1.Left - button2.Width, button1.Top);

        }
        int l = 0, k = 0;
        int[,] p = new int[3, 3];
        private void button1_Click(object sender, EventArgs e)
        {
            label3.Text = "Счёт\n 0:0";
            Array.Clear(p, 0, 9);
            this.Invalidate();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Array.Clear(p, 0, 9);
            this.Invalidate();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            l = (label2.Left - label1.Width / 2 - label1.Right) / 2;
            this.Height = label3.Bottom * 3 + l * 2 + 3 / 2 * button1.Height;
            g.TranslateTransform(this.ClientRectangle.Width / 2, label3.Bottom + l); // смешение оси кординат

            g.DrawLine(new Pen(Color.Black, 1.0f), -l, l / 3, l, l / 3);
            g.DrawLine(new Pen(Color.Black, 1.0f), -l, -l / 3, l, -l / 3);

            g.DrawLine(new Pen(Color.Black, 1.0f), -l / 3, -l, -l / 3, l);
            g.DrawLine(new Pen(Color.Black, 1.0f), l / 3, -l, l / 3, l);

            //g.DrawLine(new Pen(Color.Green, 2.0f), 0, 0, 0, 50); //ось -y
            //g.DrawLine(new Pen(Color.Blue, 2.0f), 0, 0, 50, 0); //ось x
            //g.DrawEllipse(new Pen(Color.Red, 1.0f), -5, 5, 10, -10); //центр
            
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X, y = e.Y, dx = this.ClientRectangle.Width / 2 - l, dy = label3.Bottom;
            int ll = (l * 2) / 3;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if ((x >= dx + ll * i) && (x <= dx + ll * (i + 1)) && (y >= dy + ll * j) && (y <= dy + ll * (j + 1)))
                    {

                      // richTextBox1.Text = i + ", " + j + "\n" + richTextBox1.Text;
                        if (p[i, j] == 0)
                        {
                            if (k % 2 == 0)
                            {
                                nol(i, j);
                                p[i, j] = -1;
                            }
                            else
                            {
                                krest(i, j);
                                p[i, j] = 1;
                            }
                            k++;
                        }
                        if (k >= 4)
                            win();

                        break;
                    }

        }
        void nol(int x, int y)
        {
            int n = l * 2 / 3;
            x--; y--;
            Graphics g = this.CreateGraphics();
            g.TranslateTransform(this.ClientRectangle.Width / 2 - l / 3 + 5, label3.Bottom + l * 2 / 3 + 5); // смешение оси кординат
            g.DrawEllipse(new Pen(Color.Red, 1.0f), x * n, y * n + 2, n - 10, n - 10);
        }
        void krest(int x, int y)
        {
            int n = l * 2 / 3;
            x--; y--;
            Graphics g = this.CreateGraphics();
            g.TranslateTransform(this.ClientRectangle.Width / 2 - l / 3, label3.Bottom + l * 2 / 3); // смешение оси кординат
            g.DrawLine(new Pen(Color.Blue, 1.0f), x * n + 10, y * n + 10, n * (x + 1) - 10, n * (y + 1) - 10);
            g.DrawLine(new Pen(Color.Blue, 1.0f), x * n + 10, n * (y + 1) - 10, n * (x + 1) - 10, y * n + 10);
        }
        void win()
        {
            bool fs = false, fc = false;
            int x = -1;
            for (int i = 0; i < 3; i++)
            {
                if ((p[i, 0] == p[i, 1]) && (p[i, 0] == p[i, 2] && (p[i, 0] != 0)))
                {
                    fc = true;
                    x = i;
                }
                else if ((p[0, i] == p[1, i]) && (p[0, i] == p[2, i]) && (p[0, i] != 0))
                {
                    fs = true;
                    x = i;
                }
            }
            if ((fs == false) && (fc == false))
            {
                if ((p[1, 1] != 0) && (p[0, 0] == p[2, 2]) && (p[0, 0] == p[1, 1]))
                    fc = true;
                else if ((p[0, 2] == p[2, 0]) && (p[0, 2] == p[1, 1]) && (p[1, 1] != 0))
                    fs = true;
            }
            if ((fs == true) || (fc == true))
            {
                
                Graphics g = this.CreateGraphics();
                g.TranslateTransform(this.ClientRectangle.Width / 2, label3.Bottom + l); // смешение оси кординат
                int ll = 2 * l / 3;
                if (x >= 0)
                {
                    x -= 1;
                    switch (fc, fs)
                    {
                        case (true, false):
                            g.DrawLine(new Pen(Color.LimeGreen, 3.0f), x * ll, ll, x * ll, -ll);
                            break;
                        case (false, true):
                            g.DrawLine(new Pen(Color.LimeGreen, 3.0f), -ll, ll * x, ll, ll * x);
                            break;
                    }
                }
                else
                {
                    switch (fc, fs)
                    {
                        case (true, false):
                            g.DrawLine(new Pen(Color.LimeGreen, 3.0f), -ll, -ll, ll, ll);
                            break;
                        case (false, true):
                            g.DrawLine(new Pen(Color.LimeGreen, 3.0f), -ll, ll, ll, -ll);
                            break;
                    }
                }
                string s = label3.Text;
                s.Split(':');
                string[] words = s.Split(new char[] { ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);
                //label3.Text = words[0] + ":" + words[1] + ":" + words[2];
                if (k % 2 != 0)
                {
                    label3.Text = words[0] +" "+ (int.Parse(words[1]) + 1) + ":" + words[2];
                    MessageBox.Show("Игрок 1 выиграл!", "Партия закончена");
                }
                else
                {
                    label3.Text = words[0] +" "+ words[1] + ":" + (int.Parse(words[2]) + 1);
                    MessageBox.Show("Игрок 2 выиграл!", "Партия закончена");
                }
            }
            else
            {
                bool f = true;
                for  (int i= 0; i < 3; i++)
                for  (int j= 0; j < 3; j++)
                {
                        if (p[i, j] == 0)
                        {
                            f = false;
                            break;
                        }
                }
                if (f == true)
                {
                    MessageBox.Show("!Ничья!", "Партия закончена");
                }
            }

        }
    }
}
