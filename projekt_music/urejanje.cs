﻿using System;
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
        }

        private void urejanje_Load(object sender, EventArgs e)
        {
            List<string> kraji = new List<string>();
            kraji = bazaa.Kraji();
            foreach (string x in kraji)
            {
                comboBox2.Items.Add(x);
            }
        }
    }
}