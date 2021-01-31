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
    public partial class Registracija : Form
    {
        public Registracija()
        {
            InitializeComponent();
        }
        string hash = "l5ep2o4t@";
        private void button4_Click(object sender, EventArgs e)
        {
            Baza bazaa = new Baza();
            string email = textBox3.Text;
            string password = textBox4.Text;       
            bazaa.Registracija(email, password);

            string nacin = "registracija";
            string emaill = textBox3.Text;
            string passwordd = textBox4.Text;
            bool dela = bazaa.Prijava(email, password);
            if (dela == true)
            {
                Main lol1 = new Main(email,nacin);
                lol1.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Nekaj je šlo narobe :(");

            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
