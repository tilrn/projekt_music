﻿using System;
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

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("ime:       priimek:     datum_roj:     email:     oddelek:     kraj:     ");
            List<string> Izpis = new List<string>();
            Izpis = bazaa.IzpisVsega();
            foreach(string x in Izpis)
            {
                listBox1.Items.Add(x);
                //NEDELA SE CIST
            }

        }
    }
}
