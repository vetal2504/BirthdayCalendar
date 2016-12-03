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
using System.Xml.Linq;
using System.IO;

namespace BirthdayCalendar
{
    public partial class AddBirthday : Form
    {
        private string path = String.Empty;
        private MainFrame frame;

        public AddBirthday(string path)
        {
            InitializeComponent();
            this.path = path;
            frame = new MainFrame();
        }

        public AddBirthday(MainFrame frame, string path)
        {
            InitializeComponent();
            this.path = path;
            this.frame = frame;
            frame.Hide();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            string date = dateTimePicker1.Text.Substring(0, dateTimePicker1.Text.Length - 5);
            addData(date);
            this.Close();
            frame.Show();
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            this.Close();
            frame.Show();
        }

        private void addData(string date)
        {
            int countPerson = 0;
            XDocument xdoc = XDocument.Load(path);
            foreach (XElement phoneElement in xdoc.Element("persons").Elements("person"))
            {
                countPerson++;
            }

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);

            XmlElement xRoot = xDoc.DocumentElement;
            XmlElement userElem = xDoc.CreateElement("person");
            XmlAttribute idAttr = xDoc.CreateAttribute("id");
            XmlElement dateElem = xDoc.CreateElement("date");
            XmlElement nameElem = xDoc.CreateElement("name");

            XmlText nameText = xDoc.CreateTextNode(fullName.Text);
            XmlText dateText = xDoc.CreateTextNode(date);
            XmlText idText = xDoc.CreateTextNode("" + countPerson);

            idAttr.AppendChild(idText);
            dateElem.AppendChild(dateText);
            nameElem.AppendChild(nameText);
            userElem.Attributes.Append(idAttr);
            userElem.AppendChild(dateElem);
            userElem.AppendChild(nameElem);
            xRoot.AppendChild(userElem);
            xDoc.Save("Birthday.xml");
        }
    }
}
