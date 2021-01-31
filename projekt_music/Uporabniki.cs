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
    public partial class Uporabniki : Form
    {
        public Uporabniki()
        {
            InitializeComponent();
        }
        Baza bazaa = new Baza();
        connection baza = new connection();
        string connect = connection.connect();

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Uporabniki_Load(object sender, EventArgs e)
        {
            
            List<string> userslist = new List<string>();
            userslist = bazaa.usersIzpis();
            foreach (string x in userslist)
            {
                comboBox2.Items.Add(x);
                comboBox1.Items.Add(x);

            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string username = comboBox2.SelectedItem.ToString();
            textBox1.Text = username;
            string geslo = bazaa.usersIzpisOboje(username);
            textBox2.Text = geslo;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string ime = comboBox1.SelectedItem.ToString();
            
            bazaa.adminUser(ime);
            MessageBox.Show("uporabnik : " + ime + " je sedaj admin.");
        }
    }
}
