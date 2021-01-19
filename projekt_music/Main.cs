using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace projekt_music
{
    public partial class Main : Form
    {
        public Main(string mail)
        {
            InitializeComponent();
            string lol = mail;
            
        }
        Baza bazaa = new Baza();
        connection baza = new connection();
        string connect = connection.connect();

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {
            List<string> kraji = new List<string>();
            kraji = bazaa.Kraji();
            foreach(string x in kraji)
            {
                comboBox2.Items.Add(x);
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string index = Convert.ToString(comboBox2.SelectedItem);
            
            bazaa.Dodaj(textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, index);
        }
    }
}
