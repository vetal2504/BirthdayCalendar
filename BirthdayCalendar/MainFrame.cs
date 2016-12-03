using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Xml;

namespace BirthdayCalendar
{
    public partial class MainFrame : Form
    {
        private string path = Directory.GetCurrentDirectory() + "\\Birthday.xml";
        public MainFrame()
        {
            InitializeComponent();
            if (!File.Exists(path))
            {
                MessageBox.Show("Create file XML");

                using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.UTF8))
                {
                    sw.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
                    sw.WriteLine("<persons>");
                    sw.WriteLine("</persons>");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isChecked = true;
            for (int i = 0; i < 3; i++)
            {
                if ( ((RadioButton)groupBox1.Controls[i]).Checked == true)
                {
                    isChecked = false;
                    switch (i)
                    {
                        case 0:
                            ShowBirthday show = new ShowBirthday(path);
                            show.Show();
                            break;
                        case 1:
                            AddBirthday add = new AddBirthday(path);
                            add.Show();
                            break;
                        case 2:
                            UpdateForm update = new UpdateForm(path);
                            update.Show();
                            break;
                    }
                }
            }
            if (isChecked)
            {
                MessageBox.Show("Change action");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
