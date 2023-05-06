using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Lab13_l2_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.Text = "Банковский счёт";
            groupBox1.Text = "Состояние счёта 1 клиента";
            groupBox3.Text = "Состояние счёта 2 клиента";
            groupBox2.Text = "Транкзация 1 клиента";
            groupBox4.Text = "Транкзация 2 клиента";
            button1.Text = "Зачислить";
            button3.Text = button1.Text;
            button1.AutoSize = true;
            button3.AutoSize = true;
            groupBox2.Controls.Add(button1);
            groupBox4.Controls.Add(button3);
            button2.Text = "Снять";
            button4.Text = button2.Text;
            button2.AutoSize = true;
            button4.AutoSize = true;
            groupBox2.Controls.Add(button2);
            groupBox4.Controls.Add(button4);
            label1.Text = "Баланс";
            label5.Text = label1.Text;
            groupBox1.Controls.Add(label1);
            groupBox3.Controls.Add(label5);
            label2.Text = "Валюта";
            label6.Text = label2.Text;
            groupBox1.Controls.Add(label2);
            groupBox3.Controls.Add(label6);
            label3.Text = "Сумма";
            label7.Text = label3.Text;
            groupBox2.Controls.Add(label3);
            groupBox4.Controls.Add(label7);
            label4.Text = "Валюта";
            label8.Text = label4.Text;
            groupBox2.Controls.Add(label4);
            groupBox4.Controls.Add(label8);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(textBox1);
            groupBox2.Controls.Add(comboBox2);
            groupBox2.Controls.Add(textBox2);

            groupBox3.Controls.Add(comboBox3);
            groupBox3.Controls.Add(textBox3);
            groupBox4.Controls.Add(comboBox4);
            groupBox4.Controls.Add(textBox4);

            this.Size = new Size(500, 500);

            groupBox1.Location = new Point(20, 20);
            groupBox1.Size = new Size(this.ClientRectangle.Width / 2 - 30, this.ClientRectangle.Height / 2 - 30);
            groupBox2.Location = new Point(groupBox1.Left, groupBox1.Bottom + 20);
            groupBox2.Size = groupBox1.Size;

            groupBox3.Location = new Point(20 + groupBox1.Left + groupBox1.Width, groupBox1.Top);
            groupBox3.Size = groupBox1.Size;
            groupBox4.Location = new Point(groupBox3.Left, groupBox1.Bottom + 20);
            groupBox4.Size = groupBox1.Size;


            label1.Location = new Point(groupBox1.Left + 10, groupBox1.Height / 3);
            textBox1.Location = new Point(groupBox1.Left + 10 + label2.Width + 10, groupBox1.Height / 3);
            label2.Location = new Point(groupBox1.Left + 10, groupBox1.Height * 2 / 3);
            comboBox1.Location = new Point(groupBox1.Left + 10 + label2.Width + 10, groupBox1.Height * 2 / 3);

            label5.Location = new Point(groupBox1.Left + 10, groupBox3.Height / 3);
            textBox3.Location = new Point(groupBox1.Left + 10 + label2.Width + 10, groupBox1.Height / 3);
            label6.Location = new Point(groupBox1.Left + 10, groupBox1.Height * 2 / 3);
            comboBox3.Location = new Point(groupBox1.Left + 10 + label2.Width + 10, groupBox1.Height * 2 / 3);


            label3.Location = new Point(groupBox2.Left + 10, groupBox2.Height / 5);
            textBox2.Location = new Point(groupBox2.Left + 10 + label2.Width + 10, groupBox2.Height / 5);
            label4.Location = new Point(groupBox2.Left + 10, groupBox2.Height * 2 / 5);
            comboBox2.Location = new Point(groupBox2.Left + 10 + label2.Width + 10, groupBox2.Height * 2 / 5);
            button1.Location = new Point(groupBox2.Width / 3 - button1.Width / 2, groupBox2.Height * 3 / 5);
            button2.Location = new Point(groupBox2.Width * 2 / 3 - button2.Width / 2, groupBox2.Height * 3 / 5);

            label7.Location = new Point(groupBox2.Left + 10, groupBox2.Height / 5);
            textBox4.Location = new Point(groupBox2.Left + 10 + label2.Width + 10, groupBox2.Height / 5);
            label8.Location = new Point(groupBox2.Left + 10, groupBox2.Height * 2 / 5);
            comboBox4.Location = new Point(groupBox2.Left + 10 + label2.Width + 10, groupBox2.Height * 2 / 5);
            button3.Location = new Point(groupBox2.Width / 3 - button1.Width / 2, groupBox2.Height * 3 / 5);
            button4.Location = new Point(groupBox2.Width * 2 / 3 - button2.Width / 2, groupBox2.Height * 3 / 5);


            textBox1.Width = groupBox1.Width - 110;
            comboBox1.Width = textBox1.Width;
            textBox2.Width = textBox1.Width;
            comboBox2.Width = textBox1.Width;
            textBox3.Width = textBox1.Width;
            comboBox3.Width = textBox1.Width;
            textBox4.Width = textBox1.Width;
            comboBox4.Width = textBox1.Width;

            label9.Text = "Комиссия:";
            label10.Text = "Комиссия:";
            groupBox2.Controls.Add(label9);
            groupBox4.Controls.Add(label10);
            label10.Location = new Point((groupBox2.Width - label9.Width) / 2, groupBox2.Height * 4 / 5);
            label9.Location = new Point((groupBox2.Width - label10.Width) / 2, groupBox2.Height * 4 / 5);

            textBox1.ReadOnly = true;
            textBox3.ReadOnly = true;

            for (int i = 0; i < cur.Length; i++)
            {
                comboBox1.Items.Add(cur[i].getname());
                comboBox2.Items.Add(cur[i].getname());
                comboBox3.Items.Add(cur[i].getname());
                comboBox4.Items.Add(cur[i].getname());
            }

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;

            textBox2.Text = "";
            textBox4.Text = "";

            textBox1.Text = acc[0].getbalance(cur[0]).ToString();
            textBox3.Text = acc[1].getbalance(cur[0]).ToString();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            groupBox1.Location = new Point(20, 20);
            groupBox1.Size = new Size(this.ClientRectangle.Width / 2 - 30, this.ClientRectangle.Height / 2 - 30);
            groupBox2.Location = new Point(groupBox1.Left, groupBox1.Bottom + 20);
            groupBox2.Size = groupBox1.Size;

            groupBox3.Location = new Point(20 + groupBox1.Left + groupBox1.Width, groupBox1.Top);
            groupBox3.Size = groupBox1.Size;
            groupBox4.Location = new Point(groupBox3.Left, groupBox1.Bottom + 20);
            groupBox4.Size = groupBox1.Size;


            label1.Location = new Point(groupBox1.Left + 10, groupBox1.Height / 3);
            textBox1.Location = new Point(groupBox1.Left + 10 + label2.Width + 10, groupBox1.Height / 3);
            label2.Location = new Point(groupBox1.Left + 10, groupBox1.Height * 2 / 3);
            comboBox1.Location = new Point(groupBox1.Left + 10 + label2.Width + 10, groupBox1.Height * 2 / 3);

            label5.Location = new Point(groupBox1.Left + 10, groupBox3.Height / 3);
            textBox3.Location = new Point(groupBox1.Left + 10 + label2.Width + 10, groupBox1.Height / 3);
            label6.Location = new Point(groupBox1.Left + 10, groupBox1.Height * 2 / 3);
            comboBox3.Location = new Point(groupBox1.Left + 10 + label2.Width + 10, groupBox1.Height * 2 / 3);


            label3.Location = new Point(groupBox2.Left + 10, groupBox2.Height / 5);
            textBox2.Location = new Point(groupBox2.Left + 10 + label2.Width + 10, groupBox2.Height / 5);
            label4.Location = new Point(groupBox2.Left + 10, groupBox2.Height * 2 / 5);
            comboBox2.Location = new Point(groupBox2.Left + 10 + label2.Width + 10, groupBox2.Height * 2 / 5);
            button1.Location = new Point(groupBox2.Width / 3 - button1.Width / 2, groupBox2.Height * 3 / 5);
            button2.Location = new Point(groupBox2.Width * 2 / 3 - button2.Width / 2, groupBox2.Height * 3 / 5);

            label7.Location = new Point(groupBox2.Left + 10, groupBox2.Height / 5);
            textBox4.Location = new Point(groupBox2.Left + 10 + label2.Width + 10, groupBox2.Height / 5);
            label8.Location = new Point(groupBox2.Left + 10, groupBox2.Height * 2 / 5);
            comboBox4.Location = new Point(groupBox2.Left + 10 + label2.Width + 10, groupBox2.Height * 2 / 5);
            button3.Location = new Point(groupBox2.Width / 3 - button1.Width / 2, groupBox2.Height * 3 / 5);
            button4.Location = new Point(groupBox2.Width * 2 / 3 - button2.Width / 2, groupBox2.Height * 3 / 5);


            textBox1.Width = groupBox1.Width - 110;
            comboBox1.Width = textBox1.Width;
            textBox2.Width = textBox1.Width;
            comboBox2.Width = textBox1.Width;
            textBox3.Width = textBox1.Width;
            comboBox3.Width = textBox1.Width;
            textBox4.Width = textBox1.Width;
            comboBox4.Width = textBox1.Width;

            label10.Location = new Point((groupBox2.Width - label9.Width) / 2, groupBox2.Height * 4 / 5);
            label9.Location = new Point((groupBox2.Width - label10.Width) / 2, groupBox2.Height * 4 / 5);
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
            new Currency("GBP",51.73),
            new Currency("JGS", 66.65)
        };
        private Account[] acc = { new Account(500), new Account(500) };
        private void show()
        {
            textBox1.Text = acc[0].getbalance(cur[comboBox1.SelectedIndex]).ToString();
            textBox3.Text = acc[1].getbalance(cur[comboBox3.SelectedIndex]).ToString();
        }
        private void update()
        {
            //if (textBox2.Text == "0")
            check1();
            //else
            check2();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = acc[0].getbalance(cur[comboBox1.SelectedIndex]).ToString();
            update();
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            update();

        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Text = acc[1].getbalance(cur[comboBox3.SelectedIndex]).ToString();
            update();
        }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            update();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            double? x = check1();// x в заданной в comboBox2 валюте
            if (x != null)
            {
                if (x < 0)
                    MessageBox.Show("Введите положительное чиcло!", "!Предупреждение Клиенту 1!");
                else
                {
                    double y1 = double.Parse(label9.Text.Split(' ')[1]);//label9  в валюте comboBox1
                    double y2 = double.Parse(label10.Text.Split(' ')[1]);//label10  в валюте comboBox3
                    //есть ли у клиента 1 денеги на коммисию
                    if (y1 > acc[0].getbalance(cur[comboBox1.SelectedIndex]))
                        MessageBox.Show("Вы не можете оплатить комиссию!", "!Предупреждение Клиенту 1!");

                    else
                    {
                        //есть ли у клиента 2 денеги на перевод и коммисию

                        if (x * (cur[comboBox3.SelectedIndex].getrate() / cur[comboBox2.SelectedIndex].getrate()) + y2 
                            > acc[1].getbalance(cur[comboBox3.SelectedIndex]))
                            MessageBox.Show("Вы не можете зачислить!\n" +
                                "У другого клиента недостаточно средств!", "!Предупреждение Клиенту 1!");
                        else
                        {
                            acc[0].add(cur[comboBox2.SelectedIndex], (double)x);
                            acc[0].add(cur[comboBox1.SelectedIndex], -y1);
                            acc[1].add(cur[comboBox3.SelectedIndex], -(double)(x * (cur[comboBox3.SelectedIndex].getrate() / cur[comboBox2.SelectedIndex].getrate()) + y2));
                            show();
                            MessageBox.Show("Перевод", "Завершён!");
                        }
                    }
                }
            }
            else
                MessageBox.Show("Некооректные данные!", "!Предупреждение Клиенту 1!");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            double? x = check1();// x в заданной в comboBox2 валюте
            if (x != null)
            {
                if (x < 0)
                    MessageBox.Show("Введите положительное чиcло!", "!Предупреждение Клиенту 1!");
                else
                {
                    double y1 = double.Parse(label9.Text.Split(' ')[1]);//label9  в валюте comboBox1
                    double y2 = double.Parse(label10.Text.Split(' ')[1]);//label10  в валюте comboBox3
                    //есть ли у клиента 1 денеги на перевод и на коммисию
                    if (y1 + x* (cur[comboBox1.SelectedIndex].getrate() / cur[comboBox2.SelectedIndex].getrate()) > acc[0].getbalance(cur[comboBox1.SelectedIndex]))
                        MessageBox.Show("Вы не можете снять!\n" +
                                "У вас недостаточно средств!", "!Предупреждение Клиенту 1!");
                    else
                    {
                        if(y2 > acc[1].getbalance(cur[comboBox3.SelectedIndex]))
                            MessageBox.Show("Другой клиент может оплатить комиссию!", "!Предупреждение Клиенту 1!");
                        else
                        {
                            acc[0].add(cur[comboBox1.SelectedIndex], -(double)(y1 + x * (cur[comboBox1.SelectedIndex].getrate() / cur[comboBox2.SelectedIndex].getrate())));
                            acc[1].add(cur[comboBox2.SelectedIndex], (double)x);
                            acc[1].add(cur[comboBox3.SelectedIndex], -y2);
                            show();
                            MessageBox.Show("Перевод", "Завершён!");
                        }
                    }
                }
            }
            else
                MessageBox.Show("Некооректные данные!", "!Предупреждение Клиенту 1!");

        }
        private void button3_Click(object sender, EventArgs e)
        {
            double? x = check2();// x в заданной в comboBox4 валюте
            if (x != null)
            {
                if (x < 0)
                    MessageBox.Show("Введите положительное чиcло!", "!Предупреждение Клиенту 2!");
                else
                {
                    double y1 = double.Parse(label9.Text.Split(' ')[1]);//label9  в валюте comboBox1
                    double y2 = double.Parse(label10.Text.Split(' ')[1]);//label10  в валюте comboBox3
                    //есть ли у клиента 2 денеги на коммисию
                    if (y2 > acc[1].getbalance(cur[comboBox3.SelectedIndex]))
                        MessageBox.Show("Вы не можете оплатить комиссию!", "!Предупреждение Клиенту 2!");

                    else
                    {
                        //есть ли у клиента 1 денеги на перевод и коммисию

                        if (x * (cur[comboBox1.SelectedIndex].getrate() / cur[comboBox4.SelectedIndex].getrate()) + y1
                            > acc[0].getbalance(cur[comboBox1.SelectedIndex]))
                            MessageBox.Show("Вы не можете зачислить!\n" +
                                "У другого клиента недостаточно средств!", "!Предупреждение Клиенту 2!");
                        else
                        {
                            acc[1].add(cur[comboBox4.SelectedIndex], (double)x);
                            acc[1].add(cur[comboBox3.SelectedIndex], -y2);
                            acc[10].add(cur[comboBox1.SelectedIndex], -(double)(x * (cur[comboBox1.SelectedIndex].getrate() / cur[comboBox4.SelectedIndex].getrate()) + y1));
                            show();
                            MessageBox.Show("Перевод", "Завершён!");
                        }
                    }
                }
            }
            else
                MessageBox.Show("Некооректные данные!", "!Предупреждение Клиенту 2!");

        }
        private void button4_Click(object sender, EventArgs e)
        {
            double? x = check1();// x в заданной в comboBox4 валюте
            if (x != null)
            {
                if (x < 0)
                    MessageBox.Show("Введите положительное чиcло!", "!Предупреждение Клиенту 2!");
                else
                {
                    double y1 = double.Parse(label9.Text.Split(' ')[1]);//label9  в валюте comboBox1
                    double y2 = double.Parse(label10.Text.Split(' ')[1]);//label10  в валюте comboBox3
                    //есть ли у клиента 2 денеги на перевод и на коммисию
                    if (y2 + x * (cur[comboBox3.SelectedIndex].getrate() / cur[comboBox4.SelectedIndex].getrate()) > acc[1].getbalance(cur[comboBox1.SelectedIndex]))
                        MessageBox.Show("Вы не можете снять!\n" +
                                "У вас недостаточно средств!", "!Предупреждение Клиенту 2!");
                    else
                    {
                        if (y1 > acc[1].getbalance(cur[comboBox1.SelectedIndex]))
                            MessageBox.Show("Другой клиент может оплатить комиссию!", "!Предупреждение Клиенту 2!");
                        else
                        {
                            acc[1].add(cur[comboBox3.SelectedIndex], -(double)(y2 + x * (cur[comboBox3.SelectedIndex].getrate() / cur[comboBox4.SelectedIndex].getrate())));
                            acc[0].add(cur[comboBox4.SelectedIndex], (double)x);
                            acc[0].add(cur[comboBox1.SelectedIndex], -y1);
                            show();
                            MessageBox.Show("Перевод", "Завершён!");
                        }
                    }
                }
            }
            else
                MessageBox.Show("Некооректные данные!", "!Предупреждение Клиенту 2!");

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox4.Text = "";
            label10.Text = "Комиссия:";
            double? x = check1();
            if (x == null)
                label9.Text = "!Некорректное значение!";
            else if (x < 0)
                label9.Text = "!Введите положительное число!";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = "";
            label9.Text = "Комиссия:";
            double? x = check2();
            if (x == null)
                label10.Text = "!Некорректное значение!";
            else if (x < 0)
                label10.Text = "!Введите положительное число!";
        }

        private double? check1() //проверка для textBox2 и изменений comboBox
        {

            if (double.TryParse(textBox2.Text.Replace(".", ","), out double x))
            {
                if (cur[comboBox1.SelectedIndex] != cur[comboBox2.SelectedIndex])
                    label9.Text = "Комиссия: " + (x * (cur[comboBox1.SelectedIndex].getrate() / cur[comboBox2.SelectedIndex].getrate()) * 0.01).ToString("N2") + " " + cur[comboBox1.SelectedIndex].getname();
                else
                    label9.Text = "Комиссия: 0 " + cur[comboBox2.SelectedIndex].getname();
                if (cur[comboBox2.SelectedIndex] != cur[comboBox3.SelectedIndex])
                    label10.Text = "Комиссия: " + (x * (cur[comboBox3.SelectedIndex].getrate() / cur[comboBox2.SelectedIndex].getrate()) * 0.01).ToString("N2") + " " + cur[comboBox3.SelectedIndex].getname();
                else
                    label10.Text = "Комиссия: 0 " + cur[comboBox2.SelectedIndex].getname();
                return x;
            }

            return null;
        }

        private double? check2() //проверка для textBox4 и изменений comboBox
        {
            if (double.TryParse(textBox4.Text.Replace(".", ","), out double x))
            {
                if (cur[comboBox3.SelectedIndex] != cur[comboBox4.SelectedIndex])
                    label10.Text = "Комиссия: " + (x * (cur[comboBox3.SelectedIndex].getrate() / cur[comboBox4.SelectedIndex].getrate()) * 0.01).ToString("N2") + " " + cur[comboBox3.SelectedIndex].getname();
                else
                    label10.Text = "Комиссия: 0 " + cur[comboBox2.SelectedIndex].getname();
                if (cur[comboBox3.SelectedIndex] != cur[comboBox1.SelectedIndex])
                    label9.Text = "Комиссия: " + (x * (cur[comboBox1.SelectedIndex].getrate() / cur[comboBox3.SelectedIndex].getrate()) * 0.01).ToString("N2") + " " + cur[comboBox1.SelectedIndex].getname();
                else
                    label9.Text = "Комиссия: 0 " + cur[comboBox4.SelectedIndex].getname();
                return x / cur[comboBox4.SelectedIndex].getrate(); //перевод в RU БЕЗ комиссии
            }

            return null;
        }

    }
}
