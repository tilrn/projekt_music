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
        string nacinn;
        string maill;
        public Uporabniki(string mail, string nacin)
        {            
            InitializeComponent();
            nacinn = nacin;
            maill = mail;
        }
        Baza bazaa = new Baza();
        connection baza = new connection();
        string connect = connection.connect();

        public void Refresh()
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            textBox1.Clear();
            textBox2.Clear();
            comboBox2.Text = String.Empty;
            comboBox1.Text = String.Empty;
            List<string> userslist = new List<string>();
            userslist = bazaa.usersIzpis();
            foreach (string x in userslist)
            {
                comboBox2.Items.Add(x);
                comboBox1.Items.Add(x);

            }
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
        
        private void Uporabniki_Load(object sender, EventArgs e)
        {
            Refresh();



        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string username = comboBox2.SelectedItem.ToString();
            //MessageBox.Show(username);
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

        private void button2_Click(object sender, EventArgs e)
        {
            string ime = comboBox2.SelectedItem.ToString();

            bazaa.deleteUser(ime);
            MessageBox.Show("uporabnik : " + ime + " je izbrisan.");
            //textBox1.Clear();
            //textBox2.Clear();
            //comboBox2.Text = String.Empty;
            //comboBox2.SelectedIndex = -1; NE DELUJE
            Refresh();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usernames = comboBox2.SelectedItem.ToString();         
            string geslos = bazaa.usersIzpisOboje(usernames);
            string usernamen = textBox1.Text;
            string geslo = textBox2.Text;
            bazaa.UpdateUser(usernames, geslos, usernamen, geslo);
            
            Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Main lol1 = new Main(maill, nacinn);
            lol1.Show();
            this.Hide();
        }
    }
}
