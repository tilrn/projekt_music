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
using projekt_music;


namespace projekt_music
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        connection baza = new connection();
        string connect = connection.connect();

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
        }
       
        

        private void button4_Click(object sender, EventArgs e)
        {
            
           
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            Registracija lol = new Registracija();
            lol.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Prijava lol2 = new Prijava();
            lol2.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string email = "tilen.hostnik@gmail.com";
            Main lol1 = new Main(email);
            lol1.Show();
            this.Hide();
        }
    }
}