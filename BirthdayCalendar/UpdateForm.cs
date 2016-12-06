using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BirthdayCalendar
{
    public partial class UpdateForm : Form
    {
        private string path = String.Empty;
        public UpdateForm(string path)
        {
            InitializeComponent();
            this.path = path;

            XDocument xdoc = XDocument.Load(path);
            XElement root = xdoc.Element("persons");

            foreach (XElement xe in root.Elements("person").ToList())
            {
                fullName.Items.Add(xe.Element("name").Value);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            XDocument xdoc = XDocument.Load(path);
            XElement root = xdoc.Element("persons");

            foreach (XElement xe in root.Elements("person").ToList())
            {
                if (String.Compare(xe.Element("name").Value, fullName.Text) == 0)
                {
                    xe.Element("name").Value = newFullName.Text;

                    dateTimePicker1.Format = DateTimePickerFormat.Short;
                    xe.Element("date").Value = dateTimePicker1.Value.ToShortDateString();
                }
                else
                {
                    MessageBox.Show("Такого человека в базе нету");
                }
            }
            xdoc.Save(path);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            XDocument xdoc = XDocument.Load(path);
            XElement root = xdoc.Element("persons");

            foreach (XElement xe in root.Elements("person").ToList())
            {
                if(xe.Element("name").Value == fullName.Text)
                {
                    xe.Remove();
                    xe.Save(path);
                }
            }
        }
    }
}
