using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projekt_music
{
    public partial class Oddelki : Form
    {
        string emaill;
        string nacinn;
        public Oddelki(string mail, string nacin)
        {
            InitializeComponent();
        }
        Baza bazaa = new Baza();
        connection baza = new connection();
        string connect = connection.connect();
        private void Oddelki_Load(object sender, EventArgs e)
        {
            List<string> oddelki = new List<string>();
            oddelki = bazaa.oddelki();
            foreach (string x in oddelki)
            {
                comboBox1.Items.Add(x);
            }
        }
        void update()
        {
            textBox1.Text = "";
            comboBox1.Items.Clear();
            List<string> oddelki = new List<string>();
            oddelki = bazaa.oddelki();
            foreach (string x in oddelki)
            {
                comboBox1.Items.Add(x);
            }

            comboBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ime_oddelka = textBox1.Text.ToString();
            bazaa.InsertOddelki(ime_oddelka);
            update();
        }
        string ime_oddelka;
        private void button3_Click(object sender, EventArgs e)
        {
            ime_oddelka = comboBox1.SelectedItem.ToString();
            bazaa.DELETEodelka(ime_oddelka);
            update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string novo_ime = textBox1.Text.ToString();
            string staro_ime = comboBox1.SelectedItem.ToString();
            bazaa.UpdateOddelki(novo_ime, staro_ime);
            update();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string imeOddelka = Convert.ToString(comboBox1.SelectedItem);
            textBox1.Text = imeOddelka;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Main lol1 = new Main(emaill, nacinn);
            lol1.Show();
            this.Hide();
        }
    }
}
