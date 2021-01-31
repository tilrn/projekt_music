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
        string lol;
        string nacinn;
        public Main(string mail,string nacin)
        {
            InitializeComponent();
             lol = mail;
            nacinn = nacin;
            
        }
        Baza bazaa = new Baza();
        connection baza = new connection();
        string connect = connection.connect();

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {
            button4.Enabled = false;
            
            label1.Text = lol;
            if(nacinn == "prijava") { 
            bool dela = bazaa.Admin(label1.Text);
            if (dela == true)
            {
                button4.Enabled = true;                
            }
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            urejanje urejanje = new urejanje();
            urejanje.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            pregled Pregled = new pregled();
            Pregled.Show();
            this.Hide();
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            Kraji kraji = new Kraji();
            kraji.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            Uporabniki uporabniki = new Uporabniki();
            uporabniki.Show();
            this.Hide();
            
        }
    }
}
