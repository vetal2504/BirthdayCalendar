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
using System.IO;

namespace BirthdayCalendar
{
    public partial class AddBirthday : Form
    {
        private string path = String.Empty;
        public AddBirthday(string path)
        {
            InitializeComponent();
            this.path = path;
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            string date = dateTimePicker1.Text.Substring(0, dateTimePicker1.Text.Length - 5);
            addData(date);
            this.Close();
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addData(string date)
        {

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);

            XmlElement xRoot = xDoc.DocumentElement;
            XmlElement userElem = xDoc.CreateElement("person");
            XmlAttribute nameAttr = xDoc.CreateAttribute("name");
            XmlElement dateElem = xDoc.CreateElement("date");

            XmlText nameText = xDoc.CreateTextNode(fullName.Text);
            XmlText dateText = xDoc.CreateTextNode(date);

            nameAttr.AppendChild(nameText);
            dateElem.AppendChild(dateText);
            userElem.Attributes.Append(nameAttr);
            userElem.AppendChild(dateElem);
            xRoot.AppendChild(userElem);
            xDoc.Save("Birthday.xml");
        }
    }
}
