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
    public partial class ShowBirthday : Form
    {
        private int countPerson = 0;
        private string path = string.Empty;
        public ShowBirthday(string path)
        {
            InitializeComponent();
            this.path = path;
            try
            {
                XDocument xdoc = XDocument.Load(path);
                foreach (XElement phoneElement in xdoc.Element("persons").Elements("person"))
                {
                    XAttribute nameAttribute = phoneElement.Attribute("name");
                    XElement dateElement = phoneElement.Element("date");

                    if (nameAttribute != null && dateElement != null)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[countPerson].Cells[1].Value = nameAttribute.Value;
                        dataGridView1.Rows[countPerson].Cells[0].Value = dateElement.Value;
                    }
                    countPerson++;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("База данных пуста");
            }
            
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
