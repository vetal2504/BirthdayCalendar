using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BirthdayCalendar
{
    public partial class ShowBirthday : Form
    {
        private int countPerson = 0;
        private string path = string.Empty;
        private MainFrame frame;

        public ShowBirthday(string path)
        {
            InitializeComponent();
            this.path = path;
            try
            {
                XDocument xdoc = XDocument.Load(path);
                foreach (XElement phoneElement in xdoc.Element("persons").Elements("person"))
                {
                    XAttribute idAttribute = phoneElement.Attribute("id");
                    XElement dateElement = phoneElement.Element("date");
                    XElement nameElement = phoneElement.Element("name");

                    if (nameElement != null && dateElement != null)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[countPerson].Cells[1].Value = dateElement.Value;
                        dataGridView1.Rows[countPerson].Cells[0].Value = idAttribute.Value;
                        dataGridView1.Rows[countPerson].Cells[2].Value = nameElement.Value;
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
