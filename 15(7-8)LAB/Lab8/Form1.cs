using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml;
using System.Net;
using System.IO;
using System.Data.SQLite;
using System.Data.Common;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab8
{
    public partial class Form1 : Form
    {
        private SQLiteConnection db;
        private XmlDocument xmlNews;
        private string strNews;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            db = new SQLiteConnection("Data Source = dataBase.db;");
            db.Open();
            textBox1.Text = "https://lenta.ru/rss/news";
            label3.Text = "Введите ссылку:";
            label1.Text = "Текст rss-ленты";
            label2.Text = "Преобразованный текст rss-ленты:";

            label4.Text = "Из базы данных:";
            button1.Text = "Чтение ссылки";
            button2.Text = "Загрузка в базу данных";
            button3.Text = "Чтение из базы данных";
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // textBox1.Text="https://lenta.ru/rss/news";
            string rssUrl = textBox1.Text;//https://lenta.ru/rss/news
            xmlNews = new XmlDocument();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(rssUrl);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            strNews = reader.ReadToEnd(); // считываем текст rss-ленты.
            richTextBox1.Text = strNews;
            xmlNews.LoadXml(strNews);
            XmlNodeList childNodeList = xmlNews.DocumentElement.SelectSingleNode("channel").SelectNodes("item");

            richTextBox2.Clear();

            foreach (XmlNode xmlNode in childNodeList)
            {
                richTextBox2.AppendText(new string('=', 50) + "\n");
                richTextBox2.AppendText(xmlNode.SelectSingleNode("pubDate").InnerText + "\n");
                richTextBox2.AppendText(xmlNode.SelectSingleNode("title").InnerText + "\n");
                richTextBox2.AppendText(xmlNode.SelectSingleNode("link").InnerText + "\n");
                richTextBox2.AppendText(xmlNode.SelectSingleNode("description").InnerText + "\n");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SQLiteCommand command;
            // создаём в базе данных таблицу «News» со следующими столбцами: 
            // «Id», «Title», «Link», «Description», «PubDate»
            command = new SQLiteCommand("PRAGMA synchronous = 1;" +
                "CREATE TABLE IF NOT EXISTS News (Id INTEGER PRIMARY KEY AUTOINCREMENT," +
                "Title,Link,Description,PubDate);", db);
            command.ExecuteNonQuery();

            XmlNodeList childNodeList = xmlNews?.DocumentElement?.SelectSingleNode("channel")?.SelectNodes("item");

            command = new SQLiteCommand("DELETE FROM News", db);
            command.ExecuteNonQuery();

            foreach (XmlNode xmlNode in childNodeList)
            {
                command = new SQLiteCommand("INSERT INTO News(Title,Link,Description,PubDate) " +
                    "VALUES(@title,@link,@description,@pubDate)", db);
                command.Parameters.AddWithValue("@title", xmlNode.SelectSingleNode("title").InnerText);
                command.Parameters.AddWithValue("@link", xmlNode.SelectSingleNode("link").InnerText);
                command.Parameters.AddWithValue("@description", xmlNode.SelectSingleNode("description").InnerText);
                command.Parameters.AddWithValue("@pubDate", xmlNode.SelectSingleNode("pubDate").InnerText);
                command.ExecuteNonQuery();
            }
            command.Dispose();

            MessageBox.Show("Запись " + childNodeList.Count + " новостей в базу данных прошла успешно", "Выполнено", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SQLiteCommand command;
            SQLiteDataReader reader;
            command = new SQLiteCommand("SELECT * FROM News", db);
            reader = command.ExecuteReader();

            richTextBox3.Clear();

            foreach (DbDataRecord item in reader)
            {
                richTextBox3.AppendText(new string('=', 50) + "\n");
                richTextBox3.AppendText(item["PubDate"].ToString().TrimEnd(new char[] { '+', '0' }) + "\n");
                richTextBox3.AppendText(item["Title"].ToString() + "\n");
                richTextBox3.AppendText(item["Link"].ToString() + "\n\n");
                richTextBox3.AppendText(item["Description"].ToString() + "\n");
            }
            command.Dispose();

            MessageBox.Show("Чтение " + reader.StepCount + " новостей из базы данных прошло успешно", "Выполнено", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
