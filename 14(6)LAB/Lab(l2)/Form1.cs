using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Lab_l2_
{
    public partial class Form1 : Form
    {
        private List<geomtry_figure> figures = new List<geomtry_figure>();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Text = "Создать";
            button2.Text = "Сохранить";
            button3.Text = "Загрузить";
            button1.AutoSize = true;
            button2.AutoSize = true;
            button3.AutoSize = true;

            button1.Left = 10;
            button2.Left = button1.Left;
            button3.Left = button1.Left;

            button1.Top = 10;
            button2.Top = this.ClientRectangle.Height / 2;
            button3.Top = this.ClientRectangle.Height - 10 - button3.Height;

            textBox1.Size = new Size(90, this.ClientRectangle.Height - 20);
            textBox1.Location = new Point(this.ClientRectangle.Width - 100, 10);
            textBox1.ReadOnly = true;

            //listBox1.Hide();


        }
        public class geomtry_figure
        {
            protected Point center { get; }
            protected Color color { get; }
            protected float size { get; }
            public string name { get; set; }
            protected Random r = new Random();

            protected Graphics g { get; }
            protected Form form;
            public geomtry_figure(int x, int y, Form f)
            {
                center = new Point(r.Next(0, x), r.Next(0, y));
                color = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));
                size = r.Next(10, Math.Min(x, y) / 5);

                form = f;
                g = form.CreateGraphics();
            }
            public virtual double area() { return 0; }

            public virtual void draw() { }
            public virtual bool test(Point point) { return false; }
            public virtual void choice(Point point) { }

        }
        public class circle : geomtry_figure
        {

            public circle(int x, int y, Form f) : base(x, y, f)
            {
                name = "Круг";
            }
            public override double area() { return Math.Round(Math.PI * size * size / 4, 1); }
            public override void draw()
            {
                g.FillEllipse(new SolidBrush(color), center.X - size / 2, center.Y - size / 2, size, size);
                base.draw();
            }
            public override bool test(Point point)
            {
                base.test(point);
                if (Math.Pow((center.X - point.X), 2) + Math.Pow((center.Y - point.Y), 2) <= Math.Pow(size / 2, 2))
                    return true;
                else return false;
            }
            public override void choice(Point point)
            {
                bool f = test(point);
                base.choice(point);
                if (f)
                {
                    g.DrawString(name + "\n" + area(), new System.Drawing.Font("Times New Roman", 10, FontStyle.Bold),
                         new SolidBrush(Color.Black), new Point((int)(center.X - size / 2), (int)(center.Y - size / 2)));
                }
            }
        }

        public class triangle : geomtry_figure
        {

            public triangle(int x, int y, Form f) : base(x, y, f)
            {
                name = "Треугольник";
            }
            public override double area() { return Math.Round(Math.Pow(size, 2) / Math.Sqrt(3), 1); }
            public override void draw()
            {
                Point[] points = { new Point(center.X,(int)(center.Y-size*2/3)),
                    new Point((int)(center.X-Math.Cos(45)*size/ Math.Sin(45)), (int)(center.Y + size * 1 / 3)),
                    new Point((int)(center.X+Math.Cos(45)*size/ Math.Sin(45)), (int)(center.Y + size * 1 / 3)) };
                g.FillPolygon(new SolidBrush(color), points);
                base.draw();
            }
            public override bool test(Point point)
            {
                base.test(point);
                if (
                    (point.Y >= center.Y - size * 2 / 3)
                    && (point.Y <= center.Y + size * 1 / 3)
                    // && ((point.X- center.X)/(center.X - Math.Cos(45) * size / Math.Sin(45)) - center.X)==(point.Y-(center.Y - size * 2 / 3))/(center.Y + size * 1 / 3 - (center.Y - size * 2 / 3))

                    && (point.X) <= (point.Y - (center.Y - size * 2 / 3)) / (Math.Cos(45) / Math.Sin(45)) + center.X
                    && (point.X) >= (point.Y - (center.Y - size * 2 / 3)) / (-Math.Cos(45) / Math.Sin(45)) + center.X
                    )
                    return true;
                else return false;
            }
            public override void choice(Point point)
            {
                bool f = test(point);
                base.choice(point);
                if (f)
                {
                    g.DrawString(name + "\n" + area(), new System.Drawing.Font("Times New Roman", 10, FontStyle.Bold),
                         new SolidBrush(Color.Black), new Point((int)(center.X - size / 2), (int)(center.Y - size / 2)));
                }
            }
        }

        public class square : geomtry_figure
        {

            public square(int x, int y, Form f) : base(x, y, f)
            {
                name = "Квадрат";
            }
            public override double area() { return size * size; }
            public override void draw()
            {
                g.FillRectangle(new SolidBrush(color), center.X - size / 2, center.Y - size / 2, size, size);
                base.draw();
            }
            public override bool test(Point point)
            {
                base.test(point);
                if ((point.X >= center.X - size / 2) && (point.X <= center.X + size / 2) &&
                    (point.Y >= center.Y - size / 2) && (point.Y <= center.Y + size / 2))
                    return true;
                else return false;
            }
            public override void choice(Point point)
            {
                bool f = test(point);
                base.choice(point);
                if (f)
                {
                    g.DrawString(name + "\n" + area(), new System.Drawing.Font("Times New Roman", 10, FontStyle.Bold),
                         new SolidBrush(Color.Black), new Point((int)(center.X - size / 2), (int)(center.Y - size / 2)));
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            switch (r.Next(0, 3))
            {
                case 0:
                    figures.Add(new circle(this.ClientRectangle.Width, this.ClientRectangle.Height, this));
                    break;
                case 1:
                    figures.Add(new triangle(this.ClientRectangle.Width, this.ClientRectangle.Height, this));
                    break;
                case 2:
                    figures.Add(new square(this.ClientRectangle.Width, this.ClientRectangle.Height, this));
                    break;
            }
            figures[figures.Count - 1].draw();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            //label1.Text += figures.Count + "\n";
            Point point = new Point(e.X, e.Y);
            for (int i = 0; i < figures.Count; i++)
            {
                figures[i].choice(point);
                // label1.Text += figures[i].test(point) +"\n";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string filePath = @"D:\Misis\ООП(Объектно-орентирование программирование)\14(6)LAB\out.txt";
            string s = "";
            for (int i = 0; i < figures.Count; i++)
                s += figures[i].name + ": " + figures[i].area() + "\n";
            File.WriteAllText(filePath, s);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            string filePath = @"D:\Misis\ООП(Объектно-орентирование программирование)\14(6)LAB\out.txt";
            string[] lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i++)
                textBox1.Text += lines[i] + "\n";
        }
    }
}