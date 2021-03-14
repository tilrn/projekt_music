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
        bool krajj = false;
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
            string staroIme = Convert.ToString(comboBox1.SelectedItem);
            string starPriimek = Convert.ToString(comboBox2.SelectedItem);
            string novKraj = Convert.ToString(comboBox4.SelectedItem);
            if (krajj == false)
            {
                bazaa.UpdateUporabnik(textBox4.Text,textBox10.Text,textBox1.Text,textBox5.Text, staroIme, starPriimek);
                
            }
            else
            {
                bazaa.UpdateUporabnik(novKraj, textBox10.Text, textBox1.Text, textBox5.Text, staroIme, starPriimek);
                krajj = false;
            }
            update();
            
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
            comboBox4.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            label4.Visible = false;
            label11.Visible = false;
            List<string> kraji = new List<string>();
            kraji = bazaa.Kraji();
            foreach (string x in kraji)
            {
                comboBox2.Items.Add(x);
                comboBox4.Items.Add(x);
            }
            List<string> zaposleni = new List<string>();
            zaposleni = bazaa.VsiZaposleni();
            foreach (string x in zaposleni)
            {
                comboBox1.Items.Add(x);
            }
        }
        
        string uporabnikime = "";
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                      
            textBox5.Clear();
            textBox1.Clear();
            textBox10.Clear();
            comboBox3.SelectedIndex = -1;
            comboBox3.Items.Clear();
            uporabnikime = comboBox1.SelectedItem.ToString();
            List<string> zaposlenipriimek = new List<string>();
            zaposlenipriimek = bazaa.VsiZaposleniPriimek(uporabnikime);
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
        string uporabnikpriimek = "";
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            uporabnikpriimek = comboBox3.SelectedItem.ToString();
            string gmail = bazaa.izpisGmaila(uporabnikime, uporabnikpriimek);
            textBox5.Text = gmail;
            textBox10.Text = uporabnikime;
            textBox1.Text = uporabnikpriimek;
            textBox4.Text = bazaa.izpisKraja(uporabnikime, uporabnikpriimek);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBox4.Visible = false;
            comboBox4.Visible = true;
            krajj = true;

        }
        public void update()
        {
            textBox10.Text = "";
            textBox1.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.SelectedItem = -1;
            comboBox3.SelectedItem = -1;
            comboBox4.SelectedItem = -1;
            textBox4.Visible = true;
            comboBox4.Visible = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            bazaa.DELETE(uporabnikime, uporabnikpriimek);
            //10,1,4,5
            update();
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
