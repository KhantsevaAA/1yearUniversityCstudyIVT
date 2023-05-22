using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
{
    public partial class Form1 : Form
    {
        private circle[] figure;
        private restange[] figure1;
        public Form1()
        {
            InitializeComponent();

            figure = new circle[]{
                new circle(this.ClientRectangle.Width, this.ClientRectangle.Height, this),
                new circle(this.ClientRectangle.Width, this.ClientRectangle.Height, this),
                new circle(this.ClientRectangle.Width, this.ClientRectangle.Height, this),
            };
            figure1 = new restange[]{
                new restange(this.ClientRectangle.Width/3, this.ClientRectangle.Height / 3, this),
                new restange(this.ClientRectangle.Width*2/3, this.ClientRectangle.Height*2/3, this),
                new restange(this.ClientRectangle.Width, this.ClientRectangle.Height, this),
            };

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "";
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < figure.Length; i++)
            {
                figure[i].draw();
                figure1[i].draw();
            }
        }
        public class geometry_figure
        {
            //private - доступно только в своём классе, protected - доступно и в производных классах;
            //private protected - доступен из любого места в своем классе или в производных классах, которые определены в той же сборке.
            public Point center;
            private Color figure;
            private Color line;
            protected private float line_weight;
            protected Random r;//= new Random((int)DateTime.Now.Millisecond);


            public geometry_figure(int x, int y)
            {
                Thread.Sleep(1);
                r = new Random((int)DateTime.Now.Ticks);
                center = new Point(r.Next(0, x), r.Next(0, y));
                figure = Color.Transparent;
                line = Color.Black;
                line_weight = 1;
            }
            public virtual void change()
            {
                r = new Random(DateTime.Now.Millisecond);
                figure = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));
                line = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));
                line_weight = (float)(r.Next(1, 100) * 0.1);
            }
            public Color color_line { get => this.line; }
            public Color color_figure { get => this.figure; }
        }

        public class circle : geometry_figure
        {
            public float radius;
            protected Graphics g;
            protected Form form;
            public circle(int x, int y, Form f) : base(x, y)
            {

                r = new Random((int)DateTime.Now.Ticks);
                radius = r.Next(10, Math.Min(x, y) / 5);
                form = f;
                g = form.CreateGraphics();
            }

            public void draw()
            {
                g.FillEllipse(new SolidBrush(color_figure), center.X - radius, center.Y - radius, radius * 2, radius * 2);
                g.DrawEllipse(new Pen(color_line, line_weight), center.X - radius, center.Y - radius, radius * 2, radius * 2);
            }
            public double area()
            {
                return Math.PI * radius * radius;
            }
        }

        public class restange : geometry_figure
        {
            public float height;
            public float width;
            protected Graphics g;
            protected Form form;
            public restange(int x, int y, Form f) : base(x, y)
            {

                r = new Random((int)DateTime.Now.Ticks);
                height = r.Next(10, Math.Min(x, y) / 2);
                width = r.Next(10, Math.Min(x, y) / 2);
                form = f;
                g = form.CreateGraphics();
            }

            public void draw()
            {
                g.FillRectangle(new SolidBrush(color_figure), center.X - width / 2, center.Y - height / 2, width, height);
                g.DrawRectangle(new Pen(color_line, line_weight), center.X - width / 2, center.Y - height / 2, width, height);
            }
            public double area()
            {
                return height * width;
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Point point = new Point(e.X, e.Y);
            bool f = false;
            for (int i = 0; i < 3; i++)
            {
                if (Math.Pow((figure[i].center.X - point.X), 2) + Math.Pow((figure[i].center.Y - point.Y), 2) <= Math.Pow(figure[i].radius, 2))
                {
                    figure[i].change();
                    figure[i].draw();
                    label1.Text = $"Попали в круг№{i + 1}: {Math.Round(figure[i].area(), 3)}\n";
                    f = true;
                }

                if ((figure1[i].center.X - figure1[i].width / 2 <= e.X) && (e.X <= figure1[i].center.X + figure1[i].width / 2)
                    && (figure1[i].center.Y - figure1[i].height / 2 <= e.Y) && (e.Y <= figure1[i].center.Y + figure1[i].height / 2))
                {
                    figure1[i].change();
                    figure1[i].draw();
                    label1.Text = $"Попали в прямоугольник№{i + 1}: S = {Math.Round(figure1[i].area(), 3)}\n";
                    f = true;
                }
                if (!f)
                    label1.Text = " Не попали!";
            }
        }


    }
}
