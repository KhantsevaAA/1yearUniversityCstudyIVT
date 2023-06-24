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
using System.Net;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Text = "Загрузить ссылку";
            label1.Text = "Ссылка";
            textBox1.Text = "https://lenta.ru/rss/news";
        }
        private XmlDataDocument xmlNew;//объект загружает реляционные данные или XML-данные и управлять этими данными
        private string strNews;

        private void button1_Click(object sender, EventArgs e)
        {
            string rssUrl = textBox1.Text;
            xmlNew = new XmlDataDocument();


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(rssUrl); //объект - взаимодействует напрямую с серверами с помощью HTTP
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();//объект - отправление HTTP-запросы и получение HTTP-ответы
                                                                              //метод - возвращает ответ от интернет-ресурса
            Stream stream = response.GetResponseStream();//метод-возвращает поток, используемый для чтения основного текста ответа с сервера
            StreamReader reader = new StreamReader(stream);
            strNews = reader.ReadToEnd().ToString(); // считываем текст rss-ленты.



            richTextBox1.Text = strNews;

            /*stirng*/

            xmlNew.LoadXml(strNews);//метод - загружает XML-документ из указанной строки
            XmlNodeList childNodeList = xmlNew.DocumentElement.SelectSingleNode("channel").SelectNodes("item");



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
    }
}
