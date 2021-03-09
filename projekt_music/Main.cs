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
        string emaill;
        string nacinn;
        public Main(string mail,string nacin)
        {
            InitializeComponent();
             emaill = mail;
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
            
            label1.Text = emaill;
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
            urejanje urejanje = new urejanje(emaill, nacinn);
            urejanje.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            pregled Pregled = new pregled(emaill,nacinn);
            Pregled.Show();
            this.Hide();
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            Kraji kraji = new Kraji(emaill, nacinn);
            kraji.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            Uporabniki uporabniki = new Uporabniki(emaill, nacinn);
            uporabniki.Show();
            this.Hide();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
