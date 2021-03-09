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
        string maill;
        string nacinn;
        public urejanje(string mail, string nacin)
        {
            InitializeComponent();
            maill = mail;
            nacinn = nacin;
        }
        Baza bazaa = new Baza();
        connection baza = new connection();
        string connect = connection.connect();
        int clicked = 0;

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string index = Convert.ToString(comboBox2.SelectedItem);
            if (clicked == 0) { 
            

                bazaa.Dodaj(textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, index);
            
            }
            else
            {
               
                bazaa.DodajZkraju(textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text,textBox3.Text,Convert.ToInt32(textBox2.Text));
                
            }
            textBox2.Clear();
            textBox3.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            comboBox2.SelectedIndex = -1;
            this.Refresh();
            label4.Visible = false;
            label11.Visible = false;
            comboBox2.Enabled = true;
            textBox2.Visible = false;
            textBox3.Visible = false;
        }

        private void urejanje_Load(object sender, EventArgs e)
        {
            textBox2.Visible = false;
            textBox3.Visible = false;
            label4.Visible = false;
            label11.Visible = false;
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            label4.Visible = true;
            label11.Visible = true;
            comboBox2.Enabled = false;
            textBox2.Visible = true;
            textBox3.Visible = true;
            clicked = 1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Main lol1 = new Main(maill, nacinn);
            lol1.Show();
            this.Hide();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
