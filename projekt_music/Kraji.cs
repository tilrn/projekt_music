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
    public partial class Kraji : Form
    {
        string maill;
        string nacinn;
        public Kraji(string mail, string nacin)
        {
            InitializeComponent();
            maill = mail;
            nacinn = nacin;
        }
        Baza bazaa = new Baza();
        connection baza = new connection();
        string connect = connection.connect();
        private void update()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.SelectedIndex = -1;
            

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //bazaa.DELETEKraja();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Main lol1 = new Main(maill, nacinn);
            lol1.Show();
            this.Hide();

        }
        string starKraj = "";
        int staraPostna;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string imeKraja = Convert.ToString(comboBox1.SelectedItem);
            starKraj = imeKraja;
            int postnaKraja = bazaa.izpisPostne(imeKraja);
            textBox1.Text = imeKraja;
            textBox3.Text = Convert.ToString(postnaKraja);
            
            staraPostna = postnaKraja;
        }

        private void Kraji_Load(object sender, EventArgs e)
        {
            List<string> kraji = new List<string>();
            kraji = bazaa.Kraji();
            foreach (string x in kraji)
            {
                comboBox1.Items.Add(x);
                
            }
            /*
            List<string> zaposleni = new List<string>();
            zaposleni = bazaa.VsiZaposleni();
            foreach (string x in zaposleni)
            {
                comboBox1.Items.Add(x);
            }
            */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(starKraj);
            MessageBox.Show(textBox1.Text);
            bazaa.Updatekrajov(textBox1.Text, Convert.ToInt32(textBox3.Text),starKraj,Convert.ToInt32(staraPostna));
            update();
            /*
            CREATE OR REPLACE FUNCTION UpdateKraji (krajj varchar, postnaa varchar, starkraj varchar, startaPostna varchar) 
RETURNS void 
AS $$ 
DECLARE 

BEGIN

UPDATE zaposleni 
SET ime_kraja = krajj , postna_stevilka = postnaa
WHERE ime_kraja = starkraj AND postna_stevilka = startaPostna;




END; $$ 
LANGUAGE 'plpgsql';

            */
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
