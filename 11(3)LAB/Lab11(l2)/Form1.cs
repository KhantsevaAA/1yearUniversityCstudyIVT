using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab11_l2_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int l = 0, k = 0;
        int[,] p = new int[10, 10];
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
            Array.Clear(p, 0, 100);
            button1.Text = "Сбросить счёт";
            button1.Size = new Size(90, 30);
            button2.Size = button1.Size;
            button2.Text = "Новая игра";
            button1.Font = label1.Font;
            button2.Font = label1.Font;
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            label2.Top = label1.Top;
            label2.Left = this.Width - label1.Left - label2.Width - 20;
            label3.Left = (this.Width - 10 - label3.Width) / 2;
            l = (label2.Left - label1.Width / 2 - label1.Right);
            l = l - l % 10;
            button1.Location = new Point(label1.Left, label3.Bottom + l + button1.Height);
            button2.Location = new Point(this.ClientRectangle.Width - label1.Left - button2.Width, button1.Top);


            //for (int i = 0; i < p.GetLength(0); i++)
            //    for (int j = 0; j < p.GetLength(0); j++)
            //    {

            //        richTextBox1.Text = i + ", " + j + "\n" + richTextBox1.Text;
            //        if (p[i, j] == -1)
            //            nol(i, j);

            //        else if (p[i, j] == 1)
            //           krest(i, j);


            //    }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            label3.Text = "Счёт\n 0:0";
            k = 0;
            Array.Clear(p, 0, 100);
            this.Invalidate();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Array.Clear(p, 0, 100);
            k = 0;
            this.Invalidate();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            this.Height = label3.Bottom * 3 + l + 3 / 2 * button1.Height;
            g.TranslateTransform(this.ClientRectangle.Width / 2, label3.Bottom + l / 2); // смешение оси кординат
            g.FillRectangle(new SolidBrush(Color.LightGray), new Rectangle(-l / 2, -l / 2, l, l));
            for (int i = -p.GetLength(0) / 2 + 1; i < p.GetLength(1) / 2; i++)
            {
                int ll = l / p.GetLength(0) * i;
                g.DrawLine(new Pen(Color.Black, 1.0f), -l / 2, ll, l / 2, ll);
                g.DrawLine(new Pen(Color.Black, 1.0f), -ll, -l / 2, -ll, l / 2);
            }
            //g.DrawLine(new Pen(Color.Green, 2.0f), 0, 0, 0, 50); //ось -y
            //g.DrawLine(new Pen(Color.Blue, 2.0f), 0, 0, 50, 0); //ось x
            g.DrawEllipse(new Pen(Color.Red, 1.0f), -5, 5, 10, -10); //центр
        }



        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X, y = e.Y, dx = this.ClientRectangle.Width / 2 - l / 2, dy = label3.Bottom;
            int ll = l / p.GetLength(0);
            for (int i = 0; i < p.GetLength(0); i++)
                for (int j = 0; j < p.GetLength(0); j++)
                    if ((x >= dx + ll * i) && (x <= dx + ll * (i + 1)) && (y >= dy + ll * j) && (y <= dy + ll * (j + 1)))
                    {

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
                        if (k >= 9)
                            win();

                        break;
                    }
        }
        void nol(int x, int y)
        {
            int n = l / p.GetLength(0);
            x -= 5; y -= 5;
            Graphics g = this.CreateGraphics();
            g.TranslateTransform(this.ClientRectangle.Width / 2, label3.Bottom + l / 2); // смешение оси кординат
            g.DrawEllipse(new Pen(Color.Red, 1.0f), x * n, y * n, n, n);
        }
        void krest(int x, int y)
        {
            int n = l / p.GetLength(0);
            x -= 5; y -= 5;
            Graphics g = this.CreateGraphics();
            g.TranslateTransform(this.ClientRectangle.Width / 2, label3.Bottom + l / 2); // смешение оси кординат
            g.DrawLine(new Pen(Color.Blue, 1.0f), x * n, y * n, n * (x + 1), n * (y + 1));
            g.DrawLine(new Pen(Color.Blue, 1.0f), x * n, n * (y + 1), n * (x + 1), y * n);
        }
        void win()
        {
            bool fs = false, fc = false, f = false;
            int x = -1, y = -1;
            for (int i = 0; i < p.GetLength(0); i++)
            {
                for (int j = 0; j < p.GetLength(0); j++)
                {
                    fs = false; fc = false;
                    if (p[i, j] != 0)
                    {
                        
                        if (i <= 5)
                        {
                            fs = true;
                            int z = 1;
                            while ((fs == true) && (z <= 4))
                            {
                                if (p[i, j] == p[i + z, j])
                                    z++;
                                else
                                    fs = false;
                            }
                            if (fs == true)
                            {
                                x = i;
                                y = j;
                                break;
                            }

                        }
                        if (j <= 5)
                        {
                            fc = true;
                            int z = 1;
                            while ((fc == true) && (z <= 4))
                            {
                                if (p[i, j] == p[i, j + z])
                                    z++;
                                else
                                    fc = false;
                            }
                            if (fc == true)
                            {
                                x = i;
                                y = j;
                                break;
                            }
                        }
                    }
                }
                if ((fc == true) || (fs == true))
                    break;
            }


            if ((fc == false) & (fs == false))
            {
                for (int i = 0; i < p.GetLength(0); i++)
                {
                    for (int j = 0; j <= 5; j++)
                    {
                        fs = false; fc = false;
                        if (p[i, j] != 0)
                        {
                            if (i <= 5)
                            {
                                fs = true;
                                int z = 1;
                                while ((fs == true) && (z <= 4))
                                {
                                    if (p[i, j] == p[i + z, j + z])
                                        z++;
                                    else
                                        fs = false;
                                }
                            }
                            if (i >= 4)
                            {
                                fc = true;
                                int z = 1;
                                while ((fc == true) && (z <= 4))
                                {
                                    if (p[i, j] == p[i - z, j + z])
                                        z++;
                                    else
                                        fc = false;
                                }
                                
                            }
                            if ((fc == true) || (fs == true))
                            {
                                x = i;
                                y = j;
                            }
                        }
                        if ((fc == true) || (fs == true))
                            break;
                    }
                    if ((fc == true) || (fs == true))
                        break;
                }
                if ((fc == true) || (fs == true))
                {
                    Graphics g = this.CreateGraphics();
                    g.TranslateTransform((this.ClientRectangle.Width - l) / 2, label3.Bottom); // смешение оси кординат
                                                                                               //g.DrawEllipse(new Pen(Color.Red, 1.0f), -5, 5, 10, -10);
                    int n = l / p.GetLength(0);
                    if (fs == true)
                        g.DrawLine(new Pen(Color.LightGreen, 2.0f), x * n + n / 2, y * n + n / 2, n * (x + 4) + n / 2, n * (y + 4) + n / 2);
                    else
                        g.DrawLine(new Pen(Color.LightGreen, 2.0f), x * n + n / 2, y * n + n / 2, n * (x - 4) + n / 2, n * (y + 4) + n / 2);

                }
            }
            else
            {
                Graphics g = this.CreateGraphics();
                g.TranslateTransform((this.ClientRectangle.Width - l) / 2, label3.Bottom); // смешение оси кординат
                //g.DrawEllipse(new Pen(Color.Red, 1.0f), -5, 5, 10, -10);
                int n = l / p.GetLength(0);
                if (fs == true)
                    g.DrawLine(new Pen(Color.LightGreen, 2.0f), x * n + n / 2, y * n + n / 2, n * (x + 4) + n / 2, n * y + n / 2);
                else
                    g.DrawLine(new Pen(Color.LightGreen, 2.0f), x * n + n / 2, y * n + n / 2, n * x + n / 2, n * (y + 4) + n / 2);
            }
            
            score(fc,fs);
        }
        void score(bool fc, bool fs)
        {
            if ((fc == true) || (fs == true))
            {
                Thread.Sleep(400);
                string s = label3.Text;
                s.Split(':');
                string[] words = s.Split(new char[] { ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);
                //label3.Text = words[0] + ":" + words[1] + ":" + words[2];
                if (k % 2 != 0)
                {
                    label3.Text = words[0] + " " + (int.Parse(words[1]) + 1) + ":" + words[2];
                    MessageBox.Show("Игрок 1 выиграл!", "Партия закончена");
                }
                else
                {
                    label3.Text = words[0] + " " + words[1] + ":" + (int.Parse(words[1]) + 1);
                    MessageBox.Show("Игрок 2 выиграл!", "Партия закончена");
                }
                k = 0;
            }
            else
            {
                bool f = true;
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
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

