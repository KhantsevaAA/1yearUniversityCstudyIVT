using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Lab13
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(350, 500);
            this.Text = "Банковский счёт";
            groupBox1.Text = "Состояние счёта";
            groupBox2.Text = "Транкзация";
            button1.Text = "Зачислить";
            button1.AutoSize = true;
            groupBox2.Controls.Add(button1);
            button2.Text = "Снять";
            button2.AutoSize = true;
            groupBox2.Controls.Add(button2);
            label1.Text = "Баланс";
            groupBox1.Controls.Add(label1);
            label2.Text = "Валюта";
            groupBox1.Controls.Add(label2);
            label3.Text = "Сумма";
            groupBox2.Controls.Add(label3);
            label4.Text = "Валюта";
            groupBox2.Controls.Add(label4);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(textBox1);
            groupBox2.Controls.Add(comboBox2);
            groupBox2.Controls.Add(textBox2);


            groupBox1.Location = new Point(20, 20);
            groupBox1.Size = new Size(this.ClientRectangle.Width - 40, this.ClientRectangle.Height / 2 - 40);
            groupBox2.Location = new Point(20, groupBox1.Bottom + 20);
            groupBox2.Size = groupBox1.Size;
            label1.Location = new Point(groupBox1.Left + 10, groupBox1.Height / 3);
            textBox1.Location = new Point(groupBox1.Left + 10 + label2.Width + 10, groupBox1.Height / 3);
            label2.Location = new Point(groupBox1.Left + 10, groupBox1.Height * 2 / 3);
            comboBox1.Location = new Point(groupBox1.Left + 10 + label2.Width + 10, groupBox1.Height * 2 / 3);

            label3.Location = new Point(groupBox2.Left + 10, groupBox2.Height / 4);
            textBox2.Location = new Point(groupBox2.Left + 10 + label2.Width + 10, groupBox2.Height / 4);
            label4.Location = new Point(groupBox2.Left + 10, groupBox2.Height * 2 / 4);
            comboBox2.Location = new Point(groupBox2.Left + 10 + label2.Width + 10, groupBox2.Height * 2 / 4);
            button1.Location = new Point(groupBox2.Width / 3 - button1.Width / 2, groupBox2.Height * 3 / 4);
            button2.Location = new Point(groupBox2.Width * 2 / 3 - button2.Width / 2, groupBox2.Height * 3 / 4);

            textBox1.Width = this.ClientRectangle.Width - 150;
            comboBox1.Width = textBox1.Width;
            textBox2.Width = textBox1.Width;
            comboBox2.Width = textBox1.Width;


            for (int i = 0; i < cur.Length; i++)
            {
                comboBox1.Items.Add(cur[i].getname());
                comboBox2.Items.Add(cur[i].getname());
            }
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;


            textBox1.ReadOnly = true;
            show();
            //textBox1.Text = acc.getbalance(cur[comboBox1.SelectedIndex]); 
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            groupBox1.Location = new Point(20, 20);
            groupBox1.Size = new Size(this.ClientRectangle.Width - 40, this.ClientRectangle.Height / 2 - 40);
            groupBox2.Location = new Point(20, groupBox1.Bottom + 20);
            groupBox2.Size = groupBox1.Size;
            label1.Location = new Point(groupBox1.Left + 10, groupBox1.Height / 3);
            textBox1.Location = new Point(groupBox1.Left + 10 + label2.Width + 10, groupBox1.Height / 3);
            label2.Location = new Point(groupBox1.Left + 10, groupBox1.Height * 2 / 3);
            comboBox1.Location = new Point(groupBox1.Left + 10 + label2.Width + 10, groupBox1.Height * 2 / 3);

            label3.Location = new Point(groupBox2.Left + 10, groupBox2.Height / 4);
            textBox2.Location = new Point(groupBox2.Left + 10 + label2.Width + 10, groupBox2.Height / 4);
            label4.Location = new Point(groupBox2.Left + 10, groupBox2.Height * 2 / 4);
            comboBox2.Location = new Point(groupBox2.Left + 10 + label2.Width + 10, groupBox2.Height * 2 / 4);
            button1.Location = new Point(groupBox2.Width / 3 - button1.Width / 2, groupBox2.Height * 3 / 4);
            button2.Location = new Point(groupBox2.Width * 2 / 3 - button2.Width / 2, groupBox2.Height * 3 / 4);

            textBox1.Width = this.ClientRectangle.Width - 150;
            comboBox1.Width = textBox1.Width;
            textBox2.Width = textBox1.Width;
            comboBox2.Width = textBox1.Width;
        }

        public class Currency
        {
            private string name;
            private double rate;
            public Currency(string n, double r)
            {
                name = n;
                rate = r;
            }
            public string getname() { return name; }
            public double getrate() { return rate; }

        }

        public class Account
        {
            private double balance;
            public Account(double b) { balance = b; }
            public double getbalance(Currency c) { return Math.Round(balance / c.getrate(), 2); }
            //public string getbalance(Currency c) { return (balance / c.getrate()).ToString("N2"); }
            public void convert() { }
            public void add(Currency c, double v) { balance += v * c.getrate(); }
        }

        //https://bankiros.ru/currency/cbrf/date/31-01-2004
        private Currency[] cur = {
            new Currency("RU",1.0),
            new Currency("EU",88.37),
            new Currency("US",80.51),
            new Currency("RU", 1),
            new Currency("GBP",51.73),
            new Currency("JGS", 66.65)
        };

        private Account acc = new Account(0);

        private void show()
        {
            textBox1.Text = acc.getbalance(cur[comboBox1.SelectedIndex]).ToString();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            double x;
            if (double.TryParse(textBox2.Text.Replace(".", ","), out  x) && (x > 0))
            {
                acc.add(cur[comboBox2.SelectedIndex], x);
                show();
            }
            else
                textBox2.Text = "Некорректное значение!";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double x;
            if (double.TryParse(textBox2.Text.Replace(".", ","), out  x) && (x > 0) && 
                (x * cur[comboBox2.SelectedIndex].getrate() < acc.getbalance(cur[comboBox2.SelectedIndex])))
            {
                acc.add(cur[comboBox2.SelectedIndex], -x);
                show();
            }
            else
                textBox2.Text = "Некорректное значение!";
        }
    }
}
