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
    public partial class urejanje : Form
    {
        public urejanje()
        {
            InitializeComponent();
        }
        Baza bazaa = new Baza();
        connection baza = new connection();
        string connect = connection.connect();

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string index = Convert.ToString(comboBox2.SelectedItem);

            bazaa.Dodaj(textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, index);
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            comboBox2.SelectedIndex = -1;
        }

        private void urejanje_Load(object sender, EventArgs e)
        {
            List<string> kraji = new List<string>();
            kraji = bazaa.Kraji();
            foreach (string x in kraji)
            {
                comboBox2.Items.Add(x);
            }
            List<string> zaposleni = new List<string>();
            zaposleni = bazaa.VsiZaposleni();
            foreach (string x in zaposleni)
            {
                comboBox1.Items.Add(x);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                      
            textBox5.Clear();
            textBox1.Clear();
            textBox10.Clear();
            comboBox3.SelectedIndex = -1;
            comboBox3.Items.Clear();
            string uporabnik = comboBox1.SelectedItem.ToString();
            List<string> zaposlenipriimek = new List<string>();
            zaposlenipriimek = bazaa.VsiZaposleniPriimek(uporabnik);
            foreach (string x in zaposlenipriimek)
            {
                comboBox3.Items.Add(x);
                
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            

        }
    }
}
