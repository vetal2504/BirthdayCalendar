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
    public partial class ShowFirstForm : Form
    {
        private string path;
        private int countPerson = 0;
        private MainFrame mainFrame;
        public ShowFirstForm()
        {
            InitializeComponent();
            //this.mainFrame = mainFrame;

            path = new MainFrame().Path;

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
                        ListViewItem lvi = new ListViewItem();
                        ListViewItem.ListViewSubItem lvs1 = new ListViewItem.ListViewSubItem();
                        ListViewItem.ListViewSubItem lvs2 = new ListViewItem.ListViewSubItem();

                        lvi.Text = idAttribute.Value;
                        lvs1.Text = dateElement.Value;
                        lvs2.Text = nameElement.Value;
                        lvi.SubItems.Add(lvs1);
                        lvi.SubItems.Add(lvs2);
                        listView1.Items.Add(lvi);
                    }
                    countPerson++;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("База данных пуста");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Hide();
            AddBirthday frame = new AddBirthday(path);
            if(frame.ShowDialog() == DialogResult.OK)
            {
                frame.addData(frame.Date);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainFrame frame = new MainFrame();
            frame.ShowDialog();
        }
    }
}
